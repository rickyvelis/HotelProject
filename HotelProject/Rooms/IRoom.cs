﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Rooms
{
    interface IRoom
    {
        string AreaType { get; set; }
        Dictionary<IRoom, int> Neighbours { get; set; }
        IRoom Previous { get; set; }
        int Distance { get; set; }

        private IRoom()
        {
            Previous = null;
            Distance = Int32.MaxValue / 2;
            Neighbours = new Dictionary<IRoom, int>();
        }
    }
}