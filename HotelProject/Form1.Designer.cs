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
            this.statsBox = new System.Windows.Forms.RichTextBox();
            this.dirtyRoomsBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.elevatorBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // playPause_checkBox
            // 
            this.playPause_checkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.playPause_checkBox.AutoSize = true;
            this.playPause_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playPause_checkBox.Location = new System.Drawing.Point(7, 636);
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
            this.speedUp_checkBox.Location = new System.Drawing.Point(49, 636);
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
            this.hotelStatus_label.Location = new System.Drawing.Point(10, 679);
            this.hotelStatus_label.Name = "hotelStatus_label";
            this.hotelStatus_label.Size = new System.Drawing.Size(60, 13);
            this.hotelStatus_label.TabIndex = 4;
            this.hotelStatus_label.Text = "hotelStatus";
            // 
            // guestAmount_Label
            // 
            this.guestAmount_Label.AutoSize = true;
            this.guestAmount_Label.Location = new System.Drawing.Point(92, 616);
            this.guestAmount_Label.Name = "guestAmount_Label";
            this.guestAmount_Label.Size = new System.Drawing.Size(52, 13);
            this.guestAmount_Label.TabIndex = 6;
            this.guestAmount_Label.Text = "Guests: 0";
            // 
            // statsBox
            // 
            this.statsBox.Location = new System.Drawing.Point(95, 636);
            this.statsBox.Name = "statsBox";
            this.statsBox.Size = new System.Drawing.Size(187, 118);
            this.statsBox.TabIndex = 7;
            this.statsBox.Text = "";
            // 
            // dirtyRoomsBox
            // 
            this.dirtyRoomsBox.Location = new System.Drawing.Point(288, 636);
            this.dirtyRoomsBox.Name = "dirtyRoomsBox";
            this.dirtyRoomsBox.Size = new System.Drawing.Size(164, 118);
            this.dirtyRoomsBox.TabIndex = 8;
            this.dirtyRoomsBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 616);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dirty Rooms:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 616);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Elevator:";
            // 
            // elevatorBox
            // 
            this.elevatorBox.Location = new System.Drawing.Point(458, 636);
            this.elevatorBox.Name = "elevatorBox";
            this.elevatorBox.Size = new System.Drawing.Size(164, 118);
            this.elevatorBox.TabIndex = 11;
            this.elevatorBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 766);
            this.Controls.Add(this.elevatorBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dirtyRoomsBox);
            this.Controls.Add(this.statsBox);
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
        private System.Windows.Forms.RichTextBox statsBox;
        private System.Windows.Forms.RichTextBox dirtyRoomsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox elevatorBox;
    }
}

