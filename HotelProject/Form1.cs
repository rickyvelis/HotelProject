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
    public partial class Form1 : Form
    {
        private Hotel _Hotel { get; set; }

        public Form1()
        {
            InitializeComponent();

            Hotel hotel = new Hotel(this);
            _Hotel = hotel;
        }
    }
}
