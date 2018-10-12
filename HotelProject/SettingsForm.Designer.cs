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
            this.components = new System.ComponentModel.Container();
            this.cleanerAmount_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cleaningSpeed_textBox = new System.Windows.Forms.TextBox();
            this.cleaningSpeed_label = new System.Windows.Forms.Label();
            this.sPerHTE_textBox = new System.Windows.Forms.TextBox();
            this.sPerHTE_label = new System.Windows.Forms.Label();
            this.elevatorCapacity_textBox = new System.Windows.Forms.TextBox();
            this.elevatorCapacity_label = new System.Windows.Forms.Label();
            this.cleanerAmount_label = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.sPerHTE_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.cleanerAmount_tooltip = new System.Windows.Forms.ToolTip(this.components);
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
            this.groupBox1.Controls.Add(this.elevatorCapacity_textBox);
            this.groupBox1.Controls.Add(this.elevatorCapacity_label);
            this.groupBox1.Controls.Add(this.cleanerAmount_label);
            this.groupBox1.Controls.Add(this.cleanerAmount_textBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 167);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // cleaningSpeed_textBox
            // 
            this.cleaningSpeed_textBox.Location = new System.Drawing.Point(161, 61);
            this.cleaningSpeed_textBox.Name = "cleaningSpeed_textBox";
            this.cleaningSpeed_textBox.Size = new System.Drawing.Size(100, 22);
            this.cleaningSpeed_textBox.TabIndex = 2;
            // 
            // cleaningSpeed_label
            // 
            this.cleaningSpeed_label.AutoSize = true;
            this.cleaningSpeed_label.Location = new System.Drawing.Point(7, 61);
            this.cleaningSpeed_label.Name = "cleaningSpeed_label";
            this.cleaningSpeed_label.Size = new System.Drawing.Size(148, 17);
            this.cleaningSpeed_label.TabIndex = 3;
            this.cleaningSpeed_label.Text = "Cleaner Speed (HTE):";
            // 
            // sPerHTE_textBox
            // 
            this.sPerHTE_textBox.Location = new System.Drawing.Point(161, 117);
            this.sPerHTE_textBox.Name = "sPerHTE_textBox";
            this.sPerHTE_textBox.Size = new System.Drawing.Size(100, 22);
            this.sPerHTE_textBox.TabIndex = 6;
            // 
            // sPerHTE_label
            // 
            this.sPerHTE_label.AutoSize = true;
            this.sPerHTE_label.Location = new System.Drawing.Point(7, 117);
            this.sPerHTE_label.Name = "sPerHTE_label";
            this.sPerHTE_label.Size = new System.Drawing.Size(84, 17);
            this.sPerHTE_label.TabIndex = 7;
            this.sPerHTE_label.Text = "HTE Factor:";
            this.sPerHTE_tooltip.SetToolTip(this.sPerHTE_label, "Set how many seconds one HTE should take");
            // 
            // elevatorCapacity_textBox
            // 
            this.elevatorCapacity_textBox.Location = new System.Drawing.Point(161, 89);
            this.elevatorCapacity_textBox.Name = "elevatorCapacity_textBox";
            this.elevatorCapacity_textBox.Size = new System.Drawing.Size(100, 22);
            this.elevatorCapacity_textBox.TabIndex = 4;
            // 
            // elevatorCapacity_label
            // 
            this.elevatorCapacity_label.AutoSize = true;
            this.elevatorCapacity_label.Location = new System.Drawing.Point(7, 89);
            this.elevatorCapacity_label.Name = "elevatorCapacity_label";
            this.elevatorCapacity_label.Size = new System.Drawing.Size(122, 17);
            this.elevatorCapacity_label.TabIndex = 5;
            this.elevatorCapacity_label.Text = "Elevator Capacity:";
            // 
            // cleanerAmount_label
            // 
            this.cleanerAmount_label.AutoSize = true;
            this.cleanerAmount_label.Location = new System.Drawing.Point(7, 33);
            this.cleanerAmount_label.Name = "cleanerAmount_label";
            this.cleanerAmount_label.Size = new System.Drawing.Size(136, 17);
            this.cleanerAmount_label.TabIndex = 1;
            this.cleanerAmount_label.Text = "Amount of Cleaners:";
            this.cleanerAmount_tooltip.SetToolTip(this.cleanerAmount_label, "Set the amount of cleaners the hotel should have");
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(12, 185);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(289, 58);
            this.start_button.TabIndex = 8;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 255);
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
        private System.Windows.Forms.TextBox elevatorCapacity_textBox;
        private System.Windows.Forms.Label elevatorCapacity_label;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label sPerHTE_label;
        private System.Windows.Forms.TextBox sPerHTE_textBox;
        private System.Windows.Forms.TextBox cleaningSpeed_textBox;
        private System.Windows.Forms.Label cleaningSpeed_label;
        private System.Windows.Forms.ToolTip sPerHTE_tooltip;
        private System.Windows.Forms.ToolTip cleanerAmount_tooltip;
    }
}