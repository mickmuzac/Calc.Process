namespace calc.process
{
    partial class Visual
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
            this.submitButton = new System.Windows.Forms.Button();
            this.functionBox = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.dxLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endValueLabel = new System.Windows.Forms.Label();
            this.endIntegral = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xScale = new System.Windows.Forms.TrackBar();
            this.yScale = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endIntegral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(132, 82);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(127, 23);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Visualize";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // functionBox
            // 
            this.functionBox.Location = new System.Drawing.Point(63, 56);
            this.functionBox.Name = "functionBox";
            this.functionBox.Size = new System.Drawing.Size(296, 20);
            this.functionBox.TabIndex = 2;
            this.functionBox.Text = "1x^3";
            this.functionBox.Click += new System.EventHandler(this.functionBox_Click);
            this.functionBox.TextChanged += new System.EventHandler(this.functionBox_TextChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(542, 24);
            this.trackBar1.Maximum = -1;
            this.trackBar1.Minimum = -7;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(267, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = -4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // dxLabel
            // 
            this.dxLabel.AutoSize = true;
            this.dxLabel.Location = new System.Drawing.Point(631, 56);
            this.dxLabel.Name = "dxLabel";
            this.dxLabel.Size = new System.Drawing.Size(81, 13);
            this.dxLabel.TabIndex = 6;
            this.dxLabel.Text = "dx Value: .0001";
            this.dxLabel.Click += new System.EventHandler(this.dxLabel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endValueLabel);
            this.groupBox1.Controls.Add(this.endIntegral);
            this.groupBox1.Controls.Add(this.functionBox);
            this.groupBox1.Controls.Add(this.dxLabel);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.submitButton);
            this.groupBox1.Location = new System.Drawing.Point(40, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 168);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customize Parameters";
            // 
            // endValueLabel
            // 
            this.endValueLabel.AutoSize = true;
            this.endValueLabel.Location = new System.Drawing.Point(647, 125);
            this.endValueLabel.Name = "endValueLabel";
            this.endValueLabel.Size = new System.Drawing.Size(65, 13);
            this.endValueLabel.TabIndex = 8;
            this.endValueLabel.Text = "End Point: 5";
            this.endValueLabel.Click += new System.EventHandler(this.endValueLabel_Click);
            // 
            // endIntegral
            // 
            this.endIntegral.Location = new System.Drawing.Point(542, 93);
            this.endIntegral.Maximum = 15;
            this.endIntegral.Minimum = -15;
            this.endIntegral.Name = "endIntegral";
            this.endIntegral.Size = new System.Drawing.Size(267, 45);
            this.endIntegral.TabIndex = 7;
            this.endIntegral.Value = 5;
            this.endIntegral.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(40, 186);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(815, 267);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // xScale
            // 
            this.xScale.LargeChange = 100;
            this.xScale.Location = new System.Drawing.Point(40, 459);
            this.xScale.Maximum = 6;
            this.xScale.Minimum = -4;
            this.xScale.Name = "xScale";
            this.xScale.Size = new System.Drawing.Size(815, 45);
            this.xScale.SmallChange = 100;
            this.xScale.TabIndex = 9;
            this.xScale.Value = 5;
            this.xScale.ValueChanged += new System.EventHandler(this.xScale_ValueChanged);
            // 
            // yScale
            // 
            this.yScale.Location = new System.Drawing.Point(865, 186);
            this.yScale.Maximum = 6;
            this.yScale.Minimum = -4;
            this.yScale.Name = "yScale";
            this.yScale.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.yScale.Size = new System.Drawing.Size(45, 267);
            this.yScale.TabIndex = 10;
            this.yScale.Value = -2;
            this.yScale.ValueChanged += new System.EventHandler(this.yScale_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(779, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.TabStop = false;
            this.button1.Text = "Save Graph";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(40, 510);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Transparent";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Visual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 545);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.yScale);
            this.Controls.Add(this.xScale);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Visual";
            this.Text = "Vizualization Window";
            this.Load += new System.EventHandler(this.Visual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endIntegral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox functionBox;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label dxLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label endValueLabel;
        private System.Windows.Forms.TrackBar endIntegral;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar xScale;
        private System.Windows.Forms.TrackBar yScale;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}