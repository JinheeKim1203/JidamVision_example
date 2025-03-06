using MvCamCtrl.NET;
using OpenCvSharp.Dnn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MvCamCtrl.NET.MyCamera;

namespace JidamVision.Grab
{
    internal class HikRobotCam : GrabModel
    {
        public static MyCamera.cbOutputExdelegate ImageCallback;

        private MyCamera _camera = null;

        #region 
        private bool _disposed = false;
        #endregion


        void ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            if (_userImageBuffer[BufferIndex].ImageBuffer != null)
            {
                if (pFrameInfo.enPixelType == MvGvspPixelType.PixelType_Gvsp_Mono8)
                {
                    if (_userImageBuffer[BufferIndex].ImageBuffer != null)
                        Marshal.Copy(pData, _userImageBuffer[BufferIndex].ImageBuffer, 0, (int)pFrameInfo.nFrameLen);
                }
                else
                {
                    MV_PIXEL_CONVERT_PARAM _pixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                    _pixelConvertParam.nWidth = pFrameInfo.nWidth;  // 넓이/가로폭
                    _pixelConvertParam.nHeight = pFrameInfo.nHeight;  // 높이/세로폭
                    _pixelConvertParam.pSrcData = pData;  // 원본소스 경로
                    _pixelConvertParam.nSrcDataLen = pFrameInfo.nFrameLen;  // 원본 데이터 양(크기,길이 이런의미)
                    _pixelConvertParam.enSrcPixelType = pFrameInfo.enPixelType;  // 픽셀타입(베이어타입)
                    _pixelConvertParam.enDstPixelType = MvGvspPixelType.PixelType_Gvsp_RGB8_Packed; // 변환목적
                    _pixelConvertParam.pDstBuffer = _userImageBuffer[BufferIndex].ImageBufferPtr;
                    _pixelConvertParam.nDstBufferSize = pFrameInfo.nFrameLen * 3; // 변환크기?

                    int nRet = _camera.MV_CC_ConvertPixelType_NET(ref _pixelConvertParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        Console.WriteLine("Convert pixel type Failed:{0:x8}", nRet);
                        return;
                    }

                }


            }

            OnTransferCompleted(BufferIndex);

        }

        internal override bool GetPixelBpp(out int pixelBpp)
        {
            pixelBpp = 8;
            if (_camera == null)
                return false;

            //Get Pixel Format
            MyCamera.MVCC_ENUMVALUE stEnumValue = new MyCamera.MVCC_ENUMVALUE();
            int nRet = _camera.MV_CC_GetEnumValue_NET("PixelFormat", ref stEnumValue);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Get PixelFormat failed: nRet {0:x8}", nRet);
                return false;
            }

            MyCamera.MvGvspPixelType ePixelFormat = (MyCamera.MvGvspPixelType)stEnumValue.nCurValue;

            if (ePixelFormat == MvGvspPixelType.PixelType_Gvsp_Mono8)
                pixelBpp = 8;
            else
                pixelBpp = 24;

            return true;
        }



        internal override bool Create(string strIpAddr = null)
        {
            int nRet = MyCamera.MV_OK;
            _camera = new MyCamera();
            IntPtr pBufForConvert = IntPtr.Zero;

            // ch: 枚举设备 | en:Enum deivce
            MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref stDevList);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Enum device failed:{0:x8}", nRet);
                return false;
            }
            Console.WriteLine("Enum device count :{0} \n", stDevList.nDeviceNum);
            if (0 == stDevList.nDeviceNum)
            {
                return false;
            }

            MyCamera.MV_CC_DEVICE_INFO stDevInfo;

            // ch:打印设备信息 | en:Print device info
            for (Int32 i = 0; i < stDevList.nDeviceNum; i++)
            {
                stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));

                if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    uint nIp1 = ((stGigEDeviceInfo.nCurrentIp & 0xff000000) >> 24);
                    uint nIp2 = ((stGigEDeviceInfo.nCurrentIp & 0x00ff0000) >> 16);
                    uint nIp3 = ((stGigEDeviceInfo.nCurrentIp & 0x0000ff00) >> 8);
                    uint nIp4 = (stGigEDeviceInfo.nCurrentIp & 0x000000ff);
                    Console.WriteLine("[device " + i.ToString() + "]:");
                    Console.WriteLine("DevIP:" + nIp1 + "." + nIp2 + "." + nIp3 + "." + nIp4);
                    Console.WriteLine("UserDefineName:" + stGigEDeviceInfo.chUserDefinedName + "\n");
                }
                else if (MyCamera.MV_USB_DEVICE == stDevInfo.nTLayerType)
                {
                    MyCamera.MV_USB3_DEVICE_INFO stUsb3DeviceInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    Console.WriteLine("[device " + i.ToString() + "]:");
                    Console.WriteLine("SerialNumber:" + stUsb3DeviceInfo.chSerialNumber);
                    Console.WriteLine("UserDefineName:" + stUsb3DeviceInfo.chUserDefinedName + "\n");
                }
            }

            Int32 nDevIndex = 0;
            
            if (nDevIndex > stDevList.nDeviceNum - 1 || nDevIndex < 0)
            {
                Console.Write("Input Error!\n");
                return false;
            }
            stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[nDevIndex], typeof(MyCamera.MV_CC_DEVICE_INFO));

            // ch:创建设备 | en: Create device
            nRet = _camera.MV_CC_CreateDevice_NET(ref stDevInfo);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Create device failed:{0:x8}", nRet);
                return false;
            }

            return true;
        }

        internal override bool Open()
        {
            Thread.Sleep(1000);
            int nRet = MyCamera.MV_OK;

            // ch:打开设备 | en:Open device
            nRet = _camera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Open device failed:{0:x8}", nRet);
                return false;
            }

            // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)

            int nPacketSize = _camera.MV_CC_GetOptimalPacketSize_NET();
            if (nPacketSize > 0)
            {
                nRet = _camera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Warning: Set Packet Size failed {0:x8}", nRet);
                }
            }
            else
            {
                Console.WriteLine("Warning: Get Packet Size failed {0:x8}", nPacketSize);
            }


            // ch:设置触发模式为off || en:set trigger mode as off
            nRet = _camera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Set TriggerMode failed:{0:x8}", nRet);
                return false;
            }
            
            // ch:注册回调函数 | en:Register image callback
            ImageCallback = new MyCamera.cbOutputExdelegate(ImageCallbackFunc);
            nRet = _camera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Register image callback failed!");
                return false;
            }

            // ch:开启抓图 || en: start grab image
            nRet = _camera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Start grabbing failed:{0:x8}", nRet);
                return false;
            }

            nRet = _camera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Set TriggerMode failed:{0:x8}", nRet);
                return false;
            }



            nRet = _camera.MV_CC_SetEnumValue_NET("BalanceWhiteAuto", (uint)MyCamera.MV_CAM_BALANCEWHITE_AUTO.MV_BALANCEWHITE_AUTO_CONTINUOUS);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("BalanceWhiteAuto failed!");
                return false;
            }



            return true;
        }

        internal override bool Grab(int bufferIndex, bool waitDone = true)
        {
            // ch:触发命令 | en:Trigger command
            int nRet = _camera.MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Trigger Software Fail:{0:x8}", nRet);
                return false;
            }

            return true;
        }

        internal override bool Close()
        {
            int nRet = MyCamera.MV_OK;

            // ch:停止抓图 | en:Stop grabbing
            nRet = _camera.MV_CC_StopGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Stop grabbing failed:{0:x8}", nRet);
                return false;
            }

            // ch:关闭设备 | en:Close device
            nRet = _camera.MV_CC_CloseDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Close device failed:{0:x8}", nRet);
                return false;
            }

            // ch:销毁设备 | en:Destroy device
            nRet = _camera.MV_CC_DestroyDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Destroy device failed:{0:x8}", nRet);
                return false;
            }

            return true;
        }
    
        internal override bool GetResolution(out int width, out int height, out int stride)
        {
            width = 0;
            height = 0;
            stride = 0;

            if (_camera == null)
                return false;

            MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
            int nRet = _camera.MV_CC_GetIntValue_NET("Width", ref stParam);

            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Get Width Failed: nRet {0:x8}", nRet);
                return false;
            }

            width = (ushort)stParam.nCurValue;

            nRet = _camera.MV_CC_GetIntValue_NET("Height", ref stParam);

            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Get Height Failed: nRet {0:x8}", nRet);
                return false;
            }
            height = (ushort)stParam.nCurValue;

            MyCamera.MVCC_ENUMVALUE stEnumParam = new MyCamera.MVCC_ENUMVALUE();
            nRet = _camera.MV_CC_GetEnumValue_NET("PixelFormat", ref stEnumParam);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Get PixelFormat Failed: nRet {0:x8}", nRet);
                return false;
            }

            if ((MvGvspPixelType)stEnumParam.nCurValue == MvGvspPixelType.PixelType_Gvsp_Mono8)
                stride = width * 1;
            else
                stride = width * 3;
            
            return true;
        }


        // 2/27 오전 진도 ---> 여기부터
        internal override bool SetExposureTime(long exposure)
        {
            if (_camera == null) return false;

            _camera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
            int nRet = _camera.MV_CC_SetFloatValue_NET("ExposureTime", exposure);
            if (nRet != MyCamera.MV_OK)
            {
                Console.WriteLine("Set Exposure Time Fail!", nRet);
            }
            return true;
        }

        internal override bool GetExposureTime(out long exposure)
        {
            exposure = 0;
            if (_camera == null)
                return false;

            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
            int nRet = _camera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                exposure = (long)stParam.fCurValue;
            }
            return true;
        }
        internal override bool SetGain(long gain)
        {
            if (_camera == null)
                return false;

            _camera.MV_CC_SetEnumValue_NET("GainAuto", 0);

            int nRet = _camera.MV_CC_SetFloatValue_NET("Gain", gain);
            if (nRet != MyCamera.MV_OK)
            {
                Console.WriteLine("Set Gain Time Fail!", nRet);
                return false;
            }

            return true;
        }

        internal override bool GetGain(out long gain)
        {
            gain = 0;
            if (_camera == null)
                return false;

            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
            int nRet = _camera.MV_CC_GetFloatValue_NET("Gain", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                gain = (long)stParam.fCurValue;
            }

            return true;
        }
        // 2/27 오전 진도 <----- 여기까지

        internal override void Dispose()
        {
            Dispose(disposing: true);
        }

        internal void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _camera.MV_CC_CloseDevice_NET();
                _camera.MV_CC_DestroyDevice_NET();
            }
            _disposed = true;
        }

        ~HikRobotCam()
        {
            Dispose(disposing: false);
        }

    }
}
