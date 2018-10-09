using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotelProject.Rooms;

namespace HotelProject
{
    public class Cleaner : Human
    {
        private Hotel _Hotel { get; }
        public bool Cleaning { get; set; }

        public Cleaner()
        {
            _Hotel = Hotel.GetInstance();
            SetPosition(1, 0);
            SpritePosition = new Point(Position.Position.X, Position.Position.Y);
        }

        public void CleanRoom(IRoom room)
        {
            Cleaning = true;
            FindRoom(room);
            //TODO: If Cleaner.Position == room, then room.Dirty = false
            //Then go to Lobby again (or other place where Cleaners stay
        }
    }
}
