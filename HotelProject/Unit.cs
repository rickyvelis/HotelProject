using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace HotelProject
{
    class Unit
    {
        public string AreaType { get; set; }
        public int Capacity { get; set; }
        public string Classification { get; set; }
        public Point Position { get; set; }
        public Point Dimention { get; set; }

        public Unit()
        {
            Capacity = Int32.MaxValue / 2;
        }
    }
}
