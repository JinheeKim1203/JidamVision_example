using JidamVision.Algorithm;
using JidamVision.Core;
using JidamVision.Grab;
using JidamVision.Setting;
using JidamVision.Teach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace JidamVision.Property
{
    public partial class FmInspProp : UserControl
    {

        public FmInspProp()
        {
            InitializeComponent();

            //최초 로딩시, 환경설정 정보 로딩
            LoadSetting();
        }

        public void LoadInspParam()
        {

            //#BINARY FILTER#8 이진화 필터값을 GUI에 로딩
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow != null)
            {
                //#INSP WORKER#13 inspWindow에서 이진화 알고리즘 찾는 코드
                FmInspAlgorithm fmAlgo = (FmInspAlgorithm)inspWindow.FindInspAlgorithm(InspectType.InspFm);
                if (fmAlgo != null)
                {
                    int diffGv = fmAlgo.DifferanceGv;
                    txtDiffGv.Text = diffGv.ToString();

                    int sizeX = fmAlgo.SizeX;
                    txtSizeX.Text = sizeX.ToString();

                    int sizeY = fmAlgo.SizeY;
                    txtSizeY.Text = sizeY.ToString();
                }
            }

        }

        private void LoadSetting()
        {
            //컬러 타입을 콤보박스에 추가
            cbDiffGvColor.DataSource = Enum.GetValues(typeof(DiffGVColor)).Cast<DiffGVColor>().ToList();
            //환경설정에서 현재 컬러 타입 얻기
            cbDiffGvColor.SelectedIndex = (int)SettingXml.Inst.CamType;
        }
    }
}
