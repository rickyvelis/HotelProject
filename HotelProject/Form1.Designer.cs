namespace HotelProject
{
    partial class Form1
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
            this.playPause_checkBox = new System.Windows.Forms.CheckBox();
            this.speedUp_checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // playPause_checkBox
            // 
            this.playPause_checkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.playPause_checkBox.AutoSize = true;
            this.playPause_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playPause_checkBox.Location = new System.Drawing.Point(2, 2);
            this.playPause_checkBox.MinimumSize = new System.Drawing.Size(30, 30);
            this.playPause_checkBox.Name = "playPause_checkBox";
            this.playPause_checkBox.Size = new System.Drawing.Size(32, 30);
            this.playPause_checkBox.TabIndex = 2;
            this.playPause_checkBox.Text = "⏸";
            this.playPause_checkBox.UseVisualStyleBackColor = true;
            this.playPause_checkBox.CheckedChanged += new System.EventHandler(this.PlayPause_checkBox_CheckedChanged);
            // 
            // speedUp_checkBox
            // 
            this.speedUp_checkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.speedUp_checkBox.AutoSize = true;
            this.speedUp_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedUp_checkBox.Location = new System.Drawing.Point(34, 2);
            this.speedUp_checkBox.MinimumSize = new System.Drawing.Size(30, 30);
            this.speedUp_checkBox.Name = "speedUp_checkBox";
            this.speedUp_checkBox.Size = new System.Drawing.Size(30, 30);
            this.speedUp_checkBox.TabIndex = 3;
            this.speedUp_checkBox.Text = "⏩";
            this.speedUp_checkBox.UseVisualStyleBackColor = true;
            this.speedUp_checkBox.CheckedChanged += new System.EventHandler(this.SpeedUp_checkBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 766);
            this.Controls.Add(this.speedUp_checkBox);
            this.Controls.Add(this.playPause_checkBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox playPause_checkBox;
        private System.Windows.Forms.CheckBox speedUp_checkBox;
    }
}

