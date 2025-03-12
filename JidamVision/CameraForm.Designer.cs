namespace JidamVision
{
    partial class CameraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGrab = new System.Windows.Forms.Button();
            this.btnLive = new System.Windows.Forms.Button();
            this.imageViewer = new JidamVision.ImageViewCCtrl();
            this.grpChannel = new System.Windows.Forms.GroupBox();
            this.rbtnGrayChannel = new System.Windows.Forms.RadioButton();
            this.rbtnGreenChannel = new System.Windows.Forms.RadioButton();
            this.rbtnBlueChannel = new System.Windows.Forms.RadioButton();
            this.rbtnRedChannel = new System.Windows.Forms.RadioButton();
            this.btnSetRoi = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.grpChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(500, 18);
            this.btnGrab.Margin = new System.Windows.Forms.Padding(4);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(107, 34);
            this.btnGrab.TabIndex = 1;
            this.btnGrab.Text = "Grab";
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // btnLive
            // 
            this.btnLive.Location = new System.Drawing.Point(500, 62);
            this.btnLive.Margin = new System.Windows.Forms.Padding(4);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(107, 34);
            this.btnLive.TabIndex = 3;
            this.btnLive.Text = "Live";
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // imageViewer
            // 
            this.imageViewer.AutoSize = true;
            this.imageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageViewer.Location = new System.Drawing.Point(13, 30);
            this.imageViewer.Margin = new System.Windows.Forms.Padding(6);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.RoiMode = false;
            this.imageViewer.Size = new System.Drawing.Size(473, 406);
            this.imageViewer.TabIndex = 2;
            // 
            // grpChannel
            // 
            this.grpChannel.Controls.Add(this.rbtnGrayChannel);
            this.grpChannel.Controls.Add(this.rbtnGreenChannel);
            this.grpChannel.Controls.Add(this.rbtnBlueChannel);
            this.grpChannel.Controls.Add(this.rbtnRedChannel);
            this.grpChannel.Location = new System.Drawing.Point(501, 278);
            this.grpChannel.Name = "grpChannel";
            this.grpChannel.Size = new System.Drawing.Size(106, 154);
            this.grpChannel.TabIndex = 4;
            this.grpChannel.TabStop = false;
            this.grpChannel.Text = "Channel";
            // 
            // rbtnGrayChannel
            // 
            this.rbtnGrayChannel.AutoSize = true;
            this.rbtnGrayChannel.Location = new System.Drawing.Point(6, 122);
            this.rbtnGrayChannel.Name = "rbtnGrayChannel";
            this.rbtnGrayChannel.Size = new System.Drawing.Size(71, 22);
            this.rbtnGrayChannel.TabIndex = 3;
            this.rbtnGrayChannel.TabStop = true;
            this.rbtnGrayChannel.Text = "Gray";
            this.rbtnGrayChannel.UseVisualStyleBackColor = true;
            // 
            // rbtnGreenChannel
            // 
            this.rbtnGreenChannel.AutoSize = true;
            this.rbtnGreenChannel.Location = new System.Drawing.Point(6, 94);
            this.rbtnGreenChannel.Name = "rbtnGreenChannel";
            this.rbtnGreenChannel.Size = new System.Drawing.Size(81, 22);
            this.rbtnGreenChannel.TabIndex = 2;
            this.rbtnGreenChannel.TabStop = true;
            this.rbtnGreenChannel.Text = "Green";
            this.rbtnGreenChannel.UseVisualStyleBackColor = true;
            // 
            // rbtnBlueChannel
            // 
            this.rbtnBlueChannel.AutoSize = true;
            this.rbtnBlueChannel.Location = new System.Drawing.Point(6, 66);
            this.rbtnBlueChannel.Name = "rbtnBlueChannel";
            this.rbtnBlueChannel.Size = new System.Drawing.Size(67, 22);
            this.rbtnBlueChannel.TabIndex = 1;
            this.rbtnBlueChannel.TabStop = true;
            this.rbtnBlueChannel.Text = "Blue";
            this.rbtnBlueChannel.UseVisualStyleBackColor = true;
            // 
            // rbtnRedChannel
            // 
            this.rbtnRedChannel.AutoSize = true;
            this.rbtnRedChannel.Location = new System.Drawing.Point(6, 38);
            this.rbtnRedChannel.Name = "rbtnRedChannel";
            this.rbtnRedChannel.Size = new System.Drawing.Size(64, 22);
            this.rbtnRedChannel.TabIndex = 0;
            this.rbtnRedChannel.TabStop = true;
            this.rbtnRedChannel.Text = "Red";
            this.rbtnRedChannel.UseVisualStyleBackColor = true;
            // 
            // btnSetRoi
            // 
            this.btnSetRoi.Location = new System.Drawing.Point(500, 105);
            this.btnSetRoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetRoi.Name = "btnSetRoi";
            this.btnSetRoi.Size = new System.Drawing.Size(107, 34);
            this.btnSetRoi.TabIndex = 3;
            this.btnSetRoi.Text = "Set ROI";
            this.btnSetRoi.UseVisualStyleBackColor = true;
            this.btnSetRoi.Click += new System.EventHandler(this.btnSetRoi_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(500, 149);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 34);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 444);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpChannel);
            this.Controls.Add(this.btnSetRoi);
            this.Controls.Add(this.btnLive);
            this.Controls.Add(this.imageViewer);
            this.Controls.Add(this.btnGrab);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CameraForm";
            this.Text = "CameraForm";
            this.Resize += new System.EventHandler(this.CameraForm_Resize);
            this.grpChannel.ResumeLayout(false);
            this.grpChannel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGrab;
        private ImageViewCCtrl imageViewer;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.GroupBox grpChannel;
        private System.Windows.Forms.RadioButton rbtnRedChannel;
        private System.Windows.Forms.RadioButton rbtnGrayChannel;
        private System.Windows.Forms.RadioButton rbtnGreenChannel;
        private System.Windows.Forms.RadioButton rbtnBlueChannel;
        public System.Windows.Forms.Button btnSetRoi;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}