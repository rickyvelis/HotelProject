﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HotelProject.Rooms
{
    class IRoom
    {
        public string AreaType { get; set; }
        public Dictionary<IRoom, int> Neighbours { get; set; }
        public IRoom Previous { get; set; }
        public int Distance { get; set; }
        public Point Position { get; set; }
        public Point Dimension { get; set; }
        public string Classification { get; set; }
        public int Capacity { get; set; }
        public Image Img { get; set; }

        public IRoom()
        {
            Neighbours = new Dictionary<IRoom, int>();
        }
    }
}
