﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class HumanFactory
    {
        public dynamic CreateHuman(string type)
        {
            switch (type)
            {
                case "guest":
                    return new Guest(1, 0);
                case "cleaner":
                    return new Cleaner();
                default:
                    return null;
            }
        }
    }
}