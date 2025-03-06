using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JidamVision.Grab
{
    public enum CameraType
    {
        None = 0,
        WebCam,
        HikVision
    }
    struct GrabUserBuffer
    {
        private byte[] _imageBuffer;
        private IntPtr _imageBufferPtr;
        private GCHandle _imageHandle;

        public byte[] ImageBuffer
        {
            get
            {
                return _imageBuffer;
            }
            set
            {
                _imageBuffer = value;
            }
        }
        public IntPtr ImageBufferPtr
        {
            get
            {
                return _imageBufferPtr;
            }
            set
            {
                _imageBufferPtr = value;
            }
        }
        public GCHandle ImageHandle
        {
            get
            {
                return _imageHandle;
            }
            set
            {
                _imageHandle = value;
            }
        }
    }

    internal abstract class GrabModel
    {
        //유저버퍼 올리기
        // 콜백 필요하긴 하나 hik와 웹캠은 콜백  방식이 다르므로 올리진 않음
        // 카메라 기능적인 부분은 대부분 올리면 됨
        // 다른 자식클래서에서 없을수도 있는 기능은 virtual로 만들기

        public delegate void GrabEventHandler<T>(object sender, T obj = null) where T : class;

        public event GrabEventHandler<object> GrabCompleted;
        public event GrabEventHandler<object> TransferCompleted;

        protected GrabUserBuffer[] _userImageBuffer = null;

        protected string _strIpAddr = "";
        public int BufferIndex { get; set; } = 0;

        internal bool HardwareTrigger { get; set; } = false;

        internal bool IncreaseBufferIndex { get; set; } = false;

        internal abstract bool Create(string strIpAddr = null); // 카메라 생성할때 IP주소를 입력 받음 : 여러개의 카메라를 사용할때 사용
        // string strIpAddr = null  -->  기본값을 설정
        internal abstract bool Grab(int bufferIndex, bool waitDone = true);

        internal abstract bool Open();

        internal abstract bool Close();

        internal virtual bool Reconnect()
        {
            return false;
        }

        internal abstract bool GetPixelBpp(out int pixelBpp);

        internal abstract bool SetExposureTime(long exposure);

        internal abstract bool GetExposureTime(out long exposure);

        internal abstract bool SetGain(long gain);

        internal abstract bool GetGain(out long gain);

        internal abstract bool GetResolution(out int width, out int height, out int stride);

        internal virtual bool SetTriggerMode(bool hardwareTrigger) { return true; }
        internal bool InitGrab()
        {
            if (!Create())
                return false;

            if (!Open())
                return false;

            return true;
        }

        internal bool InitBuffer(int bufferCount = 1)  // 다른 클래스에서 자식클래스의 InitBuffer를 호출할때 부모클래스까지 타고 넘어옴
        {
            if (bufferCount < 1)
                return false;

            _userImageBuffer = new GrabUserBuffer[bufferCount];
            return true;
        }

        internal bool SetBuffer(byte[] buffer, IntPtr bufferPtr, GCHandle bufferHandle, int bufferIndex = 0)
        {
            _userImageBuffer[bufferIndex].ImageBuffer = buffer;
            _userImageBuffer[bufferIndex].ImageBufferPtr = bufferPtr;
            _userImageBuffer[bufferIndex].ImageHandle = bufferHandle;

            return true;
        }

        protected virtual void OnGrabCompleted(object obj = null)
        {
            GrabCompleted?.Invoke(this, obj);
        }
        protected virtual void OnTransferCompleted(object obj = null)
        {
            TransferCompleted?.Invoke(this, obj);
        }

        internal abstract void Dispose();







    }

}
