namespace JidamVision.Property
{
    partial class BinaryInspProp
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
                if (trackBarLower != null)
                    trackBarLower.ValueChanged -= OnValueChanged;

                if (trackBarUpper != null)
                    trackBarUpper.ValueChanged -= OnValueChanged;

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBinary = new System.Windows.Forms.GroupBox();
            this.chkShowBinary = new System.Windows.Forms.CheckBox();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.chkHighlight = new System.Windows.Forms.CheckBox();
            this.trackBarUpper = new System.Windows.Forms.TrackBar();
            this.trackBarLower = new System.Windows.Forms.TrackBar();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.chkWidth = new System.Windows.Forms.CheckBox();
            this.chkHeight = new System.Windows.Forms.CheckBox();
            this.txtMaxArea = new System.Windows.Forms.TextBox();
            this.txtMinArea = new System.Windows.Forms.TextBox();
            this.txtMaxWidth = new System.Windows.Forms.TextBox();
            this.txtMinWidth = new System.Windows.Forms.TextBox();
            this.txtMaxHeight = new System.Windows.Forms.TextBox();
            this.txtMinHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.grpBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBinary
            // 
            this.grpBinary.Controls.Add(this.chkShowBinary);
            this.grpBinary.Controls.Add(this.chkInvert);
            this.grpBinary.Controls.Add(this.chkHighlight);
            this.grpBinary.Controls.Add(this.trackBarUpper);
            this.grpBinary.Controls.Add(this.trackBarLower);
            this.grpBinary.Location = new System.Drawing.Point(3, 3);
            this.grpBinary.Name = "grpBinary";
            this.grpBinary.Size = new System.Drawing.Size(304, 170);
            this.grpBinary.TabIndex = 0;
            this.grpBinary.TabStop = false;
            this.grpBinary.Text = "이진화";
            // 
            // chkShowBinary
            // 
            this.chkShowBinary.AutoSize = true;
            this.chkShowBinary.Location = new System.Drawing.Point(125, 125);
            this.chkShowBinary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkShowBinary.Name = "chkShowBinary";
            this.chkShowBinary.Size = new System.Drawing.Size(60, 16);
            this.chkShowBinary.TabIndex = 6;
            this.chkShowBinary.Text = "이진화";
            this.chkShowBinary.UseVisualStyleBackColor = true;
            this.chkShowBinary.CheckedChanged += new System.EventHandler(this.chkBinaryOnly_CheckedChanged);
            // 
            // chkInvert
            // 
            this.chkInvert.AutoSize = true;
            this.chkInvert.Location = new System.Drawing.Point(23, 145);
            this.chkInvert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Size = new System.Drawing.Size(48, 16);
            this.chkInvert.TabIndex = 5;
            this.chkInvert.Text = "반전";
            this.chkInvert.UseVisualStyleBackColor = true;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.chkInvert_CheckedChanged);
            // 
            // chkHighlight
            // 
            this.chkHighlight.AutoSize = true;
            this.chkHighlight.Checked = true;
            this.chkHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlight.Location = new System.Drawing.Point(23, 125);
            this.chkHighlight.Name = "chkHighlight";
            this.chkHighlight.Size = new System.Drawing.Size(72, 16);
            this.chkHighlight.TabIndex = 3;
            this.chkHighlight.Text = "Highlight";
            this.chkHighlight.UseVisualStyleBackColor = true;
            this.chkHighlight.CheckedChanged += new System.EventHandler(this.chkHighlight_CheckedChanged);
            // 
            // trackBarUpper
            // 
            this.trackBarUpper.Location = new System.Drawing.Point(23, 74);
            this.trackBarUpper.Maximum = 255;
            this.trackBarUpper.Name = "trackBarUpper";
            this.trackBarUpper.Size = new System.Drawing.Size(219, 45);
            this.trackBarUpper.TabIndex = 1;
            this.trackBarUpper.Value = 255;
            // 
            // trackBarLower
            // 
            this.trackBarLower.Location = new System.Drawing.Point(23, 23);
            this.trackBarLower.Maximum = 255;
            this.trackBarLower.Name = "trackBarLower";
            this.trackBarLower.Size = new System.Drawing.Size(219, 45);
            this.trackBarLower.TabIndex = 0;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblMax);
            this.grpFilter.Controls.Add(this.lblMin);
            this.grpFilter.Controls.Add(this.label3);
            this.grpFilter.Controls.Add(this.label2);
            this.grpFilter.Controls.Add(this.label1);
            this.grpFilter.Controls.Add(this.txtMinHeight);
            this.grpFilter.Controls.Add(this.txtMaxHeight);
            this.grpFilter.Controls.Add(this.txtMinWidth);
            this.grpFilter.Controls.Add(this.txtMaxWidth);
            this.grpFilter.Controls.Add(this.txtMinArea);
            this.grpFilter.Controls.Add(this.txtMaxArea);
            this.grpFilter.Controls.Add(this.chkHeight);
            this.grpFilter.Controls.Add(this.chkWidth);
            this.grpFilter.Controls.Add(this.chkArea);
            this.grpFilter.Controls.Add(this.btnFilter);
            this.grpFilter.Controls.Add(this.lblArea);
            this.grpFilter.Controls.Add(this.txtArea);
            this.grpFilter.Location = new System.Drawing.Point(3, 178);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFilter.Size = new System.Drawing.Size(304, 209);
            this.grpFilter.TabIndex = 4;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(178, -2);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(73, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "필터적용";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(4, 27);
            this.lblArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(31, 12);
            this.lblArea.TabIndex = 1;
            this.lblArea.Text = "Area";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(66, 0);
            this.txtArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(71, 21);
            this.txtArea.TabIndex = 0;
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.Location = new System.Drawing.Point(5, 60);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(50, 16);
            this.chkArea.TabIndex = 3;
            this.chkArea.Text = "Area";
            this.chkArea.UseVisualStyleBackColor = true;
            // 
            // chkWidth
            // 
            this.chkWidth.AutoSize = true;
            this.chkWidth.Location = new System.Drawing.Point(5, 95);
            this.chkWidth.Name = "chkWidth";
            this.chkWidth.Size = new System.Drawing.Size(54, 16);
            this.chkWidth.TabIndex = 4;
            this.chkWidth.Text = "Width";
            this.chkWidth.UseVisualStyleBackColor = true;
            // 
            // chkHeight
            // 
            this.chkHeight.AutoSize = true;
            this.chkHeight.Location = new System.Drawing.Point(5, 130);
            this.chkHeight.Name = "chkHeight";
            this.chkHeight.Size = new System.Drawing.Size(59, 16);
            this.chkHeight.TabIndex = 5;
            this.chkHeight.Text = "Height";
            this.chkHeight.UseVisualStyleBackColor = true;
            // 
            // txtMaxArea
            // 
            this.txtMaxArea.Location = new System.Drawing.Point(198, 55);
            this.txtMaxArea.Name = "txtMaxArea";
            this.txtMaxArea.Size = new System.Drawing.Size(100, 21);
            this.txtMaxArea.TabIndex = 6;
            // 
            // txtMinArea
            // 
            this.txtMinArea.Location = new System.Drawing.Point(71, 55);
            this.txtMinArea.Name = "txtMinArea";
            this.txtMinArea.Size = new System.Drawing.Size(100, 21);
            this.txtMinArea.TabIndex = 7;
            // 
            // txtMaxWidth
            // 
            this.txtMaxWidth.Location = new System.Drawing.Point(198, 91);
            this.txtMaxWidth.Name = "txtMaxWidth";
            this.txtMaxWidth.Size = new System.Drawing.Size(100, 21);
            this.txtMaxWidth.TabIndex = 8;
            // 
            // txtMinWidth
            // 
            this.txtMinWidth.Location = new System.Drawing.Point(71, 91);
            this.txtMinWidth.Name = "txtMinWidth";
            this.txtMinWidth.Size = new System.Drawing.Size(100, 21);
            this.txtMinWidth.TabIndex = 9;
            // 
            // txtMaxHeight
            // 
            this.txtMaxHeight.Location = new System.Drawing.Point(198, 128);
            this.txtMaxHeight.Name = "txtMaxHeight";
            this.txtMaxHeight.Size = new System.Drawing.Size(100, 21);
            this.txtMaxHeight.TabIndex = 10;
            // 
            // txtMinHeight
            // 
            this.txtMinHeight.Location = new System.Drawing.Point(71, 128);
            this.txtMinHeight.Name = "txtMinHeight";
            this.txtMinHeight.Size = new System.Drawing.Size(100, 21);
            this.txtMinHeight.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "~";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "~";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(102, 35);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(26, 12);
            this.lblMin.TabIndex = 15;
            this.lblMin.Text = "Min";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(233, 35);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(30, 12);
            this.lblMax.TabIndex = 16;
            this.lblMax.Text = "Max";
            // 
            // BinaryInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpBinary);
            this.Name = "BinaryInspProp";
            this.Size = new System.Drawing.Size(327, 405);
            this.grpBinary.ResumeLayout(false);
            this.grpBinary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBinary;
        private System.Windows.Forms.TrackBar trackBarUpper;
        private System.Windows.Forms.TrackBar trackBarLower;
        private System.Windows.Forms.CheckBox chkHighlight;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.CheckBox chkInvert;
        private System.Windows.Forms.CheckBox chkShowBinary;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.CheckBox chkHeight;
        private System.Windows.Forms.CheckBox chkWidth;
        private System.Windows.Forms.CheckBox chkArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinHeight;
        private System.Windows.Forms.TextBox txtMaxHeight;
        private System.Windows.Forms.TextBox txtMinWidth;
        private System.Windows.Forms.TextBox txtMaxWidth;
        private System.Windows.Forms.TextBox txtMinArea;
        private System.Windows.Forms.TextBox txtMaxArea;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
    }
}
