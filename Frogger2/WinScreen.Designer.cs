﻿namespace Frogger2
{
    partial class WinScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.congratsLabel = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.playAgain = new System.Windows.Forms.Label();
            this.noButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // congratsLabel
            // 
            this.congratsLabel.BackColor = System.Drawing.Color.Transparent;
            this.congratsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.congratsLabel.Location = new System.Drawing.Point(19, 24);
            this.congratsLabel.Name = "congratsLabel";
            this.congratsLabel.Size = new System.Drawing.Size(358, 110);
            this.congratsLabel.TabIndex = 0;
            this.congratsLabel.Text = "Congrats!\r\nYou Win!";
            this.congratsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(69, 228);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            // 
            // playAgain
            // 
            this.playAgain.AutoSize = true;
            this.playAgain.BackColor = System.Drawing.Color.Transparent;
            this.playAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.playAgain.Location = new System.Drawing.Point(149, 177);
            this.playAgain.Name = "playAgain";
            this.playAgain.Size = new System.Drawing.Size(90, 20);
            this.playAgain.TabIndex = 2;
            this.playAgain.Text = "Play again?";
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(230, 228);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 3;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.playAgain);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.congratsLabel);
            this.Name = "WinScreen";
            this.Size = new System.Drawing.Size(400, 348);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label congratsLabel;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Label playAgain;
        private System.Windows.Forms.Button noButton;
    }
}
