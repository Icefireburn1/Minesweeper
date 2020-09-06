namespace MilestoneGUI
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.easyRadioButton = new System.Windows.Forms.RadioButton();
            this.moderateRadioButton = new System.Windows.Forms.RadioButton();
            this.difficultRadioButton = new System.Windows.Forms.RadioButton();
            this.playButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a difficulty";
            // 
            // easyRadioButton
            // 
            this.easyRadioButton.AutoSize = true;
            this.easyRadioButton.Checked = true;
            this.easyRadioButton.Location = new System.Drawing.Point(59, 30);
            this.easyRadioButton.Name = "easyRadioButton";
            this.easyRadioButton.Size = new System.Drawing.Size(48, 17);
            this.easyRadioButton.TabIndex = 1;
            this.easyRadioButton.TabStop = true;
            this.easyRadioButton.Text = "Easy";
            this.easyRadioButton.UseVisualStyleBackColor = true;
            // 
            // moderateRadioButton
            // 
            this.moderateRadioButton.AutoSize = true;
            this.moderateRadioButton.Location = new System.Drawing.Point(59, 54);
            this.moderateRadioButton.Name = "moderateRadioButton";
            this.moderateRadioButton.Size = new System.Drawing.Size(70, 17);
            this.moderateRadioButton.TabIndex = 2;
            this.moderateRadioButton.TabStop = true;
            this.moderateRadioButton.Text = "Moderate";
            this.moderateRadioButton.UseVisualStyleBackColor = true;
            // 
            // difficultRadioButton
            // 
            this.difficultRadioButton.AutoSize = true;
            this.difficultRadioButton.Location = new System.Drawing.Point(59, 78);
            this.difficultRadioButton.Name = "difficultRadioButton";
            this.difficultRadioButton.Size = new System.Drawing.Size(60, 17);
            this.difficultRadioButton.TabIndex = 3;
            this.difficultRadioButton.TabStop = true;
            this.difficultRadioButton.Text = "Difficult";
            this.difficultRadioButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(143, 111);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "Play Game";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 141);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.difficultRadioButton);
            this.Controls.Add(this.moderateRadioButton);
            this.Controls.Add(this.easyRadioButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Select Level";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton easyRadioButton;
        private System.Windows.Forms.RadioButton moderateRadioButton;
        private System.Windows.Forms.RadioButton difficultRadioButton;
        private System.Windows.Forms.Button playButton;
    }
}