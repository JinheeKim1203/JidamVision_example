namespace JidamVision.Property
{
    partial class MatchInspProp
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMatch = new System.Windows.Forms.GroupBox();
            this.lblExtend = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.txtExtendY = new System.Windows.Forms.TextBox();
            this.txtExtendX = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.grpMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMatch
            // 
            this.grpMatch.Controls.Add(this.txtScore);
            this.grpMatch.Controls.Add(this.txtExtendX);
            this.grpMatch.Controls.Add(this.txtExtendY);
            this.grpMatch.Controls.Add(this.lblX);
            this.grpMatch.Controls.Add(this.lblScore);
            this.grpMatch.Controls.Add(this.lblExtend);
            this.grpMatch.Location = new System.Drawing.Point(3, 3);
            this.grpMatch.Name = "grpMatch";
            this.grpMatch.Size = new System.Drawing.Size(434, 244);
            this.grpMatch.TabIndex = 1;
            this.grpMatch.TabStop = false;
            this.grpMatch.Text = "패턴매칭";
            // 
            // lblExtend
            // 
            this.lblExtend.AutoSize = true;
            this.lblExtend.Location = new System.Drawing.Point(23, 60);
            this.lblExtend.Name = "lblExtend";
            this.lblExtend.Size = new System.Drawing.Size(80, 18);
            this.lblExtend.TabIndex = 0;
            this.lblExtend.Text = "확장영역";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(23, 131);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(98, 18);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "매칭스코어";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(251, 61);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(19, 18);
            this.lblX.TabIndex = 2;
            this.lblX.Text = "X";
            // 
            // txtExtendY
            // 
            this.txtExtendY.Location = new System.Drawing.Point(290, 55);
            this.txtExtendY.Name = "txtExtendY";
            this.txtExtendY.Size = new System.Drawing.Size(100, 28);
            this.txtExtendY.TabIndex = 3;
            // 
            // txtExtendX
            // 
            this.txtExtendX.Location = new System.Drawing.Point(132, 55);
            this.txtExtendX.Name = "txtExtendX";
            this.txtExtendX.Size = new System.Drawing.Size(100, 28);
            this.txtExtendX.TabIndex = 4;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(132, 131);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(258, 28);
            this.txtScore.TabIndex = 5;
            // 
            // MatchInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMatch);
            this.Name = "MatchInspProp";
            this.Size = new System.Drawing.Size(440, 247);
            this.grpMatch.ResumeLayout(false);
            this.grpMatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMatch;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.TextBox txtExtendX;
        private System.Windows.Forms.TextBox txtExtendY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblExtend;
    }
}
