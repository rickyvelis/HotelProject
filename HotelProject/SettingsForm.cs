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

        public SettingsForm()
        {
            //InitializeComponent();

            _Hotel = Hotel.GetInstance();
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (cleanerAmount_textBox.Text != "" 
                //&& cleanerAmount_textBox.Text != ""
                //&& maxLiftPassengers_textBox.Text != ""
                //&& sPerHTE_textBox.Text != ""
                )
            {

            }
        }
    }
}
