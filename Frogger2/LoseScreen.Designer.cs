namespace Frogger2
{
    partial class LoseScreen
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
            this.noButton = new System.Windows.Forms.Button();
            this.playAgain = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.endLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(240, 211);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 7;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // playAgain
            // 
            this.playAgain.AutoSize = true;
            this.playAgain.BackColor = System.Drawing.Color.Transparent;
            this.playAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.playAgain.Location = new System.Drawing.Point(149, 147);
            this.playAgain.Name = "playAgain";
            this.playAgain.Size = new System.Drawing.Size(90, 20);
            this.playAgain.TabIndex = 6;
            this.playAgain.Text = "Play again?";
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(64, 211);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 5;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // endLabel
            // 
            this.endLabel.BackColor = System.Drawing.Color.Transparent;
            this.endLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.endLabel.Location = new System.Drawing.Point(8, 10);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(358, 110);
            this.endLabel.TabIndex = 4;
            this.endLabel.Text = "That\'s unfortunate!\r\nYou lose :(";
            this.endLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.playAgain);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.endLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoseScreen";
            this.Size = new System.Drawing.Size(375, 284);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Label playAgain;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Label endLabel;
    }
}
