using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JidamVision.Algorithm;
using OpenCvSharp;
using JidamVision.Core;
using System.Drawing;
using System.Security.Policy;
using System.IO;


namespace JidamVision.Teach

//#MATCH PROP#3 InspWindow 클래스 추가, ROI 관리 및 검사를 처리하는 클래스
//검사 알고리즘를 관리하는 클래스
{
    public class InspWindow
    {
        //템플릿 매칭할 윈도우 크기
        private System.Drawing.Rectangle _rect;
        //템플릿 매칭 이미지
        private Mat _teachingImage;

        public InspWindowType InspWindowType {  get; private set; }

        public string Name {  get; private set; }
        public string UID { get; set; }

        public Rect WindowArea { get; set; }

        //#ABSTRACT ALGORITHM#9 개별 변수로 있던, MatchAlgorithm과 BlobAlgorithm을
        //InspAlgorithm으로 추상화하여 리스트로 관리하도록 

        //private MatchAlgorithm _matchAlgorithm;

        //private List<OpenCvSharp.Point> _outPoints;

        //public MatchAlgorithm MatchAlgorithm => _matchAlgorithm;

        ////#BINARY FILTER#5 이진화 알고리즘 추가
        ////이진화 검사 클래스
        //private BlobAlgorithm _blobAlgorithm;

        //public BlobAlgorithm BlobAlgorithm => _blobAlgorithm;

        public List<InspAlgorithm> AlgorithmList { get; set; } = new List<InspAlgorithm>();

        public InspWindow()
        {

            //#ABSTRACT ALGORITHM#13 매칭 알고리즘과 이진화 알고리즘 추가
            AddInspAlgorithm(InspectType.InspMatch);
            AddInspAlgorithm(InspectType.InspBinary);

            //_matchAlgorithm = new MatchAlgorithm();

            ////#BINARY FILTER#6 이진화 알고리즘 인스턴스 생성
            //_blobAlgorithm = new BlobAlgorithm();
        }

        public InspWindow(InspWindowType windowType, string name)
        {
            InspWindowType = windowType;
            Name = name;
            AddInspAlgorithm(InspectType.InspMatch);
            AddInspAlgorithm(InspectType.InspBinary);
        }

        public bool SetTeachingImage(Mat image, Rectangle rect)
        {
            _rect = rect;
            _teachingImage = new Mat(image, new Rect(rect.X, rect.Y, rect.Width, rect.Height));
            return true;
        }


        //#MATCH PROP#4 템플릿 매칭 이미지 로딩
        public bool PatternLearn()
        {

            //if (_matchAlgorithm == null)
            //    return false;

            //string templatePath = Path.Combine(Directory.GetCurrentDirectory(), Define.ROI_IMAGE_NAME);
            //if (File.Exists(templatePath))
            //{
            //    _teachingImage = Cv2.ImRead(templatePath);

            //    if (_teachingImage != null)
            //        _matchAlgorithm.SetTemplateImage(_teachingImage);
            //}

            //return true;

            foreach (var algorithm in AlgorithmList)
            {
                if (algorithm.InspectType != InspectType.InspMatch)
                    continue;

                MatchAlgorithm matchAlgo = (MatchAlgorithm)algorithm;

                string templatePath = Path.Combine(Directory.GetCurrentDirectory(), Define.ROI_IMAGE_NAME);
                if (File.Exists(templatePath))
                {
                    _teachingImage = Cv2.ImRead(templatePath);

                    if (_teachingImage != null)
                        matchAlgo.SetTemplateImage(_teachingImage);
                }
            }

            return true;
        }

        //#ABSTRACT ALGORITHM#10 타입에 따라 알고리즘을 추가하는 함수
        public bool AddInspAlgorithm(InspectType inspType)
        {
            InspAlgorithm inspAlgo = null;

            switch (inspType)
            {
                case InspectType.InspBinary:
                    inspAlgo = new BlobAlgorithm();
                    break;
                case InspectType.InspMatch:
                    inspAlgo = new MatchAlgorithm();
                    break;
            }

            if (inspAlgo is null)
                return false;

            AlgorithmList.Add(inspAlgo);

            return true;
        }

        //#ABSTRACT ALGORITHM#11 알고리즘을 리스트로 관리하므로, 필요한 타입의 알고리즘을 찾는 함수
        public InspAlgorithm FindInspAlgorithm(InspectType inspType)
        {
            foreach (var algorithm in AlgorithmList)
            {
                if (algorithm.InspectType == inspType)
                    return algorithm;
            }

            return null;
        }

        //#MATCH PROP#5 템플릿 매칭 검사
        //#ABSTRACT ALGORITHM#12 클래스 내에서, 인자로 입력된 타입의 알고리즘을 검사하거나,
        ///모든 알고리즘을 검사하는 옵션을 가지는 검사 함수
        public bool DoInspect(InspectType inspType)
        {
            foreach (var inspAlgo in AlgorithmList)
            {
                if (inspAlgo.InspectType == inspType || inspAlgo.InspectType == InspectType.InspNone)
                    inspAlgo.DoInspect();
              
            }
                //if (_teachingImage is null)
                //    return false;

                //if (_matchAlgorithm is null)
                //    _matchAlgorithm = new MatchAlgorithm();

                //Mat srcImage = Global.Inst.InspStage.GetMat();

                //if (_matchAlgorithm.MatchCount == 1)
                //{
                //    if (_matchAlgorithm.MatchTemplateSingle(srcImage) == false)
                //        return false;

                //    _outPoints = new List<OpenCvSharp.Point>();
                //    _outPoints.Add(_matchAlgorithm.OutPoint);
                //}
                //else
                //{
                //    int matchCount = _matchAlgorithm.MatchTemplateMultiple(srcImage, out _outPoints);
                //    if (matchCount <= 0)
                //        return false;
                //}
                return true;
        }

        //#MATCH PROP#6 템플릿 매칭 검사 결과 위치를 Rectangle 리스트로 반환

        //public int GetMatchRect(out List<Rect> rects)
        //{
        //    rects = new List<Rect>();

        //    int halfwidth = _teachingImage.Width;
        //    int halfheight = _teachingImage.Height;

        //    foreach (var point in _outPoints)
        //    {
        //        Console.WriteLine($"매칭된 위치: {_outPoints}");
        //        rects.Add(new Rect(point.X - halfwidth, point.Y - halfheight, _teachingImage.Width, _teachingImage.Height));
        //    }

        //    return rects.Count;

        //}
    }
}
