using JidamVision.Core;
using JidamVision.Grab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JidamVision.Setting
{
    public partial class NetworkSetting : UserControl
    {
        public NetworkSetting()
        {
            InitializeComponent();

            //최초 로딩시, 환경설정 정보 로딩
            LoadSetting();
        }
        private void LoadSetting()
        {
            //네트워크 타입을 콤보박스에 추가
            cbCommunicationType.DataSource = Enum.GetValues(typeof(NetworkType)).Cast<NetworkType>().ToList();
            //환경설정에서 현재 카메라 타입 얻기
            cbCommunicationType.SelectedIndex = (int)SettingXml.Inst.NetType;
            //환경설정에서 모델 저장 경로 얻기
            txtIpAddress.Text = SettingXml.Inst.IpAddress;

        }

        private void SaveSetting()
        {
            //환경설정에 카메라 타입 설정
            SettingXml.Inst.NetType = (NetworkType)cbCommunicationType.SelectedIndex;
            //환경설정에 모델 저장 경로 설정
            SettingXml.Inst.IpAddress = txtIpAddress.Text;
            //환경설정 저장
            SettingXml.Save();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }
    }
}
