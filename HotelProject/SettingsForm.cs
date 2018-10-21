using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

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

        private int ConvertMovieDuration()
        {
            int i = int.Parse(movieDuration_textBox.Text);
            return i;
        }

        private int ConvertEatDuration()
        {
            int i = int.Parse(eatDuration_textBox.Text);
            return i;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            bool sallgood = true;

            foreach (TextBox txtBox in Controls.OfType<TextBox>())
            {
                if (txtBox.Text == "" || txtBox.Text == null)
                {
                    txtBox.BackColor = Color.AntiqueWhite;
                    sallgood = false;
                }
            }

            if (sallgood)
            {
                Hide();
                MainForm = new Form1(ConvertHTEFactor(), 
                    ConvertCleanerAmount(),
                    ConvertCleaningSpeed(), 
                    ConvertElevatorCapacity(), 
                    ConvertMovieDuration(),
                    ConvertEatDuration());
                MainForm.Show();
                MainForm.Closed += (s, args) => Close();
            }
        }
    }
}
