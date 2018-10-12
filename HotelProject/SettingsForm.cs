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
            _Hotel = Hotel.GetInstance();
        }

        //TODO Maybe remove all the convert methods and put their functionality in start_button_Click()
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

        private int ConvertElevatorCapacity()
        {
            int i = int.Parse(elevatorCapacity_textBox.Text);
            return i;
        }

        private float ConvertHTEFactor()
        {
            float f = float.Parse(sPerHTE_textBox.Text);
            return f;
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
                MainForm = new Form1(ConvertHTEFactor(), ConvertCleanerAmount(), ConvertCleaningSpeed(), ConvertElevatorCapacity());
                MainForm.Show();
                MainForm.Closed += (s, args) => Close();
            }
        }
    }
}
