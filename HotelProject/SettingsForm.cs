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

        /// <summary>
        /// Converts the text in cleanerAmount_textBox to an integer
        /// </summary>
        /// <returns></returns>
        private int ConvertCleanerAmount()
        {
            int i = int.Parse(cleanerAmount_textBox.Text);
            return i;
        }

        /// <summary>
        /// Converts the text in cleaningSpeed_textBox to an integer
        /// </summary>
        /// <returns></returns>
        private int ConvertCleaningSpeed()
        {
            int i = int.Parse(cleaningSpeed_textBox.Text);
            return i;
        }

        /// <summary>
        /// Converts the text in sPerHTE_textBox to a float
        /// </summary>
        /// <returns></returns>
        private float ConvertHTEFactor()
        {
            float f = float.Parse(sPerHTE_textBox.Text);
            return f;
        }

        /// <summary>
        /// Converts the text in movieDuration_textBox to an integer
        /// </summary>
        /// <returns></returns>
        private int ConvertMovieDuration()
        {
            int i = int.Parse(movieDuration_textBox.Text);
            return i;
        }

        /// <summary>
        /// Converts the text in eatDuration_textBox to an integer
        /// </summary>
        /// <returns></returns>
        private int ConvertEatDuration()
        {
            int i = int.Parse(eatDuration_textBox.Text);
            return i;
        }

        /// <summary>
        /// Occurs when start_button is clicked. Checks whether all textBoxes have been filled; if so, open next Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_button_Click(object sender, EventArgs e)
        {
            bool sallgood = true;

            foreach (TextBox txtBox in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(txtBox.Text))
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
                    ConvertMovieDuration(),
                    ConvertEatDuration());
                MainForm.Show();
                MainForm.Closed += (s, args) => Close();
            }
        }
    }
}
