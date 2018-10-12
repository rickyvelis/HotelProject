namespace HotelProject
{
    partial class SettingsForm
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
            this.cleanerAmount_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cleanerAmount_label = new System.Windows.Forms.Label();
            this.maxLiftPassengers_label = new System.Windows.Forms.Label();
            this.maxLiftPassengers_textBox = new System.Windows.Forms.TextBox();
            this.start_button = new System.Windows.Forms.Button();
            this.sPerHTE_label = new System.Windows.Forms.Label();
            this.sPerHTE_textBox = new System.Windows.Forms.TextBox();
            this.cleaningSpeed_label = new System.Windows.Forms.Label();
            this.cleaningSpeed_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cleanerAmount_textBox
            // 
            this.cleanerAmount_textBox.Location = new System.Drawing.Point(161, 33);
            this.cleanerAmount_textBox.Name = "cleanerAmount_textBox";
            this.cleanerAmount_textBox.Size = new System.Drawing.Size(100, 22);
            this.cleanerAmount_textBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cleaningSpeed_textBox);
            this.groupBox1.Controls.Add(this.cleaningSpeed_label);
            this.groupBox1.Controls.Add(this.sPerHTE_textBox);
            this.groupBox1.Controls.Add(this.sPerHTE_label);
            this.groupBox1.Controls.Add(this.maxLiftPassengers_textBox);
            this.groupBox1.Controls.Add(this.maxLiftPassengers_label);
            this.groupBox1.Controls.Add(this.cleanerAmount_label);
            this.groupBox1.Controls.Add(this.cleanerAmount_textBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 279);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // cleanerAmount_label
            // 
            this.cleanerAmount_label.AutoSize = true;
            this.cleanerAmount_label.Location = new System.Drawing.Point(7, 33);
            this.cleanerAmount_label.Name = "cleanerAmount_label";
            this.cleanerAmount_label.Size = new System.Drawing.Size(136, 17);
            this.cleanerAmount_label.TabIndex = 1;
            this.cleanerAmount_label.Text = "Amount of Cleaners:";
            // 
            // maxLiftPassengers_label
            // 
            this.maxLiftPassengers_label.AutoSize = true;
            this.maxLiftPassengers_label.Location = new System.Drawing.Point(7, 93);
            this.maxLiftPassengers_label.Name = "maxLiftPassengers_label";
            this.maxLiftPassengers_label.Size = new System.Drawing.Size(139, 17);
            this.maxLiftPassengers_label.TabIndex = 2;
            this.maxLiftPassengers_label.Text = "Max Lift Passengers:";
            // 
            // maxLiftPassengers_textBox
            // 
            this.maxLiftPassengers_textBox.Location = new System.Drawing.Point(161, 93);
            this.maxLiftPassengers_textBox.Name = "maxLiftPassengers_textBox";
            this.maxLiftPassengers_textBox.Size = new System.Drawing.Size(100, 22);
            this.maxLiftPassengers_textBox.TabIndex = 3;
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(164, 360);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 4;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // sPerHTE_label
            // 
            this.sPerHTE_label.AutoSize = true;
            this.sPerHTE_label.Location = new System.Drawing.Point(7, 121);
            this.sPerHTE_label.Name = "sPerHTE_label";
            this.sPerHTE_label.Size = new System.Drawing.Size(124, 17);
            this.sPerHTE_label.TabIndex = 4;
            this.sPerHTE_label.Text = "Seconds per HTE:";
            // 
            // sPerHTE_textBox
            // 
            this.sPerHTE_textBox.Location = new System.Drawing.Point(161, 121);
            this.sPerHTE_textBox.Name = "sPerHTE_textBox";
            this.sPerHTE_textBox.Size = new System.Drawing.Size(100, 22);
            this.sPerHTE_textBox.TabIndex = 5;
            // 
            // cleaningSpeed_label
            // 
            this.cleaningSpeed_label.AutoSize = true;
            this.cleaningSpeed_label.Location = new System.Drawing.Point(7, 61);
            this.cleaningSpeed_label.Name = "cleaningSpeed_label";
            this.cleaningSpeed_label.Size = new System.Drawing.Size(148, 17);
            this.cleaningSpeed_label.TabIndex = 6;
            this.cleaningSpeed_label.Text = "Cleaner Speed (HTE):";
            // 
            // cleaningSpeed_textBox
            // 
            this.cleaningSpeed_textBox.Location = new System.Drawing.Point(161, 61);
            this.cleaningSpeed_textBox.Name = "cleaningSpeed_textBox";
            this.cleaningSpeed_textBox.Size = new System.Drawing.Size(100, 22);
            this.cleaningSpeed_textBox.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 450);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox cleanerAmount_textBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label cleanerAmount_label;
        private System.Windows.Forms.TextBox maxLiftPassengers_textBox;
        private System.Windows.Forms.Label maxLiftPassengers_label;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label sPerHTE_label;
        private System.Windows.Forms.TextBox sPerHTE_textBox;
        private System.Windows.Forms.TextBox cleaningSpeed_textBox;
        private System.Windows.Forms.Label cleaningSpeed_label;
    }
}