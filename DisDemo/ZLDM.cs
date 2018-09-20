using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DisDemo
{
      public class ZLDM
    {
        public static  ushort m_DevCnt;    // 搜索到的设备数量
        public static byte m_SelectedDevNo = 0;
        [DllImport ("ZlDevManage.dll", EntryPoint = "ZLDM_StartSearchDev")]
        public static extern UInt16 StartSearchDev();

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetVer")]
        public static extern int GetVer();

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetParam")]
        public static extern bool SetParam(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint="ZLDM_GetDevID")]
        public static extern IntPtr GetDevID(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetDevName")]
        public static extern IntPtr GetDevName(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetIPMode")]
        public static extern byte GetIPMode(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetIP")]
        public static extern IntPtr GetIP(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetPort")]
        public static extern ushort GetPort(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetGateWay")]
        unsafe public static extern IntPtr GetGateWay(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetWorkMode")]
        public static extern byte  GetWordMode(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetNetMask")]
         public static extern IntPtr GetNetMask(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetDestName")]
         public static extern IntPtr GetDestName(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetDestPort")]
        public static extern ushort GetDestPort(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetBaudrateIndex")]
        public static extern byte GetBaudrateIndex(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetParity")]
        public static extern byte GetParity(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_GetDataBits")]
        public static extern byte GetDataBits(byte nNum);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetDevName")]
        unsafe public static extern bool SetDevName(byte nNum, char* DevName);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetIP")]
        unsafe public static extern bool SetIP(byte nNum,  byte[] IP);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetGateWay")]
        unsafe public static extern bool SetGateWay(byte nNum, byte[] GateWay);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetNetMask")]
        unsafe public static extern bool SetNetMask(byte nNum, byte[] NetMask);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetDestName")]
        unsafe public static extern bool SetDestName(byte nNum, byte[] DestName);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetIPMode")]
        public static extern bool SetIPMode(byte nNum, byte IPMode);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetPort")]
        public static extern bool SetPort(byte nNum, ushort Port);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetWorkMode")]
        public static extern bool SetWorkMode(byte nNum, byte WorkMode);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetDestPort")]
        public static extern bool SetDestPort(byte nNum, ushort DestPort);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetBaudrateIndex")]
        public static extern bool SetBaudrateIndex(byte nNum, byte BaudrateIndex);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetParity")]
        public static extern bool SetParity(byte nNum, byte Parity);

        [DllImport("ZlDevManage.dll", EntryPoint = "ZLDM_SetDataBits")]
        public static extern bool SetDataBits(byte nNum, byte DataBits);

  }

}


/* 函数指针定义 */
//typedef zl_u16	(__stdcall * tZLDM_StartSearchDev)();
//typedef  int		(__stdcall * tZLDM_GetVer)();
//typedef  zl_bool (__stdcall * tZLDM_SetParam)(zl_u8 nNum);

////V2.0 Add
//typedef  zl_s8 * (__stdcall * tZLDM_GetDevID)(zl_u8 nNum);
//typedef zl_u8	(__stdcall * tZLDM_GetStatus)(zl_u8 nNum);
//typedef zl_s8 * (__stdcall * tZLDM_GetDevName)(zl_u8 nNum);
//typedef zl_u8	(__stdcall * tZLDM_GetIPMode)(zl_u8 nNum);
//typedef zl_s8 *	(__stdcall * tZLDM_GetIP)(zl_u8 nNum);
//typedef zl_u16	(__stdcall * tZLDM_GetPort)(zl_u8 nNum);
//typedef zl_s8 *	(__stdcall * tZLDM_GetGateWay)(zl_u8 nNum);
//typedef zl_u8	(__stdcall * tZLDM_GetWorkMode)(zl_u8 nNum);
//typedef zl_s8 *	(__stdcall * tZLDM_GetNetMask)(zl_u8 nNum);
//typedef zl_s8 *	(__stdcall * tZLDM_GetDestName)(zl_u8 nNum);
//typedef zl_u16	(__stdcall * tZLDM_GetDestPort)(zl_u8 nNum);

////baud rate param
//typedef zl_u8	(__stdcall * tZLDM_GetBaudrateIndex)(zl_u8 nNum);
//typedef zl_u8	(__stdcall * tZLDM_GetParity)(zl_u8 nNum);
//typedef zl_u8	(__stdcall * tZLDM_GetDataBits)(zl_u8 nNum);
//typedef zl_u8	(__stdcall * tZLDM_GetFlowControl)(zl_u8 nNum);


////设置
//typedef zl_bool	(__stdcall * tZLDM_SetDevName)(zl_u8 nNum, zl_s8 * DevName);
//typedef zl_bool	(__stdcall * tZLDM_SetIPMode)(zl_u8 nNum, zl_u8 IPMode);
//typedef zl_bool	(__stdcall * tZLDM_SetIP)(zl_u8 nNum, zl_s8 * IP);
//typedef zl_bool	(__stdcall * tZLDM_SetPort)(zl_u8 nNum, zl_u16 Port);
//typedef zl_bool	(__stdcall * tZLDM_SetGateWay)(zl_u8 nNum, zl_s8 * GateWay);
//typedef zl_bool	(__stdcall * tZLDM_SetWorkMode)(zl_u8 nNum, zl_u8 WorkMode);
//typedef zl_bool	(__stdcall * tZLDM_SetNetMask)(zl_u8 nNum, zl_s8 * NetMask);
//typedef zl_bool	(__stdcall * tZLDM_SetDestName)(zl_u8 nNum, zl_s8 * DestName);
//typedef zl_bool	(__stdcall * tZLDM_SetDestPort)(zl_u8 nNum, zl_u16 DestPort);

////baud rate param
//typedef zl_bool	(__stdcall * tZLDM_SetBaudrateIndex)(zl_u8 nNum, zl_u8 Baudrate);
//typedef zl_bool	(__stdcall * tZLDM_SetParity)(zl_u8 nNum, zl_u8 Parity);
//typedef zl_bool	(__stdcall * tZLDM_SetDataBits)(zl_u8 nNum, zl_u8 DataBits);
//typedef zl_bool	(__stdcall * tZLDM_SetFlowControl)(zl_u8 nNum, zl_u8 FlowControl);
