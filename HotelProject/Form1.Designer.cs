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
            this.hotelStatus_label = new System.Windows.Forms.Label();
            this.guestAmount_Label = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // playPause_checkBox
            // 
            this.playPause_checkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.playPause_checkBox.AutoSize = true;
            this.playPause_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playPause_checkBox.Location = new System.Drawing.Point(3, 3);
            this.playPause_checkBox.MinimumSize = new System.Drawing.Size(40, 40);
            this.playPause_checkBox.Name = "playPause_checkBox";
            this.playPause_checkBox.Size = new System.Drawing.Size(40, 40);
            this.playPause_checkBox.TabIndex = 2;
            this.playPause_checkBox.Text = "⏸";
            this.playPause_checkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playPause_checkBox.UseVisualStyleBackColor = true;
            this.playPause_checkBox.CheckedChanged += new System.EventHandler(this.PlayPause_checkBox_CheckedChanged);
            // 
            // speedUp_checkBox
            // 
            this.speedUp_checkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.speedUp_checkBox.AutoSize = true;
            this.speedUp_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedUp_checkBox.Location = new System.Drawing.Point(45, 3);
            this.speedUp_checkBox.MinimumSize = new System.Drawing.Size(40, 40);
            this.speedUp_checkBox.Name = "speedUp_checkBox";
            this.speedUp_checkBox.Size = new System.Drawing.Size(40, 40);
            this.speedUp_checkBox.TabIndex = 3;
            this.speedUp_checkBox.Text = "⏩";
            this.speedUp_checkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.speedUp_checkBox.UseVisualStyleBackColor = true;
            this.speedUp_checkBox.CheckedChanged += new System.EventHandler(this.SpeedUp_checkBox_CheckedChanged);
            // 
            // hotelStatus_label
            // 
            this.hotelStatus_label.AutoSize = true;
            this.hotelStatus_label.Location = new System.Drawing.Point(6, 46);
            this.hotelStatus_label.Name = "hotelStatus_label";
            this.hotelStatus_label.Size = new System.Drawing.Size(79, 17);
            this.hotelStatus_label.TabIndex = 4;
            this.hotelStatus_label.Text = "hotelStatus";
            // 
            // guestAmount_Label
            // 
            this.guestAmount_Label.AutoSize = true;
            this.guestAmount_Label.Location = new System.Drawing.Point(0, 108);
            this.guestAmount_Label.Name = "guestAmount_Label";
            this.guestAmount_Label.Size = new System.Drawing.Size(69, 17);
            this.guestAmount_Label.TabIndex = 6;
            this.guestAmount_Label.Text = "Guests: 0";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 128);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 766);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.guestAmount_Label);
            this.Controls.Add(this.hotelStatus_label);
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
        private System.Windows.Forms.Label hotelStatus_label;
        private System.Windows.Forms.Label guestAmount_Label;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

