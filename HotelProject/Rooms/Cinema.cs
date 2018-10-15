﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;
using HotelProject.Rooms;

namespace HotelProject.Rooms
{    
    class Cinema : IRoom
    {
        public override string AreaType { get; set; }
        public override int ID { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public override Image Img { get; set; }

        public Cinema(int dimX, int dimY, int posX, int posY, int iD)
        {
            AreaType = "Cinema";
            Dimension = new Point(dimX, dimY);
            Position = new Point(posX, posY);
            Img = Resources.Cinema1;
            ID = iD;
        }
    }
}
