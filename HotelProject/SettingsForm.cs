using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelProject
{
    public partial class SettingsForm : Form
    {
        private Hotel _Hotel { get; set; }
        private Form1 MainForm { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            elevatorCapacity_textBox.Enabled = false;
            _Hotel = Hotel.GetInstance();
        }

        private float ConvertHTEFactor()
        {
            float f = float.Parse(sPerHTE_textBox.Text);
            return f;
        }

        private int ConvertCleanerAmount()
        {
            int i = int.Parse(cleanerAmount_textBox.Text);
            return i;
        }

        private int ConvertCleaningSpeed()
        {
            int i = int.Parse(cleaningSpeed_textBox.Text);
            return i;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (cleanerAmount_textBox.Text != "" 
                && cleanerAmount_textBox.Text != ""
                //&& maxLiftPassengers_textBox.Text != ""
                && sPerHTE_textBox.Text != ""
                )
            {
                Hide();
                MainForm = new Form1(ConvertHTEFactor(), ConvertCleanerAmount(), ConvertCleaningSpeed(), 5);
                MainForm.Show();
                MainForm.Closed += (s, args) => Close();
            }
        }
    }
}
