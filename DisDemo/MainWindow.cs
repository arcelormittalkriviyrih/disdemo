using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Resources;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;


namespace DisDemo
{
    public partial class MainWindow : Form
    {
        [DllImport("ws2_32.dll")]
        public static extern Int32 WSAStartup(UInt16 wVersionRequested, ref  WSADATA wsaData);
        [DllImport("ws2_32.dll")]
        public static extern Int32 WSACleanup();

        static List<EPC_data> Tag_data = new List<EPC_data>();
        static bool bNewTag = false;
        static int nItemNo = 0; // 记录需要更新的EPC数据索引
        int RWBank = 0;// 记录选择的读写区域及开始、结束地址，便于更新控件
        int addStart = 0;
        int addEnd = 0;
        bool bConnected = false; // 连接标志，由委托的异步线程改写
        public Dis.HANDLE_FUN f = new Dis.HANDLE_FUN(HandleData);
        // 加载字符串资源
        static ResourceManager[] rmArray = new ResourceManager[2]{  
                                                    new ResourceManager("DisDemo.SimpChinese", typeof(MainWindow).Assembly),
                                                    new ResourceManager("DisDemo.English", typeof(MainWindow).Assembly)};
        static ResourceManager rm = rmArray[0];

        static byte deviceNo = 0;
        // 负责连接设备的委托
        public delegate void DeleConnectDev(byte[] ip, int CommPort, int PortOrBaudRate);
        // 数据产生时，触发此事件，更新ListView控件
        public delegate void UpdateControlEventHandler();
        public static event UpdateControlEventHandler UpdateControl;


        public MainWindow()
        {
            InitializeComponent();

            UpdateControl = new UpdateControlEventHandler(UpdateListView);  //订阅UpdateControl事件
            // 允许跨线程更新窗口控件
            Control.CheckForIllegalCrossThreadCalls = false;

            rbNet.Checked = true;
            textBoxPort.Text = "4196";

            // 主数据表
            listView.Columns.Add("No", 45, HorizontalAlignment.Center);
            listView.Columns.Add("EPC", 260, HorizontalAlignment.Center);
            listView.Columns.Add("Count", 60, HorizontalAlignment.Center);
            listView.Columns.Add("AntNo", 80, HorizontalAlignment.Center);
            listView.Columns.Add("DevNo", 80, HorizontalAlignment.Center);


            // 初始化各个页面控件
            InitCommParamControl();
            InitAccessTagControl();
            InitParamSetControl();
            InitWigginsTakePlaceValueControl();
            DisableAccessTagButton(false);
            cbbLangSwitch.SelectedIndex = 1; // 默认中文
            cbbLangSwitch_SelectedIndexChanged(null, null);

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnStartReadData.Enabled = false;
            btnReadOnce.Enabled = false;
            btnStopReadData.Enabled = false;
            comboBoxSerialCommPort.Visible = false;
            btnUpdate_Click(null, null);
            rbReadSingleTag.Enabled = false;
            rbReadMultiTag.Enabled = false;

            // 设置默认的界面显示选项
            cbbWorkMode.SelectedIndex = 0;
            cbbCommMode.SelectedIndex = 0;
            cboBand.SelectedIndex = 0;
            cbbFreqModeUS.SelectedIndex = 0;
            cboFreqModeEU.SelectedIndex = 0;
            cboReadSpeed.SelectedIndex = 1;
            rbAsc.Checked = true;
        }

        private void InitParamSetControl()
        {
            // 韦根协议
            cbbWiegandProtocol.Items.Add("Wiegand26");
            cbbWiegandProtocol.Items.Add("Wiegand34");
            cbbWiegandProtocol.Items.Add("Wiegand32");
            // 频点
            for (int i = 0; i < 50; ++i)
            {
                cbbFreqPointUS.Items.Add(string.Format("{0}-{1:F1}Mhz", i + 1, 902.5 + i * 0.5));
            }
            // 频点
            for (int i = 0; i < 5; ++i)
            {
                cboFreqPointEU.Items.Add(string.Format("{0}-{1:F1}Mhz", i + 1, 865.5 + i * 0.5));
            }
        }

        private void InitWigginsTakePlaceValueControl()
        {
            // 韦根取位值
            for (int i = 0; i < 10; i++)
            {
                cboWigginsTakePlaceValue.Items.Add(i);
            }
        }

        private void InitAccessTagControl()
        {
            // 读写区域
            cbbRWBank.Items.Add("Reserve");
            cbbRWBank.Items.Add("EPC");
            cbbRWBank.Items.Add("TID");
            cbbRWBank.Items.Add("User");

            // 锁卡区域
            cbbLockBank.Items.Add("Kill");
            cbbLockBank.Items.Add("Access");
            cbbLockBank.Items.Add("EPC");
            cbbLockBank.Items.Add("TID");
            cbbLockBank.Items.Add("User");
        }

        private void DisableAccessTagButton(bool bEnabled)
        {
            // 标签访问页面按钮
            btnFastWrite.Enabled = bEnabled;
            btnReadData.Enabled = bEnabled;
            btnWriteData.Enabled = bEnabled;
            btnLockTag.Enabled = bEnabled;
            btnUnlockTag.Enabled = bEnabled;
            btnKillTag.Enabled = bEnabled;
            btnInitTag.Enabled = bEnabled;
            // 参数设置页面按钮
            btnReadWorkMode.Enabled = bEnabled;
            btnSetWorkMode.Enabled = bEnabled;
            btnReadCommMode.Enabled = bEnabled;
            btnSetCommMode.Enabled = bEnabled;
            btnReadFreq.Enabled = bEnabled;
            btnSetFreq.Enabled = bEnabled;
            //其他操作页面
            btnTagAuth.Enabled = bEnabled;
            btnModifyAuthPwd.Enabled = bEnabled;
            btnSetBeep.Enabled = bEnabled;
            btnSetRelayTime.Enabled = bEnabled;
            btnSetUsbFormat.Enabled = bEnabled;
            btnReadBeep.Enabled = bEnabled;
            btnReadRelayTime.Enabled = bEnabled;
        }

        // 更新串口列表
        public void GetSerialPortList(ref ComboBox comboBoxSP)
        {
            comboBoxSP.Items.Clear();
            comboBoxSP.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxSP.Items.Count > 0)
            {
                comboBoxSP.SelectedIndex = 0;
            }
        }

        bool bWSAInit = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 获得串口列表
            GetSerialPortList(ref comboBoxSerialCommPort);
            WSADATA wsaData = new WSADATA();

            if (!bWSAInit)
            {
                bWSAInit = true;
                WSAStartup(0x0202, ref wsaData);
            }
            // 搜索设备，获得IP列表
            ZLDM.m_DevCnt = ZLDM.StartSearchDev();
            comboBoxIP.Items.Clear();
            for (byte i = 0; i < ZLDM.m_DevCnt; ++i)
            {
                comboBoxIP.Items.Add(Marshal.PtrToStringAnsi(ZLDM.GetIP(i)));
            }
            if (ZLDM.m_DevCnt > 0)
            {
                comboBoxIP.SelectedIndex = 0;
            }
        }

        // 委托执行的连接函数，成功后修改标志并停止定时器
        private void ConnectDevice(byte[] ip, int CommPort, int PortOrBaudRate)
        {
            if (0 == Dis.DeviceInit(ip, CommPort, PortOrBaudRate))
            {
                labelVersion.Text = rm.GetString("strMsgInitFailure");
                return;
            }
            if (0 == Dis.DeviceConnect())
            {
                return;
            }
            for (int i = 0; i < 3; ++i)
            { Dis.StopWork(deviceNo); }
            int mainVer = 0, minSer = 0;
            Dis.GetDeviceVersion(deviceNo, out mainVer, out minSer);
            labelVersion.Text = "Version:" + string.Format("{0}.{1}", mainVer, minSer);
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnStartReadData.Enabled = true;
            btnReadOnce.Enabled = true;
            rbReadSingleTag.Enabled = true;
            rbReadMultiTag.Enabled = true;
            rbReadSingleTag.Checked = true;
            DisableAccessTagButton(true);
            bConnected = true;
            timerConnect.Stop();// 连接成功，结束定时器
        }

        // 定时器函数，在指定时间内没有完成连接，则执行此函数
        private void timerConnect_Tick(object sender, EventArgs e)
        {
            if (!bConnected)
            {
                labelVersion.Text = rm.GetString("strMsgConnectFailure");
                timerConnect.Stop();
            }
        }

        /// <summary>
        /// 通信连接
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            byte[] ip = new byte[32];
            int CommPort = 0;
            int PortOrBaudRate = 0;
            if (rbNet.Checked) // TCP/IP
            {
                if ((!Regex.IsMatch(comboBoxIP.Text, "^[0-9.]+$")) || comboBoxIP.Text.Length < 7 || comboBoxIP.Text.Length > 15)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidIPAdd"));
                    return;
                }
                ip = Encoding.ASCII.GetBytes(comboBoxIP.Text); // 由string获得byte数组
                if (!Regex.IsMatch(textBoxPort.Text, "^[0-9]+$") || textBoxPort.Text.Length > 5)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidPort"));
                    return;
                }
                PortOrBaudRate = Int32.Parse(textBoxPort.Text);
            }
            else // SerialCommPort
            {
                if (comboBoxSerialCommPort.SelectedIndex >= 0)
                {
                    CommPort = int.Parse(comboBoxSerialCommPort.Text.Trim("COM".ToCharArray()));
                    PortOrBaudRate = 9600;
                }
                else
                {
                    MessageBox.Show(rm.GetString("strMsgSelectPort"));
                    return;
                }
            }
            if (!Regex.IsMatch(tbDeviceNo.Text, "^[0-9]+$"))
            {
                MessageBox.Show(rm.GetString("strMsgNotDigit"));
                return;
            }
            if (int.Parse(tbDeviceNo.Text) > 255)
            {
                MessageBox.Show(rm.GetString("strMsgDevNoValid"));
                return;
            }
            deviceNo = Byte.Parse(tbDeviceNo.Text);

            // 使用委托异步线程执行连接，同时启动定时器，等待
            DeleConnectDev dcd = new DeleConnectDev(ConnectDevice);
            dcd.BeginInvoke(ip, CommPort, PortOrBaudRate, null, null);
            bConnected = false;
            timerConnect.Interval = 3000; // 等待3秒时间
            timerConnect.Start();
        }

        // 回调函数
        static string epc;
        public static void HandleData(IntPtr pData, int length)
        {
            epc = "";
            byte[] data = new byte[32];
            Marshal.Copy(pData, data, 0, length);
            for (int i = 1; i < length - 2; ++i)
            {
                epc += string.Format("{0:X2} ", data[i]);
            }

            bNewTag = true;
            for (int i = 0; i < Tag_data.Count; ++i)
            {
                if (epc == Tag_data[i].epc)
                {
                    Tag_data[i].count++;
                    Tag_data[i].antNo = data[13];
                    Tag_data[i].devNo = data[0];
                    bNewTag = false;     // 不是新标签
                    nItemNo = i;             //记录数据索引值，用于更新listView表
                    break;
                }
            }
            if (bNewTag)
            {
                EPC_data epcdata = new EPC_data();
                epcdata.epc = epc;
                epcdata.antNo = data[length - 1];
                epcdata.devNo = data[length - 2];
                epcdata.count = 1;
                Tag_data.Add(epcdata);
            }
            UpdateControl(); // 有新数据产生，更新listView
        }

        public static void WriteFile(string strTxt, string path)
        {
            using (StreamWriter wlog = File.AppendText(path))
            {
                wlog.Write("{0}", strTxt);
                wlog.Write(wlog.NewLine);
            }
        }

        private void UpdateListView()
        {
            if (cbSaveFile.Checked)
            {
                WriteFile(epc, "tag.txt");
            }

            if (rbAsc.Checked)
            {
                Tag_data.Sort();
            }
            else if (rbDesc.Checked)
            {
                Tag_data.Sort();
                Tag_data.Reverse();
            }
            if (!bNewTag) // 非新标签，更新对应项的读取次数及天线号、设备号等
            {
                labelCount.Text = (int.Parse(labelCount.Text) + 1).ToString();
                listView.Items[nItemNo].SubItems[2].Text = Tag_data[nItemNo].count.ToString();
                listView.Items[nItemNo].SubItems[3].Text = Tag_data[nItemNo].antNo.ToString();
                listView.Items[nItemNo].SubItems[4].Text = Tag_data[nItemNo].devNo.ToString();
            }
            else // 新标签
            {
                labelCount.Text = (int.Parse(labelCount.Text) + 1).ToString(); // 更新读取次数
                labelTagCount.Text = (int.Parse(labelTagCount.Text) + 1).ToString();// 更新标签计数
                ListViewItem lvi = new ListViewItem();
                int no = Tag_data.Count;
                lvi.Text = no.ToString();
                lvi.SubItems.Add(Tag_data[no - 1].epc);
                lvi.SubItems.Add(Tag_data[no - 1].count.ToString());
                lvi.SubItems.Add(Tag_data[no - 1].antNo.ToString());
                lvi.SubItems.Add(Tag_data[no - 1].devNo.ToString());
                listView.Items.Add(lvi);
            }
        }

        private void UpdateLV()
        {
            listView.BeginUpdate();
            listView.Items.Clear();
            for (int i = 1; i <= Tag_data.Count; ++i)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = i.ToString();
                lvi.SubItems.Add(Tag_data[i - 1].epc);
                lvi.SubItems.Add(Tag_data[i - 1].count.ToString());
                lvi.SubItems.Add(Tag_data[i - 1].antNo.ToString());
                lvi.SubItems.Add(Tag_data[i - 1].devNo.ToString());
                listView.Items.Add(lvi);
            }
            listView.EndUpdate();
        }

        /// <summary>
        /// 开始连续寻卡
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            Dis.BeginMultiInv(deviceNo, f);
            btnStopReadData.Enabled = true;
            btnStartReadData.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        /// <summary>
        /// 停止连续寻卡
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            Dis.StopInv(deviceNo);
            btnStartReadData.Enabled = true;
            btnStopReadData.Enabled = false;
            btnDisconnect.Enabled = true;
        }

        /// <summary>
        /// 清空
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            Tag_data.Clear();
            labelTagCount.Text = "0";
            labelCount.Text = "0";
        }

        /// <summary>
        /// 通信断开
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Dis.ResetReader(deviceNo);
            Dis.DeviceDisconnect();
            Dis.DeviceUninit();
            labelVersion.Text = "";
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnStartReadData.Enabled = false;
            btnReadOnce.Enabled = false;
            btnStopReadData.Enabled = false;
            bConnected = false;
        }

        /// <summary>
        /// 升序
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonAsc_CheckedChanged(object sender, EventArgs e)
        {
            Tag_data.Sort();
            UpdateLV();
        }

        /// <summary>
        /// 降序
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonDesc_CheckedChanged(object sender, EventArgs e)
        {
            Tag_data.Sort();
            Tag_data.Reverse();
            UpdateLV();
        }

        /// <summary>
        /// 串口通信
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonSP_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSerialCommPort.Visible = true;
            comboBoxIP.Visible = false;
            textBoxPort.Visible = false;
            labCommPort.Visible = false;
        }

        /// <summary>
        /// 网络通信
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonNet_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSerialCommPort.Visible = false;
            comboBoxIP.Visible = true;
            textBoxPort.Visible = true;
            labCommPort.Visible = true;
        }

        private void SetCommParam_Enter(object sender, EventArgs e)
        {
        }

        private void InitCommParamControl()
        {
            comboBoxNetMode.Items.Add("TCP Server");
            comboBoxNetMode.Items.Add("TCP Client");
            comboBoxNetMode.Items.Add("UDP");
            comboBoxNetMode.Items.Add("UDP Group");

            comboBoxIPMode.Items.Add("Static");
            comboBoxIPMode.Items.Add("Dynamic");

            comboBoxBaudRate.Items.Add("1200");
            comboBoxBaudRate.Items.Add("2400");
            comboBoxBaudRate.Items.Add("4800");
            comboBoxBaudRate.Items.Add("7200");
            comboBoxBaudRate.Items.Add("9600");
            comboBoxBaudRate.Items.Add("14400");
            comboBoxBaudRate.Items.Add("19200");
            comboBoxBaudRate.Items.Add("28800");
            comboBoxBaudRate.Items.Add("38400");
            comboBoxBaudRate.Items.Add("57600");
            comboBoxBaudRate.Items.Add("76800");
            comboBoxBaudRate.Items.Add("115200");
            comboBoxBaudRate.Items.Add("230400");

            comboBoxDataBits.Items.Add("8");
            comboBoxDataBits.Items.Add("7");
            comboBoxDataBits.Items.Add("6");
            comboBoxDataBits.Items.Add("5");

            comboBoxCheckBits.Items.Add("None");
            comboBoxCheckBits.Items.Add("Odd");
            comboBoxCheckBits.Items.Add("Even");
            comboBoxCheckBits.Items.Add("Marked");
            comboBoxCheckBits.Items.Add("Space");

            cbbRelayTime.Visible = false;
            lblCloseTime.Visible = false;
            rdoOpen1.Visible = false;
            rdoOpen2.Visible = false;
            rdoClose1.Visible = false;
            rdoClose2.Visible = false;
        }

        /// <summary>
        /// 搜索设备
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchDev_Click(object sender, EventArgs e)
        {
            lvZl.Items.Clear();
            ZLDM.m_DevCnt = ZLDM.StartSearchDev();
            for (byte i = 0; i < ZLDM.m_DevCnt; ++i)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i + 1).ToString();
                lvi.SubItems.Add(Marshal.PtrToStringAnsi(ZLDM.GetIP(i)));
                lvi.SubItems.Add(ReverseByte(ZLDM.GetPort(i)).ToString());
                lvi.SubItems.Add(Marshal.PtrToStringAnsi(ZLDM.GetDevID(i)));
                lvZl.Items.Add(lvi);
            }
            if (ZLDM.m_DevCnt > 0)
            {
                UpdateCommParamControl(); // 更新页面控件
                lvZl.FocusedItem = lvZl.Items[0];// 设置第一项为焦点项
            }

        }

        // 大小端转换
        public static UInt16 ReverseByte(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        /// <summary>
        /// 编辑设备
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyDev_Click(object sender, EventArgs e)
        {
            if (lvZl.SelectedItems != null)
                listViewDev_ItemActivate(sender, e);
        }

        /// <summary>
        /// 设置默认参数
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultParams_Click(object sender, EventArgs e)
        {
            comboBoxNetMode.SelectedIndex = 0;
            comboBoxIPMode.SelectedIndex = 0;
            textBoxIPAdd.Text = "192.168.1.200";
            textBoxNetMask.Text = "255.255.255.0";
            textBoxPortNo.Text = "20058";
            textBoxGateway.Text = "192.168.1.1";
            textBoxDestIP.Text = "192.168.1.100";
            textBoxDestPort.Text = "20058";
            comboBoxBaudRate.SelectedIndex = 12;
            comboBoxDataBits.SelectedIndex = 0;
            comboBoxCheckBits.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置通信参数
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetParams_Click(object sender, EventArgs e)
        {
            if (-1 == comboBoxNetMode.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectNetMode"));
                return;
            }
            if (-1 == comboBoxIPMode.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectIPMode"));
                return;
            }
            if (-1 == comboBoxBaudRate.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectBaudRate"));
                return;
            }
            if (-1 == comboBoxDataBits.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectDataBits"));
                return;
            }
            if (-1 == comboBoxDataBits.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgSelectParity"));
                return;
            }
            // 检查IP地址
            if (!IsValidIP(textBoxIPAdd.Text))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidIP"));
                return;
            }
            // 检查掩码
            if (!IsValidIP(textBoxNetMask.Text))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidMask"));
                return;
            }
            // 检查网关
            if (!IsValidIP(textBoxGateway.Text))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidGateway"));
                return;
            }
            // 检查目标IP
            if (!IsValidIP(textBoxDestIP.Text))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidDestIP"));
                return;
            }
            // 检查端口号
            int value = int.Parse(textBoxPortNo.Text);
            if (value < 1000 || value > 65535)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidPort"));
                return;
            }
            value = int.Parse(textBoxDestPort.Text);
            if (value < 1000 || value > 65535)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidDestPort"));
                return;
            }
            ushort port = ReverseByte(ushort.Parse(textBoxPortNo.Text));
            ushort destport = ReverseByte(ushort.Parse(textBoxDestPort.Text));

            byte[] ip = new byte[32];
            byte[] netmask = new byte[32];
            byte[] gateway = new byte[32];
            byte[] destip = new byte[32];
            ip = Encoding.ASCII.GetBytes(textBoxIPAdd.Text);
            netmask = Encoding.ASCII.GetBytes(textBoxNetMask.Text);
            gateway = Encoding.ASCII.GetBytes(textBoxGateway.Text);
            destip = Encoding.ASCII.GetBytes(textBoxDestIP.Text);

            ZLDM.SetWorkMode(ZLDM.m_SelectedDevNo, (byte)comboBoxNetMode.SelectedIndex);
            ZLDM.SetIPMode(ZLDM.m_SelectedDevNo, (byte)comboBoxIPMode.SelectedIndex);
            ZLDM.SetIP(ZLDM.m_SelectedDevNo, ip);
            ZLDM.SetNetMask(ZLDM.m_SelectedDevNo, netmask);
            ZLDM.SetPort(ZLDM.m_SelectedDevNo, port);
            ZLDM.SetGateWay(ZLDM.m_SelectedDevNo, gateway);

            ZLDM.SetDestName(ZLDM.m_SelectedDevNo, destip);
            ZLDM.SetDestPort(ZLDM.m_SelectedDevNo, destport);

            ZLDM.SetBaudrateIndex(ZLDM.m_SelectedDevNo, (byte)comboBoxBaudRate.SelectedIndex);
            ZLDM.SetDataBits(ZLDM.m_SelectedDevNo, (byte)comboBoxDataBits.SelectedIndex);
            ZLDM.SetParity(ZLDM.m_SelectedDevNo, (byte)comboBoxCheckBits.SelectedIndex);

            bool res = ZLDM.SetParam(ZLDM.m_SelectedDevNo);
            if (res)
                MessageBox.Show(rm.GetString("strMsgSucceedSetCommParam"));
            else
                MessageBox.Show(rm.GetString("strMsgFailedSetCommParam"));
        }
        private bool IsValidIP(string strIP)
        {
            // 先检查有无非数字字符
            if (!Regex.IsMatch(strIP, "^[0-9.]+$"))
            {
                return false;
            }
            // 再检查数据范围是否合理
            string[] strNumArray = strIP.Split('.');
            if (strNumArray.Length != 4)
            {
                return false;
            }
            int n = 0;
            for (int i = 0; i < 4; ++i)
            {
                n = int.Parse(strNumArray[i]);
                if (n > 255)
                {
                    return false;
                }
            }
            return true;
        }

        private void listViewDev_ItemActivate(object sender, EventArgs e)
        {
            if (lvZl.Items.Count > 0)
            {
                ZLDM.m_SelectedDevNo = (byte)(lvZl.Items.IndexOf(lvZl.FocusedItem));
                UpdateCommParamControl();
            }
        }

        private void UpdateCommParamControl()
        {
            if (ZLDM.m_DevCnt > 0)
            {
                comboBoxNetMode.SelectedIndex = ZLDM.GetWordMode(ZLDM.m_SelectedDevNo);
                comboBoxIPMode.SelectedIndex = ZLDM.GetIPMode(ZLDM.m_SelectedDevNo);
                textBoxIPAdd.Text = Marshal.PtrToStringAnsi(ZLDM.GetIP(ZLDM.m_SelectedDevNo));
                textBoxNetMask.Text = Marshal.PtrToStringAnsi(ZLDM.GetNetMask(ZLDM.m_SelectedDevNo));
                textBoxPortNo.Text = (ReverseByte(ZLDM.GetPort(ZLDM.m_SelectedDevNo))).ToString();
                textBoxGateway.Text = Marshal.PtrToStringAnsi(ZLDM.GetGateWay(ZLDM.m_SelectedDevNo));
                textBoxDestIP.Text = Marshal.PtrToStringAnsi(ZLDM.GetDestName(ZLDM.m_SelectedDevNo));
                textBoxDestPort.Text = (ReverseByte(ZLDM.GetDestPort(ZLDM.m_SelectedDevNo))).ToString();
                comboBoxBaudRate.SelectedIndex = ZLDM.GetBaudrateIndex(ZLDM.m_SelectedDevNo);
                comboBoxDataBits.SelectedIndex = ZLDM.GetDataBits(ZLDM.m_SelectedDevNo);
                comboBoxCheckBits.SelectedIndex = ZLDM.GetParity(ZLDM.m_SelectedDevNo);
            }
        }

        /// <summary>
        /// 读写数据操作
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbRWBank_SelectedIndexChanged(object sender, EventArgs e)
        {   // 根据操作区域，确定有效的起始地址
            if (cbbRWBank.SelectedIndex == 0) // 保留区
            {
                RWBank = 0;
                addStart = 0;
                addEnd = 3;
            }
            else if (cbbRWBank.SelectedIndex == 1) // EPC区
            {
                RWBank = 1;
                addStart = 2;
                addEnd = 7;
            }
            else if (cbbRWBank.SelectedIndex == 2) // TID
            {
                RWBank = 2;
                addStart = 0;
                addEnd = 5;
            }
            else if (cbbRWBank.SelectedIndex == 3) // User
            {
                RWBank = 3;
                addStart = 0;
                addEnd = 31;
            }
            cbbStartAdd.Items.Clear();
            for (int i = addStart; i <= addEnd; ++i)
            {
                cbbStartAdd.Items.Add(i.ToString());
            }
        }

        /// <summary>
        /// 起始地址
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbStartAdd_SelectedIndexChanged(object sender, EventArgs e)
        { // 根据起始地址，确定长度选项
            int nItem = cbbStartAdd.SelectedIndex; // 取出起始地址索引值
            int maxLength = addEnd - addStart - nItem + 1;
            cbbLength.Items.Clear();
            for (int i = 1; i <= maxLength; ++i)
            {
                cbbLength.Items.Add(i.ToString());
            }
        }

        /// <summary>
        /// 清空
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearData_Click(object sender, EventArgs e)
        {
            tbRWData.Text = "";
            tbRWData.Focus();
        }

        /// <summary>
        /// 读取
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadData_Click(object sender, EventArgs e)
        {
            int RWBank = -1;
            int StartAdd = -1;
            int Length = -1;
            labResult.Text = "";
            if ((RWBank = cbbRWBank.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectRWBank"));
                return;
            }
            if ((StartAdd = cbbStartAdd.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectStartAdd"));
                return;
            }
            StartAdd = int.Parse(cbbStartAdd.Text);
            if ((Length = cbbLength.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectLength"));
                return;
            }
            Length = int.Parse(cbbLength.Text);

            //string strpwd = tbRWAccessPwd.Text.Replace(" ", "");
            //if (strpwd.Length != 8)
            //{
            //    MessageBox.Show(rm.GetString("strMsgPwdMustEight")); 
            //    return;
            //}
            //if (!IsHexCharacter(strpwd))
            //{
            //    MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));
            //    return;
            //}

            //// 转密码框的字符转为byte数组
            //byte[] pwd = new byte[4];
            //for (int i = 0; i < 4; ++i)
            //{
            //    pwd[i] = Convert.ToByte(strpwd.Substring(i * 2, 2), 16); // 把字符串的子串转为16进制的8位无符号整数
            //}
            byte[] byteArray = new byte[64];
            tbRWData.Text = "";
            if (1 == Dis.ReadTagData(deviceNo, (byte)RWBank, (byte)StartAdd, (byte)Length, byteArray))
            {
                for (int i = 3; i < 2 * Length + 3; i++) // 前面３个字节为输入的参数
                {
                    tbRWData.Text += string.Format("{0:X2} ", byteArray[i]);
                }
                labResult.Text = rm.GetString("strMsgSussecReadData");
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedReadData");
            }
        }

        /// <summary>
        /// 写入
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteData_Click(object sender, EventArgs e)
        {
            int RWBank = -1;
            int StartAdd = -1;
            int Length = -1;
            labResult.Text = "";
            if ((RWBank = cbbRWBank.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectRWBank"));
                return;
            }
            if ((StartAdd = cbbStartAdd.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectStartAdd"));
                return;
            }
            StartAdd = int.Parse(cbbStartAdd.Text);
            if ((Length = cbbLength.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelectLength"));
                return;
            }
            Length = int.Parse(cbbLength.Text);

            string strData = tbRWData.Text.Replace(" ", "");// 去空格
            if (strData.Length % 4 != 0 || strData.Length / 4 != Length)
            {
                MessageBox.Show(rm.GetString("strMsgLengthDiff"));
                return;
            }
            if (!IsHexCharacter(strData))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));
                return;
            }

            byte[] byteArray = new byte[64];
            for (int i = 0; i < 2 * Length; ++i)
            {
                byteArray[i] = Convert.ToByte(strData.Substring(2 * i, 2), 16);
            }
            if (1 == Dis.WriteTagData(deviceNo, (byte)RWBank, (byte)StartAdd, (byte)Length, byteArray))
            {
                labResult.Text = rm.GetString("strMsgSucceedWrite");
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedWrite");
            }
        }
        private bool IsHexCharacter(string str)
        {
            return Regex.IsMatch(str, "^[0-9A-Fa-f]+$");
        }

        /// <summary>
        /// 锁定
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLockTag_Click(object sender, EventArgs e)
        {
            int lockBank = -1;
            labResult.Text = "";

            string strpwd = tbLockAccessPwd.Text.Replace(" ", "");
            if (strpwd.Length != 8)
            {
                MessageBox.Show(rm.GetString("strMsgPwdMustEight"));
                return;
            }
            if (!IsHexCharacter(strpwd))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));
                return;
            }
            if ((lockBank = cbbLockBank.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgSelecOprBank"));
                return;
            }

            byte[] pwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                pwd[i] = Convert.ToByte(strpwd.Substring(i * 2, 2), 16); // 把字符串的子串转为16进制的8位无符号整数
            }
            if (1 == Dis.LockTag(deviceNo, (byte)lockBank, pwd))
            {
                labResult.Text = rm.GetString("strMsgSucceedLock");
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedLock");
            }
            return;
        }

        /// <summary>
        /// 销毁
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKillTag_Click(object sender, EventArgs e)
        {
            string strKillPwd = tbKillKillPwd.Text.Replace(" ", "");
            if (strKillPwd.Length != 8)
            {
                MessageBox.Show(rm.GetString("strMsgPwdMustEight"));
                return;
            }
            if (!IsHexCharacter(strKillPwd))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));
                return;
            }
            byte[] byteAccessPwd = new byte[4];
            byte[] byteKillPwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                byteKillPwd[i] = Convert.ToByte(strKillPwd.Substring(i * 2, 2), 16);
            }
            if (1 == Dis.KillTag(deviceNo, byteKillPwd))
            {
                labResult.Text = rm.GetString("strMsgSucceedDes");
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedDes");
            }
        }
        bool IsDecNumber(string str)
        {
            return Regex.IsMatch(str, "^[0-9]+$");
        }

        /// <summary>
        ///  频率及其它参数设置
        ///  2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetFreq_Click(object sender, EventArgs e)
        {
            //  检查设备号
            if (!int.TryParse(tbNewDevNo.Text, out m_DeviceNo))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidDevNo"));
                return;
            }
            else
            {
                if (m_DeviceNo < 0 && m_DeviceNo > 255)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidDevNo"));
                    return;
                }
            }
            // 检查功率值
            if (!int.TryParse(tbPower.Text, out m_Power))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidPower"));
                return;
            }
            else
            {
                if (m_Power < 100 && m_Power > 150)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidPower"));
                    return;
                }
            }
            // 检查单卡多卡模式
            if ((m_ReadingMode = cbbSingOrMulti.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidSingleOrMulti"));
                return;
            }
            if ((m_Band = cboBand.SelectedIndex) == 0)
            {
                // 检查频率模式
                if ((m_FreqMode = cbbFreqModeUS.SelectedIndex) == -1)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidFreqMode"));
                    return;
                }
                // 检查频点
                if ((m_FreqPoint = cbbFreqPointUS.SelectedIndex) == -1)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidFreqPoint"));
                    return;
                }
            }
            else if ((m_Band=cboBand.SelectedIndex) == 1) 
            {
                // 检查频率模式
                if ((m_FreqMode = cboFreqModeEU.SelectedIndex) == -1)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidFreqMode"));
                    return;
                }
                // 检查频点
                if ((m_FreqPoint = cboFreqPointEU.SelectedIndex) == -1)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidFreqPoint"));
                    return;
                }
            }
            if (m_FreqMode > 0) // 定频模式
            {
                m_FreqMode = m_FreqPoint; // 写入值为频率索引
            }
            int res = Dis.SetSingleParameter(deviceNo, Dis.ADD_USERCODE, (byte)m_DeviceNo);
            res *= Dis.SetSingleParameter(deviceNo, Dis.ADD_POWER, (byte)m_Power);
            res *= Dis.SetSingleParameter(deviceNo, Dis.ADD_SINGLE_OR_MULTI_TAG, (byte)m_ReadingMode);
            res *= Dis.SetSingleParameter(deviceNo, Dis.ADD_FREQUENCY_SET, (byte)m_FreqMode);
            res *= Dis.SetSingleParameter(deviceNo, Dis.ADD_ANT_MODE, (byte)m_Band);//设置哪个国家的国标名称 2016-04-25 hz

            byte[] fp = new byte[8];
            if (cboBand.SelectedIndex == 0)//美标
            {
                // 处理各个频点
                m_fp[0] = cbFp1.Checked ? 1 : 0;
                m_fp[1] = cbFp2.Checked ? 1 : 0;
                m_fp[2] = cbFp3.Checked ? 1 : 0;
                m_fp[3] = cbFp4.Checked ? 1 : 0;
                m_fp[4] = cbFp5.Checked ? 1 : 0;
                m_fp[5] = cbFp6.Checked ? 1 : 0;
                m_fp[6] = cbFp7.Checked ? 1 : 0;
                m_fp[7] = cbFp8.Checked ? 1 : 0;
                m_fp[8] = cbFp9.Checked ? 1 : 0;
                m_fp[9] = cbFp10.Checked ? 1 : 0;

                m_fp[10] = cbFp11.Checked ? 1 : 0;
                m_fp[11] = cbFp12.Checked ? 1 : 0;
                m_fp[12] = cbFp13.Checked ? 1 : 0;
                m_fp[13] = cbFp14.Checked ? 1 : 0;
                m_fp[14] = cbFp15.Checked ? 1 : 0;
                m_fp[15] = cbFp16.Checked ? 1 : 0;
                m_fp[16] = cbFp17.Checked ? 1 : 0;
                m_fp[17] = cbFp18.Checked ? 1 : 0;
                m_fp[18] = cbFp19.Checked ? 1 : 0;
                m_fp[19] = cbFp20.Checked ? 1 : 0;

                m_fp[20] = cbFp21.Checked ? 1 : 0;
                m_fp[21] = cbFp22.Checked ? 1 : 0;
                m_fp[22] = cbFp23.Checked ? 1 : 0;
                m_fp[23] = cbFp24.Checked ? 1 : 0;
                m_fp[24] = cbFp25.Checked ? 1 : 0;
                m_fp[25] = cbFp26.Checked ? 1 : 0;
                m_fp[26] = cbFp27.Checked ? 1 : 0;
                m_fp[27] = cbFp28.Checked ? 1 : 0;
                m_fp[28] = cbFp29.Checked ? 1 : 0;
                m_fp[29] = cbFp30.Checked ? 1 : 0;

                m_fp[30] = cbFp31.Checked ? 1 : 0;
                m_fp[31] = cbFp32.Checked ? 1 : 0;
                m_fp[32] = cbFp33.Checked ? 1 : 0;
                m_fp[33] = cbFp34.Checked ? 1 : 0;
                m_fp[34] = cbFp35.Checked ? 1 : 0;
                m_fp[35] = cbFp36.Checked ? 1 : 0;
                m_fp[36] = cbFp37.Checked ? 1 : 0;
                m_fp[37] = cbFp38.Checked ? 1 : 0;
                m_fp[38] = cbFp39.Checked ? 1 : 0;
                m_fp[39] = cbFp40.Checked ? 1 : 0;

                m_fp[40] = cbFp41.Checked ? 1 : 0;
                m_fp[41] = cbFp42.Checked ? 1 : 0;
                m_fp[42] = cbFp43.Checked ? 1 : 0;
                m_fp[43] = cbFp44.Checked ? 1 : 0;
                m_fp[44] = cbFp45.Checked ? 1 : 0;
                m_fp[45] = cbFp46.Checked ? 1 : 0;
                m_fp[46] = cbFp47.Checked ? 1 : 0;
                m_fp[47] = cbFp48.Checked ? 1 : 0;
                m_fp[48] = cbFp49.Checked ? 1 : 0;
                m_fp[49] = cbFp50.Checked ? 1 : 0;

                fp[0] += (byte)m_fp[0];
                fp[0] += (byte)(m_fp[1] << 1);
                fp[0] += (byte)(m_fp[2] << 2);
                fp[0] += (byte)(m_fp[3] << 3);
                fp[0] += (byte)(m_fp[4] << 4);
                fp[0] += (byte)(m_fp[5] << 5);
                fp[0] += (byte)(m_fp[6] << 6);
                fp[0] += (byte)(m_fp[7] << 7);

                fp[1] += (byte)m_fp[8];
                fp[1] += (byte)(m_fp[9] << 1);
                fp[1] += (byte)(m_fp[10] << 2);
                fp[1] += (byte)(m_fp[11] << 3);
                fp[1] += (byte)(m_fp[12] << 4);
                fp[1] += (byte)(m_fp[13] << 5);
                fp[1] += (byte)(m_fp[14] << 6);
                fp[1] += (byte)(m_fp[15] << 7);

                fp[2] += (byte)m_fp[16];
                fp[2] += (byte)(m_fp[17] << 1);
                fp[2] += (byte)(m_fp[18] << 2);
                fp[2] += (byte)(m_fp[19] << 3);
                fp[2] += (byte)(m_fp[20] << 4);
                fp[2] += (byte)(m_fp[21] << 5);
                fp[2] += (byte)(m_fp[22] << 6);
                fp[2] += (byte)(m_fp[23] << 7);

                fp[3] += (byte)m_fp[24];
                fp[3] += (byte)(m_fp[25] << 1);
                fp[3] += (byte)(m_fp[26] << 2);
                fp[3] += (byte)(m_fp[27] << 3);
                fp[3] += (byte)(m_fp[28] << 4);
                fp[3] += (byte)(m_fp[29] << 5);
                fp[3] += (byte)(m_fp[30] << 6);
                fp[3] += (byte)(m_fp[31] << 7);

                fp[4] += (byte)m_fp[32];
                fp[4] += (byte)(m_fp[33] << 1);
                fp[4] += (byte)(m_fp[34] << 2);
                fp[4] += (byte)(m_fp[35] << 3);
                fp[4] += (byte)(m_fp[36] << 4);
                fp[4] += (byte)(m_fp[37] << 5);
                fp[4] += (byte)(m_fp[38] << 6);
                fp[4] += (byte)(m_fp[39] << 7);

                fp[5] += (byte)m_fp[40];
                fp[5] += (byte)(m_fp[41] << 1);
                fp[5] += (byte)(m_fp[42] << 2);
                fp[5] += (byte)(m_fp[43] << 3);
                fp[5] += (byte)(m_fp[44] << 4);
                fp[5] += (byte)(m_fp[45] << 5);
                fp[5] += (byte)(m_fp[46] << 6);
                fp[5] += (byte)(m_fp[47] << 7);

                fp[6] += (byte)m_fp[48];
                fp[6] += (byte)(m_fp[49] << 1);
            }
            else if (cboBand.SelectedIndex == 1) //欧标
            {
                // 处理各个频点
                m_EU[0] = chkFp1.Checked ? 1 : 0;
                m_EU[1] = chkFp2.Checked ? 1 : 0;
                m_EU[2] = chkFp3.Checked ? 1 : 0;
                m_EU[3] = chkFp4.Checked ? 1 : 0;
                m_EU[4] = chkFp5.Checked ? 1 : 0;

                fp[0] += (byte)m_EU[0];
                fp[0] += (byte)(m_EU[1] << 1);
                fp[0] += (byte)(m_EU[2] << 2);
                fp[0] += (byte)(m_EU[3] << 3);
                fp[0] += (byte)(m_EU[4] << 4);
            }


            res *= Dis.SetMultiParameters(deviceNo, Dis.ADD_FREQUENCY_PARA_92, 7, fp);
            if (0 != res)
            {
                MessageBox.Show(rm.GetString("strMsgSucceedSetFreq"));
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedSetFreq"));
            }
        }

        /// <summary>
        /// 工作模式设置
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetWorkMode_Click(object sender, EventArgs e)
        {
            // 工作模式
            if ((m_WorkMode = cbbWorkMode.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidWordMode"));
                return;
            }
            // 定时参数
            if (!int.TryParse(tbTiming.Text, out m_TimingInterval))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidTimingParam"));
                return;
            }
            else
            {
                if (m_TimingInterval < 2 || m_TimingInterval > 100)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidTimingParam"));
                    return;
                }
            }
            // 触发延时参数

            if (!int.TryParse(tbDelay.Text, out m_DelayTime))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidDelayTime"));
                return;
            }
            else
            {
                if (m_DelayTime < 0 || m_DelayTime > 240)
                {
                    MessageBox.Show(rm.GetString("strMsgInvalidDelayTime"));
                    return;
                }
            }
            // 触发开关参数
            if ((m_TrigSwitch = cbbTrigSwitch.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidTrigSwitch"));
                return;
            }

            // 相邻判别时间
            if (!int.TryParse(tbNeighJudge.Text, out m_AdjaDisTime))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidNJ"));
                return;
            }
            else
            {
                if (m_AdjaDisTime > 255 || m_AdjaDisTime < 0)
                {
                    MessageBox.Show(rm.GetString("stMsgNJValid"));
                    return;
                }
            }
            // 相邻判别
            if (cbAjaDisc.Checked)
            {
                m_AdjaDis = 1;
            }
            else
            {
                m_AdjaDis = 2;
            }
            int readSpeed =(cboReadSpeed.Text == null || cboReadSpeed.Text == "") ? 1 : int.Parse(cboReadSpeed.Text);
            // 写入参数值
            int bRes = Dis.SetSingleParameter(deviceNo, Dis.ADD_WORKMODE, (byte)(m_WorkMode + 1));    // 工作模式
            bRes *= Dis.SetSingleParameter(deviceNo, Dis.ADD_TIME_INTERVAL, (byte)m_TimingInterval);  // 定时间间隔
            bRes *= Dis.SetSingleParameter(deviceNo, Dis.ADD_TRIG_DELAYTIME, (byte)m_DelayTime);      // 触发延迟时间
            bRes *= Dis.SetSingleParameter(deviceNo, Dis.ADD_TRIG_SWITCH, (byte)m_TrigSwitch);        // 启用管脚0
            bRes *= Dis.SetSingleParameter(deviceNo, Dis.ADD_TRIG_MODE, 0x1);                         // 管脚0设置成高电平模式，0为低电平
            bRes *= Dis.SetSingleParameter(deviceNo, Dis.ADD_NEIGHJUDGE_TIME, (byte)m_AdjaDisTime);   // 相邻判别时间
            bRes *= Dis.SetSingleParameter(deviceNo, Dis.ADD_NEIGHJUDGE_SET, (byte)m_AdjaDis);        // 启动相邻判别
            bRes *= Dis.SetSingleParameter(deviceNo, Dis.ADD_READSPEED, (byte)readSpeed);             //设置单位读卡速度 2016-04-26 hz

            if (0 != bRes)
            {
                MessageBox.Show(rm.GetString("strMsgSucceedSetWorkMode"));
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedSetWorkMode"));
            }
        }

        private void cbbLangSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// 锁卡操作类型
            cbbLockBank.Items.Clear();
            cbbWorkMode.Items.Clear();
            cbbTrigSwitch.Items.Clear();
            cbbCommMode.Items.Clear();
            cbbSingOrMulti.Items.Clear();
            cbbFreqModeUS.Items.Clear();
            cboFreqModeEU.Items.Clear();
            cbbBeepControl.Items.Clear();
            cbbUsbFormat.Items.Clear();
            cboBand.Items.Clear();
            if (cbbLangSwitch.SelectedIndex == 0)
            {
                // 加密操作区
                cbbLockBank.Items.Add("用户区");
                cbbLockBank.Items.Add("TID");
                cbbLockBank.Items.Add("EPC");
                cbbLockBank.Items.Add("访问密码区");
                cbbLockBank.Items.Add("灭活密码区");
                cbbLockBank.Items.Add("全部区域");
                // 工作模式
                cbbWorkMode.Items.Add("主从模式");
                cbbWorkMode.Items.Add("定时模式");
                cbbWorkMode.Items.Add("触发模式");
                // 触发模式
                cbbTrigSwitch.Items.Add("关");
                cbbTrigSwitch.Items.Add("高电平触发");

                // 通信方式
                cbbCommMode.Items.Add("RS485/RJ45");
                cbbCommMode.Items.Add("韦根");
                cbbCommMode.Items.Add("RS232");
                // 读卡模式
                cbbSingOrMulti.Items.Add("单标签");
                cbbSingOrMulti.Items.Add("多标签");
                // 频率设置
                cbbFreqModeUS.Items.Add("跳频");
                cbbFreqModeUS.Items.Add("定频");

                cboFreqModeEU.Items.Add("跳频");
                cboFreqModeEU.Items.Add("定频");
                // 频率标名
                cboBand.Items.Add("美标");
                cboBand.Items.Add("欧标");
                //cboBand.Items.Add("国标");
                // 读卡声音控制
                cbbBeepControl.Items.Add("关闭");
                cbbBeepControl.Items.Add("连续Beep");
                cbbBeepControl.Items.Add("只响一声");
                // USB输出格式
                cbbUsbFormat.Items.Add("韦根26(1字节+2字节)，8位10进制数");
                cbbUsbFormat.Items.Add("韦根26(3字节)，8位十进制数");
                cbbUsbFormat.Items.Add("00+3字节16进制");
                cbbUsbFormat.Items.Add("4字节16进制");
                cbbUsbFormat.Items.Add("12字节16进制");
                cbbUsbFormat.Items.Add("12字节TID");
                cbbUsbFormat.Items.Add("0000+前3字节16进制");
            }
            else
            {
                cbbLockBank.Items.Add("User");
                cbbLockBank.Items.Add("TID");
                cbbLockBank.Items.Add("EPC");
                cbbLockBank.Items.Add("AccessPwd");
                cbbLockBank.Items.Add("KillPwd");
                cbbLockBank.Items.Add("All");
                // 工作模式
                cbbWorkMode.Items.Add("Master/Slave");
                cbbWorkMode.Items.Add("Timing");
                cbbWorkMode.Items.Add("Trigger");
                // 触发模式
                cbbTrigSwitch.Items.Add("Off");
                cbbTrigSwitch.Items.Add("High level");

                // 通信方式
                cbbCommMode.Items.Add("RS485/RJ45");
                cbbCommMode.Items.Add("Wiegand");
                cbbCommMode.Items.Add("RS232");
                // 读卡模式
                cbbSingOrMulti.Items.Add("Single Tag");
                cbbSingOrMulti.Items.Add("Multi Tag");
                // 频率设置
                cbbFreqModeUS.Items.Add("Freq Hopping");
                cbbFreqModeUS.Items.Add("Fixed Freq");

                cboFreqModeEU.Items.Add("Freq Hopping");
                cboFreqModeEU.Items.Add("Fixed Freq");

                // 频率标名
                cboBand.Items.Add("US Band");
                cboBand.Items.Add("EU Band");
                //cboBand.Items.Add("Chinese Band");

                // 读卡声音控制
                cbbBeepControl.Items.Add("Off");
                cbbBeepControl.Items.Add("Continuous beep");
                cbbBeepControl.Items.Add("Only once");
                // USB输出格式
                cbbUsbFormat.Items.Add("Wiegand26 (1B+2B) 8bits(Dec) ");
                cbbUsbFormat.Items.Add("Wiegand26 3B 8bits(Dec)");
                cbbUsbFormat.Items.Add("00+3Bytes(Hex)");
                cbbUsbFormat.Items.Add("4Bytes(Hex)");
                cbbUsbFormat.Items.Add("12Bytes(Hex)");
                cbbUsbFormat.Items.Add("12Bytes(TID)");
                cbbUsbFormat.Items.Add("0000+3Bytes(Front) ");
            }
            // 引用所选择的语言字符串
            rm = rmArray[cbbLangSwitch.SelectedIndex];
            // Tab标签页标题
            General.Text = rm.GetString("strTpGeneral");
            TagAccess.Text = rm.GetString("strTpTagAccess");
            SetCommParam.Text = rm.GetString("strTpSetCommParam");
            SetReaderParam.Text = rm.GetString("strTpSetReaderParam");
            OtherOpreation.Text = rm.GetString("strTpOtherOpr");

            // 表头更新
            listView.Columns[0].Text = rm.GetString("strLvHeadNo");
            listView.Columns[1].Text = rm.GetString("strLvHeadEPC");
            listView.Columns[2].Text = rm.GetString("strLvHeadCount");
            listView.Columns[3].Text = rm.GetString("strLvHeadAntNo");
            listView.Columns[4].Text = rm.GetString("strLvHeadDevNo");
            lvZl.Columns[0].Text = rm.GetString("strZlHeadNo");
            lvZl.Columns[1].Text = rm.GetString("strZlHeadIP");
            lvZl.Columns[2].Text = rm.GetString("strZlHeadPort");
            lvZl.Columns[3].Text = rm.GetString("strZlHeadMAC");

            // 按钮文字
            btnConnect.Text = rm.GetString("strBtnConnect");
            btnDisconnect.Text = rm.GetString("strBtnDisconnect");
            btnUpdate.Text = rm.GetString("strBtnUpdate");
            btnStartReadData.Text = rm.GetString("strBtnStartReadData");
            btnStopReadData.Text = rm.GetString("strBtnStopReadData");
            btnClearListView.Text = rm.GetString("strBtnClearListView");
            btnReadOnce.Text = rm.GetString("strBtnReadOnce");
            btnDefaultParams.Text = rm.GetString("strBtnDefaultParams");
            btnKillTag.Text = rm.GetString("strBtnKillTag");
            btnModifyDev.Text = rm.GetString("strBtnModifyDev");
            btnLockTag.Text = rm.GetString("strBtnLock");
            btnUnlockTag.Text = rm.GetString("strBtnUnlockTag");
            btnInitTag.Text = rm.GetString("strBtnInitTag");
            btnReadData.Text = rm.GetString("strBtnReadTagData");
            btnSearchDev.Text = rm.GetString("strBtnSearchDev");
            btnSetFreq.Text = rm.GetString("strBtnSetDevNo");
            btnSetWorkMode.Text = rm.GetString("strBtnSetNeighJudge");
            btnSetParams.Text = rm.GetString("strBtnSetParams");
            btnWriteData.Text = rm.GetString("strBtnWriteTagData");
            btnClearData.Text = rm.GetString("strBtnClearEditData");
            btnFastWrite.Text = rm.GetString("strBtnFastWrite");
            btnClearFWData.Text = rm.GetString("strBtnClearFWData");
            btnReadWorkMode.Text = rm.GetString("strBtnReadWorkMode");
            btnDefaultWorkMode.Text = rm.GetString("strBtnDefaultWorkMode");
            btnSetWorkMode.Text = rm.GetString("strBtnSetWorkMode");
            btnReadCommMode.Text = rm.GetString("strBtnReadCommMode");
            btnDefaultCommMode.Text = rm.GetString("strBtnDefaultCommMode");
            btnSetCommMode.Text = rm.GetString("strBtnSetCommMode");
            btnReadFreq.Text = rm.GetString("strBtnReadFreq");
            btnSetFreq.Text = rm.GetString("strBtnSetFreq");
            btnDefaultFreq.Text = rm.GetString("strBtnDefaultFreq");
            btnClearFreq.Text = rm.GetString("strBtnClearFreq");
            btnTagAuth.Text = rm.GetString("strBtnTagAuth");
            btnModifyAuthPwd.Text = rm.GetString("strBtnModAuthPwd");
            btnSetBeep.Text = rm.GetString("strBtnSetBeep");
            btnSetUsbFormat.Text = rm.GetString("strBtnSetUsbFormat");
            btnReadBeep.Text = rm.GetString("btnReadBeep");
            btnReadRelayTime.Text = rm.GetString("btnReadRelayTime");
            rdoOpen1.Text = rm.GetString("rdoOpen1");
            rdoClose1.Text = rm.GetString("rdoClose1");
            rdoOpen2.Text = rm.GetString("rdoOpen2");
            rdoClose2.Text = rm.GetString("rdoClose2");
            chkZD.Text = rm.GetString("chkZD");

            // RadioButton标示
            rbReadSingleTag.Text = rm.GetString("strRbReadSingleTag");
            rbReadMultiTag.Text = rm.GetString("strRbReadMultiTag");
            rbAsc.Text = rm.GetString("strRbAsc");
            rbDesc.Text = rm.GetString("strRbDesc");
            rbNet.Text = rm.GetString("strRbNet");
            rbSerialPort.Text = rm.GetString("strRbSerialPort");

            // CheckBox标示

            // GroupBox说明文字
            gbCommMode.Text = rm.GetString("strGbCommMode");
            gbReadMode.Text = rm.GetString("strGbReadMode");
            gbAdvancedOpr.Text = rm.GetString("strGbAdvanceOpr");
            gbWorkMode.Text = rm.GetString("strGbDevParams");
            gbFastWrite.Text = rm.GetString("strGbFastWrite");
            gbNetParams.Text = rm.GetString("strGbNetParams");
            gbRWData.Text = rm.GetString("strGbRWData");
            gbSPParams.Text = rm.GetString("strGbSPParams");
            gbCommModeParam.Text = rm.GetString("strGbCommModeParam");
            gbFreq.Text = rm.GetString("strGbFreq");
            gbTagAuth.Text = rm.GetString("strGbTagAuth");
            gbBeepControl.Text = rm.GetString("strGbBeepControl");
            gbUsbFormat.Text = rm.GetString("strGbUsbFormat");

            cbAjaDisc.Text = rm.GetString("strChkAjaDis");
            cbSaveFile.Text = rm.GetString("strChkSaveFile");

            // Label标签
            labBaudRate.Text = rm.GetString("strLabBaudRate");
            labCheckBits.Text = rm.GetString("strLabCheckBits");
            labCommPort.Text = rm.GetString("strLabCommPort");
            labDataBits.Text = rm.GetString("strLabDataBits");
            labDestIP.Text = rm.GetString("strLabDestIP");
            labDeviceNo.Text = rm.GetString("strLabDeviceNo");
            labDestPort.Text = rm.GetString("strLabDestPort");
            labDestroyPwd.Text = rm.GetString("strLabDestrlyPwd");
            labDevNo.Text = rm.GetString("strLabDevNo");
            labGateway.Text = rm.GetString("strLabGateway");
            labIPAdd.Text = rm.GetString("strLabIPAdd");
            labIPMode.Text = rm.GetString("strLabIPMode");
            labLength.Text = rm.GetString("strLabLength");
            labLockAccessPwd.Text = rm.GetString("strLabLockAccessPwd");
            labLockBank.Text = rm.GetString("strLabLockBank");
            labMask.Text = rm.GetString("strLabMask");
            labNetMode.Text = rm.GetString("strLabNetMode");
            labPort.Text = rm.GetString("strLabPort");
            labPromotion.Text = rm.GetString("strLabPromotion");
            labOprBank.Text = rm.GetString("strLabRWBank");
            labData.Text = rm.GetString("strLabRWData");
            labStartAdd.Text = rm.GetString("strLabStartAdd");
            labReadCount.Text = rm.GetString("strLabCount");
            labTagCount.Text = rm.GetString("strLabTagCount");
            labFWData.Text = rm.GetString("strLabFWData");
            labFWPromo.Text = rm.GetString("strLabFWPromotion");
            labWorkMode.Text = rm.GetString("strLabWorkMode");
            labTimingParam.Text = rm.GetString("strLabTimingParam");
            labTimingUnit.Text = rm.GetString("strLabTimingUnit");
            labTrigSwitch.Text = rm.GetString("strLabTrigSwitch");
            labTrigParam.Text = rm.GetString("strLabTrigParam");
            labDelayUnit.Text = rm.GetString("strLabDelayUnit");
            labCommMode.Text = rm.GetString("strLabCommMode");
            labPulseWidth.Text = rm.GetString("strLabPulseWidth");
            labPulseWidthUnit.Text = rm.GetString("strLabPulseWidthUnit");
            labPulseCycle.Text = rm.GetString("strLabPulseCycle");
            labPulseCycleUnit.Text = rm.GetString("strLabPulseCycleUnit");
            labWiegandProtocol.Text = rm.GetString("strLabWiegandProtocol");
            labPower.Text = rm.GetString("strLabPower");
            labSingleOrMulti.Text = rm.GetString("strLabReadMode");
            labFreq.Text = rm.GetString("strLabFreqSet");
            lblFreq.Text = rm.GetString("strLabFreqSet");
            labAuthPwd.Text = rm.GetString("strLabAuthPwd");
            labNewAuthPwd.Text = rm.GetString("strLabNewAuthPwd");
            lblWigginsTakePlaceValue.Text = rm.GetString("lblWigginsTakePlaceValue");
            lblReadVoice.Text = rm.GetString("lblReadVoice");

            // 语言切换后，清空左下角结果提示串
            labResult.Text = "";
            labelVersion.Text = "";
            labSetParam.Text = "";
            //继电器控制
            GopRelayControl.Text = rm.GetString("GopRelayControl");
            rdoOpenRelay.Text = rm.GetString("rdoOpenRelay");
            rdoCloseRelay.Text = rm.GetString("rdoCloseRelay");
            lblCloseTime.Text = rm.GetString("lblCloseTime");
            btnSetRelayTime.Text = rm.GetString("btnSetRelayTime");
        }

        /// <summary>
        /// 寻卡一次
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadOnce_Click(object sender, EventArgs e)
        {
            labelVersion.Text = "";
            byte[] outData = new byte[64];
            byte[] antNo = new byte[4];
            byte[] res = new byte[14]; // 传给HandleData函数的结果集
            int dv = 0;
            Dis.GetSingleParameter(deviceNo, 0x64, out dv);// 第一个字节是设备号
            res[0] = (byte)dv;
            int nub = 3;//2016-01-05 如果读卡失败，增加3次读卡 hz
            while (true)
            {
                if (0 != Dis.ReadSingleTag(deviceNo, outData, antNo))
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        res[i] = outData[i - 1];
                    }
                    res[13] = 1;// 最后的字节是天线号
                    InsertTag(res, 14);
                    break;
                }
                else
                {
                    nub -= 1;
                    if (nub == 0)
                        labelVersion.Text = rm.GetString("strMsgFailedReadData");
                }
            }

            //if (0 != Dis.ReadSingleTag(deviceNo, outData, antNo))
            //{
            //    for (int i = 1; i <= 12; i++)
            //    {
            //        res[i] = outData[i - 1];
            //    }
            //    res[13] = 1;// 最后的字节是天线号
            //    InsertTag(res, 14);
            //}
            //else
            //{
            //    labelVersion.Text = rm.GetString("strMsgFailedReadData");
            //}
        }
        // 把标签数据插入到结果集中
        static void InsertTag(byte[] data, int length)
        {
            string epc = "";
            for (int i = 1; i < length - 1; ++i)
            {
                epc += string.Format("{0:X2} ", data[i]);
            }
            bNewTag = true;
            for (int i = 0; i < Tag_data.Count; ++i)
            {
                if (epc == Tag_data[i].epc)
                {
                    Tag_data[i].count++;
                    Tag_data[i].antNo = data[13];
                    Tag_data[i].devNo = data[0];
                    bNewTag = false;     // 不是新标签
                    nItemNo = i;             //记录数据索引值，用于更新listView表
                    break;
                }
            }
            if (bNewTag)
            {
                EPC_data epcdata = new EPC_data();
                epcdata.epc = epc;
                epcdata.antNo = data[length - 1];
                epcdata.devNo = data[length - 2];
                epcdata.count = 1;
                Tag_data.Add(epcdata);
            }
            UpdateControl(); // 有新数据产生，更新listView
        }

        /// <summary>
        /// 连续读卡
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbReadMultiTag_CheckedChanged(object sender, EventArgs e)
        {
            btnStartReadData.Enabled = true;
            btnReadOnce.Enabled = false;
        }

        /// <summary>
        /// 单卡识别
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbReadSingleTag_CheckedChanged(object sender, EventArgs e)
        {
            btnStartReadData.Enabled = false;
            btnReadOnce.Enabled = true;
        }

        /// <summary>
        /// 快写
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFastWrite_Click(object sender, EventArgs e)
        {
            string strData = tbFWData.Text.Replace(" ", "");
            if (strData.Length == 0)
            {
                MessageBox.Show(rm.GetString("strMsgDataNotEmpty"));
                return;
            }
            if (!Regex.IsMatch(strData, "^[0-9A-Fa-f]+$"))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));
                return;
            }
            if (strData.Length % 4 != 0)
            {
                MessageBox.Show(rm.GetString("strMsgDataMustFourTimes"));
                return;
            }
            int leng = strData.Length / 2;
            byte[] byteArray = new byte[64];
            int index = 0;
            for (int i = 0; i < leng; ++i)
            {
                byteArray[i] = Convert.ToByte(strData.Substring(2 * i, 2), 16);
                if(i==leng-1)
                    index = Convert.ToInt32(strData.Substring(2 * i, 2), 16)+1;
            }
            if (0 != Dis.FastWriteTag(deviceNo, byteArray, (byte)(leng / 2)))
            {
                labResult.Text = rm.GetString("strMsgSucceedWrite");

                if (chkZD.Checked)//自动增1 2016-04-08 hz
                {
                    string strEpc = "";
                    for (int i = 0; i < leng - 1; ++i)
                    {
                        strEpc += string.Format("{0:X2} ", byteArray[i]);
                    }
                    tbFWData.Text = strEpc + string.Format("{0:X2} ", index);
                }
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedWrite");
            }
        }

        /// <summary>
        /// 清空
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearFWData_Click(object sender, EventArgs e)
        {
            tbFWData.Text = "";
            tbFWData.Focus();
        }

        /// <summary>
        /// 解锁
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnlockTag_Click(object sender, EventArgs e)
        {
            labResult.Text = "";
            string strpwd = tbLockAccessPwd.Text.Replace(" ", "");
            if (strpwd.Length != 8)
            {
                MessageBox.Show(rm.GetString("strMsgPwdMustEight"));
                return;
            }
            if (!IsHexCharacter(strpwd))
            {
                MessageBox.Show(rm.GetString("strMsgPwdInvalidChar"));
                return;
            }

            byte[] pwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                pwd[i] = Convert.ToByte(strpwd.Substring(i * 2, 2), 16); // 把字符串的子串转为16进制的8位无符号整数
            }
            int unlockBank = cbbLockBank.SelectedIndex;
            if (-1 == unlockBank)
            {
                MessageBox.Show(rm.GetString("strMsgSelecOprBank"));
                return;
            }
            if (1 == Dis.UnlockTag(deviceNo, (byte)unlockBank, pwd))
            {
                labResult.Text = rm.GetString("strMsgSucceedUnlock");
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedUnlock");
            }
        }

        /// <summary>
        /// 初始化
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitTag_Click(object sender, EventArgs e)
        {
            labResult.Text = "";
            //int res = Dis.InitializeTag(deviceNo);
            //MessageBox.Show(res.ToString());
            //return;
            if (1 == Dis.InitializeTag(deviceNo))
            {
                labResult.Text = rm.GetString("strMsgSucceedInit");
            }
            else
            {
                labResult.Text = rm.GetString("strMsgFailedInit");
            }
        }

        // 工作模式参数变量
        int m_WorkMode = 0;
        int m_TimingInterval = 0;
        int m_DelayTime = 0;
        int m_TrigSwitch = 0;
        int m_AdjaDis = 0;
        int m_AdjaDisTime = 0;

        // 通信模式参数变量
        int m_CommMode = 0;
        int m_WiegandProto = 0;
        int m_PulseWidth = 0;
        int m_PulseCycle = 0;
        int m_WiegandValue = 0;

        // 频率及其他参数变量
        int m_DeviceNo = 0;
        int m_Power = 0;
        int m_ReadingMode = 0;
        int m_FreqMode = 0;
        int m_FreqPoint = 0;
        int m_Band = 0;
        int[] m_fp = new int[50];
        int[] m_EU = new int[5];

        // 读卡速度
        int m_ReadSpeed = 1;

        // 继电器控制
        int m_Relay_C_O = 0;
        int m_Relay_Time = 0;

        /// <summary>
        /// 工作模式读取
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadWorkMode_Click(object sender, EventArgs e)
        {
            Dis.GetSingleParameter(deviceNo, Dis.ADD_WORKMODE, out m_WorkMode);
            Dis.GetSingleParameter(deviceNo, Dis.ADD_TIME_INTERVAL, out m_TimingInterval);
            Dis.GetSingleParameter(deviceNo, Dis.ADD_TRIG_DELAYTIME, out m_DelayTime);
            Dis.GetSingleParameter(deviceNo, Dis.ADD_TRIG_SWITCH, out m_TrigSwitch);
            Dis.GetSingleParameter(deviceNo, Dis.ADD_NEIGHJUDGE_TIME, out m_AdjaDisTime);                    // 相邻判别时间
            Dis.GetSingleParameter(deviceNo, Dis.ADD_NEIGHJUDGE_SET, out m_AdjaDis);                                // 相邻判别
            Dis.GetSingleParameter(deviceNo, Dis.ADD_READSPEED, out m_ReadSpeed); //获取读卡速度 2016-04-26 hz

            cbbWorkMode.SelectedIndex = m_WorkMode - 1;
            //    // OnCbnSelchangeComboWorkmode();

            tbDelay.Text = m_DelayTime.ToString();
            tbTiming.Text = m_TimingInterval.ToString();
            tbNeighJudge.Text = m_AdjaDisTime.ToString();
            cbbTrigSwitch.SelectedIndex = 0x1 & m_TrigSwitch;
            int readspeed = 0;
            if (m_ReadSpeed == 1)
                readspeed = 0;
            else if (m_ReadSpeed == 10)
                readspeed = 1;
            else
                readspeed = 0;
            cboReadSpeed.SelectedIndex = readspeed;
            if (1 == m_AdjaDis)
            {
                cbAjaDisc.Checked = true;
            }
            else
            {
                cbAjaDisc.Checked = false;
            }
        }

        /// <summary>
        /// 工作模式默认参数
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultWorkMode_Click(object sender, EventArgs e)
        {
            cbbWorkMode.SelectedIndex = 1;
            cbbTrigSwitch.SelectedIndex = 1;
            tbTiming.Text = "5";
            tbDelay.Text = "10";
            cbAjaDisc.Checked = false;
            tbNeighJudge.Text = "5";
        }

        /// <summary>
        /// 通信方式读取
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCommMode_Click(object sender, EventArgs e)
        {
            int res = Dis.GetSingleParameter(deviceNo, Dis.ADD_COMM_MODE, out m_CommMode);
            res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_WIEGAND_PROTO, out m_WiegandProto);
            res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_WIEGAND_PULSEWIDTH, out m_PulseWidth);
            res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_WIEGAND_PULSECYCLE, out m_PulseCycle);
            res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_WIEGAND_VALUE, out m_WiegandValue);
            if (0 != res)
            {
                cbbCommMode.SelectedIndex = m_CommMode - 1;
                cbbWiegandProtocol.SelectedIndex = m_WiegandProto - 1;
                tbPulseWidth.Text = m_PulseWidth.ToString();
                tbPulseCycle.Text = m_PulseCycle.ToString();
                cboWigginsTakePlaceValue.SelectedIndex = m_WiegandValue > 9 ? 9 : m_WiegandValue;
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedReadCommMode"));
            }
        }

        /// <summary>
        /// 通信方式默认参数
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultCommMode_Click(object sender, EventArgs e)
        {
            cbbCommMode.SelectedIndex = 0;
            cbbWiegandProtocol.SelectedIndex = 0;
            tbPulseWidth.Text = "10";
            tbPulseCycle.Text = "16";
            cboWigginsTakePlaceValue.SelectedIndex = 9;
        }

        /// <summary>
        /// 通信方式设置
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetCommMode_Click(object sender, EventArgs e)
        {
            // 通信方式
            if ((m_CommMode = cbbCommMode.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidCommMode"));
                return;
            }
            // 韦根协议
            if ((m_WiegandProto = cbbWiegandProtocol.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidWiegandProto"));
                return;
            }
            // 韦根脉冲宽度
            if (!int.TryParse(tbPulseWidth.Text, out m_PulseWidth))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidPulseWidth"));
                return;
            }
            // 脉冲周期
            if (!int.TryParse(tbPulseCycle.Text, out m_PulseCycle))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidPulseCycle"));
                return;
            }
            // 韦根取位值
            if ((m_WiegandValue = cboWigginsTakePlaceValue.SelectedIndex) == -1)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidWiegandValue"));
                return;
            }
            int res = Dis.SetSingleParameter(deviceNo, Dis.ADD_COMM_MODE, (byte)(m_CommMode + 1));
            res *= Dis.SetSingleParameter(deviceNo, Dis.ADD_WIEGAND_PROTO, (byte)(m_WiegandProto + 1));
            res *= Dis.SetSingleParameter(deviceNo, Dis.ADD_WIEGAND_PULSEWIDTH, (byte)m_PulseWidth);
            res *= Dis.SetSingleParameter(deviceNo, Dis.ADD_WIEGAND_PULSECYCLE, (byte)m_PulseCycle);
            res *= Dis.SetSingleParameter(deviceNo, Dis.ADD_WIEGAND_VALUE, (byte)m_WiegandValue);

            if (0 != res)
            {
                MessageBox.Show(rm.GetString("strMsgSucceedSetCommMode"));
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedSetCommMode"));
            }
        }

        /// <summary>
        /// 频率及其它参数读取
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadFreq_Click(object sender, EventArgs e)
        {
            int res = Dis.GetSingleParameter(deviceNo, Dis.ADD_USERCODE, out m_DeviceNo);
            res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_POWER, out m_Power);
            res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_SINGLE_OR_MULTI_TAG, out m_ReadingMode);
            res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_FREQUENCY_SET, out m_FreqPoint); // 频率模式
            byte[] fp = new byte[10];
            res *= Dis.GetMultiParameters(deviceNo, Dis.ADD_FREQUENCY_PARA_92, 7, fp);
            res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_ANT_MODE, out m_Band);//获取哪个国家的国标名称 2016-04-25 hz

            m_fp[0] = fp[3] & Dis.MASK_BIT_0;
            m_fp[1] = fp[3] & Dis.MASK_BIT_1;
            m_fp[2] = fp[3] & Dis.MASK_BIT_2;
            m_fp[3] = fp[3] & Dis.MASK_BIT_3;
            m_fp[4] = fp[3] & Dis.MASK_BIT_4;
            m_fp[5] = fp[3] & Dis.MASK_BIT_5;
            m_fp[6] = fp[3] & Dis.MASK_BIT_6;
            m_fp[7] = fp[3] & Dis.MASK_BIT_7;

            m_fp[8] = fp[4] & Dis.MASK_BIT_0;
            m_fp[9] = fp[4] & Dis.MASK_BIT_1;
            m_fp[10] = fp[4] & Dis.MASK_BIT_2;
            m_fp[11] = fp[4] & Dis.MASK_BIT_3;
            m_fp[12] = fp[4] & Dis.MASK_BIT_4;
            m_fp[13] = fp[4] & Dis.MASK_BIT_5;
            m_fp[14] = fp[4] & Dis.MASK_BIT_6;
            m_fp[15] = fp[4] & Dis.MASK_BIT_7;

            m_fp[16] = fp[5] & Dis.MASK_BIT_0;
            m_fp[17] = fp[5] & Dis.MASK_BIT_1;
            m_fp[18] = fp[5] & Dis.MASK_BIT_2;
            m_fp[19] = fp[5] & Dis.MASK_BIT_3;
            m_fp[20] = fp[5] & Dis.MASK_BIT_4;
            m_fp[21] = fp[5] & Dis.MASK_BIT_5;
            m_fp[22] = fp[5] & Dis.MASK_BIT_6;
            m_fp[23] = fp[5] & Dis.MASK_BIT_7;

            m_fp[24] = fp[6] & Dis.MASK_BIT_0;
            m_fp[25] = fp[6] & Dis.MASK_BIT_1;
            m_fp[26] = fp[6] & Dis.MASK_BIT_2;
            m_fp[27] = fp[6] & Dis.MASK_BIT_3;
            m_fp[28] = fp[6] & Dis.MASK_BIT_4;
            m_fp[29] = fp[6] & Dis.MASK_BIT_5;
            m_fp[30] = fp[6] & Dis.MASK_BIT_6;
            m_fp[31] = fp[6] & Dis.MASK_BIT_7;

            m_fp[32] = fp[7] & Dis.MASK_BIT_0;
            m_fp[33] = fp[7] & Dis.MASK_BIT_1;
            m_fp[34] = fp[7] & Dis.MASK_BIT_2;
            m_fp[35] = fp[7] & Dis.MASK_BIT_3;
            m_fp[36] = fp[7] & Dis.MASK_BIT_4;
            m_fp[37] = fp[7] & Dis.MASK_BIT_5;
            m_fp[38] = fp[7] & Dis.MASK_BIT_6;
            m_fp[39] = fp[7] & Dis.MASK_BIT_7;

            m_fp[40] = fp[8] & Dis.MASK_BIT_0;
            m_fp[41] = fp[8] & Dis.MASK_BIT_1;
            m_fp[42] = fp[8] & Dis.MASK_BIT_2;
            m_fp[43] = fp[8] & Dis.MASK_BIT_3;
            m_fp[44] = fp[8] & Dis.MASK_BIT_4;
            m_fp[45] = fp[8] & Dis.MASK_BIT_5;
            m_fp[46] = fp[8] & Dis.MASK_BIT_6;
            m_fp[47] = fp[8] & Dis.MASK_BIT_7;

            m_fp[48] = fp[9] & Dis.MASK_BIT_0;
            m_fp[49] = fp[9] & Dis.MASK_BIT_1;


            if (0 == m_FreqPoint) // ０为跳频模式
            {
                m_FreqMode = 0;// 非0则为频点索引
            }
            else if (m_FreqPoint > 0)　// 非０为定频模式
            {
                m_FreqMode = 1;
            }
            if (0 != res)
            {
                tbNewDevNo.Text = m_DeviceNo.ToString();
                tbPower.Text = m_Power.ToString();
                cbbSingOrMulti.SelectedIndex = m_ReadingMode;
                cboBand.SelectedIndex = m_Band;

                if (cboBand.SelectedIndex == 0)
                {
                    cbbFreqModeUS.SelectedIndex = m_FreqMode;
                    cbbFreqPointUS.SelectedIndex = m_FreqPoint;

                    cbFp1.Checked = m_fp[0] == 0 ? false : true;
                    cbFp2.Checked = m_fp[1] == 0 ? false : true;
                    cbFp3.Checked = m_fp[2] == 0 ? false : true;
                    cbFp4.Checked = m_fp[3] == 0 ? false : true;
                    cbFp5.Checked = m_fp[4] == 0 ? false : true;
                    cbFp6.Checked = m_fp[5] == 0 ? false : true;
                    cbFp7.Checked = m_fp[6] == 0 ? false : true;
                    cbFp8.Checked = m_fp[7] == 0 ? false : true;
                    cbFp9.Checked = m_fp[8] == 0 ? false : true;
                    cbFp10.Checked = m_fp[9] == 0 ? false : true;

                    cbFp11.Checked = m_fp[10] == 0 ? false : true;
                    cbFp12.Checked = m_fp[11] == 0 ? false : true;
                    cbFp13.Checked = m_fp[12] == 0 ? false : true;
                    cbFp14.Checked = m_fp[13] == 0 ? false : true;
                    cbFp15.Checked = m_fp[14] == 0 ? false : true;
                    cbFp16.Checked = m_fp[15] == 0 ? false : true;
                    cbFp17.Checked = m_fp[16] == 0 ? false : true;
                    cbFp18.Checked = m_fp[17] == 0 ? false : true;
                    cbFp19.Checked = m_fp[18] == 0 ? false : true;
                    cbFp20.Checked = m_fp[19] == 0 ? false : true;

                    cbFp21.Checked = m_fp[20] == 0 ? false : true;
                    cbFp22.Checked = m_fp[21] == 0 ? false : true;
                    cbFp23.Checked = m_fp[22] == 0 ? false : true;
                    cbFp24.Checked = m_fp[23] == 0 ? false : true;
                    cbFp25.Checked = m_fp[24] == 0 ? false : true;
                    cbFp26.Checked = m_fp[25] == 0 ? false : true;
                    cbFp27.Checked = m_fp[26] == 0 ? false : true;
                    cbFp28.Checked = m_fp[27] == 0 ? false : true;
                    cbFp29.Checked = m_fp[28] == 0 ? false : true;
                    cbFp30.Checked = m_fp[29] == 0 ? false : true;

                    cbFp31.Checked = m_fp[30] == 0 ? false : true;
                    cbFp32.Checked = m_fp[31] == 0 ? false : true;
                    cbFp33.Checked = m_fp[32] == 0 ? false : true;
                    cbFp34.Checked = m_fp[33] == 0 ? false : true;
                    cbFp35.Checked = m_fp[34] == 0 ? false : true;
                    cbFp36.Checked = m_fp[35] == 0 ? false : true;
                    cbFp37.Checked = m_fp[36] == 0 ? false : true;
                    cbFp38.Checked = m_fp[37] == 0 ? false : true;
                    cbFp39.Checked = m_fp[38] == 0 ? false : true;
                    cbFp40.Checked = m_fp[39] == 0 ? false : true;

                    cbFp41.Checked = m_fp[40] == 0 ? false : true;
                    cbFp42.Checked = m_fp[41] == 0 ? false : true;
                    cbFp43.Checked = m_fp[42] == 0 ? false : true;
                    cbFp44.Checked = m_fp[43] == 0 ? false : true;
                    cbFp45.Checked = m_fp[44] == 0 ? false : true;
                    cbFp46.Checked = m_fp[45] == 0 ? false : true;
                    cbFp47.Checked = m_fp[46] == 0 ? false : true;
                    cbFp48.Checked = m_fp[47] == 0 ? false : true;
                    cbFp49.Checked = m_fp[48] == 0 ? false : true;
                    cbFp50.Checked = m_fp[49] == 0 ? false : true;
                }
                else if (cboBand.SelectedIndex == 1)
                {
                    cboFreqModeEU.SelectedIndex = m_FreqMode;
                    cboFreqPointEU.SelectedIndex = m_FreqPoint;

                    chkFp1.Checked = m_fp[0] == 0 ? false : true;
                    chkFp2.Checked = m_fp[1] == 0 ? false : true;
                    chkFp3.Checked = m_fp[2] == 0 ? false : true;
                    chkFp4.Checked = m_fp[3] == 0 ? false : true;
                    chkFp5.Checked = m_fp[4] == 0 ? false : true;
                }
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedReadCommMode"));
            }
        }

        /// <summary>
        ///  频率及其它参数默认参数
        ///  2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultFreq_Click(object sender, EventArgs e)
        {
            tbNewDevNo.Text = "0";
            tbPower.Text = "150";
            cbbSingOrMulti.SelectedIndex = 0;
            cbbFreqModeUS.SelectedIndex = 0;
            cbbFreqPointUS.SelectedIndex = 0;

            cbFp1.Checked = true;
            cbFp2.Checked = false;
            cbFp3.Checked = false;
            cbFp4.Checked = false;
            cbFp5.Checked = false;
            cbFp6.Checked = false;
            cbFp7.Checked = false;
            cbFp8.Checked = false;
            cbFp9.Checked = false;
            cbFp10.Checked = false;

            cbFp11.Checked = true;
            cbFp12.Checked = false;
            cbFp13.Checked = false;
            cbFp14.Checked = false;
            cbFp15.Checked = false;
            cbFp16.Checked = false;
            cbFp17.Checked = false;
            cbFp18.Checked = false;
            cbFp19.Checked = false;
            cbFp20.Checked = false;

            cbFp21.Checked = true;
            cbFp22.Checked = false;
            cbFp23.Checked = false;
            cbFp24.Checked = false;
            cbFp25.Checked = false;
            cbFp26.Checked = false;
            cbFp27.Checked = false;
            cbFp28.Checked = false;
            cbFp29.Checked = false;
            cbFp30.Checked = false;

            cbFp31.Checked = true;
            cbFp32.Checked = false;
            cbFp33.Checked = false;
            cbFp34.Checked = false;
            cbFp35.Checked = false;
            cbFp36.Checked = false;
            cbFp37.Checked = false;
            cbFp38.Checked = false;
            cbFp39.Checked = false;
            cbFp40.Checked = false;

            cbFp41.Checked = true;
            cbFp42.Checked = false;
            cbFp43.Checked = false;
            cbFp44.Checked = false;
            cbFp45.Checked = false;
            cbFp46.Checked = false;
            cbFp47.Checked = false;
            cbFp48.Checked = false;
            cbFp49.Checked = false;
            cbFp50.Checked = true;
        }

        /// <summary>
        ///  频率及其它参数清除频点
        ///  2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearFreq_Click(object sender, EventArgs e)
        {
            cbFp1.Checked = false;
            cbFp2.Checked = false;
            cbFp3.Checked = false;
            cbFp4.Checked = false;
            cbFp5.Checked = false;
            cbFp6.Checked = false;
            cbFp7.Checked = false;
            cbFp8.Checked = false;
            cbFp9.Checked = false;
            cbFp10.Checked = false;

            cbFp11.Checked = false;
            cbFp12.Checked = false;
            cbFp13.Checked = false;
            cbFp14.Checked = false;
            cbFp15.Checked = false;
            cbFp16.Checked = false;
            cbFp17.Checked = false;
            cbFp18.Checked = false;
            cbFp19.Checked = false;
            cbFp20.Checked = false;

            cbFp21.Checked = false;
            cbFp22.Checked = false;
            cbFp23.Checked = false;
            cbFp24.Checked = false;
            cbFp25.Checked = false;
            cbFp26.Checked = false;
            cbFp27.Checked = false;
            cbFp28.Checked = false;
            cbFp29.Checked = false;
            cbFp30.Checked = false;

            cbFp31.Checked = false;
            cbFp32.Checked = false;
            cbFp33.Checked = false;
            cbFp34.Checked = false;
            cbFp35.Checked = false;
            cbFp36.Checked = false;
            cbFp37.Checked = false;
            cbFp38.Checked = false;
            cbFp39.Checked = false;
            cbFp40.Checked = false;

            cbFp41.Checked = false;
            cbFp42.Checked = false;
            cbFp43.Checked = false;
            cbFp44.Checked = false;
            cbFp45.Checked = false;
            cbFp46.Checked = false;
            cbFp47.Checked = false;
            cbFp48.Checked = false;
            cbFp49.Checked = false;
            cbFp50.Checked = false;
        }

        /// <summary>
        /// 工作模式（主从/定时/触发）
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbWorkMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNeighJudge.Visible = cbAjaDisc.Checked;
            switch (cbbWorkMode.SelectedIndex)
            {
                case 0: // 主从
                    {
                        labTimingParam.Visible = false;
                        labTimingUnit.Visible = false;
                        labDelayUnit.Visible = false;
                        labTrigParam.Visible = false;
                        labTrigSwitch.Visible = false;
                        tbTiming.Visible = false;
                        tbDelay.Visible = false;
                        cbbTrigSwitch.Visible = false;
                        cboReadSpeed.Visible = false;
                    }
                    break;
                case 1:// 定时
                    {
                        labTimingParam.Visible = true;
                        labTimingUnit.Visible = true;
                        labDelayUnit.Visible = false;
                        labTrigParam.Visible = false;
                        labTrigSwitch.Visible = false;
                        tbTiming.Visible = true;
                        tbDelay.Visible = false;
                        cbbTrigSwitch.Visible = false;
                        cboReadSpeed.Visible = true;
                    }
                    break;
                case 2: // 触发
                    {
                        labTimingParam.Visible = false;
                        labTimingUnit.Visible = false;
                        labDelayUnit.Visible = true;
                        labTrigParam.Visible = true;
                        labTrigSwitch.Visible = true;
                        tbTiming.Visible = false;
                        tbDelay.Visible = true;
                        cbbTrigSwitch.Visible = true;
                        cboReadSpeed.Visible = false;
                    }
                    break;
            }

        }

        /// <summary>
        /// 通信方式
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbCommMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbCommMode.SelectedIndex)
            {
                case -1:
                case 0: // RS485/RJ45
                case 2: // RS232
                    {
                        labWiegandProtocol.Visible = false;
                        labPulseWidth.Visible = false;
                        labPulseCycle.Visible = false;
                        labPulseWidthUnit.Visible = false;
                        labPulseCycleUnit.Visible = false;
                        tbPulseWidth.Visible = false;
                        tbPulseCycle.Visible = false;
                        cbbWiegandProtocol.Visible = false;
                        lblWigginsTakePlaceValue.Visible = false;
                        cboWigginsTakePlaceValue.Visible = false;
                    }
                    break;
                case 1: // Wiegand
                    {
                        labWiegandProtocol.Visible = true;
                        labPulseWidth.Visible = true;
                        labPulseCycle.Visible = true;
                        labPulseWidthUnit.Visible = true;
                        labPulseCycleUnit.Visible = true;
                        tbPulseWidth.Visible = true;
                        tbPulseCycle.Visible = true;
                        cbbWiegandProtocol.Visible = true;
                        lblWigginsTakePlaceValue.Visible = true;
                        cboWigginsTakePlaceValue.Visible = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// 频率设置
        /// </summary>
        /// <param name="bVisibled"></param>
        private void ShowFreqPointEU(bool bVisibled)
        {
            chkFp1.Visible = bVisibled;
            chkFp2.Visible = bVisibled;
            chkFp3.Visible = bVisibled;
            chkFp4.Visible = bVisibled;
            chkFp5.Visible = bVisibled;
        }

        /// <summary>
        /// 频率设置
        /// </summary>
        /// <param name="bVisibled"></param>
        private void ShowFreqPoint(bool bVisibled)
        {
            cbFp1.Visible = bVisibled;
            cbFp2.Visible = bVisibled;
            cbFp3.Visible = bVisibled;
            cbFp4.Visible = bVisibled;
            cbFp5.Visible = bVisibled;
            cbFp6.Visible = bVisibled;
            cbFp7.Visible = bVisibled;
            cbFp8.Visible = bVisibled;
            cbFp9.Visible = bVisibled;
            cbFp10.Visible = bVisibled;

            cbFp11.Visible = bVisibled;
            cbFp12.Visible = bVisibled;
            cbFp13.Visible = bVisibled;
            cbFp14.Visible = bVisibled;
            cbFp15.Visible = bVisibled;
            cbFp16.Visible = bVisibled;
            cbFp17.Visible = bVisibled;
            cbFp18.Visible = bVisibled;
            cbFp19.Visible = bVisibled;
            cbFp20.Visible = bVisibled;

            cbFp21.Visible = bVisibled;
            cbFp22.Visible = bVisibled;
            cbFp23.Visible = bVisibled;
            cbFp24.Visible = bVisibled;
            cbFp25.Visible = bVisibled;
            cbFp26.Visible = bVisibled;
            cbFp27.Visible = bVisibled;
            cbFp28.Visible = bVisibled;
            cbFp29.Visible = bVisibled;
            cbFp30.Visible = bVisibled;

            cbFp31.Visible = bVisibled;
            cbFp32.Visible = bVisibled;
            cbFp33.Visible = bVisibled;
            cbFp34.Visible = bVisibled;
            cbFp35.Visible = bVisibled;
            cbFp36.Visible = bVisibled;
            cbFp37.Visible = bVisibled;
            cbFp38.Visible = bVisibled;
            cbFp39.Visible = bVisibled;
            cbFp40.Visible = bVisibled;

            cbFp41.Visible = bVisibled;
            cbFp42.Visible = bVisibled;
            cbFp43.Visible = bVisibled;
            cbFp44.Visible = bVisibled;
            cbFp45.Visible = bVisibled;
            cbFp46.Visible = bVisibled;
            cbFp47.Visible = bVisibled;
            cbFp48.Visible = bVisibled;
            cbFp49.Visible = bVisibled;
            cbFp50.Visible = bVisibled;
        }

        /// <summary>
        /// 频率设置
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbFreqMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbFreqModeUS.SelectedIndex)
            {
                case -1:
                case 0: // 跳频
                    {
                        cbbFreqPointUS.Visible = false;
                        ShowFreqPoint(true);
                    }
                    break;
                case 1:// 定频
                    {
                        cbbFreqPointUS.Visible = true;
                        ShowFreqPoint(false);
                    }
                    break;
            }
        }

        private void SetReaderParam_Enter(object sender, EventArgs e)
        {
            btnReadWorkMode_Click(null, null);
            btnReadCommMode_Click(null, null);
            btnReadFreq_Click(null, null);
        }

        private void cbAjaDisc_CheckedChanged(object sender, EventArgs e)
        {
            tbNeighJudge.Visible = cbAjaDisc.Checked;
        }

        /// <summary>
        /// 标签加密
        /// 标签授权
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTagAuth_Click(object sender, EventArgs e)
        {
            if (0 != Dis.TagAuther(deviceNo))
            {
                MessageBox.Show(rm.GetString("strMsgSucceedAuth"));
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedAuth"));
            }
        }

        /// <summary>
        /// 读卡声音设置
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetBeep_Click(object sender, EventArgs e)
        {
            if (-1 == cbbBeepControl.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidBeepControl"));
                return;
            }
            if (0 != Dis.BeepCtrl(deviceNo, (byte)cbbBeepControl.SelectedIndex))
            {
                MessageBox.Show(rm.GetString("strMsgSucceedBeepControl"));
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedBeepControl"));
            }
        }

        /// <summary>
        /// USB输出格式设置
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetUsbFormat_Click(object sender, EventArgs e)
        {
            if (-1 == cbbUsbFormat.SelectedIndex)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidUsbFormat"));
                return;
            }
            if (0 != Dis.SetSingleParameter(deviceNo, 0xC4, (byte)cbbUsbFormat.SelectedIndex))
            {
                MessageBox.Show(rm.GetString("strMsgSucceedSetUsbFormat"));
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedSetUsbFormat"));
            }
        }

        /// <summary>
        /// 标签加密
        /// 修改授权码
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyAuthPwd_Click(object sender, EventArgs e)
        {
            string strAuthPwd = tbAuthPwd.Text.Replace(" ", "");
            string strNewAuthPwd = tbNewAuthPwd.Text.Replace(" ", "");
            if (tbAuthPwd.Text.Length != 4 || tbNewAuthPwd.Text.Length != 4)
            {
                MessageBox.Show(rm.GetString("strMsgPwdMustFour"));
                return;
            }
            if (!Regex.IsMatch(tbAuthPwd.Text, "^[0-9A-Fa-f]+$") || !Regex.IsMatch(tbNewAuthPwd.Text, "^[0-9A-Fa-f]+$"))
            {
                MessageBox.Show(rm.GetString("strMsgInvalidChar"));
                return;
            }

            byte[] oldPwd = new Byte[2];
            byte[] newPwd = new Byte[2];

            for (int i = 0; i < 2; i++)
            {
                oldPwd[i] = Convert.ToByte(strAuthPwd.Substring(i * 2, 2), 16);
                newPwd[i] = Convert.ToByte(strNewAuthPwd.Substring(i * 2, 2), 16);
            }

            byte[] readPwd = new Byte[2];
            Dis.GetAutherPwd(deviceNo, readPwd);
            if (readPwd[0] == oldPwd[0] && readPwd[1] == oldPwd[1])
            {
                if (0 != Dis.SetAutherPwd(deviceNo, newPwd))
                {
                    MessageBox.Show(rm.GetString("strMsgSuccedSetAuthPwd"));
                }
                else
                {
                    MessageBox.Show(rm.GetString("strMsgFailedSetAuthPwd"));
                }
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgInvalidOldPwd"));
                return;
            }

        }

        /// <summary>
        /// 继电器主动
        /// 2016-02-20
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoOpenRelay_Click(object sender, EventArgs e)
        {
            //if (rdoOpenRelay.Checked)
            //{
            //    Dis.SetRelay(0, 1);
            //}
            //int res = Dis.SetSingleParameter(deviceNo, Dis.ADD_RELAY_AUTOMATIC_CLOSE, (byte)1);
            cbbRelayTime.Visible = true;
            lblCloseTime.Visible = true;
            rdoOpen1.Visible = false;
            rdoOpen2.Visible = false;
            rdoClose1.Visible = false;
            rdoClose2.Visible = false;
        }

        /// <summary>
        /// 继电器被动
        /// 2016-02-20
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoCloseRelay_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdoCloseRelay.Checked)
            //{
            //    Dis.SetRelay(0, 0);
            //}
            //int res = Dis.SetSingleParameter(deviceNo, Dis.ADD_RELAY_AUTOMATIC_CLOSE, (byte)0);
            cbbRelayTime.Visible = false;
            lblCloseTime.Visible = false;
            rdoOpen1.Visible = true;
            rdoOpen2.Visible = true;
            rdoClose1.Visible = true;
            rdoClose2.Visible = true;
        }

        /// <summary>
        /// 续电器控制设置
        /// 2016-02-20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetRelayTime_Click(object sender, EventArgs e)
        {
            try
            {
                byte time = 0;
                int pValue = 0;
                if (rdoOpenRelay.Checked == true) //继电器工作模式-主动
                {
                    if (!int.TryParse(cbbRelayTime.Text, out pValue))
                    {
                        MessageBox.Show(rm.GetString("StrMsgcbbRelayTime"));
                        return;
                    }
                    else
                    {
                        if (pValue < 0)
                        {
                            MessageBox.Show(rm.GetString("StrMsgcbbRelayTime"));
                            return;
                        }
                    }

                    int res = int.Parse(cbbRelayTime.Text);
                    time = (byte)res;
                    int result = Dis.SetSingleParameter(deviceNo, Dis.ADD_RELAY_TIME_DELAY, time);
                    result *= Dis.SetSingleParameter(deviceNo, Dis.ADD_RELAY_AUTOMATIC_CLOSE, 1);

                    if (0 == result)
                    {
                        labResult.Text = rm.GetString("strMsgSucceedInvalidbtnSetRelayTime");
                    }
                    else
                    {
                        labResult.Text = rm.GetString("strMsgFailedInvalidbtnSetRelayTime");
                    }
                }
                else if (rdoCloseRelay.Checked == true) //继电器工作模式 -被动
                {
                    int relay1 = -1;
                    int relay2 = -1;

                    //继电器一路
                    if (rdoOpen1.Checked == true)
                    {
                        relay1 = 1;
                    }
                    else if (rdoClose1.Checked == true)
                    {
                        relay1 = 0;
                    }
                    //继电器二路
                    if (rdoOpen2.Checked == true)
                    {
                        relay2 = 3;
                    }
                    else if (rdoClose2.Checked == true)
                    {
                        relay2 = 2;
                    }
                    int result = Dis.SetSingleParameter(deviceNo, Dis.ADD_RELAY_AUTOMATIC_CLOSE, 0);
                    result *= relay1 != -1 ? Dis.SetRelay((byte)deviceNo, (byte)relay1) : 0;
                    result *= relay2 != -1 ? Dis.SetRelay((byte)deviceNo, (byte)relay2) : 0;

                    if (0 == result)
                    {
                        labResult.Text = rm.GetString("strMsgSucceedInvalidbtnSetRelayTime");
                    }
                    else
                    {
                        labResult.Text = rm.GetString("strMsgFailedInvalidbtnSetRelayTime");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(rm.GetString("strMsgFailedInvalidbtnSetRelayTime"));
            }
        }

        /// <summary>
        /// 关闭
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show(rm.GetString("MainWindowFormClosing"), rm.GetString("ClosePrompt"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (result == DialogResult.Yes)
            //{
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
            

            //导出Excel 2015-11-9 hz
            //DialogResult result = MessageBox.Show(rm.GetString("SaveExcel"), rm.GetString("ClosePrompt"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (result == DialogResult.Yes)
            //{
            //    string fileName = "\\DisSave\\Dis" + DateTime.Now.ToString("yyyyMMdd")+".xlsx";
            //    int res = SaveExcel(null, Application.StartupPath + fileName);
            //    if (res == -1)
            //    {
            //        MessageBox.Show(rm.GetString("MsgSaveExcel"));
            //        return;
            //    }
            //    else
            //    {
            //        DialogResult reg = MessageBox.Show(rm.GetString("MsgOpenExcel"), rm.GetString("ClosePrompt"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //        if (reg == DialogResult.Yes)
            //        {
            //            string strPath = Application.StartupPath + fileName;
            //            System.Diagnostics.Process.Start(strPath);
            //        }
            //    }
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        /// <summary>
        /// SaveExcel
        /// hz
        /// 2015-11-9
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filePath"></param>
        private int SaveExcel(System.Data.DataTable dt, string filePath)
        {
            int reg = 0;
            try
            {
                //将要生成的Excel文件                
                StreamWriter writer = new StreamWriter(filePath, false);
                writer.WriteLine("<?xml version=\"1.0\"?>");
                writer.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                //Excel工作薄开始
                writer.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                writer.WriteLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
                writer.WriteLine(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
                writer.WriteLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                //writer.WriteLine(" xmlns:html=\"http://www.w3.org/TR/REC-html40//">");
                writer.WriteLine(" <DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">");
                writer.WriteLine(" <Author>Mrluo735</Author>");
                writer.WriteLine(string.Format("  <Created>{0}T{1}Z</Created>", DateTime.Now.ToString("yyyy-mm-dd"), DateTime.Now.ToString("HH:MM:SS")));
                writer.WriteLine(" <Company>Mrluo735</Company>");
                writer.WriteLine(" <Version>11.6408</Version>");
                writer.WriteLine(" </DocumentProperties>");
                writer.WriteLine(" <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("  <WindowHeight>8955</WindowHeight>");
                writer.WriteLine("  <WindowWidth>11355</WindowWidth>");
                writer.WriteLine("  <WindowTopX>480</WindowTopX>");
                writer.WriteLine("  <WindowTopY>15</WindowTopY>");
                writer.WriteLine("  <ProtectStructure>False</ProtectStructure>");
                writer.WriteLine("  <ProtectWindows>False</ProtectWindows>");
                writer.WriteLine(" </ExcelWorkbook>");
                //Excel工作薄结束
                //工作薄样式
                writer.WriteLine("<Styles>");
                writer.WriteLine("<Style ss:ID=\"Default\" ss:Name=\"Normal\">");
                writer.WriteLine("  <Alignment ss:Vertical=\"Center\" ss:WrapText=\"1\"/>");
                //writer.WriteLine("  <Borders>");
                //writer.WriteLine("      <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                //writer.WriteLine("      <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                //writer.WriteLine("      <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/> ");
                //writer.WriteLine("      <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                //writer.WriteLine("  </Borders>");
                writer.WriteLine(string.Format("<Font ss:FontName=\"{0}\" x:CharSet=\"{1}\" ss:Size=\"{2}\"/>", "宋体", 134, 12));
                writer.WriteLine("  <Interior/>");
                writer.WriteLine("  <Protection/>");
                writer.WriteLine("</Style>");
                writer.WriteLine("  <Style ss:ID=\"s21\">");
                writer.WriteLine("   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\" ss:WrapText=\"1\"/>");
                writer.WriteLine("  </Style>");
                writer.WriteLine("<Style ss:ID=\"BoldColumn\">");
                writer.WriteLine("  <Font ss:FontName=\"宋体\" ss:Bold=\"1\" ss:Size=\"14\"/>");
                writer.WriteLine("  <Borders>");
                writer.WriteLine("      <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("  </Borders>");
                writer.WriteLine("</Style>");
                writer.WriteLine("<Style ss:ID=\"DataColumn\">");
                writer.WriteLine("  <Font ss:FontName=\"宋体\" ss:WrapText=\"1\"/>");
                writer.WriteLine("  <Borders>");
                writer.WriteLine("      <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("  </Borders>");
                writer.WriteLine("</Style>");
                //文本样式
                writer.WriteLine("<Style ss:ID=\"StringLiteral\">");
                writer.WriteLine("  <NumberFormat ss:Format=\"@\"/>");
                writer.WriteLine("</Style>");
                //浮点型样式
                writer.WriteLine("<Style ss:ID=\"Decimal\">");
                writer.WriteLine("  <NumberFormat ss:Format=\"0.00\"/>");
                writer.WriteLine("</Style>");
                //整型样式
                writer.WriteLine("<Style ss:ID=\"Integer\">");
                writer.WriteLine("  <NumberFormat ss:Format=\"0\"/>");
                writer.WriteLine("</Style>");
                //日期样式
                writer.WriteLine("<Style ss:ID=\"DateLiteral\">");
                writer.WriteLine("  <NumberFormat ss:Format=\"yyyy/mm/dd;@\"/>");
                writer.WriteLine("</Style>");
                writer.WriteLine(" </Styles>");

                int rows = dt.Rows.Count + 1;
                int cols = dt.Columns.Count;
                //第i个工作表
                writer.WriteLine(string.Format("<Worksheet ss:Name=\"{0}\">", dt.TableName));
                writer.WriteLine(string.Format("    <Table ss:ExpandedColumnCount=\"{0}\" ss:ExpandedRowCount=\"{1}\" x:FullColumns=\"1\"", cols.ToString(), rows.ToString()));
                writer.WriteLine("   x:FullRows=\"1\">");

                int width = 80;
                //指定每一列的宽度
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    if (c == 1) width = 245; else width = 80;
                    writer.WriteLine(string.Format("<Column ss:Index=\"{0}\" ss:AutoFitWidth=\"{1}\" ss:Width=\"{2}\"/> ", c + 1, 1, width));
                }

                //生成标题
                writer.WriteLine(string.Format("<Row ss:AutoFitHeight=\"{0}\" ss:Height=\"{1}\">", 0, 28.5));
                foreach (DataColumn eachCloumn in dt.Columns)
                {
                    //writer.Write("<Cell ss:StyleID=\"s21\"><Data ss:Type=\"String\">");
                    writer.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                    writer.Write(eachCloumn.ColumnName.ToString());
                    writer.WriteLine("</Data></Cell>");
                }
                writer.WriteLine("</Row>");

                //生成数据记录
                foreach (DataRow eachRow in dt.Rows)
                {
                    writer.WriteLine("<Row ss:AutoFitHeight=\"0\">");
                    for (int currentRow = 0; currentRow != cols; currentRow++)
                    {
                        object[] getValue = ExcelContent(eachRow[currentRow]);

                        //writer.Write(string.Format("<Cell ss:StyleID=\"{0}\"><Data ss:Type=\"{1}\">", getValue[0], getValue[1]));
                        writer.Write("<Cell ss:StyleID=\"DataColumn\"><Data ss:Type=\"String\">");
                        writer.Write(getValue[2]);
                        writer.WriteLine("</Data></Cell>");
                    }
                    writer.WriteLine("</Row>");
                }
                writer.WriteLine("</Table>");
                writer.WriteLine("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("<Selected/>");
                writer.WriteLine("<Panes>");
                writer.WriteLine("<Pane>");
                writer.WriteLine("  <Number>3</Number>");
                writer.WriteLine("  <ActiveRow>1</ActiveRow>");
                writer.WriteLine("</Pane>");
                writer.WriteLine("</Panes>");
                writer.WriteLine("<ProtectObjects>False</ProtectObjects>");
                writer.WriteLine("<ProtectScenarios>False</ProtectScenarios>");
                writer.WriteLine("</WorksheetOptions>");
                writer.WriteLine("</Worksheet>");

                writer.WriteLine("</Workbook>");
                writer.Close();
            }
            catch (Exception ex)
            {
                reg = -1;
            }
            return reg;
        }

        /// <summary>
        /// 根据C#值把它转换成Excel值
        /// 2015-11-9
        /// hz
        /// </summary>
        /// <param name="Value">值</param>
        /// <returns>Excel样式，数据类型，文本</returns>
        private static object[] ExcelContent(object Value)
        {
            object[] strValue = new object[3];
            System.Type rowType = Value.GetType();
            switch (rowType.ToString())
            {
                case "System.String":
                case "System.Guid":
                    string XMLstring = Value.ToString();
                    XMLstring = XMLstring.Trim();
                    XMLstring = XMLstring.Replace("&", "&");
                    XMLstring = XMLstring.Replace(">", ">");
                    XMLstring = XMLstring.Replace("<", "<");
                    strValue[0] = "StringLiteral";
                    strValue[1] = "String";
                    strValue[2] = XMLstring;
                    break;
                case "System.DateTime":
                    DateTime XMLDate = (DateTime)Value;
                    string XMLDatetoString = ""; //Excel Converted Date
                    //把日期时间转化为：“yyyy-MM-ddTHH:mm:ss”这种Excel中的格式
                    XMLDatetoString = XMLDate.ToString(System.Globalization.DateTimeFormatInfo.CurrentInfo.SortableDateTimePattern);
                    strValue[0] = "DateLiteral";
                    strValue[1] = "DateTime";
                    if (XMLDate < Convert.ToDateTime("1900-1-1"))
                    {
                        strValue[0] = "StringLiteral";
                        strValue[1] = "String";
                        XMLDatetoString = string.Empty;
                    }
                    strValue[2] = XMLDatetoString;
                    break;
                case "System.Boolean":
                    strValue[0] = "StringLiteral";
                    strValue[1] = "String";
                    strValue[2] = Value.ToString();
                    break;
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Byte":
                    strValue[0] = "Integer";
                    strValue[1] = "Number";
                    strValue[2] = Value.ToString();
                    break;
                case "System.Byte[]":
                    strValue[0] = "StringLiteral";
                    strValue[1] = "String";
                    strValue[2] = (byte[])Value;
                    break;
                case "System.Decimal":
                case "System.Double":
                    strValue[0] = "Decimal";
                    strValue[1] = "Number";
                    strValue[2] = Value.ToString();
                    break;
                case "System.DBNull":
                    strValue[0] = "StringLiteral";
                    strValue[1] = "String";
                    strValue[2] = "";
                    break;
                default:
                    throw (new Exception(rowType.ToString() + " not handled."));
            }
            return strValue;
        }

        private void txtTemperature2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        /// <summary>
        /// 闭合时间
        /// 2016-01-08
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbRelayTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((ComboBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((ComboBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        /// <summary>
        /// 读卡速度
        /// 2016-01-08
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadSpeed_Click(object sender, EventArgs e)
        {
            if (cboReadSpeed.SelectedIndex == -1)
            {
                MessageBox.Show(rm.GetString("strMsgInvalidReadSpeedSet"));
                return;
            }
            int readSpeed = cboReadSpeed.Text == "" ? 1 : int.Parse(cboReadSpeed.Text);
            int res = Dis.SetSingleParameter(deviceNo, Dis.ADD_READSPEED, (byte)readSpeed);

            if (0 != res)
            {
                MessageBox.Show(rm.GetString("strMsgSucceedSetReadSpeed"));
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedSetReadSpeed"));
            }
        }

        /// <summary>
        /// 声音读取
        /// 2016-01-08
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadBeep_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 速度读取
        /// 2016-01-08
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadSpeed_Click_1(object sender, EventArgs e)
        {
            int res = Dis.GetSingleParameter(deviceNo, Dis.ADD_READSPEED, out m_ReadSpeed);
            if (0 != res)
            {
                int readspeed = 0;
                if (m_ReadSpeed == 1)
                    readspeed = 0;
                else if (m_ReadSpeed == 10)
                    readspeed = 1;
                else
                    readspeed = 0;
                cboReadSpeed.SelectedIndex = readspeed;
            }
            else
            {
                MessageBox.Show(rm.GetString("strMsgFailedReadCommMode"));
            }
        }

        /// <summary>
        /// 继电器控制读取
        /// 2016-02-20
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadRelayTime_Click(object sender, EventArgs e)
        {
            try
            {
                int res = Dis.GetSingleParameter(deviceNo, Dis.ADD_RELAY_AUTOMATIC_CLOSE, out m_Relay_C_O);
                res *= Dis.GetSingleParameter(deviceNo, Dis.ADD_RELAY_TIME_DELAY, out m_Relay_Time);
                if (0 == res)
                {
                    if (m_Relay_C_O == 1)
                    {
                        rdoOpenRelay.Checked = true;
                        cbbRelayTime.Visible = true;
                        lblCloseTime.Visible = true;
                        rdoOpen1.Visible = false;
                        rdoOpen2.Visible = false;
                        rdoClose1.Visible = false;
                        rdoClose2.Visible = false;
                        cbbRelayTime.Text = m_Relay_Time.ToString();
                        labResult.Text = rm.GetString("strMsgSucceedInvalidbtnReadRelayTime");
                    }
                    else if (m_Relay_C_O == 0)
                    {
                        rdoCloseRelay.Checked = true;
                        cbbRelayTime.Visible = false;
                        lblCloseTime.Visible = false;
                        rdoOpen1.Visible = true;
                        rdoOpen2.Visible = true;
                        rdoClose1.Visible = true;
                        rdoClose2.Visible = true;
                        labResult.Text = rm.GetString("strMsgSucceedInvalidbtnReadRelayTime");
                    }
                }
                else
                {
                    labResult.Text = rm.GetString("strMsgFailedInvalidbtnReadRelayTime");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(rm.GetString("strMsgFailedInvalidbtnReadRelayTime"));
            }
        }

        /// <summary>
        /// 国标选取
        /// 2016-04-25
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBand.SelectedIndex == 0) 
            {
                pnlUSBand.Visible = true;
                pnlEUBand.Visible = false;
            }
            else if (cboBand.SelectedIndex == 1)
            {
                pnlEUBand.Visible = true;
                pnlUSBand.Visible = false;
            }
        }

        /// <summary>
        /// 欧标频点设置
        /// 2016-4-25
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboFreqModeEU_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboFreqModeEU.SelectedIndex)
            {
                case -1:
                case 0: // 跳频
                    {
                        cboFreqPointEU.Visible = false;
                        ShowFreqPointEU(true);
                    }
                    break;
                case 1:// 定频
                    {
                        cboFreqPointEU.Visible = true;
                        ShowFreqPointEU(false);
                    }
                    break;
            }
        }
    }

    public struct WSADATA 
    { 
         public short wVersion; 
         public short wHighVersion; 
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)] 
         public string szDescription; 
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)] 
         public string szSystemStatus; 
         [Obsolete] // Ignored for v2.0 and above 
         public int wMaxSockets; 
         [Obsolete] // Ignored for v2.0 and above 
         public int wMAXUDPDG; 
         public IntPtr dwVendorInfo; 
     }

    public sealed class EPC_data : IComparable
    {
        public string epc;
        public int count;
        public int devNo;
        public byte antNo;
        int IComparable.CompareTo(object obj)
        {
            EPC_data temp = (EPC_data)obj ;
            {
                return string.Compare(this.epc, temp.epc);
            }
        }
    }

    // 解决插入数据表格闪烁的问题
    class ListViewNF : System.Windows.Forms.ListView
    {
        public ListViewNF()
        {
            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}
