﻿using System.Collections.Generic;
using System.Drawing;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    public class Restaurant : IRoom
    {
        public override string AreaType { get; set; }
        public override int ID { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public override Image Img { get; set; }
        
        public int Capacity { get; set; }
        public int AmountOfGuests { get; set; }

        public Restaurant(int capacity, int dimX, int dimY, int posX, int posY, int iD)
        {
            AreaType = "Restaurant";
            Capacity = capacity;
            Dimension = new Point(dimX, dimY);
            Position = new Point(posX, posY);
            Img = Resources.Restaurant;
            ID = iD;
            AmountOfGuests = 0;
        }
    }
}
