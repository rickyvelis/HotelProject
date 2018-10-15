using System;
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

        public Room Room { get; set; }
        private Hotel _Hotel { get; }

        private bool CheckingOut { get; set; }
        private bool Evacuating { get; set; }

        public Guest(int posX, int posY)
        {
            _Hotel = Hotel.GetInstance();
            Visible = true;
            CheckingOut = false;
            SetPosition(posX, posY);
            SpritePosition = new Point(Position.Position.X, Position.Position.Y);
        }

        public void Update()
        {
            Step();

            //if (Position == Room)
                //Visible = false;
            if (CheckingOut && Position == _Hotel.iRoom.Single(r => r.AreaType == "Lobby"))            
                Die();
        }

        public void CheckOut()
        {
            FindRoom(_Hotel.iRoom.Single(r => r.AreaType == "Lobby"));
            //Room.Dirty = true;
            CheckingOut = true;

        }

        public void Evacuate()
        {
            Wait = 0;
            Evacuating = true;
            FindRoom(_Hotel.iRoom.Single(r => r.AreaType == "Lobby"));
        }

        public void Go_Back()
        {
            if (!Evacuating)
                FindRoom(_Hotel.iRoom.Single(r => r.Position.X == Room.Position.X && r.Position.Y == Room.Position.Y));
        }

        public void Die()
        {
            Visible = false;
            //_Hotel.Guests.Remove(this);
        }
    }
}
