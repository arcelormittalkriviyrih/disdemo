using DisDemo;
namespace DisDemo
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.cbSaveFile = new System.Windows.Forms.CheckBox();
            this.gbReadMode = new System.Windows.Forms.GroupBox();
            this.rbReadMultiTag = new System.Windows.Forms.RadioButton();
            this.rbReadSingleTag = new System.Windows.Forms.RadioButton();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelTagCount = new System.Windows.Forms.Label();
            this.labReadCount = new System.Windows.Forms.Label();
            this.labTagCount = new System.Windows.Forms.Label();
            this.gbCommMode = new System.Windows.Forms.GroupBox();
            this.labDeviceNo = new System.Windows.Forms.Label();
            this.tbDeviceNo = new System.Windows.Forms.TextBox();
            this.rbNet = new System.Windows.Forms.RadioButton();
            this.rbSerialPort = new System.Windows.Forms.RadioButton();
            this.comboBoxSerialCommPort = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labCommPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.comboBoxIP = new System.Windows.Forms.ComboBox();
            this.rbDesc = new System.Windows.Forms.RadioButton();
            this.rbAsc = new System.Windows.Forms.RadioButton();
            this.labelVersion = new System.Windows.Forms.Label();
            this.btnClearListView = new System.Windows.Forms.Button();
            this.btnStopReadData = new System.Windows.Forms.Button();
            this.btnStartReadData = new System.Windows.Forms.Button();
            this.btnReadOnce = new System.Windows.Forms.Button();
            this.TagAccess = new System.Windows.Forms.TabPage();
            this.gbFastWrite = new System.Windows.Forms.GroupBox();
            this.chkZD = new System.Windows.Forms.CheckBox();
            this.labFWPromo = new System.Windows.Forms.Label();
            this.btnClearFWData = new System.Windows.Forms.Button();
            this.btnFastWrite = new System.Windows.Forms.Button();
            this.labFWData = new System.Windows.Forms.Label();
            this.tbFWData = new System.Windows.Forms.TextBox();
            this.labResult = new System.Windows.Forms.Label();
            this.gbAdvancedOpr = new System.Windows.Forms.GroupBox();
            this.btnInitTag = new System.Windows.Forms.Button();
            this.btnUnlockTag = new System.Windows.Forms.Button();
            this.btnLockTag = new System.Windows.Forms.Button();
            this.btnKillTag = new System.Windows.Forms.Button();
            this.labLockBank = new System.Windows.Forms.Label();
            this.labLockAccessPwd = new System.Windows.Forms.Label();
            this.labDestroyPwd = new System.Windows.Forms.Label();
            this.tbLockAccessPwd = new System.Windows.Forms.TextBox();
            this.tbKillKillPwd = new System.Windows.Forms.TextBox();
            this.cbbLockBank = new System.Windows.Forms.ComboBox();
            this.gbRWData = new System.Windows.Forms.GroupBox();
            this.labData = new System.Windows.Forms.Label();
            this.labLength = new System.Windows.Forms.Label();
            this.labStartAdd = new System.Windows.Forms.Label();
            this.labOprBank = new System.Windows.Forms.Label();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.tbRWData = new System.Windows.Forms.TextBox();
            this.cbbLength = new System.Windows.Forms.ComboBox();
            this.cbbStartAdd = new System.Windows.Forms.ComboBox();
            this.cbbRWBank = new System.Windows.Forms.ComboBox();
            this.SetCommParam = new System.Windows.Forms.TabPage();
            this.gbSPParams = new System.Windows.Forms.GroupBox();
            this.labDataBits = new System.Windows.Forms.Label();
            this.labCheckBits = new System.Windows.Forms.Label();
            this.labBaudRate = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxCheckBits = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.gbNetParams = new System.Windows.Forms.GroupBox();
            this.labPromotion = new System.Windows.Forms.Label();
            this.labDestPort = new System.Windows.Forms.Label();
            this.labDestIP = new System.Windows.Forms.Label();
            this.labGateway = new System.Windows.Forms.Label();
            this.labPort = new System.Windows.Forms.Label();
            this.labMask = new System.Windows.Forms.Label();
            this.labIPAdd = new System.Windows.Forms.Label();
            this.labIPMode = new System.Windows.Forms.Label();
            this.labNetMode = new System.Windows.Forms.Label();
            this.textBoxDestPort = new System.Windows.Forms.TextBox();
            this.textBoxDestIP = new System.Windows.Forms.TextBox();
            this.textBoxGateway = new System.Windows.Forms.TextBox();
            this.textBoxPortNo = new System.Windows.Forms.TextBox();
            this.textBoxNetMask = new System.Windows.Forms.TextBox();
            this.textBoxIPAdd = new System.Windows.Forms.TextBox();
            this.comboBoxIPMode = new System.Windows.Forms.ComboBox();
            this.comboBoxNetMode = new System.Windows.Forms.ComboBox();
            this.btnSetParams = new System.Windows.Forms.Button();
            this.btnDefaultParams = new System.Windows.Forms.Button();
            this.btnModifyDev = new System.Windows.Forms.Button();
            this.btnSearchDev = new System.Windows.Forms.Button();
            this.lvZl = new System.Windows.Forms.ListView();
            this.columnHeaderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIPAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SetReaderParam = new System.Windows.Forms.TabPage();
            this.gbFreq = new System.Windows.Forms.GroupBox();
            this.pnlEUBand = new System.Windows.Forms.Panel();
            this.cboFreqModeEU = new System.Windows.Forms.ComboBox();
            this.lblFreq = new System.Windows.Forms.Label();
            this.cboFreqPointEU = new System.Windows.Forms.ComboBox();
            this.chkFp3 = new System.Windows.Forms.CheckBox();
            this.chkFp5 = new System.Windows.Forms.CheckBox();
            this.chkFp4 = new System.Windows.Forms.CheckBox();
            this.chkFp2 = new System.Windows.Forms.CheckBox();
            this.chkFp1 = new System.Windows.Forms.CheckBox();
            this.pnlUSBand = new System.Windows.Forms.Panel();
            this.cbFp50 = new System.Windows.Forms.CheckBox();
            this.cbbFreqModeUS = new System.Windows.Forms.ComboBox();
            this.cbFp49 = new System.Windows.Forms.CheckBox();
            this.cbbFreqPointUS = new System.Windows.Forms.ComboBox();
            this.cbFp48 = new System.Windows.Forms.CheckBox();
            this.labFreq = new System.Windows.Forms.Label();
            this.cbFp47 = new System.Windows.Forms.CheckBox();
            this.cbFp1 = new System.Windows.Forms.CheckBox();
            this.cbFp46 = new System.Windows.Forms.CheckBox();
            this.cbFp2 = new System.Windows.Forms.CheckBox();
            this.cbFp45 = new System.Windows.Forms.CheckBox();
            this.cbFp3 = new System.Windows.Forms.CheckBox();
            this.cbFp44 = new System.Windows.Forms.CheckBox();
            this.cbFp4 = new System.Windows.Forms.CheckBox();
            this.cbFp43 = new System.Windows.Forms.CheckBox();
            this.cbFp5 = new System.Windows.Forms.CheckBox();
            this.cbFp42 = new System.Windows.Forms.CheckBox();
            this.cbFp6 = new System.Windows.Forms.CheckBox();
            this.cbFp41 = new System.Windows.Forms.CheckBox();
            this.cbFp7 = new System.Windows.Forms.CheckBox();
            this.cbFp8 = new System.Windows.Forms.CheckBox();
            this.cbFp40 = new System.Windows.Forms.CheckBox();
            this.cbFp9 = new System.Windows.Forms.CheckBox();
            this.cbFp39 = new System.Windows.Forms.CheckBox();
            this.cbFp10 = new System.Windows.Forms.CheckBox();
            this.cbFp38 = new System.Windows.Forms.CheckBox();
            this.cbFp11 = new System.Windows.Forms.CheckBox();
            this.cbFp37 = new System.Windows.Forms.CheckBox();
            this.cbFp12 = new System.Windows.Forms.CheckBox();
            this.cbFp36 = new System.Windows.Forms.CheckBox();
            this.cbFp13 = new System.Windows.Forms.CheckBox();
            this.cbFp35 = new System.Windows.Forms.CheckBox();
            this.cbFp14 = new System.Windows.Forms.CheckBox();
            this.cbFp34 = new System.Windows.Forms.CheckBox();
            this.cbFp15 = new System.Windows.Forms.CheckBox();
            this.cbFp33 = new System.Windows.Forms.CheckBox();
            this.cbFp16 = new System.Windows.Forms.CheckBox();
            this.cbFp32 = new System.Windows.Forms.CheckBox();
            this.cbFp17 = new System.Windows.Forms.CheckBox();
            this.cbFp31 = new System.Windows.Forms.CheckBox();
            this.cbFp18 = new System.Windows.Forms.CheckBox();
            this.cbFp30 = new System.Windows.Forms.CheckBox();
            this.cbFp19 = new System.Windows.Forms.CheckBox();
            this.cbFp29 = new System.Windows.Forms.CheckBox();
            this.cbFp20 = new System.Windows.Forms.CheckBox();
            this.cbFp28 = new System.Windows.Forms.CheckBox();
            this.cbFp21 = new System.Windows.Forms.CheckBox();
            this.cbFp27 = new System.Windows.Forms.CheckBox();
            this.cbFp22 = new System.Windows.Forms.CheckBox();
            this.cbFp26 = new System.Windows.Forms.CheckBox();
            this.cbFp23 = new System.Windows.Forms.CheckBox();
            this.cbFp25 = new System.Windows.Forms.CheckBox();
            this.cbFp24 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labDelayUnit = new System.Windows.Forms.Label();
            this.btnClearFreq = new System.Windows.Forms.Button();
            this.btnDefaultFreq = new System.Windows.Forms.Button();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.btnReadFreq = new System.Windows.Forms.Button();
            this.cboBand = new System.Windows.Forms.ComboBox();
            this.cbbSingOrMulti = new System.Windows.Forms.ComboBox();
            this.labSingleOrMulti = new System.Windows.Forms.Label();
            this.labTrigParam = new System.Windows.Forms.Label();
            this.labPower = new System.Windows.Forms.Label();
            this.tbPower = new System.Windows.Forms.TextBox();
            this.labSetParam = new System.Windows.Forms.Label();
            this.btnSetFreq = new System.Windows.Forms.Button();
            this.labDevNo = new System.Windows.Forms.Label();
            this.tbNewDevNo = new System.Windows.Forms.TextBox();
            this.gbCommModeParam = new System.Windows.Forms.GroupBox();
            this.btnDefaultCommMode = new System.Windows.Forms.Button();
            this.btnReadCommMode = new System.Windows.Forms.Button();
            this.labPulseCycleUnit = new System.Windows.Forms.Label();
            this.btnSetCommMode = new System.Windows.Forms.Button();
            this.labPulseWidthUnit = new System.Windows.Forms.Label();
            this.tbPulseCycle = new System.Windows.Forms.TextBox();
            this.tbPulseWidth = new System.Windows.Forms.TextBox();
            this.lblWigginsTakePlaceValue = new System.Windows.Forms.Label();
            this.labWiegandProtocol = new System.Windows.Forms.Label();
            this.cboWigginsTakePlaceValue = new System.Windows.Forms.ComboBox();
            this.cbbWiegandProtocol = new System.Windows.Forms.ComboBox();
            this.labPulseCycle = new System.Windows.Forms.Label();
            this.labPulseWidth = new System.Windows.Forms.Label();
            this.cbbCommMode = new System.Windows.Forms.ComboBox();
            this.labCommMode = new System.Windows.Forms.Label();
            this.gbWorkMode = new System.Windows.Forms.GroupBox();
            this.cboReadSpeed = new System.Windows.Forms.ComboBox();
            this.cbAjaDisc = new System.Windows.Forms.CheckBox();
            this.btnDefaultWorkMode = new System.Windows.Forms.Button();
            this.btnReadWorkMode = new System.Windows.Forms.Button();
            this.labTimingUnit = new System.Windows.Forms.Label();
            this.tbTiming = new System.Windows.Forms.TextBox();
            this.cbbWorkMode = new System.Windows.Forms.ComboBox();
            this.cbbTrigSwitch = new System.Windows.Forms.ComboBox();
            this.labTrigSwitch = new System.Windows.Forms.Label();
            this.labTimingParam = new System.Windows.Forms.Label();
            this.labWorkMode = new System.Windows.Forms.Label();
            this.btnSetWorkMode = new System.Windows.Forms.Button();
            this.tbNeighJudge = new System.Windows.Forms.TextBox();
            this.OtherOpreation = new System.Windows.Forms.TabPage();
            this.GopRelayControl = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoOpenRelay = new System.Windows.Forms.RadioButton();
            this.rdoCloseRelay = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoOpen1 = new System.Windows.Forms.RadioButton();
            this.rdoClose1 = new System.Windows.Forms.RadioButton();
            this.lblCloseTime = new System.Windows.Forms.Label();
            this.cbbRelayTime = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoOpen2 = new System.Windows.Forms.RadioButton();
            this.rdoClose2 = new System.Windows.Forms.RadioButton();
            this.btnReadRelayTime = new System.Windows.Forms.Button();
            this.btnSetRelayTime = new System.Windows.Forms.Button();
            this.gbTagAuth = new System.Windows.Forms.GroupBox();
            this.labNewAuthPwd = new System.Windows.Forms.Label();
            this.labAuthPwd = new System.Windows.Forms.Label();
            this.tbNewAuthPwd = new System.Windows.Forms.TextBox();
            this.tbAuthPwd = new System.Windows.Forms.TextBox();
            this.btnTagAuth = new System.Windows.Forms.Button();
            this.btnModifyAuthPwd = new System.Windows.Forms.Button();
            this.gbUsbFormat = new System.Windows.Forms.GroupBox();
            this.btnSetUsbFormat = new System.Windows.Forms.Button();
            this.cbbUsbFormat = new System.Windows.Forms.ComboBox();
            this.gbBeepControl = new System.Windows.Forms.GroupBox();
            this.lblReadVoice = new System.Windows.Forms.Label();
            this.btnReadBeep = new System.Windows.Forms.Button();
            this.btnSetBeep = new System.Windows.Forms.Button();
            this.cbbBeepControl = new System.Windows.Forms.ComboBox();
            this.timerConnect = new System.Windows.Forms.Timer(this.components);
            this.cbbLangSwitch = new System.Windows.Forms.ComboBox();
            this.listView = new DisDemo.ListViewNF();
            this.tabControl.SuspendLayout();
            this.General.SuspendLayout();
            this.gbReadMode.SuspendLayout();
            this.gbCommMode.SuspendLayout();
            this.TagAccess.SuspendLayout();
            this.gbFastWrite.SuspendLayout();
            this.gbAdvancedOpr.SuspendLayout();
            this.gbRWData.SuspendLayout();
            this.SetCommParam.SuspendLayout();
            this.gbSPParams.SuspendLayout();
            this.gbNetParams.SuspendLayout();
            this.SetReaderParam.SuspendLayout();
            this.gbFreq.SuspendLayout();
            this.pnlEUBand.SuspendLayout();
            this.pnlUSBand.SuspendLayout();
            this.gbCommModeParam.SuspendLayout();
            this.gbWorkMode.SuspendLayout();
            this.OtherOpreation.SuspendLayout();
            this.GopRelayControl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbTagAuth.SuspendLayout();
            this.gbUsbFormat.SuspendLayout();
            this.gbBeepControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.General);
            this.tabControl.Controls.Add(this.TagAccess);
            this.tabControl.Controls.Add(this.SetCommParam);
            this.tabControl.Controls.Add(this.SetReaderParam);
            this.tabControl.Controls.Add(this.OtherOpreation);
            this.tabControl.Location = new System.Drawing.Point(4, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(806, 468);
            this.tabControl.TabIndex = 0;
            // 
            // General
            // 
            this.General.Controls.Add(this.cbSaveFile);
            this.General.Controls.Add(this.gbReadMode);
            this.General.Controls.Add(this.labelCount);
            this.General.Controls.Add(this.labelTagCount);
            this.General.Controls.Add(this.labReadCount);
            this.General.Controls.Add(this.labTagCount);
            this.General.Controls.Add(this.gbCommMode);
            this.General.Controls.Add(this.rbDesc);
            this.General.Controls.Add(this.rbAsc);
            this.General.Controls.Add(this.labelVersion);
            this.General.Controls.Add(this.btnClearListView);
            this.General.Controls.Add(this.btnStopReadData);
            this.General.Controls.Add(this.btnStartReadData);
            this.General.Controls.Add(this.btnReadOnce);
            this.General.Controls.Add(this.listView);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(798, 442);
            this.General.TabIndex = 0;
            this.General.Text = "基本操作";
            this.General.UseVisualStyleBackColor = true;
            // 
            // cbSaveFile
            // 
            this.cbSaveFile.AutoSize = true;
            this.cbSaveFile.Location = new System.Drawing.Point(683, 359);
            this.cbSaveFile.Name = "cbSaveFile";
            this.cbSaveFile.Size = new System.Drawing.Size(108, 16);
            this.cbSaveFile.TabIndex = 41;
            this.cbSaveFile.Text = "自动保存为文件";
            this.cbSaveFile.UseVisualStyleBackColor = true;
            // 
            // gbReadMode
            // 
            this.gbReadMode.Controls.Add(this.rbReadMultiTag);
            this.gbReadMode.Controls.Add(this.rbReadSingleTag);
            this.gbReadMode.Location = new System.Drawing.Point(16, 270);
            this.gbReadMode.Name = "gbReadMode";
            this.gbReadMode.Size = new System.Drawing.Size(227, 81);
            this.gbReadMode.TabIndex = 40;
            this.gbReadMode.TabStop = false;
            this.gbReadMode.Text = "读卡模式";
            // 
            // rbReadMultiTag
            // 
            this.rbReadMultiTag.AutoSize = true;
            this.rbReadMultiTag.Location = new System.Drawing.Point(117, 36);
            this.rbReadMultiTag.Name = "rbReadMultiTag";
            this.rbReadMultiTag.Size = new System.Drawing.Size(71, 16);
            this.rbReadMultiTag.TabIndex = 39;
            this.rbReadMultiTag.TabStop = true;
            this.rbReadMultiTag.Text = "连续读卡";
            this.rbReadMultiTag.UseVisualStyleBackColor = true;
            this.rbReadMultiTag.CheckedChanged += new System.EventHandler(this.rbReadMultiTag_CheckedChanged);
            // 
            // rbReadSingleTag
            // 
            this.rbReadSingleTag.AutoSize = true;
            this.rbReadSingleTag.Location = new System.Drawing.Point(25, 36);
            this.rbReadSingleTag.Name = "rbReadSingleTag";
            this.rbReadSingleTag.Size = new System.Drawing.Size(71, 16);
            this.rbReadSingleTag.TabIndex = 38;
            this.rbReadSingleTag.TabStop = true;
            this.rbReadSingleTag.Text = "单卡识别";
            this.rbReadSingleTag.UseVisualStyleBackColor = true;
            this.rbReadSingleTag.CheckedChanged += new System.EventHandler(this.rbReadSingleTag_CheckedChanged);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(710, 25);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(11, 12);
            this.labelCount.TabIndex = 37;
            this.labelCount.Text = "0";
            // 
            // labelTagCount
            // 
            this.labelTagCount.AutoSize = true;
            this.labelTagCount.Location = new System.Drawing.Point(388, 26);
            this.labelTagCount.Name = "labelTagCount";
            this.labelTagCount.Size = new System.Drawing.Size(11, 12);
            this.labelTagCount.TabIndex = 36;
            this.labelTagCount.Text = "0";
            // 
            // labReadCount
            // 
            this.labReadCount.AutoEllipsis = true;
            this.labReadCount.Location = new System.Drawing.Point(584, 25);
            this.labReadCount.Name = "labReadCount";
            this.labReadCount.Size = new System.Drawing.Size(117, 12);
            this.labReadCount.TabIndex = 35;
            this.labReadCount.Text = "读取次数:";
            this.labReadCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labTagCount
            // 
            this.labTagCount.AutoEllipsis = true;
            this.labTagCount.Location = new System.Drawing.Point(256, 25);
            this.labTagCount.Name = "labTagCount";
            this.labTagCount.Size = new System.Drawing.Size(125, 12);
            this.labTagCount.TabIndex = 34;
            this.labTagCount.Text = "标签数:";
            this.labTagCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbCommMode
            // 
            this.gbCommMode.Controls.Add(this.labDeviceNo);
            this.gbCommMode.Controls.Add(this.tbDeviceNo);
            this.gbCommMode.Controls.Add(this.rbNet);
            this.gbCommMode.Controls.Add(this.rbSerialPort);
            this.gbCommMode.Controls.Add(this.comboBoxSerialCommPort);
            this.gbCommMode.Controls.Add(this.btnUpdate);
            this.gbCommMode.Controls.Add(this.btnDisconnect);
            this.gbCommMode.Controls.Add(this.btnConnect);
            this.gbCommMode.Controls.Add(this.labCommPort);
            this.gbCommMode.Controls.Add(this.textBoxPort);
            this.gbCommMode.Controls.Add(this.comboBoxIP);
            this.gbCommMode.Location = new System.Drawing.Point(16, 40);
            this.gbCommMode.Name = "gbCommMode";
            this.gbCommMode.Size = new System.Drawing.Size(228, 218);
            this.gbCommMode.TabIndex = 33;
            this.gbCommMode.TabStop = false;
            this.gbCommMode.Text = "通信方式";
            // 
            // labDeviceNo
            // 
            this.labDeviceNo.AutoSize = true;
            this.labDeviceNo.Location = new System.Drawing.Point(33, 138);
            this.labDeviceNo.Name = "labDeviceNo";
            this.labDeviceNo.Size = new System.Drawing.Size(41, 12);
            this.labDeviceNo.TabIndex = 31;
            this.labDeviceNo.Text = "设备号";
            // 
            // tbDeviceNo
            // 
            this.tbDeviceNo.Location = new System.Drawing.Point(98, 135);
            this.tbDeviceNo.Name = "tbDeviceNo";
            this.tbDeviceNo.Size = new System.Drawing.Size(55, 21);
            this.tbDeviceNo.TabIndex = 30;
            this.tbDeviceNo.Text = "0";
            // 
            // rbNet
            // 
            this.rbNet.AutoSize = true;
            this.rbNet.Location = new System.Drawing.Point(139, 26);
            this.rbNet.Name = "rbNet";
            this.rbNet.Size = new System.Drawing.Size(47, 16);
            this.rbNet.TabIndex = 29;
            this.rbNet.TabStop = true;
            this.rbNet.Text = "网络";
            this.rbNet.UseVisualStyleBackColor = true;
            this.rbNet.CheckedChanged += new System.EventHandler(this.radioButtonNet_CheckedChanged);
            // 
            // rbSerialPort
            // 
            this.rbSerialPort.AutoSize = true;
            this.rbSerialPort.Location = new System.Drawing.Point(26, 26);
            this.rbSerialPort.Name = "rbSerialPort";
            this.rbSerialPort.Size = new System.Drawing.Size(47, 16);
            this.rbSerialPort.TabIndex = 28;
            this.rbSerialPort.TabStop = true;
            this.rbSerialPort.Text = "串口";
            this.rbSerialPort.UseVisualStyleBackColor = true;
            this.rbSerialPort.CheckedChanged += new System.EventHandler(this.radioButtonSP_CheckedChanged);
            // 
            // comboBoxSerialCommPort
            // 
            this.comboBoxSerialCommPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialCommPort.FormattingEnabled = true;
            this.comboBoxSerialCommPort.Location = new System.Drawing.Point(26, 67);
            this.comboBoxSerialCommPort.Name = "comboBoxSerialCommPort";
            this.comboBoxSerialCommPort.Size = new System.Drawing.Size(112, 20);
            this.comboBoxSerialCommPort.TabIndex = 24;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(149, 62);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 29);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "刷新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(126, 178);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(85, 29);
            this.btnDisconnect.TabIndex = 9;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(17, 178);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 29);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labCommPort
            // 
            this.labCommPort.AutoSize = true;
            this.labCommPort.Location = new System.Drawing.Point(32, 88);
            this.labCommPort.Name = "labCommPort";
            this.labCommPort.Size = new System.Drawing.Size(41, 12);
            this.labCommPort.TabIndex = 7;
            this.labCommPort.Text = "端口号";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(75, 84);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(66, 21);
            this.textBoxPort.TabIndex = 6;
            // 
            // comboBoxIP
            // 
            this.comboBoxIP.FormattingEnabled = true;
            this.comboBoxIP.Location = new System.Drawing.Point(29, 54);
            this.comboBoxIP.Name = "comboBoxIP";
            this.comboBoxIP.Size = new System.Drawing.Size(112, 20);
            this.comboBoxIP.TabIndex = 5;
            // 
            // rbDesc
            // 
            this.rbDesc.AutoSize = true;
            this.rbDesc.Location = new System.Drawing.Point(334, 358);
            this.rbDesc.Name = "rbDesc";
            this.rbDesc.Size = new System.Drawing.Size(47, 16);
            this.rbDesc.TabIndex = 32;
            this.rbDesc.TabStop = true;
            this.rbDesc.Text = "降序";
            this.rbDesc.UseVisualStyleBackColor = true;
            this.rbDesc.CheckedChanged += new System.EventHandler(this.radioButtonDesc_CheckedChanged);
            // 
            // rbAsc
            // 
            this.rbAsc.AutoSize = true;
            this.rbAsc.Location = new System.Drawing.Point(256, 357);
            this.rbAsc.Name = "rbAsc";
            this.rbAsc.Size = new System.Drawing.Size(47, 16);
            this.rbAsc.TabIndex = 31;
            this.rbAsc.TabStop = true;
            this.rbAsc.Text = "升序";
            this.rbAsc.UseVisualStyleBackColor = true;
            this.rbAsc.CheckedChanged += new System.EventHandler(this.radioButtonAsc_CheckedChanged);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(41, 408);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 12);
            this.labelVersion.TabIndex = 30;
            // 
            // btnClearListView
            // 
            this.btnClearListView.Location = new System.Drawing.Point(691, 389);
            this.btnClearListView.Name = "btnClearListView";
            this.btnClearListView.Size = new System.Drawing.Size(93, 38);
            this.btnClearListView.TabIndex = 4;
            this.btnClearListView.Text = "清空";
            this.btnClearListView.UseVisualStyleBackColor = true;
            this.btnClearListView.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStopReadData
            // 
            this.btnStopReadData.Location = new System.Drawing.Point(545, 389);
            this.btnStopReadData.Name = "btnStopReadData";
            this.btnStopReadData.Size = new System.Drawing.Size(93, 38);
            this.btnStopReadData.TabIndex = 3;
            this.btnStopReadData.Text = "停止连续寻卡";
            this.btnStopReadData.UseVisualStyleBackColor = true;
            this.btnStopReadData.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStartReadData
            // 
            this.btnStartReadData.Location = new System.Drawing.Point(401, 389);
            this.btnStartReadData.Name = "btnStartReadData";
            this.btnStartReadData.Size = new System.Drawing.Size(93, 38);
            this.btnStartReadData.TabIndex = 2;
            this.btnStartReadData.Text = "开始连续寻卡";
            this.btnStartReadData.UseVisualStyleBackColor = true;
            this.btnStartReadData.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReadOnce
            // 
            this.btnReadOnce.Location = new System.Drawing.Point(256, 389);
            this.btnReadOnce.Name = "btnReadOnce";
            this.btnReadOnce.Size = new System.Drawing.Size(93, 38);
            this.btnReadOnce.TabIndex = 1;
            this.btnReadOnce.Text = "寻卡一次";
            this.btnReadOnce.UseVisualStyleBackColor = true;
            this.btnReadOnce.Click += new System.EventHandler(this.btnReadOnce_Click);
            // 
            // TagAccess
            // 
            this.TagAccess.Controls.Add(this.gbFastWrite);
            this.TagAccess.Controls.Add(this.labResult);
            this.TagAccess.Controls.Add(this.gbAdvancedOpr);
            this.TagAccess.Controls.Add(this.gbRWData);
            this.TagAccess.Location = new System.Drawing.Point(4, 22);
            this.TagAccess.Name = "TagAccess";
            this.TagAccess.Padding = new System.Windows.Forms.Padding(3);
            this.TagAccess.Size = new System.Drawing.Size(798, 442);
            this.TagAccess.TabIndex = 1;
            this.TagAccess.Text = "标签访问";
            this.TagAccess.UseVisualStyleBackColor = true;
            // 
            // gbFastWrite
            // 
            this.gbFastWrite.Controls.Add(this.chkZD);
            this.gbFastWrite.Controls.Add(this.labFWPromo);
            this.gbFastWrite.Controls.Add(this.btnClearFWData);
            this.gbFastWrite.Controls.Add(this.btnFastWrite);
            this.gbFastWrite.Controls.Add(this.labFWData);
            this.gbFastWrite.Controls.Add(this.tbFWData);
            this.gbFastWrite.Location = new System.Drawing.Point(74, 10);
            this.gbFastWrite.Name = "gbFastWrite";
            this.gbFastWrite.Size = new System.Drawing.Size(651, 98);
            this.gbFastWrite.TabIndex = 27;
            this.gbFastWrite.TabStop = false;
            this.gbFastWrite.Text = "快写";
            // 
            // chkZD
            // 
            this.chkZD.Location = new System.Drawing.Point(438, 49);
            this.chkZD.Name = "chkZD";
            this.chkZD.Size = new System.Drawing.Size(92, 34);
            this.chkZD.TabIndex = 5;
            this.chkZD.Text = "自动增1";
            this.chkZD.UseVisualStyleBackColor = true;
            // 
            // labFWPromo
            // 
            this.labFWPromo.AutoSize = true;
            this.labFWPromo.Location = new System.Drawing.Point(30, 20);
            this.labFWPromo.Name = "labFWPromo";
            this.labFWPromo.Size = new System.Drawing.Size(77, 12);
            this.labFWPromo.TabIndex = 4;
            this.labFWPromo.Text = "数据有效提示";
            // 
            // btnClearFWData
            // 
            this.btnClearFWData.Location = new System.Drawing.Point(536, 55);
            this.btnClearFWData.Name = "btnClearFWData";
            this.btnClearFWData.Size = new System.Drawing.Size(83, 27);
            this.btnClearFWData.TabIndex = 3;
            this.btnClearFWData.Text = "清空";
            this.btnClearFWData.UseVisualStyleBackColor = true;
            this.btnClearFWData.Click += new System.EventHandler(this.btnClearFWData_Click);
            // 
            // btnFastWrite
            // 
            this.btnFastWrite.Location = new System.Drawing.Point(536, 20);
            this.btnFastWrite.Name = "btnFastWrite";
            this.btnFastWrite.Size = new System.Drawing.Size(83, 27);
            this.btnFastWrite.TabIndex = 2;
            this.btnFastWrite.Text = "快写";
            this.btnFastWrite.UseVisualStyleBackColor = true;
            this.btnFastWrite.Click += new System.EventHandler(this.btnFastWrite_Click);
            // 
            // labFWData
            // 
            this.labFWData.AutoSize = true;
            this.labFWData.Location = new System.Drawing.Point(30, 53);
            this.labFWData.Name = "labFWData";
            this.labFWData.Size = new System.Drawing.Size(29, 12);
            this.labFWData.TabIndex = 1;
            this.labFWData.Text = "数据";
            // 
            // tbFWData
            // 
            this.tbFWData.Location = new System.Drawing.Point(99, 50);
            this.tbFWData.Multiline = true;
            this.tbFWData.Name = "tbFWData";
            this.tbFWData.Size = new System.Drawing.Size(335, 32);
            this.tbFWData.TabIndex = 0;
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(71, 413);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(0, 12);
            this.labResult.TabIndex = 26;
            // 
            // gbAdvancedOpr
            // 
            this.gbAdvancedOpr.Controls.Add(this.btnInitTag);
            this.gbAdvancedOpr.Controls.Add(this.btnUnlockTag);
            this.gbAdvancedOpr.Controls.Add(this.btnLockTag);
            this.gbAdvancedOpr.Controls.Add(this.btnKillTag);
            this.gbAdvancedOpr.Controls.Add(this.labLockBank);
            this.gbAdvancedOpr.Controls.Add(this.labLockAccessPwd);
            this.gbAdvancedOpr.Controls.Add(this.labDestroyPwd);
            this.gbAdvancedOpr.Controls.Add(this.tbLockAccessPwd);
            this.gbAdvancedOpr.Controls.Add(this.tbKillKillPwd);
            this.gbAdvancedOpr.Controls.Add(this.cbbLockBank);
            this.gbAdvancedOpr.Location = new System.Drawing.Point(74, 266);
            this.gbAdvancedOpr.Name = "gbAdvancedOpr";
            this.gbAdvancedOpr.Size = new System.Drawing.Size(651, 135);
            this.gbAdvancedOpr.TabIndex = 25;
            this.gbAdvancedOpr.TabStop = false;
            this.gbAdvancedOpr.Text = "高级操作";
            // 
            // btnInitTag
            // 
            this.btnInitTag.Location = new System.Drawing.Point(447, 32);
            this.btnInitTag.Name = "btnInitTag";
            this.btnInitTag.Size = new System.Drawing.Size(83, 27);
            this.btnInitTag.TabIndex = 26;
            this.btnInitTag.Text = "初始化";
            this.btnInitTag.UseVisualStyleBackColor = true;
            this.btnInitTag.Click += new System.EventHandler(this.btnInitTag_Click);
            // 
            // btnUnlockTag
            // 
            this.btnUnlockTag.Location = new System.Drawing.Point(536, 76);
            this.btnUnlockTag.Name = "btnUnlockTag";
            this.btnUnlockTag.Size = new System.Drawing.Size(83, 27);
            this.btnUnlockTag.TabIndex = 25;
            this.btnUnlockTag.Text = "解锁";
            this.btnUnlockTag.UseVisualStyleBackColor = true;
            this.btnUnlockTag.Click += new System.EventHandler(this.btnUnlockTag_Click);
            // 
            // btnLockTag
            // 
            this.btnLockTag.Location = new System.Drawing.Point(536, 32);
            this.btnLockTag.Name = "btnLockTag";
            this.btnLockTag.Size = new System.Drawing.Size(83, 27);
            this.btnLockTag.TabIndex = 20;
            this.btnLockTag.Text = "锁定";
            this.btnLockTag.UseVisualStyleBackColor = true;
            this.btnLockTag.Click += new System.EventHandler(this.btnLockTag_Click);
            // 
            // btnKillTag
            // 
            this.btnKillTag.Location = new System.Drawing.Point(447, 76);
            this.btnKillTag.Name = "btnKillTag";
            this.btnKillTag.Size = new System.Drawing.Size(83, 27);
            this.btnKillTag.TabIndex = 21;
            this.btnKillTag.Text = "销毁";
            this.btnKillTag.UseVisualStyleBackColor = true;
            this.btnKillTag.Click += new System.EventHandler(this.btnKillTag_Click);
            // 
            // labLockBank
            // 
            this.labLockBank.AutoEllipsis = true;
            this.labLockBank.Location = new System.Drawing.Point(205, 39);
            this.labLockBank.Name = "labLockBank";
            this.labLockBank.Size = new System.Drawing.Size(116, 35);
            this.labLockBank.TabIndex = 17;
            this.labLockBank.Text = "操作区域";
            // 
            // labLockAccessPwd
            // 
            this.labLockAccessPwd.AutoEllipsis = true;
            this.labLockAccessPwd.Location = new System.Drawing.Point(30, 39);
            this.labLockAccessPwd.Name = "labLockAccessPwd";
            this.labLockAccessPwd.Size = new System.Drawing.Size(53, 35);
            this.labLockAccessPwd.TabIndex = 16;
            this.labLockAccessPwd.Text = "访问密码";
            // 
            // labDestroyPwd
            // 
            this.labDestroyPwd.AutoEllipsis = true;
            this.labDestroyPwd.Location = new System.Drawing.Point(30, 83);
            this.labDestroyPwd.Name = "labDestroyPwd";
            this.labDestroyPwd.Size = new System.Drawing.Size(53, 49);
            this.labDestroyPwd.TabIndex = 24;
            this.labDestroyPwd.Text = "注销密码";
            // 
            // tbLockAccessPwd
            // 
            this.tbLockAccessPwd.Location = new System.Drawing.Point(99, 36);
            this.tbLockAccessPwd.Name = "tbLockAccessPwd";
            this.tbLockAccessPwd.Size = new System.Drawing.Size(100, 21);
            this.tbLockAccessPwd.TabIndex = 15;
            // 
            // tbKillKillPwd
            // 
            this.tbKillKillPwd.Location = new System.Drawing.Point(99, 80);
            this.tbKillKillPwd.Name = "tbKillKillPwd";
            this.tbKillKillPwd.Size = new System.Drawing.Size(100, 21);
            this.tbKillKillPwd.TabIndex = 23;
            // 
            // cbbLockBank
            // 
            this.cbbLockBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLockBank.FormattingEnabled = true;
            this.cbbLockBank.Location = new System.Drawing.Point(334, 36);
            this.cbbLockBank.Name = "cbbLockBank";
            this.cbbLockBank.Size = new System.Drawing.Size(100, 20);
            this.cbbLockBank.TabIndex = 3;
            // 
            // gbRWData
            // 
            this.gbRWData.Controls.Add(this.labData);
            this.gbRWData.Controls.Add(this.labLength);
            this.gbRWData.Controls.Add(this.labStartAdd);
            this.gbRWData.Controls.Add(this.labOprBank);
            this.gbRWData.Controls.Add(this.btnWriteData);
            this.gbRWData.Controls.Add(this.btnClearData);
            this.gbRWData.Controls.Add(this.btnReadData);
            this.gbRWData.Controls.Add(this.tbRWData);
            this.gbRWData.Controls.Add(this.cbbLength);
            this.gbRWData.Controls.Add(this.cbbStartAdd);
            this.gbRWData.Controls.Add(this.cbbRWBank);
            this.gbRWData.Location = new System.Drawing.Point(73, 112);
            this.gbRWData.Name = "gbRWData";
            this.gbRWData.Size = new System.Drawing.Size(652, 152);
            this.gbRWData.TabIndex = 21;
            this.gbRWData.TabStop = false;
            this.gbRWData.Text = "读/写数据";
            // 
            // labData
            // 
            this.labData.AutoSize = true;
            this.labData.Location = new System.Drawing.Point(31, 86);
            this.labData.Name = "labData";
            this.labData.Size = new System.Drawing.Size(29, 12);
            this.labData.TabIndex = 13;
            this.labData.Text = "数据";
            // 
            // labLength
            // 
            this.labLength.AutoEllipsis = true;
            this.labLength.Location = new System.Drawing.Point(375, 36);
            this.labLength.Name = "labLength";
            this.labLength.Size = new System.Drawing.Size(29, 40);
            this.labLength.TabIndex = 12;
            this.labLength.Text = "长度";
            // 
            // labStartAdd
            // 
            this.labStartAdd.AutoEllipsis = true;
            this.labStartAdd.Location = new System.Drawing.Point(201, 35);
            this.labStartAdd.Name = "labStartAdd";
            this.labStartAdd.Size = new System.Drawing.Size(53, 41);
            this.labStartAdd.TabIndex = 11;
            this.labStartAdd.Text = "起始地址";
            // 
            // labOprBank
            // 
            this.labOprBank.AutoEllipsis = true;
            this.labOprBank.Location = new System.Drawing.Point(27, 36);
            this.labOprBank.Name = "labOprBank";
            this.labOprBank.Size = new System.Drawing.Size(53, 40);
            this.labOprBank.TabIndex = 10;
            this.labOprBank.Text = "操作区域";
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(537, 107);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(83, 27);
            this.btnWriteData.TabIndex = 8;
            this.btnWriteData.Text = "写入";
            this.btnWriteData.UseVisualStyleBackColor = true;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(537, 69);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(83, 27);
            this.btnClearData.TabIndex = 7;
            this.btnClearData.Text = "清空";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(537, 29);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(83, 27);
            this.btnReadData.TabIndex = 6;
            this.btnReadData.Text = "读取";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // tbRWData
            // 
            this.tbRWData.Location = new System.Drawing.Point(100, 85);
            this.tbRWData.Multiline = true;
            this.tbRWData.Name = "tbRWData";
            this.tbRWData.Size = new System.Drawing.Size(404, 36);
            this.tbRWData.TabIndex = 5;
            // 
            // cbbLength
            // 
            this.cbbLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLength.FormattingEnabled = true;
            this.cbbLength.Location = new System.Drawing.Point(421, 32);
            this.cbbLength.Name = "cbbLength";
            this.cbbLength.Size = new System.Drawing.Size(88, 20);
            this.cbbLength.TabIndex = 2;
            // 
            // cbbStartAdd
            // 
            this.cbbStartAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStartAdd.FormattingEnabled = true;
            this.cbbStartAdd.Location = new System.Drawing.Point(271, 32);
            this.cbbStartAdd.Name = "cbbStartAdd";
            this.cbbStartAdd.Size = new System.Drawing.Size(88, 20);
            this.cbbStartAdd.TabIndex = 1;
            this.cbbStartAdd.SelectedIndexChanged += new System.EventHandler(this.cbbStartAdd_SelectedIndexChanged);
            // 
            // cbbRWBank
            // 
            this.cbbRWBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRWBank.FormattingEnabled = true;
            this.cbbRWBank.Location = new System.Drawing.Point(100, 32);
            this.cbbRWBank.Name = "cbbRWBank";
            this.cbbRWBank.Size = new System.Drawing.Size(88, 20);
            this.cbbRWBank.TabIndex = 0;
            this.cbbRWBank.SelectedIndexChanged += new System.EventHandler(this.cbbRWBank_SelectedIndexChanged);
            // 
            // SetCommParam
            // 
            this.SetCommParam.Controls.Add(this.gbSPParams);
            this.SetCommParam.Controls.Add(this.gbNetParams);
            this.SetCommParam.Controls.Add(this.btnSetParams);
            this.SetCommParam.Controls.Add(this.btnDefaultParams);
            this.SetCommParam.Controls.Add(this.btnModifyDev);
            this.SetCommParam.Controls.Add(this.btnSearchDev);
            this.SetCommParam.Controls.Add(this.lvZl);
            this.SetCommParam.Location = new System.Drawing.Point(4, 22);
            this.SetCommParam.Name = "SetCommParam";
            this.SetCommParam.Padding = new System.Windows.Forms.Padding(3);
            this.SetCommParam.Size = new System.Drawing.Size(798, 442);
            this.SetCommParam.TabIndex = 2;
            this.SetCommParam.Text = "设置通信参数";
            this.SetCommParam.UseVisualStyleBackColor = true;
            this.SetCommParam.Enter += new System.EventHandler(this.SetCommParam_Enter);
            // 
            // gbSPParams
            // 
            this.gbSPParams.Controls.Add(this.labDataBits);
            this.gbSPParams.Controls.Add(this.labCheckBits);
            this.gbSPParams.Controls.Add(this.labBaudRate);
            this.gbSPParams.Controls.Add(this.comboBoxBaudRate);
            this.gbSPParams.Controls.Add(this.comboBoxCheckBits);
            this.gbSPParams.Controls.Add(this.comboBoxDataBits);
            this.gbSPParams.Location = new System.Drawing.Point(48, 310);
            this.gbSPParams.Name = "gbSPParams";
            this.gbSPParams.Size = new System.Drawing.Size(349, 114);
            this.gbSPParams.TabIndex = 28;
            this.gbSPParams.TabStop = false;
            this.gbSPParams.Text = "串口参数";
            // 
            // labDataBits
            // 
            this.labDataBits.AutoSize = true;
            this.labDataBits.Location = new System.Drawing.Point(17, 79);
            this.labDataBits.Name = "labDataBits";
            this.labDataBits.Size = new System.Drawing.Size(41, 12);
            this.labDataBits.TabIndex = 27;
            this.labDataBits.Text = "数据位";
            // 
            // labCheckBits
            // 
            this.labCheckBits.AutoSize = true;
            this.labCheckBits.Location = new System.Drawing.Point(205, 36);
            this.labCheckBits.Name = "labCheckBits";
            this.labCheckBits.Size = new System.Drawing.Size(41, 12);
            this.labCheckBits.TabIndex = 26;
            this.labCheckBits.Text = "校验位";
            // 
            // labBaudRate
            // 
            this.labBaudRate.AutoSize = true;
            this.labBaudRate.Location = new System.Drawing.Point(15, 36);
            this.labBaudRate.Name = "labBaudRate";
            this.labBaudRate.Size = new System.Drawing.Size(41, 12);
            this.labBaudRate.TabIndex = 25;
            this.labBaudRate.Text = "波特率";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(83, 33);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(74, 20);
            this.comboBoxBaudRate.TabIndex = 7;
            // 
            // comboBoxCheckBits
            // 
            this.comboBoxCheckBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheckBits.FormattingEnabled = true;
            this.comboBoxCheckBits.Location = new System.Drawing.Point(255, 33);
            this.comboBoxCheckBits.Name = "comboBoxCheckBits";
            this.comboBoxCheckBits.Size = new System.Drawing.Size(74, 20);
            this.comboBoxCheckBits.TabIndex = 6;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(82, 76);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(74, 20);
            this.comboBoxDataBits.TabIndex = 5;
            // 
            // gbNetParams
            // 
            this.gbNetParams.Controls.Add(this.labPromotion);
            this.gbNetParams.Controls.Add(this.labDestPort);
            this.gbNetParams.Controls.Add(this.labDestIP);
            this.gbNetParams.Controls.Add(this.labGateway);
            this.gbNetParams.Controls.Add(this.labPort);
            this.gbNetParams.Controls.Add(this.labMask);
            this.gbNetParams.Controls.Add(this.labIPAdd);
            this.gbNetParams.Controls.Add(this.labIPMode);
            this.gbNetParams.Controls.Add(this.labNetMode);
            this.gbNetParams.Controls.Add(this.textBoxDestPort);
            this.gbNetParams.Controls.Add(this.textBoxDestIP);
            this.gbNetParams.Controls.Add(this.textBoxGateway);
            this.gbNetParams.Controls.Add(this.textBoxPortNo);
            this.gbNetParams.Controls.Add(this.textBoxNetMask);
            this.gbNetParams.Controls.Add(this.textBoxIPAdd);
            this.gbNetParams.Controls.Add(this.comboBoxIPMode);
            this.gbNetParams.Controls.Add(this.comboBoxNetMode);
            this.gbNetParams.Location = new System.Drawing.Point(436, 15);
            this.gbNetParams.Name = "gbNetParams";
            this.gbNetParams.Size = new System.Drawing.Size(331, 369);
            this.gbNetParams.TabIndex = 25;
            this.gbNetParams.TabStop = false;
            this.gbNetParams.Text = "网络参数";
            // 
            // labPromotion
            // 
            this.labPromotion.AutoSize = true;
            this.labPromotion.Location = new System.Drawing.Point(46, 259);
            this.labPromotion.Name = "labPromotion";
            this.labPromotion.Size = new System.Drawing.Size(185, 12);
            this.labPromotion.TabIndex = 24;
            this.labPromotion.Text = "以下设置仅适用于TCP Client模式";
            // 
            // labDestPort
            // 
            this.labDestPort.AutoSize = true;
            this.labDestPort.Location = new System.Drawing.Point(48, 330);
            this.labDestPort.Name = "labDestPort";
            this.labDestPort.Size = new System.Drawing.Size(53, 12);
            this.labDestPort.TabIndex = 23;
            this.labDestPort.Text = "目的端口";
            // 
            // labDestIP
            // 
            this.labDestIP.AutoSize = true;
            this.labDestIP.Location = new System.Drawing.Point(49, 291);
            this.labDestIP.Name = "labDestIP";
            this.labDestIP.Size = new System.Drawing.Size(41, 12);
            this.labDestIP.TabIndex = 22;
            this.labDestIP.Text = "目的IP";
            // 
            // labGateway
            // 
            this.labGateway.AutoSize = true;
            this.labGateway.Location = new System.Drawing.Point(48, 219);
            this.labGateway.Name = "labGateway";
            this.labGateway.Size = new System.Drawing.Size(29, 12);
            this.labGateway.TabIndex = 21;
            this.labGateway.Text = "网关";
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(48, 178);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(41, 12);
            this.labPort.TabIndex = 20;
            this.labPort.Text = "端口号";
            // 
            // labMask
            // 
            this.labMask.AutoSize = true;
            this.labMask.Location = new System.Drawing.Point(48, 142);
            this.labMask.Name = "labMask";
            this.labMask.Size = new System.Drawing.Size(53, 12);
            this.labMask.TabIndex = 19;
            this.labMask.Text = "子网掩码";
            // 
            // labIPAdd
            // 
            this.labIPAdd.AutoSize = true;
            this.labIPAdd.Location = new System.Drawing.Point(48, 101);
            this.labIPAdd.Name = "labIPAdd";
            this.labIPAdd.Size = new System.Drawing.Size(41, 12);
            this.labIPAdd.TabIndex = 18;
            this.labIPAdd.Text = "IP地址";
            // 
            // labIPMode
            // 
            this.labIPMode.AutoSize = true;
            this.labIPMode.Location = new System.Drawing.Point(48, 66);
            this.labIPMode.Name = "labIPMode";
            this.labIPMode.Size = new System.Drawing.Size(41, 12);
            this.labIPMode.TabIndex = 17;
            this.labIPMode.Text = "IP模式";
            // 
            // labNetMode
            // 
            this.labNetMode.AutoSize = true;
            this.labNetMode.Location = new System.Drawing.Point(48, 31);
            this.labNetMode.Name = "labNetMode";
            this.labNetMode.Size = new System.Drawing.Size(53, 12);
            this.labNetMode.TabIndex = 16;
            this.labNetMode.Text = "工作模式";
            // 
            // textBoxDestPort
            // 
            this.textBoxDestPort.Location = new System.Drawing.Point(181, 327);
            this.textBoxDestPort.Name = "textBoxDestPort";
            this.textBoxDestPort.Size = new System.Drawing.Size(106, 21);
            this.textBoxDestPort.TabIndex = 13;
            // 
            // textBoxDestIP
            // 
            this.textBoxDestIP.Location = new System.Drawing.Point(181, 286);
            this.textBoxDestIP.Name = "textBoxDestIP";
            this.textBoxDestIP.Size = new System.Drawing.Size(106, 21);
            this.textBoxDestIP.TabIndex = 12;
            // 
            // textBoxGateway
            // 
            this.textBoxGateway.Location = new System.Drawing.Point(181, 215);
            this.textBoxGateway.Name = "textBoxGateway";
            this.textBoxGateway.Size = new System.Drawing.Size(106, 21);
            this.textBoxGateway.TabIndex = 11;
            // 
            // textBoxPortNo
            // 
            this.textBoxPortNo.Location = new System.Drawing.Point(181, 175);
            this.textBoxPortNo.Name = "textBoxPortNo";
            this.textBoxPortNo.Size = new System.Drawing.Size(106, 21);
            this.textBoxPortNo.TabIndex = 10;
            // 
            // textBoxNetMask
            // 
            this.textBoxNetMask.Location = new System.Drawing.Point(181, 138);
            this.textBoxNetMask.Name = "textBoxNetMask";
            this.textBoxNetMask.Size = new System.Drawing.Size(106, 21);
            this.textBoxNetMask.TabIndex = 9;
            // 
            // textBoxIPAdd
            // 
            this.textBoxIPAdd.Location = new System.Drawing.Point(181, 98);
            this.textBoxIPAdd.Name = "textBoxIPAdd";
            this.textBoxIPAdd.Size = new System.Drawing.Size(106, 21);
            this.textBoxIPAdd.TabIndex = 8;
            // 
            // comboBoxIPMode
            // 
            this.comboBoxIPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIPMode.FormattingEnabled = true;
            this.comboBoxIPMode.Location = new System.Drawing.Point(182, 63);
            this.comboBoxIPMode.Name = "comboBoxIPMode";
            this.comboBoxIPMode.Size = new System.Drawing.Size(106, 20);
            this.comboBoxIPMode.TabIndex = 4;
            // 
            // comboBoxNetMode
            // 
            this.comboBoxNetMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNetMode.FormattingEnabled = true;
            this.comboBoxNetMode.Location = new System.Drawing.Point(181, 28);
            this.comboBoxNetMode.Name = "comboBoxNetMode";
            this.comboBoxNetMode.Size = new System.Drawing.Size(106, 20);
            this.comboBoxNetMode.TabIndex = 3;
            // 
            // btnSetParams
            // 
            this.btnSetParams.Location = new System.Drawing.Point(631, 391);
            this.btnSetParams.Name = "btnSetParams";
            this.btnSetParams.Size = new System.Drawing.Size(100, 35);
            this.btnSetParams.TabIndex = 15;
            this.btnSetParams.Text = "设置参数";
            this.btnSetParams.UseVisualStyleBackColor = true;
            this.btnSetParams.Click += new System.EventHandler(this.btnSetParams_Click);
            // 
            // btnDefaultParams
            // 
            this.btnDefaultParams.Location = new System.Drawing.Point(477, 392);
            this.btnDefaultParams.Name = "btnDefaultParams";
            this.btnDefaultParams.Size = new System.Drawing.Size(100, 35);
            this.btnDefaultParams.TabIndex = 14;
            this.btnDefaultParams.Text = "默认参数";
            this.btnDefaultParams.UseVisualStyleBackColor = true;
            this.btnDefaultParams.Click += new System.EventHandler(this.btnDefaultParams_Click);
            // 
            // btnModifyDev
            // 
            this.btnModifyDev.Location = new System.Drawing.Point(251, 263);
            this.btnModifyDev.Name = "btnModifyDev";
            this.btnModifyDev.Size = new System.Drawing.Size(100, 35);
            this.btnModifyDev.TabIndex = 2;
            this.btnModifyDev.Text = "编辑设备";
            this.btnModifyDev.UseVisualStyleBackColor = true;
            this.btnModifyDev.Click += new System.EventHandler(this.btnModifyDev_Click);
            // 
            // btnSearchDev
            // 
            this.btnSearchDev.Location = new System.Drawing.Point(99, 263);
            this.btnSearchDev.Name = "btnSearchDev";
            this.btnSearchDev.Size = new System.Drawing.Size(100, 35);
            this.btnSearchDev.TabIndex = 1;
            this.btnSearchDev.Text = "搜索设备";
            this.btnSearchDev.UseVisualStyleBackColor = true;
            this.btnSearchDev.Click += new System.EventHandler(this.btnSearchDev_Click);
            // 
            // lvZl
            // 
            this.lvZl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNo,
            this.columnHeaderIPAdd,
            this.columnHeaderPort,
            this.columnHeaderMAC});
            this.lvZl.Location = new System.Drawing.Point(52, 22);
            this.lvZl.Name = "lvZl";
            this.lvZl.Size = new System.Drawing.Size(346, 220);
            this.lvZl.TabIndex = 0;
            this.lvZl.UseCompatibleStateImageBehavior = false;
            this.lvZl.View = System.Windows.Forms.View.Details;
            this.lvZl.ItemActivate += new System.EventHandler(this.listViewDev_ItemActivate);
            // 
            // columnHeaderNo
            // 
            this.columnHeaderNo.Text = "序号";
            // 
            // columnHeaderIPAdd
            // 
            this.columnHeaderIPAdd.Text = "IP地址";
            this.columnHeaderIPAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderIPAdd.Width = 120;
            // 
            // columnHeaderPort
            // 
            this.columnHeaderPort.Text = "端口";
            this.columnHeaderPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderMAC
            // 
            this.columnHeaderMAC.Text = "MAC地址";
            this.columnHeaderMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMAC.Width = 120;
            // 
            // SetReaderParam
            // 
            this.SetReaderParam.Controls.Add(this.gbFreq);
            this.SetReaderParam.Controls.Add(this.gbCommModeParam);
            this.SetReaderParam.Controls.Add(this.gbWorkMode);
            this.SetReaderParam.Location = new System.Drawing.Point(4, 22);
            this.SetReaderParam.Name = "SetReaderParam";
            this.SetReaderParam.Padding = new System.Windows.Forms.Padding(3);
            this.SetReaderParam.Size = new System.Drawing.Size(798, 442);
            this.SetReaderParam.TabIndex = 3;
            this.SetReaderParam.Text = "读写器参数";
            this.SetReaderParam.UseVisualStyleBackColor = true;
            this.SetReaderParam.Enter += new System.EventHandler(this.SetReaderParam_Enter);
            // 
            // gbFreq
            // 
            this.gbFreq.Controls.Add(this.pnlEUBand);
            this.gbFreq.Controls.Add(this.pnlUSBand);
            this.gbFreq.Controls.Add(this.label8);
            this.gbFreq.Controls.Add(this.btnClearFreq);
            this.gbFreq.Controls.Add(this.btnDefaultFreq);
            this.gbFreq.Controls.Add(this.btnReadFreq);
            this.gbFreq.Controls.Add(this.cboBand);
            this.gbFreq.Controls.Add(this.cbbSingOrMulti);
            this.gbFreq.Controls.Add(this.labSingleOrMulti);
            this.gbFreq.Controls.Add(this.labPower);
            this.gbFreq.Controls.Add(this.tbPower);
            this.gbFreq.Controls.Add(this.labSetParam);
            this.gbFreq.Controls.Add(this.btnSetFreq);
            this.gbFreq.Controls.Add(this.labDevNo);
            this.gbFreq.Controls.Add(this.tbNewDevNo);
            this.gbFreq.Location = new System.Drawing.Point(34, 221);
            this.gbFreq.Name = "gbFreq";
            this.gbFreq.Size = new System.Drawing.Size(730, 217);
            this.gbFreq.TabIndex = 92;
            this.gbFreq.TabStop = false;
            this.gbFreq.Text = "频率及其它参数";
            // 
            // pnlEUBand
            // 
            this.pnlEUBand.Controls.Add(this.cboFreqModeEU);
            this.pnlEUBand.Controls.Add(this.lblFreq);
            this.pnlEUBand.Controls.Add(this.cboFreqPointEU);
            this.pnlEUBand.Controls.Add(this.chkFp3);
            this.pnlEUBand.Controls.Add(this.chkFp5);
            this.pnlEUBand.Controls.Add(this.chkFp4);
            this.pnlEUBand.Controls.Add(this.chkFp2);
            this.pnlEUBand.Controls.Add(this.chkFp1);
            this.pnlEUBand.Location = new System.Drawing.Point(4, 77);
            this.pnlEUBand.Name = "pnlEUBand";
            this.pnlEUBand.Size = new System.Drawing.Size(581, 134);
            this.pnlEUBand.TabIndex = 93;
            // 
            // cboFreqModeEU
            // 
            this.cboFreqModeEU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFreqModeEU.FormattingEnabled = true;
            this.cboFreqModeEU.Location = new System.Drawing.Point(100, 9);
            this.cboFreqModeEU.Name = "cboFreqModeEU";
            this.cboFreqModeEU.Size = new System.Drawing.Size(86, 20);
            this.cboFreqModeEU.TabIndex = 35;
            this.cboFreqModeEU.SelectedIndexChanged += new System.EventHandler(this.cboFreqModeEU_SelectedIndexChanged);
            // 
            // lblFreq
            // 
            this.lblFreq.AutoEllipsis = true;
            this.lblFreq.Location = new System.Drawing.Point(2, 12);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(97, 12);
            this.lblFreq.TabIndex = 37;
            this.lblFreq.Text = "频率设置";
            this.lblFreq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboFreqPointEU
            // 
            this.cboFreqPointEU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFreqPointEU.FormattingEnabled = true;
            this.cboFreqPointEU.Location = new System.Drawing.Point(192, 9);
            this.cboFreqPointEU.Name = "cboFreqPointEU";
            this.cboFreqPointEU.Size = new System.Drawing.Size(86, 20);
            this.cboFreqPointEU.TabIndex = 36;
            // 
            // chkFp3
            // 
            this.chkFp3.AutoSize = true;
            this.chkFp3.Location = new System.Drawing.Point(134, 38);
            this.chkFp3.Name = "chkFp3";
            this.chkFp3.Size = new System.Drawing.Size(54, 16);
            this.chkFp3.TabIndex = 40;
            this.chkFp3.Text = "866.5";
            this.chkFp3.UseVisualStyleBackColor = true;
            // 
            // chkFp5
            // 
            this.chkFp5.AutoSize = true;
            this.chkFp5.Location = new System.Drawing.Point(246, 38);
            this.chkFp5.Name = "chkFp5";
            this.chkFp5.Size = new System.Drawing.Size(54, 16);
            this.chkFp5.TabIndex = 42;
            this.chkFp5.Text = "867.5";
            this.chkFp5.UseVisualStyleBackColor = true;
            // 
            // chkFp4
            // 
            this.chkFp4.AutoSize = true;
            this.chkFp4.Location = new System.Drawing.Point(190, 38);
            this.chkFp4.Name = "chkFp4";
            this.chkFp4.Size = new System.Drawing.Size(54, 16);
            this.chkFp4.TabIndex = 41;
            this.chkFp4.Text = "867.0";
            this.chkFp4.UseVisualStyleBackColor = true;
            // 
            // chkFp2
            // 
            this.chkFp2.AutoSize = true;
            this.chkFp2.Location = new System.Drawing.Point(80, 38);
            this.chkFp2.Name = "chkFp2";
            this.chkFp2.Size = new System.Drawing.Size(54, 16);
            this.chkFp2.TabIndex = 39;
            this.chkFp2.Text = "866.0";
            this.chkFp2.UseVisualStyleBackColor = true;
            // 
            // chkFp1
            // 
            this.chkFp1.AutoSize = true;
            this.chkFp1.Location = new System.Drawing.Point(25, 38);
            this.chkFp1.Name = "chkFp1";
            this.chkFp1.Size = new System.Drawing.Size(54, 16);
            this.chkFp1.TabIndex = 38;
            this.chkFp1.Text = "865.5";
            this.chkFp1.UseVisualStyleBackColor = true;
            // 
            // pnlUSBand
            // 
            this.pnlUSBand.Controls.Add(this.cbFp50);
            this.pnlUSBand.Controls.Add(this.cbbFreqModeUS);
            this.pnlUSBand.Controls.Add(this.cbFp49);
            this.pnlUSBand.Controls.Add(this.cbbFreqPointUS);
            this.pnlUSBand.Controls.Add(this.cbFp48);
            this.pnlUSBand.Controls.Add(this.labFreq);
            this.pnlUSBand.Controls.Add(this.cbFp47);
            this.pnlUSBand.Controls.Add(this.cbFp1);
            this.pnlUSBand.Controls.Add(this.cbFp46);
            this.pnlUSBand.Controls.Add(this.cbFp2);
            this.pnlUSBand.Controls.Add(this.cbFp45);
            this.pnlUSBand.Controls.Add(this.cbFp3);
            this.pnlUSBand.Controls.Add(this.cbFp44);
            this.pnlUSBand.Controls.Add(this.cbFp4);
            this.pnlUSBand.Controls.Add(this.cbFp43);
            this.pnlUSBand.Controls.Add(this.cbFp5);
            this.pnlUSBand.Controls.Add(this.cbFp42);
            this.pnlUSBand.Controls.Add(this.cbFp6);
            this.pnlUSBand.Controls.Add(this.cbFp41);
            this.pnlUSBand.Controls.Add(this.cbFp7);
            this.pnlUSBand.Controls.Add(this.cbFp8);
            this.pnlUSBand.Controls.Add(this.cbFp40);
            this.pnlUSBand.Controls.Add(this.cbFp9);
            this.pnlUSBand.Controls.Add(this.cbFp39);
            this.pnlUSBand.Controls.Add(this.cbFp10);
            this.pnlUSBand.Controls.Add(this.cbFp38);
            this.pnlUSBand.Controls.Add(this.cbFp11);
            this.pnlUSBand.Controls.Add(this.cbFp37);
            this.pnlUSBand.Controls.Add(this.cbFp12);
            this.pnlUSBand.Controls.Add(this.cbFp36);
            this.pnlUSBand.Controls.Add(this.cbFp13);
            this.pnlUSBand.Controls.Add(this.cbFp35);
            this.pnlUSBand.Controls.Add(this.cbFp14);
            this.pnlUSBand.Controls.Add(this.cbFp34);
            this.pnlUSBand.Controls.Add(this.cbFp15);
            this.pnlUSBand.Controls.Add(this.cbFp33);
            this.pnlUSBand.Controls.Add(this.cbFp16);
            this.pnlUSBand.Controls.Add(this.cbFp32);
            this.pnlUSBand.Controls.Add(this.cbFp17);
            this.pnlUSBand.Controls.Add(this.cbFp31);
            this.pnlUSBand.Controls.Add(this.cbFp18);
            this.pnlUSBand.Controls.Add(this.cbFp30);
            this.pnlUSBand.Controls.Add(this.cbFp19);
            this.pnlUSBand.Controls.Add(this.cbFp29);
            this.pnlUSBand.Controls.Add(this.cbFp20);
            this.pnlUSBand.Controls.Add(this.cbFp28);
            this.pnlUSBand.Controls.Add(this.cbFp21);
            this.pnlUSBand.Controls.Add(this.cbFp27);
            this.pnlUSBand.Controls.Add(this.cbFp22);
            this.pnlUSBand.Controls.Add(this.cbFp26);
            this.pnlUSBand.Controls.Add(this.cbFp23);
            this.pnlUSBand.Controls.Add(this.cbFp25);
            this.pnlUSBand.Controls.Add(this.cbFp24);
            this.pnlUSBand.Location = new System.Drawing.Point(4, 79);
            this.pnlUSBand.Name = "pnlUSBand";
            this.pnlUSBand.Size = new System.Drawing.Size(581, 134);
            this.pnlUSBand.TabIndex = 93;
            // 
            // cbFp50
            // 
            this.cbFp50.AutoSize = true;
            this.cbFp50.Location = new System.Drawing.Point(518, 115);
            this.cbFp50.Name = "cbFp50";
            this.cbFp50.Size = new System.Drawing.Size(54, 16);
            this.cbFp50.TabIndex = 91;
            this.cbFp50.Text = "927.0";
            this.cbFp50.UseVisualStyleBackColor = true;
            // 
            // cbbFreqModeUS
            // 
            this.cbbFreqModeUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFreqModeUS.FormattingEnabled = true;
            this.cbbFreqModeUS.Location = new System.Drawing.Point(100, 2);
            this.cbbFreqModeUS.Name = "cbbFreqModeUS";
            this.cbbFreqModeUS.Size = new System.Drawing.Size(86, 20);
            this.cbbFreqModeUS.TabIndex = 35;
            this.cbbFreqModeUS.SelectedIndexChanged += new System.EventHandler(this.cbbFreqMode_SelectedIndexChanged);
            // 
            // cbFp49
            // 
            this.cbFp49.AutoSize = true;
            this.cbFp49.Location = new System.Drawing.Point(462, 115);
            this.cbFp49.Name = "cbFp49";
            this.cbFp49.Size = new System.Drawing.Size(54, 16);
            this.cbFp49.TabIndex = 90;
            this.cbFp49.Text = "926.5";
            this.cbFp49.UseVisualStyleBackColor = true;
            // 
            // cbbFreqPointUS
            // 
            this.cbbFreqPointUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFreqPointUS.FormattingEnabled = true;
            this.cbbFreqPointUS.Location = new System.Drawing.Point(190, 2);
            this.cbbFreqPointUS.Name = "cbbFreqPointUS";
            this.cbbFreqPointUS.Size = new System.Drawing.Size(86, 20);
            this.cbbFreqPointUS.TabIndex = 36;
            // 
            // cbFp48
            // 
            this.cbFp48.AutoSize = true;
            this.cbFp48.Location = new System.Drawing.Point(408, 115);
            this.cbFp48.Name = "cbFp48";
            this.cbFp48.Size = new System.Drawing.Size(54, 16);
            this.cbFp48.TabIndex = 89;
            this.cbFp48.Text = "926.0";
            this.cbFp48.UseVisualStyleBackColor = true;
            // 
            // labFreq
            // 
            this.labFreq.AutoEllipsis = true;
            this.labFreq.Location = new System.Drawing.Point(7, 6);
            this.labFreq.Name = "labFreq";
            this.labFreq.Size = new System.Drawing.Size(87, 12);
            this.labFreq.TabIndex = 37;
            this.labFreq.Text = "频率设置";
            this.labFreq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbFp47
            // 
            this.cbFp47.AutoSize = true;
            this.cbFp47.Location = new System.Drawing.Point(354, 115);
            this.cbFp47.Name = "cbFp47";
            this.cbFp47.Size = new System.Drawing.Size(54, 16);
            this.cbFp47.TabIndex = 88;
            this.cbFp47.Text = "925.5";
            this.cbFp47.UseVisualStyleBackColor = true;
            // 
            // cbFp1
            // 
            this.cbFp1.AutoSize = true;
            this.cbFp1.Location = new System.Drawing.Point(24, 29);
            this.cbFp1.Name = "cbFp1";
            this.cbFp1.Size = new System.Drawing.Size(54, 16);
            this.cbFp1.TabIndex = 38;
            this.cbFp1.Text = "902.5";
            this.cbFp1.UseVisualStyleBackColor = true;
            // 
            // cbFp46
            // 
            this.cbFp46.AutoSize = true;
            this.cbFp46.Location = new System.Drawing.Point(299, 115);
            this.cbFp46.Name = "cbFp46";
            this.cbFp46.Size = new System.Drawing.Size(54, 16);
            this.cbFp46.TabIndex = 87;
            this.cbFp46.Text = "925.0";
            this.cbFp46.UseVisualStyleBackColor = true;
            // 
            // cbFp2
            // 
            this.cbFp2.AutoSize = true;
            this.cbFp2.Location = new System.Drawing.Point(80, 29);
            this.cbFp2.Name = "cbFp2";
            this.cbFp2.Size = new System.Drawing.Size(54, 16);
            this.cbFp2.TabIndex = 39;
            this.cbFp2.Text = "903.0";
            this.cbFp2.UseVisualStyleBackColor = true;
            // 
            // cbFp45
            // 
            this.cbFp45.AutoSize = true;
            this.cbFp45.Location = new System.Drawing.Point(245, 115);
            this.cbFp45.Name = "cbFp45";
            this.cbFp45.Size = new System.Drawing.Size(54, 16);
            this.cbFp45.TabIndex = 86;
            this.cbFp45.Text = "924.5";
            this.cbFp45.UseVisualStyleBackColor = true;
            // 
            // cbFp3
            // 
            this.cbFp3.AutoSize = true;
            this.cbFp3.Location = new System.Drawing.Point(135, 29);
            this.cbFp3.Name = "cbFp3";
            this.cbFp3.Size = new System.Drawing.Size(54, 16);
            this.cbFp3.TabIndex = 40;
            this.cbFp3.Text = "903.5";
            this.cbFp3.UseVisualStyleBackColor = true;
            // 
            // cbFp44
            // 
            this.cbFp44.AutoSize = true;
            this.cbFp44.Location = new System.Drawing.Point(190, 115);
            this.cbFp44.Name = "cbFp44";
            this.cbFp44.Size = new System.Drawing.Size(54, 16);
            this.cbFp44.TabIndex = 85;
            this.cbFp44.Text = "924.0";
            this.cbFp44.UseVisualStyleBackColor = true;
            // 
            // cbFp4
            // 
            this.cbFp4.AutoSize = true;
            this.cbFp4.Location = new System.Drawing.Point(190, 29);
            this.cbFp4.Name = "cbFp4";
            this.cbFp4.Size = new System.Drawing.Size(54, 16);
            this.cbFp4.TabIndex = 41;
            this.cbFp4.Text = "904.0";
            this.cbFp4.UseVisualStyleBackColor = true;
            // 
            // cbFp43
            // 
            this.cbFp43.AutoSize = true;
            this.cbFp43.Location = new System.Drawing.Point(135, 115);
            this.cbFp43.Name = "cbFp43";
            this.cbFp43.Size = new System.Drawing.Size(54, 16);
            this.cbFp43.TabIndex = 84;
            this.cbFp43.Text = "923.5";
            this.cbFp43.UseVisualStyleBackColor = true;
            // 
            // cbFp5
            // 
            this.cbFp5.AutoSize = true;
            this.cbFp5.Location = new System.Drawing.Point(244, 29);
            this.cbFp5.Name = "cbFp5";
            this.cbFp5.Size = new System.Drawing.Size(54, 16);
            this.cbFp5.TabIndex = 42;
            this.cbFp5.Text = "904.5";
            this.cbFp5.UseVisualStyleBackColor = true;
            // 
            // cbFp42
            // 
            this.cbFp42.AutoSize = true;
            this.cbFp42.Location = new System.Drawing.Point(80, 115);
            this.cbFp42.Name = "cbFp42";
            this.cbFp42.Size = new System.Drawing.Size(54, 16);
            this.cbFp42.TabIndex = 83;
            this.cbFp42.Text = "923.0";
            this.cbFp42.UseVisualStyleBackColor = true;
            // 
            // cbFp6
            // 
            this.cbFp6.AutoSize = true;
            this.cbFp6.Location = new System.Drawing.Point(299, 29);
            this.cbFp6.Name = "cbFp6";
            this.cbFp6.Size = new System.Drawing.Size(54, 16);
            this.cbFp6.TabIndex = 43;
            this.cbFp6.Text = "905.0";
            this.cbFp6.UseVisualStyleBackColor = true;
            // 
            // cbFp41
            // 
            this.cbFp41.AutoSize = true;
            this.cbFp41.Location = new System.Drawing.Point(24, 115);
            this.cbFp41.Name = "cbFp41";
            this.cbFp41.Size = new System.Drawing.Size(54, 16);
            this.cbFp41.TabIndex = 82;
            this.cbFp41.Text = "922.5";
            this.cbFp41.UseVisualStyleBackColor = true;
            // 
            // cbFp7
            // 
            this.cbFp7.AutoSize = true;
            this.cbFp7.Location = new System.Drawing.Point(354, 29);
            this.cbFp7.Name = "cbFp7";
            this.cbFp7.Size = new System.Drawing.Size(54, 16);
            this.cbFp7.TabIndex = 44;
            this.cbFp7.Text = "905.5";
            this.cbFp7.UseVisualStyleBackColor = true;
            // 
            // cbFp8
            // 
            this.cbFp8.AutoSize = true;
            this.cbFp8.Location = new System.Drawing.Point(408, 29);
            this.cbFp8.Name = "cbFp8";
            this.cbFp8.Size = new System.Drawing.Size(54, 16);
            this.cbFp8.TabIndex = 45;
            this.cbFp8.Text = "906.0";
            this.cbFp8.UseVisualStyleBackColor = true;
            // 
            // cbFp40
            // 
            this.cbFp40.AutoSize = true;
            this.cbFp40.Location = new System.Drawing.Point(518, 95);
            this.cbFp40.Name = "cbFp40";
            this.cbFp40.Size = new System.Drawing.Size(54, 16);
            this.cbFp40.TabIndex = 80;
            this.cbFp40.Text = "922.0";
            this.cbFp40.UseVisualStyleBackColor = true;
            // 
            // cbFp9
            // 
            this.cbFp9.AutoSize = true;
            this.cbFp9.Location = new System.Drawing.Point(462, 29);
            this.cbFp9.Name = "cbFp9";
            this.cbFp9.Size = new System.Drawing.Size(54, 16);
            this.cbFp9.TabIndex = 46;
            this.cbFp9.Text = "906.5";
            this.cbFp9.UseVisualStyleBackColor = true;
            // 
            // cbFp39
            // 
            this.cbFp39.AutoSize = true;
            this.cbFp39.Location = new System.Drawing.Point(462, 95);
            this.cbFp39.Name = "cbFp39";
            this.cbFp39.Size = new System.Drawing.Size(54, 16);
            this.cbFp39.TabIndex = 79;
            this.cbFp39.Text = "921.5";
            this.cbFp39.UseVisualStyleBackColor = true;
            // 
            // cbFp10
            // 
            this.cbFp10.AutoSize = true;
            this.cbFp10.Location = new System.Drawing.Point(518, 29);
            this.cbFp10.Name = "cbFp10";
            this.cbFp10.Size = new System.Drawing.Size(54, 16);
            this.cbFp10.TabIndex = 47;
            this.cbFp10.Text = "907.0";
            this.cbFp10.UseVisualStyleBackColor = true;
            // 
            // cbFp38
            // 
            this.cbFp38.AutoSize = true;
            this.cbFp38.Location = new System.Drawing.Point(408, 95);
            this.cbFp38.Name = "cbFp38";
            this.cbFp38.Size = new System.Drawing.Size(54, 16);
            this.cbFp38.TabIndex = 78;
            this.cbFp38.Text = "921.0";
            this.cbFp38.UseVisualStyleBackColor = true;
            // 
            // cbFp11
            // 
            this.cbFp11.AutoSize = true;
            this.cbFp11.Location = new System.Drawing.Point(24, 51);
            this.cbFp11.Name = "cbFp11";
            this.cbFp11.Size = new System.Drawing.Size(54, 16);
            this.cbFp11.TabIndex = 48;
            this.cbFp11.Text = "907.5";
            this.cbFp11.UseVisualStyleBackColor = true;
            // 
            // cbFp37
            // 
            this.cbFp37.AutoSize = true;
            this.cbFp37.Location = new System.Drawing.Point(354, 95);
            this.cbFp37.Name = "cbFp37";
            this.cbFp37.Size = new System.Drawing.Size(54, 16);
            this.cbFp37.TabIndex = 77;
            this.cbFp37.Text = "920.5";
            this.cbFp37.UseVisualStyleBackColor = true;
            // 
            // cbFp12
            // 
            this.cbFp12.AutoSize = true;
            this.cbFp12.Location = new System.Drawing.Point(80, 51);
            this.cbFp12.Name = "cbFp12";
            this.cbFp12.Size = new System.Drawing.Size(54, 16);
            this.cbFp12.TabIndex = 49;
            this.cbFp12.Text = "908.0";
            this.cbFp12.UseVisualStyleBackColor = true;
            // 
            // cbFp36
            // 
            this.cbFp36.AutoSize = true;
            this.cbFp36.Location = new System.Drawing.Point(299, 95);
            this.cbFp36.Name = "cbFp36";
            this.cbFp36.Size = new System.Drawing.Size(54, 16);
            this.cbFp36.TabIndex = 76;
            this.cbFp36.Text = "920.0";
            this.cbFp36.UseVisualStyleBackColor = true;
            // 
            // cbFp13
            // 
            this.cbFp13.AutoSize = true;
            this.cbFp13.Location = new System.Drawing.Point(135, 51);
            this.cbFp13.Name = "cbFp13";
            this.cbFp13.Size = new System.Drawing.Size(54, 16);
            this.cbFp13.TabIndex = 50;
            this.cbFp13.Text = "908.5";
            this.cbFp13.UseVisualStyleBackColor = true;
            // 
            // cbFp35
            // 
            this.cbFp35.AutoSize = true;
            this.cbFp35.Location = new System.Drawing.Point(245, 95);
            this.cbFp35.Name = "cbFp35";
            this.cbFp35.Size = new System.Drawing.Size(54, 16);
            this.cbFp35.TabIndex = 75;
            this.cbFp35.Text = "919.5";
            this.cbFp35.UseVisualStyleBackColor = true;
            // 
            // cbFp14
            // 
            this.cbFp14.AutoSize = true;
            this.cbFp14.Location = new System.Drawing.Point(190, 51);
            this.cbFp14.Name = "cbFp14";
            this.cbFp14.Size = new System.Drawing.Size(54, 16);
            this.cbFp14.TabIndex = 51;
            this.cbFp14.Text = "909.0";
            this.cbFp14.UseVisualStyleBackColor = true;
            // 
            // cbFp34
            // 
            this.cbFp34.AutoSize = true;
            this.cbFp34.Location = new System.Drawing.Point(190, 95);
            this.cbFp34.Name = "cbFp34";
            this.cbFp34.Size = new System.Drawing.Size(54, 16);
            this.cbFp34.TabIndex = 74;
            this.cbFp34.Text = "919.0";
            this.cbFp34.UseVisualStyleBackColor = true;
            // 
            // cbFp15
            // 
            this.cbFp15.AutoSize = true;
            this.cbFp15.Location = new System.Drawing.Point(244, 51);
            this.cbFp15.Name = "cbFp15";
            this.cbFp15.Size = new System.Drawing.Size(54, 16);
            this.cbFp15.TabIndex = 52;
            this.cbFp15.Text = "909.5";
            this.cbFp15.UseVisualStyleBackColor = true;
            // 
            // cbFp33
            // 
            this.cbFp33.AutoSize = true;
            this.cbFp33.Location = new System.Drawing.Point(135, 95);
            this.cbFp33.Name = "cbFp33";
            this.cbFp33.Size = new System.Drawing.Size(54, 16);
            this.cbFp33.TabIndex = 73;
            this.cbFp33.Text = "918.5";
            this.cbFp33.UseVisualStyleBackColor = true;
            // 
            // cbFp16
            // 
            this.cbFp16.AutoSize = true;
            this.cbFp16.Location = new System.Drawing.Point(299, 51);
            this.cbFp16.Name = "cbFp16";
            this.cbFp16.Size = new System.Drawing.Size(54, 16);
            this.cbFp16.TabIndex = 53;
            this.cbFp16.Text = "910.0";
            this.cbFp16.UseVisualStyleBackColor = true;
            // 
            // cbFp32
            // 
            this.cbFp32.AutoSize = true;
            this.cbFp32.Location = new System.Drawing.Point(80, 95);
            this.cbFp32.Name = "cbFp32";
            this.cbFp32.Size = new System.Drawing.Size(54, 16);
            this.cbFp32.TabIndex = 72;
            this.cbFp32.Text = "918.0";
            this.cbFp32.UseVisualStyleBackColor = true;
            // 
            // cbFp17
            // 
            this.cbFp17.AutoSize = true;
            this.cbFp17.Location = new System.Drawing.Point(354, 51);
            this.cbFp17.Name = "cbFp17";
            this.cbFp17.Size = new System.Drawing.Size(54, 16);
            this.cbFp17.TabIndex = 54;
            this.cbFp17.Text = "910.5";
            this.cbFp17.UseVisualStyleBackColor = true;
            // 
            // cbFp31
            // 
            this.cbFp31.AutoSize = true;
            this.cbFp31.Location = new System.Drawing.Point(24, 95);
            this.cbFp31.Name = "cbFp31";
            this.cbFp31.Size = new System.Drawing.Size(54, 16);
            this.cbFp31.TabIndex = 71;
            this.cbFp31.Text = "917.5";
            this.cbFp31.UseVisualStyleBackColor = true;
            // 
            // cbFp18
            // 
            this.cbFp18.AutoSize = true;
            this.cbFp18.Location = new System.Drawing.Point(408, 51);
            this.cbFp18.Name = "cbFp18";
            this.cbFp18.Size = new System.Drawing.Size(54, 16);
            this.cbFp18.TabIndex = 55;
            this.cbFp18.Text = "911.0";
            this.cbFp18.UseVisualStyleBackColor = true;
            // 
            // cbFp30
            // 
            this.cbFp30.AutoSize = true;
            this.cbFp30.Location = new System.Drawing.Point(518, 73);
            this.cbFp30.Name = "cbFp30";
            this.cbFp30.Size = new System.Drawing.Size(54, 16);
            this.cbFp30.TabIndex = 70;
            this.cbFp30.Text = "917.0";
            this.cbFp30.UseVisualStyleBackColor = true;
            // 
            // cbFp19
            // 
            this.cbFp19.AutoSize = true;
            this.cbFp19.Location = new System.Drawing.Point(462, 51);
            this.cbFp19.Name = "cbFp19";
            this.cbFp19.Size = new System.Drawing.Size(54, 16);
            this.cbFp19.TabIndex = 56;
            this.cbFp19.Text = "911.5";
            this.cbFp19.UseVisualStyleBackColor = true;
            // 
            // cbFp29
            // 
            this.cbFp29.AutoSize = true;
            this.cbFp29.Location = new System.Drawing.Point(462, 73);
            this.cbFp29.Name = "cbFp29";
            this.cbFp29.Size = new System.Drawing.Size(54, 16);
            this.cbFp29.TabIndex = 69;
            this.cbFp29.Text = "916.5";
            this.cbFp29.UseVisualStyleBackColor = true;
            // 
            // cbFp20
            // 
            this.cbFp20.AutoSize = true;
            this.cbFp20.Location = new System.Drawing.Point(518, 51);
            this.cbFp20.Name = "cbFp20";
            this.cbFp20.Size = new System.Drawing.Size(54, 16);
            this.cbFp20.TabIndex = 57;
            this.cbFp20.Text = "912.0";
            this.cbFp20.UseVisualStyleBackColor = true;
            // 
            // cbFp28
            // 
            this.cbFp28.AutoSize = true;
            this.cbFp28.Location = new System.Drawing.Point(408, 73);
            this.cbFp28.Name = "cbFp28";
            this.cbFp28.Size = new System.Drawing.Size(54, 16);
            this.cbFp28.TabIndex = 68;
            this.cbFp28.Text = "916.0";
            this.cbFp28.UseVisualStyleBackColor = true;
            // 
            // cbFp21
            // 
            this.cbFp21.AutoSize = true;
            this.cbFp21.Location = new System.Drawing.Point(24, 73);
            this.cbFp21.Name = "cbFp21";
            this.cbFp21.Size = new System.Drawing.Size(54, 16);
            this.cbFp21.TabIndex = 61;
            this.cbFp21.Text = "912.5";
            this.cbFp21.UseVisualStyleBackColor = true;
            // 
            // cbFp27
            // 
            this.cbFp27.AutoSize = true;
            this.cbFp27.Location = new System.Drawing.Point(354, 73);
            this.cbFp27.Name = "cbFp27";
            this.cbFp27.Size = new System.Drawing.Size(54, 16);
            this.cbFp27.TabIndex = 67;
            this.cbFp27.Text = "915.5";
            this.cbFp27.UseVisualStyleBackColor = true;
            // 
            // cbFp22
            // 
            this.cbFp22.AutoSize = true;
            this.cbFp22.Location = new System.Drawing.Point(80, 73);
            this.cbFp22.Name = "cbFp22";
            this.cbFp22.Size = new System.Drawing.Size(54, 16);
            this.cbFp22.TabIndex = 62;
            this.cbFp22.Text = "913.0";
            this.cbFp22.UseVisualStyleBackColor = true;
            // 
            // cbFp26
            // 
            this.cbFp26.AutoSize = true;
            this.cbFp26.Location = new System.Drawing.Point(299, 73);
            this.cbFp26.Name = "cbFp26";
            this.cbFp26.Size = new System.Drawing.Size(54, 16);
            this.cbFp26.TabIndex = 66;
            this.cbFp26.Text = "915.0";
            this.cbFp26.UseVisualStyleBackColor = true;
            // 
            // cbFp23
            // 
            this.cbFp23.AutoSize = true;
            this.cbFp23.Location = new System.Drawing.Point(135, 73);
            this.cbFp23.Name = "cbFp23";
            this.cbFp23.Size = new System.Drawing.Size(54, 16);
            this.cbFp23.TabIndex = 63;
            this.cbFp23.Text = "913.5";
            this.cbFp23.UseVisualStyleBackColor = true;
            // 
            // cbFp25
            // 
            this.cbFp25.AutoSize = true;
            this.cbFp25.Location = new System.Drawing.Point(245, 73);
            this.cbFp25.Name = "cbFp25";
            this.cbFp25.Size = new System.Drawing.Size(54, 16);
            this.cbFp25.TabIndex = 65;
            this.cbFp25.Text = "914.5";
            this.cbFp25.UseVisualStyleBackColor = true;
            // 
            // cbFp24
            // 
            this.cbFp24.AutoSize = true;
            this.cbFp24.Location = new System.Drawing.Point(190, 73);
            this.cbFp24.Name = "cbFp24";
            this.cbFp24.Size = new System.Drawing.Size(54, 16);
            this.cbFp24.TabIndex = 64;
            this.cbFp24.Text = "914.0";
            this.cbFp24.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 12);
            this.label8.TabIndex = 81;
            // 
            // labDelayUnit
            // 
            this.labDelayUnit.AutoSize = true;
            this.labDelayUnit.Location = new System.Drawing.Point(406, 28);
            this.labDelayUnit.Name = "labDelayUnit";
            this.labDelayUnit.Size = new System.Drawing.Size(17, 12);
            this.labDelayUnit.TabIndex = 22;
            this.labDelayUnit.Text = "秒";
            // 
            // btnClearFreq
            // 
            this.btnClearFreq.Location = new System.Drawing.Point(613, 162);
            this.btnClearFreq.Name = "btnClearFreq";
            this.btnClearFreq.Size = new System.Drawing.Size(82, 30);
            this.btnClearFreq.TabIndex = 60;
            this.btnClearFreq.Text = "清除频点";
            this.btnClearFreq.UseVisualStyleBackColor = true;
            this.btnClearFreq.Click += new System.EventHandler(this.btnClearFreq_Click);
            // 
            // btnDefaultFreq
            // 
            this.btnDefaultFreq.Location = new System.Drawing.Point(613, 118);
            this.btnDefaultFreq.Name = "btnDefaultFreq";
            this.btnDefaultFreq.Size = new System.Drawing.Size(82, 30);
            this.btnDefaultFreq.TabIndex = 59;
            this.btnDefaultFreq.Text = "默认参数";
            this.btnDefaultFreq.UseVisualStyleBackColor = true;
            this.btnDefaultFreq.Click += new System.EventHandler(this.btnDefaultFreq_Click);
            // 
            // tbDelay
            // 
            this.tbDelay.Location = new System.Drawing.Point(316, 25);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(86, 21);
            this.tbDelay.TabIndex = 20;
            // 
            // btnReadFreq
            // 
            this.btnReadFreq.Location = new System.Drawing.Point(613, 30);
            this.btnReadFreq.Name = "btnReadFreq";
            this.btnReadFreq.Size = new System.Drawing.Size(82, 30);
            this.btnReadFreq.TabIndex = 58;
            this.btnReadFreq.Text = "读取";
            this.btnReadFreq.UseVisualStyleBackColor = true;
            this.btnReadFreq.Click += new System.EventHandler(this.btnReadFreq_Click);
            // 
            // cboBand
            // 
            this.cboBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBand.FormattingEnabled = true;
            this.cboBand.Location = new System.Drawing.Point(29, 53);
            this.cboBand.Name = "cboBand";
            this.cboBand.Size = new System.Drawing.Size(56, 20);
            this.cboBand.TabIndex = 35;
            this.cboBand.SelectedIndexChanged += new System.EventHandler(this.cboBand_SelectedIndexChanged);
            // 
            // cbbSingOrMulti
            // 
            this.cbbSingOrMulti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSingOrMulti.FormattingEnabled = true;
            this.cbbSingOrMulti.Location = new System.Drawing.Point(468, 28);
            this.cbbSingOrMulti.Name = "cbbSingOrMulti";
            this.cbbSingOrMulti.Size = new System.Drawing.Size(86, 20);
            this.cbbSingOrMulti.TabIndex = 34;
            // 
            // labSingleOrMulti
            // 
            this.labSingleOrMulti.AutoEllipsis = true;
            this.labSingleOrMulti.Location = new System.Drawing.Point(342, 31);
            this.labSingleOrMulti.Name = "labSingleOrMulti";
            this.labSingleOrMulti.Size = new System.Drawing.Size(120, 12);
            this.labSingleOrMulti.TabIndex = 18;
            this.labSingleOrMulti.Text = "读卡方式";
            this.labSingleOrMulti.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labTrigParam
            // 
            this.labTrigParam.AutoEllipsis = true;
            this.labTrigParam.Location = new System.Drawing.Point(200, 29);
            this.labTrigParam.Name = "labTrigParam";
            this.labTrigParam.Size = new System.Drawing.Size(110, 12);
            this.labTrigParam.TabIndex = 16;
            this.labTrigParam.Text = "触发延时";
            this.labTrigParam.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labPower
            // 
            this.labPower.AutoEllipsis = true;
            this.labPower.Location = new System.Drawing.Point(202, 31);
            this.labPower.Name = "labPower";
            this.labPower.Size = new System.Drawing.Size(67, 12);
            this.labPower.TabIndex = 17;
            this.labPower.Text = "功率";
            this.labPower.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbPower
            // 
            this.tbPower.Location = new System.Drawing.Point(275, 28);
            this.tbPower.Name = "tbPower";
            this.tbPower.Size = new System.Drawing.Size(60, 21);
            this.tbPower.TabIndex = 16;
            // 
            // labSetParam
            // 
            this.labSetParam.AutoSize = true;
            this.labSetParam.Location = new System.Drawing.Point(34, 181);
            this.labSetParam.Name = "labSetParam";
            this.labSetParam.Size = new System.Drawing.Size(0, 12);
            this.labSetParam.TabIndex = 14;
            // 
            // btnSetFreq
            // 
            this.btnSetFreq.Location = new System.Drawing.Point(613, 74);
            this.btnSetFreq.Name = "btnSetFreq";
            this.btnSetFreq.Size = new System.Drawing.Size(82, 30);
            this.btnSetFreq.TabIndex = 8;
            this.btnSetFreq.Text = "设置";
            this.btnSetFreq.UseVisualStyleBackColor = true;
            this.btnSetFreq.Click += new System.EventHandler(this.btnSetFreq_Click);
            // 
            // labDevNo
            // 
            this.labDevNo.AutoSize = true;
            this.labDevNo.Location = new System.Drawing.Point(27, 31);
            this.labDevNo.Name = "labDevNo";
            this.labDevNo.Size = new System.Drawing.Size(41, 12);
            this.labDevNo.TabIndex = 11;
            this.labDevNo.Text = "设备号";
            // 
            // tbNewDevNo
            // 
            this.tbNewDevNo.Location = new System.Drawing.Point(110, 28);
            this.tbNewDevNo.Name = "tbNewDevNo";
            this.tbNewDevNo.Size = new System.Drawing.Size(60, 21);
            this.tbNewDevNo.TabIndex = 0;
            // 
            // gbCommModeParam
            // 
            this.gbCommModeParam.Controls.Add(this.btnDefaultCommMode);
            this.gbCommModeParam.Controls.Add(this.btnReadCommMode);
            this.gbCommModeParam.Controls.Add(this.labPulseCycleUnit);
            this.gbCommModeParam.Controls.Add(this.btnSetCommMode);
            this.gbCommModeParam.Controls.Add(this.labPulseWidthUnit);
            this.gbCommModeParam.Controls.Add(this.tbPulseCycle);
            this.gbCommModeParam.Controls.Add(this.tbPulseWidth);
            this.gbCommModeParam.Controls.Add(this.lblWigginsTakePlaceValue);
            this.gbCommModeParam.Controls.Add(this.labWiegandProtocol);
            this.gbCommModeParam.Controls.Add(this.cboWigginsTakePlaceValue);
            this.gbCommModeParam.Controls.Add(this.cbbWiegandProtocol);
            this.gbCommModeParam.Controls.Add(this.labPulseCycle);
            this.gbCommModeParam.Controls.Add(this.labPulseWidth);
            this.gbCommModeParam.Controls.Add(this.cbbCommMode);
            this.gbCommModeParam.Controls.Add(this.labCommMode);
            this.gbCommModeParam.Location = new System.Drawing.Point(34, 118);
            this.gbCommModeParam.Name = "gbCommModeParam";
            this.gbCommModeParam.Size = new System.Drawing.Size(731, 97);
            this.gbCommModeParam.TabIndex = 15;
            this.gbCommModeParam.TabStop = false;
            this.gbCommModeParam.Text = "通信方式";
            // 
            // btnDefaultCommMode
            // 
            this.btnDefaultCommMode.Location = new System.Drawing.Point(510, 52);
            this.btnDefaultCommMode.Name = "btnDefaultCommMode";
            this.btnDefaultCommMode.Size = new System.Drawing.Size(82, 30);
            this.btnDefaultCommMode.TabIndex = 26;
            this.btnDefaultCommMode.Text = "默认参数";
            this.btnDefaultCommMode.UseVisualStyleBackColor = true;
            this.btnDefaultCommMode.Click += new System.EventHandler(this.btnDefaultCommMode_Click);
            // 
            // btnReadCommMode
            // 
            this.btnReadCommMode.Location = new System.Drawing.Point(408, 52);
            this.btnReadCommMode.Name = "btnReadCommMode";
            this.btnReadCommMode.Size = new System.Drawing.Size(82, 30);
            this.btnReadCommMode.TabIndex = 27;
            this.btnReadCommMode.Text = "读取";
            this.btnReadCommMode.UseVisualStyleBackColor = true;
            this.btnReadCommMode.Click += new System.EventHandler(this.btnReadCommMode_Click);
            // 
            // labPulseCycleUnit
            // 
            this.labPulseCycleUnit.AutoEllipsis = true;
            this.labPulseCycleUnit.Location = new System.Drawing.Point(635, 23);
            this.labPulseCycleUnit.Name = "labPulseCycleUnit";
            this.labPulseCycleUnit.Size = new System.Drawing.Size(95, 27);
            this.labPulseCycleUnit.TabIndex = 33;
            this.labPulseCycleUnit.Text = "*100微秒";
            // 
            // btnSetCommMode
            // 
            this.btnSetCommMode.Location = new System.Drawing.Point(611, 52);
            this.btnSetCommMode.Name = "btnSetCommMode";
            this.btnSetCommMode.Size = new System.Drawing.Size(82, 30);
            this.btnSetCommMode.TabIndex = 25;
            this.btnSetCommMode.Text = "设置";
            this.btnSetCommMode.UseVisualStyleBackColor = true;
            this.btnSetCommMode.Click += new System.EventHandler(this.btnSetCommMode_Click);
            // 
            // labPulseWidthUnit
            // 
            this.labPulseWidthUnit.AutoEllipsis = true;
            this.labPulseWidthUnit.Location = new System.Drawing.Point(374, 24);
            this.labPulseWidthUnit.Name = "labPulseWidthUnit";
            this.labPulseWidthUnit.Size = new System.Drawing.Size(74, 33);
            this.labPulseWidthUnit.TabIndex = 25;
            this.labPulseWidthUnit.Text = "*10微秒";
            // 
            // tbPulseCycle
            // 
            this.tbPulseCycle.Location = new System.Drawing.Point(570, 22);
            this.tbPulseCycle.Name = "tbPulseCycle";
            this.tbPulseCycle.Size = new System.Drawing.Size(61, 21);
            this.tbPulseCycle.TabIndex = 32;
            // 
            // tbPulseWidth
            // 
            this.tbPulseWidth.Location = new System.Drawing.Point(311, 22);
            this.tbPulseWidth.Name = "tbPulseWidth";
            this.tbPulseWidth.Size = new System.Drawing.Size(61, 21);
            this.tbPulseWidth.TabIndex = 25;
            // 
            // lblWigginsTakePlaceValue
            // 
            this.lblWigginsTakePlaceValue.AutoEllipsis = true;
            this.lblWigginsTakePlaceValue.Location = new System.Drawing.Point(205, 62);
            this.lblWigginsTakePlaceValue.Name = "lblWigginsTakePlaceValue";
            this.lblWigginsTakePlaceValue.Size = new System.Drawing.Size(102, 30);
            this.lblWigginsTakePlaceValue.TabIndex = 31;
            this.lblWigginsTakePlaceValue.Text = "韦根取位值";
            this.lblWigginsTakePlaceValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labWiegandProtocol
            // 
            this.labWiegandProtocol.AutoEllipsis = true;
            this.labWiegandProtocol.Location = new System.Drawing.Point(6, 60);
            this.labWiegandProtocol.Name = "labWiegandProtocol";
            this.labWiegandProtocol.Size = new System.Drawing.Size(81, 30);
            this.labWiegandProtocol.TabIndex = 31;
            this.labWiegandProtocol.Text = "韦根协议";
            this.labWiegandProtocol.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboWigginsTakePlaceValue
            // 
            this.cboWigginsTakePlaceValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWigginsTakePlaceValue.FormattingEnabled = true;
            this.cboWigginsTakePlaceValue.Location = new System.Drawing.Point(311, 57);
            this.cboWigginsTakePlaceValue.Name = "cboWigginsTakePlaceValue";
            this.cboWigginsTakePlaceValue.Size = new System.Drawing.Size(86, 20);
            this.cboWigginsTakePlaceValue.TabIndex = 30;
            // 
            // cbbWiegandProtocol
            // 
            this.cbbWiegandProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWiegandProtocol.FormattingEnabled = true;
            this.cbbWiegandProtocol.Location = new System.Drawing.Point(109, 59);
            this.cbbWiegandProtocol.Name = "cbbWiegandProtocol";
            this.cbbWiegandProtocol.Size = new System.Drawing.Size(86, 20);
            this.cbbWiegandProtocol.TabIndex = 30;
            // 
            // labPulseCycle
            // 
            this.labPulseCycle.AutoEllipsis = true;
            this.labPulseCycle.Location = new System.Drawing.Point(454, 25);
            this.labPulseCycle.Name = "labPulseCycle";
            this.labPulseCycle.Size = new System.Drawing.Size(110, 12);
            this.labPulseCycle.TabIndex = 29;
            this.labPulseCycle.Text = "脉冲周期";
            this.labPulseCycle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labPulseWidth
            // 
            this.labPulseWidth.AutoEllipsis = true;
            this.labPulseWidth.Location = new System.Drawing.Point(207, 25);
            this.labPulseWidth.Name = "labPulseWidth";
            this.labPulseWidth.Size = new System.Drawing.Size(88, 32);
            this.labPulseWidth.TabIndex = 26;
            this.labPulseWidth.Text = "脉冲宽度";
            this.labPulseWidth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbbCommMode
            // 
            this.cbbCommMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCommMode.FormattingEnabled = true;
            this.cbbCommMode.Location = new System.Drawing.Point(110, 20);
            this.cbbCommMode.Name = "cbbCommMode";
            this.cbbCommMode.Size = new System.Drawing.Size(86, 20);
            this.cbbCommMode.TabIndex = 25;
            this.cbbCommMode.SelectedIndexChanged += new System.EventHandler(this.cbbCommMode_SelectedIndexChanged);
            // 
            // labCommMode
            // 
            this.labCommMode.AutoEllipsis = true;
            this.labCommMode.Location = new System.Drawing.Point(6, 23);
            this.labCommMode.Name = "labCommMode";
            this.labCommMode.Size = new System.Drawing.Size(62, 30);
            this.labCommMode.TabIndex = 0;
            this.labCommMode.Text = "方式";
            this.labCommMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbWorkMode
            // 
            this.gbWorkMode.Controls.Add(this.cboReadSpeed);
            this.gbWorkMode.Controls.Add(this.cbAjaDisc);
            this.gbWorkMode.Controls.Add(this.btnDefaultWorkMode);
            this.gbWorkMode.Controls.Add(this.labDelayUnit);
            this.gbWorkMode.Controls.Add(this.btnReadWorkMode);
            this.gbWorkMode.Controls.Add(this.labTimingUnit);
            this.gbWorkMode.Controls.Add(this.tbTiming);
            this.gbWorkMode.Controls.Add(this.tbDelay);
            this.gbWorkMode.Controls.Add(this.cbbWorkMode);
            this.gbWorkMode.Controls.Add(this.cbbTrigSwitch);
            this.gbWorkMode.Controls.Add(this.labTrigSwitch);
            this.gbWorkMode.Controls.Add(this.labTimingParam);
            this.gbWorkMode.Controls.Add(this.labWorkMode);
            this.gbWorkMode.Controls.Add(this.labTrigParam);
            this.gbWorkMode.Controls.Add(this.btnSetWorkMode);
            this.gbWorkMode.Controls.Add(this.tbNeighJudge);
            this.gbWorkMode.Location = new System.Drawing.Point(34, 8);
            this.gbWorkMode.Name = "gbWorkMode";
            this.gbWorkMode.Size = new System.Drawing.Size(732, 103);
            this.gbWorkMode.TabIndex = 13;
            this.gbWorkMode.TabStop = false;
            this.gbWorkMode.Text = "工作模式";
            // 
            // cboReadSpeed
            // 
            this.cboReadSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReadSpeed.FormattingEnabled = true;
            this.cboReadSpeed.Items.AddRange(new object[] {
            "1",
            "10"});
            this.cboReadSpeed.Location = new System.Drawing.Point(405, 24);
            this.cboReadSpeed.Name = "cboReadSpeed";
            this.cboReadSpeed.Size = new System.Drawing.Size(35, 20);
            this.cboReadSpeed.TabIndex = 25;
            // 
            // cbAjaDisc
            // 
            this.cbAjaDisc.AutoSize = true;
            this.cbAjaDisc.Location = new System.Drawing.Point(46, 70);
            this.cbAjaDisc.Name = "cbAjaDisc";
            this.cbAjaDisc.Size = new System.Drawing.Size(72, 16);
            this.cbAjaDisc.TabIndex = 24;
            this.cbAjaDisc.Text = "相邻判定";
            this.cbAjaDisc.UseVisualStyleBackColor = true;
            this.cbAjaDisc.CheckedChanged += new System.EventHandler(this.cbAjaDisc_CheckedChanged);
            // 
            // btnDefaultWorkMode
            // 
            this.btnDefaultWorkMode.Location = new System.Drawing.Point(510, 61);
            this.btnDefaultWorkMode.Name = "btnDefaultWorkMode";
            this.btnDefaultWorkMode.Size = new System.Drawing.Size(82, 30);
            this.btnDefaultWorkMode.TabIndex = 15;
            this.btnDefaultWorkMode.Text = "默认参数";
            this.btnDefaultWorkMode.UseVisualStyleBackColor = true;
            this.btnDefaultWorkMode.Click += new System.EventHandler(this.btnDefaultWorkMode_Click);
            // 
            // btnReadWorkMode
            // 
            this.btnReadWorkMode.Location = new System.Drawing.Point(411, 62);
            this.btnReadWorkMode.Name = "btnReadWorkMode";
            this.btnReadWorkMode.Size = new System.Drawing.Size(82, 30);
            this.btnReadWorkMode.TabIndex = 23;
            this.btnReadWorkMode.Text = "读取";
            this.btnReadWorkMode.UseVisualStyleBackColor = true;
            this.btnReadWorkMode.Click += new System.EventHandler(this.btnReadWorkMode_Click);
            // 
            // labTimingUnit
            // 
            this.labTimingUnit.AutoSize = true;
            this.labTimingUnit.Location = new System.Drawing.Point(444, 28);
            this.labTimingUnit.Name = "labTimingUnit";
            this.labTimingUnit.Size = new System.Drawing.Size(29, 12);
            this.labTimingUnit.TabIndex = 21;
            this.labTimingUnit.Text = "毫秒";
            // 
            // tbTiming
            // 
            this.tbTiming.Location = new System.Drawing.Point(316, 24);
            this.tbTiming.Name = "tbTiming";
            this.tbTiming.Size = new System.Drawing.Size(86, 21);
            this.tbTiming.TabIndex = 19;
            // 
            // cbbWorkMode
            // 
            this.cbbWorkMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWorkMode.FormattingEnabled = true;
            this.cbbWorkMode.Location = new System.Drawing.Point(109, 25);
            this.cbbWorkMode.Name = "cbbWorkMode";
            this.cbbWorkMode.Size = new System.Drawing.Size(86, 20);
            this.cbbWorkMode.TabIndex = 18;
            this.cbbWorkMode.SelectedIndexChanged += new System.EventHandler(this.cbbWorkMode_SelectedIndexChanged);
            // 
            // cbbTrigSwitch
            // 
            this.cbbTrigSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrigSwitch.FormattingEnabled = true;
            this.cbbTrigSwitch.Location = new System.Drawing.Point(606, 22);
            this.cbbTrigSwitch.Name = "cbbTrigSwitch";
            this.cbbTrigSwitch.Size = new System.Drawing.Size(86, 20);
            this.cbbTrigSwitch.TabIndex = 17;
            // 
            // labTrigSwitch
            // 
            this.labTrigSwitch.AutoEllipsis = true;
            this.labTrigSwitch.Location = new System.Drawing.Point(510, 26);
            this.labTrigSwitch.Name = "labTrigSwitch";
            this.labTrigSwitch.Size = new System.Drawing.Size(90, 33);
            this.labTrigSwitch.TabIndex = 15;
            this.labTrigSwitch.Text = "触发开关";
            this.labTrigSwitch.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labTimingParam
            // 
            this.labTimingParam.AutoEllipsis = true;
            this.labTimingParam.Location = new System.Drawing.Point(203, 29);
            this.labTimingParam.Name = "labTimingParam";
            this.labTimingParam.Size = new System.Drawing.Size(109, 12);
            this.labTimingParam.TabIndex = 14;
            this.labTimingParam.Text = "定时间隔";
            this.labTimingParam.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labWorkMode
            // 
            this.labWorkMode.AutoEllipsis = true;
            this.labWorkMode.Location = new System.Drawing.Point(6, 28);
            this.labWorkMode.Name = "labWorkMode";
            this.labWorkMode.Size = new System.Drawing.Size(92, 30);
            this.labWorkMode.TabIndex = 13;
            this.labWorkMode.Text = "工作模式";
            this.labWorkMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSetWorkMode
            // 
            this.btnSetWorkMode.Location = new System.Drawing.Point(610, 61);
            this.btnSetWorkMode.Name = "btnSetWorkMode";
            this.btnSetWorkMode.Size = new System.Drawing.Size(82, 30);
            this.btnSetWorkMode.TabIndex = 12;
            this.btnSetWorkMode.Text = "设置";
            this.btnSetWorkMode.UseVisualStyleBackColor = true;
            this.btnSetWorkMode.Click += new System.EventHandler(this.btnSetWorkMode_Click);
            // 
            // tbNeighJudge
            // 
            this.tbNeighJudge.Location = new System.Drawing.Point(244, 67);
            this.tbNeighJudge.Name = "tbNeighJudge";
            this.tbNeighJudge.Size = new System.Drawing.Size(60, 21);
            this.tbNeighJudge.TabIndex = 1;
            // 
            // OtherOpreation
            // 
            this.OtherOpreation.Controls.Add(this.GopRelayControl);
            this.OtherOpreation.Controls.Add(this.gbTagAuth);
            this.OtherOpreation.Controls.Add(this.gbUsbFormat);
            this.OtherOpreation.Controls.Add(this.gbBeepControl);
            this.OtherOpreation.Location = new System.Drawing.Point(4, 22);
            this.OtherOpreation.Name = "OtherOpreation";
            this.OtherOpreation.Padding = new System.Windows.Forms.Padding(3);
            this.OtherOpreation.Size = new System.Drawing.Size(798, 442);
            this.OtherOpreation.TabIndex = 4;
            this.OtherOpreation.Text = "其它操作";
            this.OtherOpreation.UseVisualStyleBackColor = true;
            // 
            // GopRelayControl
            // 
            this.GopRelayControl.Controls.Add(this.panel2);
            this.GopRelayControl.Controls.Add(this.panel3);
            this.GopRelayControl.Controls.Add(this.panel1);
            this.GopRelayControl.Controls.Add(this.btnReadRelayTime);
            this.GopRelayControl.Controls.Add(this.btnSetRelayTime);
            this.GopRelayControl.Location = new System.Drawing.Point(18, 305);
            this.GopRelayControl.Name = "GopRelayControl";
            this.GopRelayControl.Size = new System.Drawing.Size(753, 100);
            this.GopRelayControl.TabIndex = 33;
            this.GopRelayControl.TabStop = false;
            this.GopRelayControl.Text = "继电器自动闭合使能";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoOpenRelay);
            this.panel2.Controls.Add(this.rdoCloseRelay);
            this.panel2.Location = new System.Drawing.Point(12, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(159, 61);
            this.panel2.TabIndex = 34;
            // 
            // rdoOpenRelay
            // 
            this.rdoOpenRelay.AccessibleName = "OpenRelay";
            this.rdoOpenRelay.AutoSize = true;
            this.rdoOpenRelay.Location = new System.Drawing.Point(30, 6);
            this.rdoOpenRelay.Name = "rdoOpenRelay";
            this.rdoOpenRelay.Size = new System.Drawing.Size(47, 16);
            this.rdoOpenRelay.TabIndex = 0;
            this.rdoOpenRelay.TabStop = true;
            this.rdoOpenRelay.Text = "主动";
            this.rdoOpenRelay.UseVisualStyleBackColor = true;
            this.rdoOpenRelay.Click += new System.EventHandler(this.rdoOpenRelay_Click);
            // 
            // rdoCloseRelay
            // 
            this.rdoCloseRelay.AccessibleName = "OpenRelay";
            this.rdoCloseRelay.AutoSize = true;
            this.rdoCloseRelay.Location = new System.Drawing.Point(30, 34);
            this.rdoCloseRelay.Name = "rdoCloseRelay";
            this.rdoCloseRelay.Size = new System.Drawing.Size(47, 16);
            this.rdoCloseRelay.TabIndex = 1;
            this.rdoCloseRelay.TabStop = true;
            this.rdoCloseRelay.Text = "被动";
            this.rdoCloseRelay.UseVisualStyleBackColor = true;
            this.rdoCloseRelay.Click += new System.EventHandler(this.rdoCloseRelay_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoOpen1);
            this.panel3.Controls.Add(this.rdoClose1);
            this.panel3.Controls.Add(this.lblCloseTime);
            this.panel3.Controls.Add(this.cbbRelayTime);
            this.panel3.Location = new System.Drawing.Point(175, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 61);
            this.panel3.TabIndex = 34;
            // 
            // rdoOpen1
            // 
            this.rdoOpen1.AccessibleName = "rdo1";
            this.rdoOpen1.AutoSize = true;
            this.rdoOpen1.Location = new System.Drawing.Point(50, 6);
            this.rdoOpen1.Name = "rdoOpen1";
            this.rdoOpen1.Size = new System.Drawing.Size(59, 16);
            this.rdoOpen1.TabIndex = 0;
            this.rdoOpen1.TabStop = true;
            this.rdoOpen1.Text = "打开 1";
            this.rdoOpen1.UseVisualStyleBackColor = true;
            // 
            // rdoClose1
            // 
            this.rdoClose1.AccessibleName = "rdo1";
            this.rdoClose1.AutoSize = true;
            this.rdoClose1.Location = new System.Drawing.Point(50, 34);
            this.rdoClose1.Name = "rdoClose1";
            this.rdoClose1.Size = new System.Drawing.Size(59, 16);
            this.rdoClose1.TabIndex = 1;
            this.rdoClose1.TabStop = true;
            this.rdoClose1.Text = "闭合 1";
            this.rdoClose1.UseVisualStyleBackColor = true;
            // 
            // lblCloseTime
            // 
            this.lblCloseTime.Location = new System.Drawing.Point(6, 3);
            this.lblCloseTime.Name = "lblCloseTime";
            this.lblCloseTime.Size = new System.Drawing.Size(119, 27);
            this.lblCloseTime.TabIndex = 3;
            this.lblCloseTime.Text = "闭合时间";
            this.lblCloseTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbbRelayTime
            // 
            this.cbbRelayTime.FormattingEnabled = true;
            this.cbbRelayTime.Items.AddRange(new object[] {
            "1",
            "5",
            "10"});
            this.cbbRelayTime.Location = new System.Drawing.Point(130, 1);
            this.cbbRelayTime.Name = "cbbRelayTime";
            this.cbbRelayTime.Size = new System.Drawing.Size(82, 20);
            this.cbbRelayTime.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoOpen2);
            this.panel1.Controls.Add(this.rdoClose2);
            this.panel1.Location = new System.Drawing.Point(406, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 63);
            this.panel1.TabIndex = 34;
            // 
            // rdoOpen2
            // 
            this.rdoOpen2.AutoSize = true;
            this.rdoOpen2.Location = new System.Drawing.Point(8, 8);
            this.rdoOpen2.Name = "rdoOpen2";
            this.rdoOpen2.Size = new System.Drawing.Size(59, 16);
            this.rdoOpen2.TabIndex = 0;
            this.rdoOpen2.TabStop = true;
            this.rdoOpen2.Text = "打开 2";
            this.rdoOpen2.UseVisualStyleBackColor = true;
            // 
            // rdoClose2
            // 
            this.rdoClose2.AutoSize = true;
            this.rdoClose2.Location = new System.Drawing.Point(8, 35);
            this.rdoClose2.Name = "rdoClose2";
            this.rdoClose2.Size = new System.Drawing.Size(59, 16);
            this.rdoClose2.TabIndex = 1;
            this.rdoClose2.TabStop = true;
            this.rdoClose2.Text = "闭合 2";
            this.rdoClose2.UseVisualStyleBackColor = true;
            // 
            // btnReadRelayTime
            // 
            this.btnReadRelayTime.Location = new System.Drawing.Point(619, 18);
            this.btnReadRelayTime.Name = "btnReadRelayTime";
            this.btnReadRelayTime.Size = new System.Drawing.Size(75, 23);
            this.btnReadRelayTime.TabIndex = 33;
            this.btnReadRelayTime.Text = "读取";
            this.btnReadRelayTime.UseVisualStyleBackColor = true;
            // 
            // btnSetRelayTime
            // 
            this.btnSetRelayTime.Location = new System.Drawing.Point(619, 50);
            this.btnSetRelayTime.Name = "btnSetRelayTime";
            this.btnSetRelayTime.Size = new System.Drawing.Size(75, 23);
            this.btnSetRelayTime.TabIndex = 11;
            this.btnSetRelayTime.Text = "设置";
            this.btnSetRelayTime.UseVisualStyleBackColor = true;
            this.btnSetRelayTime.Click += new System.EventHandler(this.btnSetRelayTime_Click);
            // 
            // gbTagAuth
            // 
            this.gbTagAuth.Controls.Add(this.labNewAuthPwd);
            this.gbTagAuth.Controls.Add(this.labAuthPwd);
            this.gbTagAuth.Controls.Add(this.tbNewAuthPwd);
            this.gbTagAuth.Controls.Add(this.tbAuthPwd);
            this.gbTagAuth.Controls.Add(this.btnTagAuth);
            this.gbTagAuth.Controls.Add(this.btnModifyAuthPwd);
            this.gbTagAuth.Location = new System.Drawing.Point(18, 27);
            this.gbTagAuth.Name = "gbTagAuth";
            this.gbTagAuth.Size = new System.Drawing.Size(753, 111);
            this.gbTagAuth.TabIndex = 6;
            this.gbTagAuth.TabStop = false;
            this.gbTagAuth.Text = "标签加密";
            // 
            // labNewAuthPwd
            // 
            this.labNewAuthPwd.AutoSize = true;
            this.labNewAuthPwd.Location = new System.Drawing.Point(43, 68);
            this.labNewAuthPwd.Name = "labNewAuthPwd";
            this.labNewAuthPwd.Size = new System.Drawing.Size(53, 12);
            this.labNewAuthPwd.TabIndex = 12;
            this.labNewAuthPwd.Text = "新授权码";
            // 
            // labAuthPwd
            // 
            this.labAuthPwd.AutoSize = true;
            this.labAuthPwd.Location = new System.Drawing.Point(43, 36);
            this.labAuthPwd.Name = "labAuthPwd";
            this.labAuthPwd.Size = new System.Drawing.Size(53, 12);
            this.labAuthPwd.TabIndex = 11;
            this.labAuthPwd.Text = "原授权码";
            // 
            // tbNewAuthPwd
            // 
            this.tbNewAuthPwd.Location = new System.Drawing.Point(226, 65);
            this.tbNewAuthPwd.Name = "tbNewAuthPwd";
            this.tbNewAuthPwd.Size = new System.Drawing.Size(82, 21);
            this.tbNewAuthPwd.TabIndex = 10;
            // 
            // tbAuthPwd
            // 
            this.tbAuthPwd.Location = new System.Drawing.Point(226, 32);
            this.tbAuthPwd.Name = "tbAuthPwd";
            this.tbAuthPwd.Size = new System.Drawing.Size(82, 21);
            this.tbAuthPwd.TabIndex = 9;
            // 
            // btnTagAuth
            // 
            this.btnTagAuth.Location = new System.Drawing.Point(607, 21);
            this.btnTagAuth.Name = "btnTagAuth";
            this.btnTagAuth.Size = new System.Drawing.Size(101, 32);
            this.btnTagAuth.TabIndex = 8;
            this.btnTagAuth.Text = "标签授权";
            this.btnTagAuth.UseVisualStyleBackColor = true;
            this.btnTagAuth.Click += new System.EventHandler(this.btnTagAuth_Click);
            // 
            // btnModifyAuthPwd
            // 
            this.btnModifyAuthPwd.Location = new System.Drawing.Point(607, 59);
            this.btnModifyAuthPwd.Name = "btnModifyAuthPwd";
            this.btnModifyAuthPwd.Size = new System.Drawing.Size(101, 32);
            this.btnModifyAuthPwd.TabIndex = 7;
            this.btnModifyAuthPwd.Text = "修改授权码";
            this.btnModifyAuthPwd.UseVisualStyleBackColor = true;
            this.btnModifyAuthPwd.Click += new System.EventHandler(this.btnModifyAuthPwd_Click);
            // 
            // gbUsbFormat
            // 
            this.gbUsbFormat.Controls.Add(this.btnSetUsbFormat);
            this.gbUsbFormat.Controls.Add(this.cbbUsbFormat);
            this.gbUsbFormat.Location = new System.Drawing.Point(412, 170);
            this.gbUsbFormat.Name = "gbUsbFormat";
            this.gbUsbFormat.Size = new System.Drawing.Size(359, 108);
            this.gbUsbFormat.TabIndex = 5;
            this.gbUsbFormat.TabStop = false;
            this.gbUsbFormat.Text = "USB输出格式(仅限双U口发卡器)";
            // 
            // btnSetUsbFormat
            // 
            this.btnSetUsbFormat.Location = new System.Drawing.Point(213, 46);
            this.btnSetUsbFormat.Name = "btnSetUsbFormat";
            this.btnSetUsbFormat.Size = new System.Drawing.Size(75, 23);
            this.btnSetUsbFormat.TabIndex = 10;
            this.btnSetUsbFormat.Text = "设置";
            this.btnSetUsbFormat.UseVisualStyleBackColor = true;
            this.btnSetUsbFormat.Click += new System.EventHandler(this.btnSetUsbFormat_Click);
            // 
            // cbbUsbFormat
            // 
            this.cbbUsbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsbFormat.FormattingEnabled = true;
            this.cbbUsbFormat.Location = new System.Drawing.Point(17, 49);
            this.cbbUsbFormat.Name = "cbbUsbFormat";
            this.cbbUsbFormat.Size = new System.Drawing.Size(171, 20);
            this.cbbUsbFormat.TabIndex = 2;
            // 
            // gbBeepControl
            // 
            this.gbBeepControl.Controls.Add(this.lblReadVoice);
            this.gbBeepControl.Controls.Add(this.btnReadBeep);
            this.gbBeepControl.Controls.Add(this.btnSetBeep);
            this.gbBeepControl.Controls.Add(this.cbbBeepControl);
            this.gbBeepControl.Location = new System.Drawing.Point(18, 170);
            this.gbBeepControl.Name = "gbBeepControl";
            this.gbBeepControl.Size = new System.Drawing.Size(352, 108);
            this.gbBeepControl.TabIndex = 4;
            this.gbBeepControl.TabStop = false;
            this.gbBeepControl.Text = "读卡控制";
            // 
            // lblReadVoice
            // 
            this.lblReadVoice.AutoSize = true;
            this.lblReadVoice.Location = new System.Drawing.Point(20, 51);
            this.lblReadVoice.Name = "lblReadVoice";
            this.lblReadVoice.Size = new System.Drawing.Size(29, 12);
            this.lblReadVoice.TabIndex = 12;
            this.lblReadVoice.Text = "声音";
            // 
            // btnReadBeep
            // 
            this.btnReadBeep.Location = new System.Drawing.Point(203, 42);
            this.btnReadBeep.Name = "btnReadBeep";
            this.btnReadBeep.Size = new System.Drawing.Size(53, 32);
            this.btnReadBeep.TabIndex = 9;
            this.btnReadBeep.Text = "读取";
            this.btnReadBeep.UseVisualStyleBackColor = true;
            this.btnReadBeep.Visible = false;
            this.btnReadBeep.Click += new System.EventHandler(this.btnReadBeep_Click);
            // 
            // btnSetBeep
            // 
            this.btnSetBeep.Location = new System.Drawing.Point(262, 43);
            this.btnSetBeep.Name = "btnSetBeep";
            this.btnSetBeep.Size = new System.Drawing.Size(53, 32);
            this.btnSetBeep.TabIndex = 9;
            this.btnSetBeep.Text = "设置";
            this.btnSetBeep.UseVisualStyleBackColor = true;
            this.btnSetBeep.Click += new System.EventHandler(this.btnSetBeep_Click);
            // 
            // cbbBeepControl
            // 
            this.cbbBeepControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBeepControl.FormattingEnabled = true;
            this.cbbBeepControl.Location = new System.Drawing.Point(65, 48);
            this.cbbBeepControl.Name = "cbbBeepControl";
            this.cbbBeepControl.Size = new System.Drawing.Size(107, 20);
            this.cbbBeepControl.TabIndex = 2;
            // 
            // timerConnect
            // 
            this.timerConnect.Tick += new System.EventHandler(this.timerConnect_Tick);
            // 
            // cbbLangSwitch
            // 
            this.cbbLangSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLangSwitch.FormattingEnabled = true;
            this.cbbLangSwitch.Items.AddRange(new object[] {
            "简体中文",
            "English"});
            this.cbbLangSwitch.Location = new System.Drawing.Point(738, 9);
            this.cbbLangSwitch.Name = "cbbLangSwitch";
            this.cbbLangSwitch.Size = new System.Drawing.Size(70, 20);
            this.cbbLangSwitch.TabIndex = 1;
            this.cbbLangSwitch.SelectedIndexChanged += new System.EventHandler(this.cbbLangSwitch_SelectedIndexChanged);
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(255, 48);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(529, 303);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(814, 480);
            this.Controls.Add(this.cbbLangSwitch);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisDemo_C#_V1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.gbReadMode.ResumeLayout(false);
            this.gbReadMode.PerformLayout();
            this.gbCommMode.ResumeLayout(false);
            this.gbCommMode.PerformLayout();
            this.TagAccess.ResumeLayout(false);
            this.TagAccess.PerformLayout();
            this.gbFastWrite.ResumeLayout(false);
            this.gbFastWrite.PerformLayout();
            this.gbAdvancedOpr.ResumeLayout(false);
            this.gbAdvancedOpr.PerformLayout();
            this.gbRWData.ResumeLayout(false);
            this.gbRWData.PerformLayout();
            this.SetCommParam.ResumeLayout(false);
            this.gbSPParams.ResumeLayout(false);
            this.gbSPParams.PerformLayout();
            this.gbNetParams.ResumeLayout(false);
            this.gbNetParams.PerformLayout();
            this.SetReaderParam.ResumeLayout(false);
            this.gbFreq.ResumeLayout(false);
            this.gbFreq.PerformLayout();
            this.pnlEUBand.ResumeLayout(false);
            this.pnlEUBand.PerformLayout();
            this.pnlUSBand.ResumeLayout(false);
            this.pnlUSBand.PerformLayout();
            this.gbCommModeParam.ResumeLayout(false);
            this.gbCommModeParam.PerformLayout();
            this.gbWorkMode.ResumeLayout(false);
            this.gbWorkMode.PerformLayout();
            this.OtherOpreation.ResumeLayout(false);
            this.GopRelayControl.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbTagAuth.ResumeLayout(false);
            this.gbTagAuth.PerformLayout();
            this.gbUsbFormat.ResumeLayout(false);
            this.gbBeepControl.ResumeLayout(false);
            this.gbBeepControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage TagAccess;
        private System.Windows.Forms.TabPage SetCommParam;
        private System.Windows.Forms.TabPage SetReaderParam;
        private System.Windows.Forms.Button btnClearListView;
        private System.Windows.Forms.Button btnStopReadData;
        private System.Windows.Forms.Button btnStartReadData;
        private System.Windows.Forms.Button btnReadOnce;
        private ListViewNF listView;
        private System.Windows.Forms.ComboBox comboBoxIP;
        private System.Windows.Forms.Label labCommPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboBoxSerialCommPort;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RadioButton rbNet;
        private System.Windows.Forms.RadioButton rbSerialPort;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.RadioButton rbDesc;
        private System.Windows.Forms.RadioButton rbAsc;
        private System.Windows.Forms.GroupBox gbCommMode;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelTagCount;
        private System.Windows.Forms.Label labReadCount;
        private System.Windows.Forms.Label labTagCount;
        private System.Windows.Forms.TextBox textBoxIPAdd;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxCheckBits;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxIPMode;
        private System.Windows.Forms.ComboBox comboBoxNetMode;
        private System.Windows.Forms.Button btnModifyDev;
        private System.Windows.Forms.Button btnSearchDev;
        private System.Windows.Forms.ListView lvZl;
        private System.Windows.Forms.Label labGateway;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.Label labMask;
        private System.Windows.Forms.Label labIPAdd;
        private System.Windows.Forms.Label labIPMode;
        private System.Windows.Forms.Label labNetMode;
        private System.Windows.Forms.Button btnSetParams;
        private System.Windows.Forms.Button btnDefaultParams;
        private System.Windows.Forms.TextBox textBoxDestPort;
        private System.Windows.Forms.TextBox textBoxDestIP;
        private System.Windows.Forms.TextBox textBoxGateway;
        private System.Windows.Forms.TextBox textBoxPortNo;
        private System.Windows.Forms.TextBox textBoxNetMask;
        private System.Windows.Forms.GroupBox gbNetParams;
        private System.Windows.Forms.Label labPromotion;
        private System.Windows.Forms.Label labDestPort;
        private System.Windows.Forms.Label labDestIP;
        private System.Windows.Forms.GroupBox gbSPParams;
        private System.Windows.Forms.Label labDataBits;
        private System.Windows.Forms.Label labCheckBits;
        private System.Windows.Forms.Label labBaudRate;
        private System.Windows.Forms.ColumnHeader columnHeaderNo;
        private System.Windows.Forms.ColumnHeader columnHeaderIPAdd;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderMAC;
        private System.Windows.Forms.GroupBox gbAdvancedOpr;
        private System.Windows.Forms.Button btnKillTag;
        private System.Windows.Forms.Label labDestroyPwd;
        private System.Windows.Forms.TextBox tbKillKillPwd;
        private System.Windows.Forms.Button btnLockTag;
        private System.Windows.Forms.Label labLockBank;
        private System.Windows.Forms.Label labLockAccessPwd;
        private System.Windows.Forms.TextBox tbLockAccessPwd;
        private System.Windows.Forms.ComboBox cbbLockBank;
        private System.Windows.Forms.GroupBox gbRWData;
        private System.Windows.Forms.Label labData;
        private System.Windows.Forms.Label labLength;
        private System.Windows.Forms.Label labStartAdd;
        private System.Windows.Forms.Label labOprBank;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.TextBox tbRWData;
        private System.Windows.Forms.ComboBox cbbLength;
        private System.Windows.Forms.ComboBox cbbStartAdd;
        private System.Windows.Forms.ComboBox cbbRWBank;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.GroupBox gbWorkMode;
        private System.Windows.Forms.Label labDevNo;
        private System.Windows.Forms.TextBox tbNeighJudge;
        private System.Windows.Forms.TextBox tbNewDevNo;
        private System.Windows.Forms.Button btnSetWorkMode;
        private System.Windows.Forms.Button btnSetFreq;
        private System.Windows.Forms.Label labSetParam;
        private System.Windows.Forms.Timer timerConnect;
        private System.Windows.Forms.ComboBox cbbLangSwitch;
        private System.Windows.Forms.Label labDeviceNo;
        private System.Windows.Forms.TextBox tbDeviceNo;
        private System.Windows.Forms.GroupBox gbReadMode;
        private System.Windows.Forms.RadioButton rbReadMultiTag;
        private System.Windows.Forms.RadioButton rbReadSingleTag;
        private System.Windows.Forms.Button btnInitTag;
        private System.Windows.Forms.Button btnUnlockTag;
        private System.Windows.Forms.GroupBox gbFastWrite;
        private System.Windows.Forms.TextBox tbFWData;
        private System.Windows.Forms.Label labFWPromo;
        private System.Windows.Forms.Button btnClearFWData;
        private System.Windows.Forms.Button btnFastWrite;
        private System.Windows.Forms.Label labFWData;
        private System.Windows.Forms.Label labTrigParam;
        private System.Windows.Forms.Label labTrigSwitch;
        private System.Windows.Forms.Label labTimingParam;
        private System.Windows.Forms.Label labWorkMode;
        private System.Windows.Forms.Button btnDefaultWorkMode;
        private System.Windows.Forms.Button btnReadWorkMode;
        private System.Windows.Forms.Label labDelayUnit;
        private System.Windows.Forms.Label labTimingUnit;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.TextBox tbTiming;
        private System.Windows.Forms.ComboBox cbbWorkMode;
        private System.Windows.Forms.ComboBox cbbTrigSwitch;
        private System.Windows.Forms.CheckBox cbAjaDisc;
        private System.Windows.Forms.GroupBox gbCommModeParam;
        private System.Windows.Forms.Label labWiegandProtocol;
        private System.Windows.Forms.ComboBox cbbWiegandProtocol;
        private System.Windows.Forms.Label labPulseCycle;
        private System.Windows.Forms.Label labPulseWidth;
        private System.Windows.Forms.ComboBox cbbCommMode;
        private System.Windows.Forms.Label labCommMode;
        private System.Windows.Forms.Button btnClearFreq;
        private System.Windows.Forms.Button btnDefaultFreq;
        private System.Windows.Forms.Button btnReadFreq;
        private System.Windows.Forms.CheckBox cbFp20;
        private System.Windows.Forms.CheckBox cbFp19;
        private System.Windows.Forms.CheckBox cbFp18;
        private System.Windows.Forms.CheckBox cbFp17;
        private System.Windows.Forms.CheckBox cbFp16;
        private System.Windows.Forms.CheckBox cbFp15;
        private System.Windows.Forms.CheckBox cbFp14;
        private System.Windows.Forms.CheckBox cbFp13;
        private System.Windows.Forms.CheckBox cbFp12;
        private System.Windows.Forms.CheckBox cbFp11;
        private System.Windows.Forms.CheckBox cbFp10;
        private System.Windows.Forms.CheckBox cbFp9;
        private System.Windows.Forms.CheckBox cbFp8;
        private System.Windows.Forms.CheckBox cbFp7;
        private System.Windows.Forms.CheckBox cbFp6;
        private System.Windows.Forms.CheckBox cbFp5;
        private System.Windows.Forms.CheckBox cbFp4;
        private System.Windows.Forms.CheckBox cbFp3;
        private System.Windows.Forms.CheckBox cbFp2;
        private System.Windows.Forms.CheckBox cbFp1;
        private System.Windows.Forms.Label labFreq;
        private System.Windows.Forms.ComboBox cbbFreqPointUS;
        private System.Windows.Forms.ComboBox cbbFreqModeUS;
        private System.Windows.Forms.ComboBox cbbSingOrMulti;
        private System.Windows.Forms.Label labSingleOrMulti;
        private System.Windows.Forms.Label labPower;
        private System.Windows.Forms.TextBox tbPower;
        private System.Windows.Forms.Button btnDefaultCommMode;
        private System.Windows.Forms.Button btnReadCommMode;
        private System.Windows.Forms.Label labPulseCycleUnit;
        private System.Windows.Forms.Button btnSetCommMode;
        private System.Windows.Forms.Label labPulseWidthUnit;
        private System.Windows.Forms.TextBox tbPulseCycle;
        private System.Windows.Forms.TextBox tbPulseWidth;
        private System.Windows.Forms.GroupBox gbFreq;
        private System.Windows.Forms.CheckBox cbFp50;
        private System.Windows.Forms.CheckBox cbFp49;
        private System.Windows.Forms.CheckBox cbFp48;
        private System.Windows.Forms.CheckBox cbFp47;
        private System.Windows.Forms.CheckBox cbFp46;
        private System.Windows.Forms.CheckBox cbFp45;
        private System.Windows.Forms.CheckBox cbFp44;
        private System.Windows.Forms.CheckBox cbFp43;
        private System.Windows.Forms.CheckBox cbFp42;
        private System.Windows.Forms.CheckBox cbFp41;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbFp40;
        private System.Windows.Forms.CheckBox cbFp39;
        private System.Windows.Forms.CheckBox cbFp38;
        private System.Windows.Forms.CheckBox cbFp37;
        private System.Windows.Forms.CheckBox cbFp36;
        private System.Windows.Forms.CheckBox cbFp35;
        private System.Windows.Forms.CheckBox cbFp34;
        private System.Windows.Forms.CheckBox cbFp33;
        private System.Windows.Forms.CheckBox cbFp32;
        private System.Windows.Forms.CheckBox cbFp31;
        private System.Windows.Forms.CheckBox cbFp30;
        private System.Windows.Forms.CheckBox cbFp29;
        private System.Windows.Forms.CheckBox cbFp28;
        private System.Windows.Forms.CheckBox cbFp27;
        private System.Windows.Forms.CheckBox cbFp26;
        private System.Windows.Forms.CheckBox cbFp25;
        private System.Windows.Forms.CheckBox cbFp24;
        private System.Windows.Forms.CheckBox cbFp23;
        private System.Windows.Forms.CheckBox cbFp22;
        private System.Windows.Forms.CheckBox cbFp21;
        private System.Windows.Forms.TabPage OtherOpreation;
        private System.Windows.Forms.GroupBox gbTagAuth;
        private System.Windows.Forms.Button btnTagAuth;
        private System.Windows.Forms.Button btnModifyAuthPwd;
        private System.Windows.Forms.GroupBox gbUsbFormat;
        private System.Windows.Forms.Button btnSetUsbFormat;
        private System.Windows.Forms.ComboBox cbbUsbFormat;
        private System.Windows.Forms.GroupBox gbBeepControl;
        private System.Windows.Forms.Button btnSetBeep;
        private System.Windows.Forms.ComboBox cbbBeepControl;
        private System.Windows.Forms.Label labNewAuthPwd;
        private System.Windows.Forms.Label labAuthPwd;
        private System.Windows.Forms.TextBox tbNewAuthPwd;
        private System.Windows.Forms.TextBox tbAuthPwd;
        private System.Windows.Forms.CheckBox cbSaveFile;
        private System.Windows.Forms.Label lblWigginsTakePlaceValue;
        private System.Windows.Forms.ComboBox cboWigginsTakePlaceValue;
        private System.Windows.Forms.Label lblReadVoice;
        private System.Windows.Forms.Button btnReadBeep;
        private System.Windows.Forms.GroupBox GopRelayControl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoOpenRelay;
        private System.Windows.Forms.RadioButton rdoCloseRelay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdoOpen1;
        private System.Windows.Forms.RadioButton rdoClose1;
        private System.Windows.Forms.Label lblCloseTime;
        private System.Windows.Forms.ComboBox cbbRelayTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoOpen2;
        private System.Windows.Forms.RadioButton rdoClose2;
        private System.Windows.Forms.Button btnReadRelayTime;
        private System.Windows.Forms.Button btnSetRelayTime;
        private System.Windows.Forms.CheckBox chkZD;
        private System.Windows.Forms.ComboBox cboBand;
        private System.Windows.Forms.Panel pnlEUBand;
        private System.Windows.Forms.ComboBox cboFreqModeEU;
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.ComboBox cboFreqPointEU;
        private System.Windows.Forms.CheckBox chkFp3;
        private System.Windows.Forms.CheckBox chkFp5;
        private System.Windows.Forms.CheckBox chkFp4;
        private System.Windows.Forms.CheckBox chkFp2;
        private System.Windows.Forms.CheckBox chkFp1;
        private System.Windows.Forms.Panel pnlUSBand;
        private System.Windows.Forms.ComboBox cboReadSpeed;
    }
}

