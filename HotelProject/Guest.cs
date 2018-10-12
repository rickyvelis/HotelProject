﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using HotelProject.Rooms;

namespace HotelProject
{
    public class Guest : Human
    {
        public IRoom Room { get; set; }
        private Hotel _Hotel { get; }

        public Guest(int posX, int posY)
        {
            _Hotel = Hotel.GetInstance();
            Visible = true;
            SetPosition(posX, posY);
            SpritePosition = new Point(Position.Position.X, Position.Position.Y);
        }

        public void CheckOut()
        {
            FindRoom(_Hotel.iRoom.Single(r => r.AreaType == "Lobby"));
            Room.Dirty = true;
        }

        public void Die()
        {
            Visible = false;
        }
    }
}
