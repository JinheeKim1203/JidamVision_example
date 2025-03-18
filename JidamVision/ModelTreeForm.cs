﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using JidamVision.Core;
using JidamVision.Teach;
using OpenCvSharp;

namespace JidamVision
{
    //# MODEL TREE#1 디자인창에서 모델 생성 후 아래 코드 구현
    public partial class ModelTreeForm : DockContent
    {
        //개별 트리 노트에서 팝업 메뉴 보이기를 위한 메뉴
        private ContextMenuStrip _contextMenu;

        public ModelTreeForm()
        {
            InitializeComponent();

            //초기 트리 노트의 기본값은 "Root"
            tvModelTree.Nodes.Add("Root");

            // 컨텍스트 메뉴 초기화
            _contextMenu = new ContextMenuStrip();
            ToolStripMenuItem addBaseRoiItem = new ToolStripMenuItem("Base", null, AddNode_Click) { Tag = "Base" };
            ToolStripMenuItem addSubRoiItem = new ToolStripMenuItem("Sub", null, AddNode_Click) { Tag = "Sub" };
            ToolStripMenuItem addIdRoiItem = new ToolStripMenuItem("ID", null, AddNode_Click) { Tag = "ID" };
            ToolStripMenuItem addHeadRoiItem = new ToolStripMenuItem("Head", null, AddNode_Click) { Tag = "Head" };
            ToolStripMenuItem addBodyRoiItem = new ToolStripMenuItem("Body", null, AddNode_Click) { Tag = "Body" };


            _contextMenu.Items.Add(addBaseRoiItem);
            _contextMenu.Items.Add(addSubRoiItem);
            _contextMenu.Items.Add(addIdRoiItem);
            _contextMenu.Items.Add(addHeadRoiItem);
            _contextMenu.Items.Add(addBodyRoiItem);

        }

        private void tvModelTree_MouseDown(object sender, MouseEventArgs e)
        {
            //Root 노드에서 마우스 오른쪽 버튼 클릭 시에, 팝업 메뉴 생성
            if (e.Button == MouseButtons.Right)
            {
                TreeNode clickedNode = tvModelTree.GetNodeAt(e.X, e.Y);
                if (clickedNode != null && clickedNode.Text == "Root") ;
                {
                    tvModelTree.SelectedNode = clickedNode;
                    _contextMenu.Show(tvModelTree, e.Location);
                }
            }

        }

        //팝업 메뉴에서, 메뉴 선택시 실행되는 함수
        private void AddNode_Click(object sender, EventArgs e)
        {
            if (tvModelTree.SelectedNode != null & sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                string nodeType = menuItem.Tag?.ToString();
                if (nodeType == "Base")
                {
                    AddNewROI(InspWindowType.Base);
                }
                else if (nodeType == "Sub")
                {
                    AddNewROI(InspWindowType.Sub);
                }
                else if (nodeType == "ID")
                {
                    AddNewROI(InspWindowType.ID);
                }
                else if (nodeType == "Head")
                {
                    AddNewROI(InspWindowType.Head);
                }
                else if (nodeType == "Body")
                {
                    AddNewROI(InspWindowType.Body);
                }
            }
        }

        //imageViewer에 ROI 추가 기능 실행
        private void AddNewROI(InspWindowType inspWindowType)
        {
            CameraForm cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.AddRoi(inspWindowType);
            }
        }

        //#MODEL#14 현재 모델 전체의 ROI를 트리 모델에 업데이트
        public void UpdateDiagramEntity()
        {
            tvModelTree.Nodes.Clear();
            TreeNode rootNode = tvModelTree.Nodes.Add("Root");

            Model model = Global.Inst.InspStage.CurModel;
            List<InspWindow> windowList = model.InspWindowList;
            if (windowList.Count <= 0)
                return;

            foreach (InspWindow window in model.InspWindowList)
            {
                if (window is null)
                    continue;

                string uid = window.UID;

                TreeNode node = new TreeNode(uid);
                rootNode.Nodes.Add(node);
            }

            tvModelTree.ExpandAll();
        }


    }
}
