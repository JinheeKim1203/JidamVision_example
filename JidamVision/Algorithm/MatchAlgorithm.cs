﻿using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JidamVision.Algorithm
{
    public class MatchAlgorithm : InspAlgorithm
    {

        private Mat _templateImage;


        public int MatchScore { get; set; } = 60;

        public Size ExtSize { get; set; } = new Size(100, 100);

        public int OutScore { get; set; } = 0;

        public Point OutPoint { get; set; } = new Point(0, 0);

        public int MatchCount { get; set; } = 1;

        private int _scanStep = 8;

        public MatchAlgorithm()
        {
        }

        public void SetTemplateImage(Mat templateImage)
        {
            _templateImage = templateImage;
        }

        /// <summary>
        /// 하나의 최적 매칭 위치만 찾기
        /// </summary>
        public bool MatchTemplateSingle(Mat image)
        {

            if (_templateImage is null)
                return false;

            Mat result = new Mat();

            // 템플릿 매칭 수행
            Cv2.MatchTemplate(image, _templateImage, result, TemplateMatchModes.CCoeffNormed);

            // 가장 높은 점수 위치 찾기
            Cv2.MinMaxLoc(result, out _, out double maxVal, out _, out Point maxLoc);

            OutScore = (int)(maxVal * 100);

            Console.WriteLine($"최적 매칭 위치: {maxLoc}, 신뢰도: {maxVal:F2}");

            OutPoint = new Point(maxLoc.X + _templateImage.Width, maxLoc.Y + _templateImage.Height);

            return true;
        }

        /// <summary>
        /// 여러 개의 매칭 위치 찾기 (임계값 이상인 경우)
        /// </summary>
        public int MatchTemplateMultiple(Mat image, out List<Point> matchedPositions)
        {
            matchedPositions = new List<Point>();
            float matchThreshold = MatchScore / 100.0f;
            Mat result = new Mat();


            // 템플릿 매칭 수행(정규화된 상관 계수 방식)
            Cv2.MatchTemplate(image, _templateImage, result, TemplateMatchModes.CCoeffNormed);

            List<Rect> detectedRegions = new List<Rect>();
            int templateWidth = _templateImage.Width;
            int templateHeight = _templateImage.Height;

            int halfWidth = templateWidth / 2;
            int halfHeight = templateHeight / 2;

            // 임계값(threshold) 이상인 위치 찾기
            for (int y = 0; y < result.Rows; y += _scanStep)
            {
                for (int x = 0; x < result.Cols; x += _scanStep)
                {
                    float score = result.At<float>(y, x);

                    if (score < matchThreshold)
                        continue;

                    Point matchLoc = new Point(x, y);

                    // 기존 매칭된 위치들과 겹치는지 확인
                    bool overlaps = false;
                    foreach (var rect in detectedRegions)
                    {
                        if (rect.Contains(matchLoc))
                        {
                            overlaps = true;
                            break;
                        }
                    }
                    if (overlaps)
                        continue;

                    Point bestPoint = matchLoc;

                    //수직 & 수평 검색 수행하여 가장 좋은 위치 찾기
                    // 수직 검색 (위→아래)
                    int indexR = bestPoint.Y;
                    bool isFindVert = false;
                    while (true)
                    {
                        indexR++;
                        if (indexR >= result.Rows)
                            break;

                        float candidateScore = result.At<float>(indexR, bestPoint.X);
                        if (score > candidateScore)
                        {
                            isFindVert = true;
                            break;
                        }
                        else
                        {
                            score = candidateScore;
                            bestPoint.Y++;
                        }
                    }

                    if (!isFindVert)
                        continue;

                    //수평 검색 (좌 → 우)
                    int indexC = bestPoint.X;
                    bool isFindHorz = false;
                    while (true)
                    {
                        indexC++;
                        if (indexC >= result.Cols)
                            break;

                        float candidateScore = result.At<float>(bestPoint.Y, indexC);
                        if (score > candidateScore)
                        {
                            isFindHorz = true;
                            break;
                        }
                        else
                        {
                            score = candidateScore;
                            bestPoint.X++;
                        }
                    }

                    if (!isFindHorz)
                        continue;

                    // 매칭된 위치 리스트에 추가
                    Point matchPos = new Point(bestPoint.X + templateWidth, bestPoint.Y + templateHeight);
                    matchedPositions.Add(matchPos);
                    detectedRegions.Add(new Rect(bestPoint.X - halfWidth, bestPoint.Y - halfHeight, templateWidth, templateHeight));
                }
            }
            return matchedPositions.Count;
        }
    }

}