﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    public abstract class IRoom
    {
        public abstract string AreaType { get; set; }
        public abstract Dictionary<IRoom, int> Neighbours { get; set; }
        public IRoom Previous { get; set; }
        public abstract int Distance { get; set; }
        public abstract Point Position { get; set; }
        public abstract Point Dimension { get; set; }
        //public string Classification { get; set; }
        //public int Capacity { get; set; }
        //public Image Img { get; set; }
        //public bool Available { get; set; }
        //public bool Dirty { get; set; }

        protected IRoom()
        {
            Neighbours = new Dictionary<IRoom, int>();
            Distance = Int32.MaxValue / 2;
        }

    }       
}
