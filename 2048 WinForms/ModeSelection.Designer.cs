namespace _2048_WinForms
{
    partial class ModeSelection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonHarder = new System.Windows.Forms.RadioButton();
            this.radioButtonHard = new System.Windows.Forms.RadioButton();
            this.radioButtonTwoPlayer = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonHarder);
            this.groupBox1.Controls.Add(this.radioButtonHard);
            this.groupBox1.Controls.Add(this.radioButtonTwoPlayer);
            this.groupBox1.Controls.Add(this.radioButtonNormal);
            this.groupBox1.Location = new System.Drawing.Point(35, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Type";
            // 
            // radioButtonHarder
            // 
            this.radioButtonHarder.AutoSize = true;
            this.radioButtonHarder.Location = new System.Drawing.Point(18, 99);
            this.radioButtonHarder.Name = "radioButtonHarder";
            this.radioButtonHarder.Size = new System.Drawing.Size(57, 17);
            this.radioButtonHarder.TabIndex = 3;
            this.radioButtonHarder.TabStop = true;
            this.radioButtonHarder.Text = "Harder";
            this.radioButtonHarder.UseVisualStyleBackColor = true;
            this.radioButtonHarder.CheckedChanged += new System.EventHandler(this.radioButtonHarder_CheckedChanged);
            // 
            // radioButtonHard
            // 
            this.radioButtonHard.AutoSize = true;
            this.radioButtonHard.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.radioButtonHard.Location = new System.Drawing.Point(18, 76);
            this.radioButtonHard.Name = "radioButtonHard";
            this.radioButtonHard.Size = new System.Drawing.Size(48, 17);
            this.radioButtonHard.TabIndex = 2;
            this.radioButtonHard.TabStop = true;
            this.radioButtonHard.Text = "Hard";
            this.radioButtonHard.UseVisualStyleBackColor = true;
            this.radioButtonHard.CheckedChanged += new System.EventHandler(this.radioButtonHard_CheckedChanged);
            // 
            // radioButtonTwoPlayer
            // 
            this.radioButtonTwoPlayer.AutoSize = true;
            this.radioButtonTwoPlayer.Location = new System.Drawing.Point(18, 53);
            this.radioButtonTwoPlayer.Name = "radioButtonTwoPlayer";
            this.radioButtonTwoPlayer.Size = new System.Drawing.Size(75, 17);
            this.radioButtonTwoPlayer.TabIndex = 1;
            this.radioButtonTwoPlayer.TabStop = true;
            this.radioButtonTwoPlayer.Text = "TwoPlayer";
            this.radioButtonTwoPlayer.UseVisualStyleBackColor = true;
            this.radioButtonTwoPlayer.CheckedChanged += new System.EventHandler(this.radioButtonTwoPerson_CheckedChanged);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(18, 30);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(58, 17);
            this.radioButtonNormal.TabIndex = 0;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Normal";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.radioButtonNormal_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 234);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModeSelection";
            this.Text = "ModeSelection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonHarder;
        private System.Windows.Forms.RadioButton radioButtonHard;
        private System.Windows.Forms.RadioButton radioButtonTwoPlayer;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.Button button1;
    }
}