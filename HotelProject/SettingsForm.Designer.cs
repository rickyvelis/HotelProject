﻿namespace HotelProject
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
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.start_button = new System.Windows.Forms.Button();
            this.eatDuration_label = new System.Windows.Forms.Label();
            this.eatDuration_textBox = new System.Windows.Forms.TextBox();
            this.movieDuration_textBox = new System.Windows.Forms.TextBox();
            this.movieDuration_label = new System.Windows.Forms.Label();
            this.cleaningSpeed_textBox = new System.Windows.Forms.TextBox();
            this.cleaningSpeed_label = new System.Windows.Forms.Label();
            this.sPerHTE_textBox = new System.Windows.Forms.TextBox();
            this.sPerHTE_label = new System.Windows.Forms.Label();
            this.cleanerAmount_label = new System.Windows.Forms.Label();
            this.cleanerAmount_textBox = new System.Windows.Forms.TextBox();
            this.elevatorDur_label = new System.Windows.Forms.Label();
            this.elevatorDur_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(11, 164);
            this.start_button.Margin = new System.Windows.Forms.Padding(2);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(207, 47);
            this.start_button.TabIndex = 12;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // eatDuration_label
            // 
            this.eatDuration_label.AutoSize = true;
            this.eatDuration_label.Location = new System.Drawing.Point(11, 105);
            this.eatDuration_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.eatDuration_label.Name = "eatDuration_label";
            this.eatDuration_label.Size = new System.Drawing.Size(100, 13);
            this.eatDuration_label.TabIndex = 24;
            this.eatDuration_label.Text = "Eat Duration (HTE):";
            // 
            // eatDuration_textBox
            // 
            this.eatDuration_textBox.Location = new System.Drawing.Point(138, 105);
            this.eatDuration_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.eatDuration_textBox.Name = "eatDuration_textBox";
            this.eatDuration_textBox.Size = new System.Drawing.Size(80, 20);
            this.eatDuration_textBox.TabIndex = 23;
            // 
            // movieDuration_textBox
            // 
            this.movieDuration_textBox.Location = new System.Drawing.Point(138, 81);
            this.movieDuration_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.movieDuration_textBox.Name = "movieDuration_textBox";
            this.movieDuration_textBox.Size = new System.Drawing.Size(80, 20);
            this.movieDuration_textBox.TabIndex = 21;
            // 
            // movieDuration_label
            // 
            this.movieDuration_label.AutoSize = true;
            this.movieDuration_label.Location = new System.Drawing.Point(11, 81);
            this.movieDuration_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.movieDuration_label.Name = "movieDuration_label";
            this.movieDuration_label.Size = new System.Drawing.Size(113, 13);
            this.movieDuration_label.TabIndex = 22;
            this.movieDuration_label.Text = "Movie Duration (HTE):";
            // 
            // cleaningSpeed_textBox
            // 
            this.cleaningSpeed_textBox.Location = new System.Drawing.Point(138, 57);
            this.cleaningSpeed_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.cleaningSpeed_textBox.Name = "cleaningSpeed_textBox";
            this.cleaningSpeed_textBox.Size = new System.Drawing.Size(80, 20);
            this.cleaningSpeed_textBox.TabIndex = 19;
            // 
            // cleaningSpeed_label
            // 
            this.cleaningSpeed_label.AutoSize = true;
            this.cleaningSpeed_label.Location = new System.Drawing.Point(11, 57);
            this.cleaningSpeed_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cleaningSpeed_label.Name = "cleaningSpeed_label";
            this.cleaningSpeed_label.Size = new System.Drawing.Size(111, 13);
            this.cleaningSpeed_label.TabIndex = 20;
            this.cleaningSpeed_label.Text = "Clean Duration (HTE):";
            // 
            // sPerHTE_textBox
            // 
            this.sPerHTE_textBox.Location = new System.Drawing.Point(138, 33);
            this.sPerHTE_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.sPerHTE_textBox.Name = "sPerHTE_textBox";
            this.sPerHTE_textBox.Size = new System.Drawing.Size(80, 20);
            this.sPerHTE_textBox.TabIndex = 17;
            // 
            // sPerHTE_label
            // 
            this.sPerHTE_label.AutoSize = true;
            this.sPerHTE_label.Location = new System.Drawing.Point(11, 33);
            this.sPerHTE_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sPerHTE_label.Name = "sPerHTE_label";
            this.sPerHTE_label.Size = new System.Drawing.Size(65, 13);
            this.sPerHTE_label.TabIndex = 18;
            this.sPerHTE_label.Text = "HTE Factor:";
            // 
            // cleanerAmount_label
            // 
            this.cleanerAmount_label.AutoSize = true;
            this.cleanerAmount_label.Location = new System.Drawing.Point(11, 9);
            this.cleanerAmount_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cleanerAmount_label.Name = "cleanerAmount_label";
            this.cleanerAmount_label.Size = new System.Drawing.Size(102, 13);
            this.cleanerAmount_label.TabIndex = 14;
            this.cleanerAmount_label.Text = "Amount of Cleaners:";
            // 
            // cleanerAmount_textBox
            // 
            this.cleanerAmount_textBox.Location = new System.Drawing.Point(138, 9);
            this.cleanerAmount_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.cleanerAmount_textBox.Name = "cleanerAmount_textBox";
            this.cleanerAmount_textBox.Size = new System.Drawing.Size(80, 20);
            this.cleanerAmount_textBox.TabIndex = 13;
            // 
            // elevatorDur_label
            // 
            this.elevatorDur_label.AutoSize = true;
            this.elevatorDur_label.Location = new System.Drawing.Point(11, 129);
            this.elevatorDur_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.elevatorDur_label.Name = "elevatorDur_label";
            this.elevatorDur_label.Size = new System.Drawing.Size(123, 13);
            this.elevatorDur_label.TabIndex = 26;
            this.elevatorDur_label.Text = "Elevator Duration (HTE):";
            // 
            // elevatorDur_textBox
            // 
            this.elevatorDur_textBox.Location = new System.Drawing.Point(138, 129);
            this.elevatorDur_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.elevatorDur_textBox.Name = "elevatorDur_textBox";
            this.elevatorDur_textBox.Size = new System.Drawing.Size(80, 20);
            this.elevatorDur_textBox.TabIndex = 25;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 222);
            this.Controls.Add(this.elevatorDur_label);
            this.Controls.Add(this.elevatorDur_textBox);
            this.Controls.Add(this.eatDuration_label);
            this.Controls.Add(this.eatDuration_textBox);
            this.Controls.Add(this.movieDuration_textBox);
            this.Controls.Add(this.movieDuration_label);
            this.Controls.Add(this.cleaningSpeed_textBox);
            this.Controls.Add(this.cleaningSpeed_label);
            this.Controls.Add(this.sPerHTE_textBox);
            this.Controls.Add(this.sPerHTE_label);
            this.Controls.Add(this.cleanerAmount_label);
            this.Controls.Add(this.cleanerAmount_textBox);
            this.Controls.Add(this.start_button);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label eatDuration_label;
        private System.Windows.Forms.TextBox eatDuration_textBox;
        private System.Windows.Forms.TextBox movieDuration_textBox;
        private System.Windows.Forms.Label movieDuration_label;
        private System.Windows.Forms.TextBox cleaningSpeed_textBox;
        private System.Windows.Forms.Label cleaningSpeed_label;
        private System.Windows.Forms.TextBox sPerHTE_textBox;
        private System.Windows.Forms.Label sPerHTE_label;
        private System.Windows.Forms.Label cleanerAmount_label;
        private System.Windows.Forms.TextBox cleanerAmount_textBox;
        private System.Windows.Forms.Label elevatorDur_label;
        private System.Windows.Forms.TextBox elevatorDur_textBox;
    }
}