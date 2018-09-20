#ifndef _DISDLL_H
#define _DISDLL_H

#ifdef APP_EXPORT
#define APP_DLL extern "C" _declspec(dllexport)
#else
#define APP_DLL extern "C" _declspec(dllimport)
#endif  // APP_EXPORT
//-----------------------------------------------------------
#define RECV_BUFF_SIZE				(1024*16)		// 接收缓冲区大小
#define SEND_BUFF_SIZE				(1024)			// 发送缓冲区大小
#define MAX_RECV_BUFFSIZE			(8192)			// 最大接收缓冲区
#define SEND_START_CODE				0xA0			// 发送命令起始码
#define RES_PACK_STARTCODE			0xE4			// 命令响应帧起始码
#define INFO_PACK_STARTCODE			0xE0			// 信息帧起始码
#define HEAD_LENGTH					4				// 命令包头长度
#define PACKAGE_LEN					17				// 连续读卡帧长度
#define MAX_TAG_NUM					50				// 一次接收的最大帧数
//--------------------操作命令码---------------------------------------

#define DIS_MULTI_BEGIN				0x65			// 重置，开始连续寻卡
#define DIS_MULTI_END				0xA8			// 停止寻卡
#define DIS_READ_VERSION			0x6A			// 获取设备版本号
#define DIS_SET_SINGLE_PARA			0x60			// 设置单个参数
#define DIS_GET_SINGLE_PARA			0x61			// 获取单个参数
#define DIS_SET_MULTI_PARA			0x62			// 设置多个参数
#define DIS_GET_MULTI_PARA			0x63			// 获取多个参数
#define DIS_READ_SINGLE_TAG			0x82			// 识别单张标签
#define DIS_READ_TAG_DATA			0x80			// 读标签指定区域数据
#define DIS_WRITE_TAG_DATA			0x81			// 写标签指定区域
#define DIS_WRITE_TAG_MULTI_WORD	0xAB			// 写多字
#define DIS_FAST_WRITE				0x9C			// 快写标签（EPC最后）
#define DIS_TID_BY_EPC				0xAA			// 根据EPC读TID
#define DIS_INIT_TAG				0x99			// 初始化标签
#define DIS_BEEP_CTRL				0xB0			// 设置读卡声音
#define DIS_LOCK_TAG				0xA5			// 锁定标签
#define DIS_UNLOCK_TAG				0xA6			// 解锁标签
#define DIS_KILL_TAG				0x86			// 销毁标签
#define DIS_SET_BAUDRATE			0xA9			// 设置波特率
//#define DIS_STOP_WORK				0x50			// 停止工作
#define DIS_SET_RELAY					0xB1		// 设置继电器
#define DIS_SET_AUTHERPWD	   0x9B			// 设置授权密码
#define DIS_TAG_AUTHER  0x9A			//  读授权密码


//----------------------错误信息---------------------------------------

#define INVALID_COM_PORT			 -2				// 无效串口号
#define INVALID_HANDLE_COM			 -3				// 无效串口句柄
#define INVALID_HOST_PORTORBAUDRATE	 -4				// 无效端口号或波特率
#define INVALID_IPADDRESS			 -5				// 无效IP地址
#define INVALID_POINTER				 -6				// 无效指针
#define INVALID_PARAMETER			 -7				// 无效参数
#define ERROR_OPEN_COM				 -8				// 打开串口出错
#define ERROR_SOCKET_INIT			 -9				// socket初始化出错
#define ERROR_SET_COMMBUFFER		 -10			// 设置网络缓冲区错
#define ERROR_NOT_CONNECT			 -11			// 设备未连接
#define ERROR_SET_DCB				 -12			// 设置DCB出错
#define ERROR_COM_SEND				 -13			// 串口发送出错
#define ERROR_COM_RECV				 -14			// 串口接收出错
#define ERROR_CREATE_SOCKET			 -15			// 创建socket出错
#define ERROR_SOCKET_CONNECT		 -16			// socket连接出错
#define ERROR_SOCKET_SEND			 -17			// socket发送出错
#define ERROR_SOCKET_RECV			 -18			// socket接收出错
#define ERROR_UNKNOWN				 -19			// 未知错误

//------------------------加锁、解锁操作区-----------------------------
#define LOCK_USER					  0				// 用户区
#define LOCK_TID					  1				// TID区
#define LOCK_EPC					  2				// EPC区
#define LOCK_ACCESS					  3				// 保留区
#define LOCK_KILL					  4				// 灭活区
#define LOCK_ALL					  5				// 全部区域

//--------------------------波特率-------------------------------------
#define BR_9600						  0
#define BR_19200						  1
#define BR_38400						  2
#define BR_57600						  3
#define BR_115200					  4
//--------------------------工作模式-----------------------------------
#define WM_MASTER_SLAVE	1
#define WM_TIMING					2
#define WM_TRIG						3
//--------------------------韦根协议-----------------------------------
#define Wiegand26							1
#define Wiegand34							2
#define Wiegand32							3
//--------------------------通信模式-----------------------------------

#define MODE_RS485					  1
#define MODE_Wiegend				  2
#define MODE_RS232					  3
//--------------------------读卡器参数地址码---------------------------
#define ADD_USERCODE							0x64
#define ADD_POWER									0x65
#define ADD_WORKMODE						0x70
#define ADD_TIME_INTERVAL					0x71
#define ADD_COMM_MODE						0x72
#define ADD_WIEGAND_PROTO				0x73
#define ADD_WIEGAND_PULSEWIDTH 0x74
#define ADD_WIEGAND_PULSECYCLE	0x75
#define ADD_NEIGHJUDGE_TIME			0x7A
#define ADD_NEIGHJUDGE_SET				0x7B
#define ADD_TRIG_SWITCH						0x80
#define ADD_TRIG_MODE							0x81
#define ADD_TRIG_DELAYTIME				0x84
#define ADD_BAUD_RATE							0x85
#define ADD_SINGLE_OR_MULTI_TAG 0x87
#define ADD_ANT_MODE						   0x89
#define ADD_ANT_SET							  0x8A
#define ADD_FREQUENCY_SET			  0x90
#define ADD_FREQUENCY_PARA_92	  0x92
#define ADD_FREQUENCY_PARA_93	  0x93
#define ADD_FREQUENCY_PARA_94	  0x94
#define ADD_FREQUENCY_PARA_95	  0x95
#define ADD_FREQUENCY_PARA_96    0x96
#define ADD_FREQUENCY_PARA_97    0x97
#define ADD_FREQUENCY_PARA_98    0x98
#define ADD_SERIAL								  0x34
#define ADD_DELAYER_TIME				  0xC6

#define MASK_BIT_0								  0x1
#define MASK_BIT_1								  0x2
#define MASK_BIT_2								  0x4
#define MASK_BIT_3								 0x8
#define MASK_BIT_4								  0x10
#define MASK_BIT_5								  0x20
#define MASK_BIT_6								  0x40
#define MASK_BIT_7								  0x80





typedef struct _PACKAGE
{
	BYTE startcode;  // 起始码
	BYTE len;		 // 长度
	BYTE cmd;		 // 命令码
	BYTE usercode;	 // 设备码
	BYTE data[100];	 // 数据
	BYTE bcc;		 // 校验码
}PACKAGE, *PPACKAGE;
//---------------------------回调函数----------------------------------------------------------------------------------------
typedef void (CALLBACK * HANDLE_FUN)(BYTE* pData, int length);

//--------------------------导出函数-------------------------------------------------------------------------------------------
APP_DLL void   _stdcall  PrintBuffer(BYTE* pBuf, int length);
APP_DLL int   _stdcall  GetErrorMessage();
/*-------------------------------------------------------------------------------
  1、名称：GetErrorMessage
  2、功能：获取错误号
  3、参数：无
  4、返回值：错误号
********************************************************************************/
APP_DLL bool  _stdcall  DeviceInit(char* pHost, int CommMode, int PortOrBandRate);
/*-------------------------------------------------------------------------------
   1、名称：deviceInit
   2、功能：设置主机串,确定连接方式，并初始化设备层各全局变量		
   3、参数：pHost IP地址字符串，　串口模式时忽略该参数
			CommMode　通信方式，0代表网络模式，1-9是串口模式，同时是串口号
			PortOrBaudRate 通信端口号或波特率。
   4、返回值
			TRUE   初始化成功
			FALSE　初始化失败
   5、错误值
			 INVALID_IPADDRESS  			// 无效IP地址
			 INVALID_COMM_PORT		 		// 无效串口号
			 INVALID_HOST_PORTORBANDRATE	// 无效端口号或波特率
			 INVALID_POINTER		    	// 空指针
			 ERROR_SOCKET_INIT				// 网络初始化错
********************************************************************************/
APP_DLL bool   _stdcall  DeviceConnect();
/*------------------------------------------------------------------------------- 
   1、名称：deviceConnect
　 2、功能：连接设备
   3、参数：无
　 4、返回值：
			TRUE  连接成功
			FALSE 连接失败
   5、错误值
			ERROR_CREATE_SOCKET				// 创建socket出错
			ERROR_SOCKET_CONNECT			// socket连接出错
			INVALID_COM_PORT				// 无效串口号
			ERROR_OPEN_COM					// 打开串口出错
/********************************************************************************/
APP_DLL bool   _stdcall  DeviceDisconnect();
/*------------------------------------------------------------------------------- 
　 1、名称：deviceDisconnect
　 2、功能：断开设备连接
   3、函数参数：无
　 4、返回值：
			TRUE  连接成功
			FALSE 连接失败
*********************************************************************************/
APP_DLL bool   _stdcall  DeviceUninit();
/*------------------------------------------------------------------------------- 
　 1、名称：deviceUnInit
　 2、功能：恢复初始值		
   3、参数：无
   4、返回值：
			TRUE  连接成功
			FALSE 连接失败
*********************************************************************************/

APP_DLL bool   _stdcall  ResetReader(unsigned char usercode);
/*------------------------------------------------------------------------------- 
	1、名称:  ResetReader
	2、功能:  重置读卡器，进入连续读卡状态
	3、参数:  usercode  设备号
	4、返回值:
			TRUE 重置读卡器成功
			FALSE 重置失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/

APP_DLL bool   _stdcall  BeginMultiInv(unsigned char usercode, HANDLE_FUN fun_name  );
/*------------------------------------------------------------------------------- 
	1、名称:  BeginMultiInv
	2、功能:  连续寻卡
	3、参数:  fun_name 调用者定义的回调函数
						usercode  设备号
	4、返回值:
			TRUE 成功返回
			FALSE 设置失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_POINTER				// 无效函数指针
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  StopInv(unsigned char usercode);
/*------------------------------------------------------------------------------- 
	1、名称:  StopInv
	2、功能:  停止寻卡
	3、参数:  usercode  设备号
	4、返回值:
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_POINTER				// 无效函数指针
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/

APP_DLL bool   _stdcall  GetDeviceVersion(unsigned char usercode, int* pMainVerion, int* pSubVersion);
/*------------------------------------------------------------------------------- 
	1、名称:  GetDeviceVersion
	2、功能:  获取设备版本号
	3、参数: 
						usercode  设备号
						pMainVersion 主版本号地址
						pSubVersion  副版本号地址
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_POINTER				// 无效函数指针
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  GetSingleParameter(unsigned char usercode, unsigned char ParaAddr, unsigned char* pValue);
/*------------------------------------------------------------------------------- 
	1、名称:  GetSingleParameter
	2、功能:  获取单个参数
	3、参数: 
						usercode  设备号
						ParaAddr　参数地址
						pValue  保存参数值的变量地址
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_POINTER				// 无效函数指针
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/

APP_DLL bool   _stdcall  SetSingleParameter(unsigned char usercode, unsigned char ParaAddr, unsigned char Value);
/*------------------------------------------------------------------------------- 
	1、名称:  SetSingleParameter
	2、功能:  设置单个参数
	3、参数:  
						usercode  设备号
						ParaAddr　参数地址
						 Value  参数值
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/

APP_DLL bool   _stdcall  GetMultiParameters(unsigned char usercode, int addr, int NumOfPara, unsigned char* pParas);
/*------------------------------------------------------------------------------- 
	1、名称:  GetMultiParameters
	2、功能:  获取多个参数
	3、参数:  
							usercode  设备号
							addr　参数地址
							NumOfPara 参数个数
							pParas  保存参数值的缓冲区地址
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  SetMultiParameters(unsigned char usercode,  int addr, int NumOfPara, unsigned char* pParas);
/*------------------------------------------------------------------------------- 
	1、名称:  SetMultiParameters
	2、功能:  设置多个参数
	3、参数: 
							usercode  设备号
							addr　参数地址
							NumOfPara 参数个数
							pParas  保存参数值的缓冲区地址
	4、返回值
			  TRUE 成功
			  FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/

APP_DLL bool   _stdcall  ReadSingleTag(unsigned char& usercode,  unsigned char* pTagID, unsigned char* pAntNo);
/*------------------------------------------------------------------------------- 
	1、名称:  ReadSingleTag
	2、功能:  读单张标签
	3、参数:  
						usercode  设备号
						pTagID　EPC地址
						 pAntNo 保存天线号地址
	4、返回值
			  TRUE 成功
			  FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  ReadTagData(unsigned char usercode,  unsigned char bank, unsigned char begin, unsigned char length, unsigned char* pOutData);
/*-------------------------------------------------------------------------------
	1、名称: ReadTagData
	2、功能: 获取读取标签指定区域的数据
	3、参数
			usercode  设备号
			bank: 要读取的数据区域
			begin:开始地址
			length: 要读取的字数
			pOutData: 存储数据buffer
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool  _stdcall   WriteTagData(unsigned char usercode, unsigned char bank, unsigned char begin, unsigned char length, unsigned char* pData);// 0x81
/*------------------------------------------------------------------------------- 
	1、名称: WriteTagData
	2、功能: 写标签到指定区域
	3、参数
			usercode  设备号
			bank: 写入的数据区域
			begin:开始地址
			length: 写入的字数
			pData: 存储数据buffer
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  WriteTagMultiWord(unsigned char usercode, unsigned char bank, unsigned char begin, unsigned char length, unsigned char* pData);// 0xAB
/*------------------------------------------------------------------------------- 
	1、名称: WriteTagMultiWord
	2、功能: 写多个字节到指定区域
	3、参数
			usercode  设备号
			bank: 写入的数据区域
			begin:开始地址
			length: 写入的字数
			pData: 存储数据buffer
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool  _stdcall   WriteTagSingleWord(unsigned char usercode, unsigned char bank, unsigned char begin, unsigned char data1, unsigned char data2);
/*------------------------------------------------------------------------------- 
	1、名称: WriteTagSingleWord
	2、功能: 写单字到指定区域
	3、参数
			usercode  设备号
			bank: 写入的数据区域
			begin:开始地址
			data1: 第一字节
			data2: 第二字节
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/


APP_DLL bool   _stdcall  FastWriteTag(unsigned char usercode, unsigned char* pData, unsigned char length);
/*------------------------------------------------------------------------------- 
	1、名称: FastWriteTag
	2、功能: 快写标签EPC
	3、参数
			usercode  设备号
			 pData : 数据区地址
			 length: 数据区长度
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/

APP_DLL bool   _stdcall  ReadTIDByEpc(unsigned char usercode, const unsigned char* pEpc, unsigned char* pTID);
/*------------------------------------------------------------------------------- 
	1、名称: ReadTIDByEpc
	2、功能: 根据EPC读TID
	3、参数
			usercode  设备号
			 pEpc: EPC数据区地址
			 pTID: 保存TID数据区地址
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  InitializeTag(unsigned char usercode );
/*------------------------------------------------------------------------------- 
	1、名称: InitializeTag
	2、功能: 初始化标签
	3、参数
			usercode  设备号
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/

APP_DLL bool   _stdcall  BeepCtrl(unsigned char usercode, unsigned char status);
/*------------------------------------------------------------------------------- 
	1、名称: BeepCtrl
	2、功能: 设置读卡声音
	3、参数
			usercode  设备号
			status 设置值  0  取消
											1	 打开读卡的Beep声
											2   单独响一次Beep声
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/


APP_DLL bool   _stdcall  LockTag(unsigned char usercode, unsigned char lockBank, unsigned char* pPassword);
/*------------------------------------------------------------------------------- 
	1、名称: LockTag
	2、功能: 锁定标签
	3、参数
			usercode  设备号
			lockBank　操作区域
			pPassword: 口令
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_BANK					// 无效区域号
			INVALID_OPCODE					// 无效操作码
			INVALID_PASSWORD				// 无效口令
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL bool   _stdcall  UnlockTag(unsigned char usercode, unsigned char unlockBank, unsigned char* pPassword);
/*------------------------------------------------------------------------------- 
	1、名称: UnlockTag
	2、功能: 解锁标签
	3、参数
			usercode  设备号
			unlockBank　操作区域
			pPassword: 口令
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_BANK					// 无效区域号
			INVALID_OPCODE					// 无效操作码
			INVALID_PASSWORD				// 无效口令
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL bool  _stdcall   KillTag(unsigned char usercode, unsigned char* pPassword);
/*------------------------------------------------------------------------------- 
	1、名称:  KillTag
	2、功能:  销毁标签
	3、参数
						usercode  设备号
						pPassword　　灭活密码
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_BANK					// 无效区域号
			INVALID_OPCODE					// 无效操作码
			INVALID_PASSWORD				// 无效口令
			ERROR_DEV_CONNECT				// 设备未连接
			ERROR_DEV_SEND					// 设备发送错
			ERROR_DEV_RECV					// 设备接收错
			ERROR_OPER_FAIL					// 操作失败
*********************************************************************************/
APP_DLL bool   _stdcall  SetBaudRate(unsigned char usercode, unsigned char BaudRate);
/*------------------------------------------------------------------------------- 
	1、名称: SetBaudRate
	2、功能: 设置波特率
	3、参数
			usercode  设备号
			BaudRate 设置值
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			INVALID_PARAMETER			// 无效参数
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  StopWork(unsigned char usercode );
/*------------------------------------------------------------------------------- 
	1、名称: StopWork
	2、功能: 停止工作
	3、参数
						usercode  设备号
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			ERROR_NOT_CONNECT			// 设备没有连接
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  SetRelay(unsigned char usercode , unsigned char relayOnOff );
/*------------------------------------------------------------------------------- 
	1、名称: SetRelay
	2、功能: 打开或关闭继电器
	3、参数
						usercode  设备号
						relayOnOff 继电器状态
								0，关闭
								1，
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			ERROR_NOT_CONNECT			// 设备没有连接
			INVALID_PARAMETER		 // 无效参数
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/

APP_DLL bool   _stdcall  SetRelayTime(unsigned char usercode , unsigned char time );
/*------------------------------------------------------------------------------- 
	1、名称: SetRelay
	2、功能: 打开或关闭继电器
	3、参数
						usercode  设备号
						time 继电器闭合时间，单位为秒。共3个值：1, 5, 10
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			ERROR_NOT_CONNECT			// 设备没有连接
			INVALID_PARAMETER		 // 无效参数
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  SetAutherPwd(unsigned char usercode , unsigned char* pPwd );
/*------------------------------------------------------------------------------- 
	1、名称: SetAutherPwd
	2、功能: 设置读卡器授权密码
	3、参数
						usercode  设备号
						pPwd 存放2个字节授权密码的地址
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			ERROR_NOT_CONNECT			// 设备没有连接
			INVALID_PARAMETER		 // 无效参数
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  TagAuther(unsigned char usercode);
/*------------------------------------------------------------------------------- 
	1、名称: TagAuther
	2、功能: 给标签认证授权
	3、参数
						usercode  设备号
	4、返回值
			TRUE 成功
			FALSE 失败
	5、错误值
			INVALID_HANDLE_COM			// 无效串口句柄
			ERROR_NOT_CONNECT			// 设备没有连接
			INVALID_PARAMETER		 // 无效参数
			ERROR_COM_SEND				// 串口发送出错
			ERROR_COM_RECV				// 串口接收出错
			ERROR_SOCKET_CONNECT		// 网络连接出错
			ERROR_SOCKET_SEND			// 网络发送出错
			ERROR_SOCKET_RECV			// 网络接收出错
			ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
APP_DLL bool   _stdcall  GetAutherPwd(unsigned char usercode , unsigned char* pPwd );
/*--------------------------------------------------------------------------------------------------------------------------------------
1、名称: GetAutherPwd
2、功能: 读取授权密码
3、参数
				usercode  设备号
				pPwd 存放2个字节授权密码的地址
4、返回值
TRUE 成功
FALSE 失败
5、错误值
INVALID_HANDLE_COM			// 无效串口句柄
ERROR_NOT_CONNECT			// 设备没有连接
INVALID_PARAMETER		 // 无效参数
ERROR_COM_SEND				// 串口发送出错
ERROR_COM_RECV				// 串口接收出错
ERROR_SOCKET_CONNECT		// 网络连接出错
ERROR_SOCKET_SEND			// 网络发送出错
ERROR_SOCKET_RECV			// 网络接收出错
ERROR_UNKNOWN				// 未知错误
*********************************************************************************/
#endif  // _DISDLL_H