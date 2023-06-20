namespace TennisApplication
{
    partial class MenuScreen
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
            this.roundRobinLabel = new System.Windows.Forms.Button();
            this.gameButton = new System.Windows.Forms.Button();
            this.playerButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roundRobinLabel
            // 
            this.roundRobinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundRobinLabel.Location = new System.Drawing.Point(604, 426);
            this.roundRobinLabel.Name = "roundRobinLabel";
            this.roundRobinLabel.Size = new System.Drawing.Size(149, 64);
            this.roundRobinLabel.TabIndex = 7;
            this.roundRobinLabel.Text = "Round Robin";
            this.roundRobinLabel.UseVisualStyleBackColor = true;
            // 
            // gameButton
            // 
            this.gameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameButton.Location = new System.Drawing.Point(351, 426);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(149, 64);
            this.gameButton.TabIndex = 6;
            this.gameButton.Text = "Games";
            this.gameButton.UseVisualStyleBackColor = true;
            // 
            // playerButton
            // 
            this.playerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerButton.Location = new System.Drawing.Point(98, 426);
            this.playerButton.Name = "playerButton";
            this.playerButton.Size = new System.Drawing.Size(149, 64);
            this.playerButton.TabIndex = 5;
            this.playerButton.Text = "Players";
            this.playerButton.UseVisualStyleBackColor = true;
            this.playerButton.Click += new System.EventHandler(this.playerButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(155, 110);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(567, 55);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Tennis Sports Application";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roundRobinLabel);
            this.Controls.Add(this.gameButton);
            this.Controls.Add(this.playerButton);
            this.Controls.Add(this.nameLabel);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(850, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button roundRobinLabel;
        private System.Windows.Forms.Button gameButton;
        private System.Windows.Forms.Button playerButton;
        private System.Windows.Forms.Label nameLabel;
    }
}
