using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using HotelProject.Rooms;
using HotelProject.Properties;

namespace HotelProject
{
    public class Guest : Human
    {
        public override string Name { get; set; }
        public override bool Visible { get; set; }
        public override List<IRoom> Path { get; set; }
        public override IRoom Position { get; set; }
        public override Point SpritePosition { get; set; }
        public override int Wait { get; set; }
        public override Image Img { get; set; }

        public Room Room { get; set; }
        private Hotel _Hotel { get; }

        private bool CheckingOut;

        public Guest(int posX, int posY)
        {
            _Hotel = Hotel.GetInstance();
            Img = Resources.Guest1;
            Visible = true;
            CheckingOut = false;
            SetPosition(posX, posY);
            SpritePosition = new Point(Position.Position.X, Position.Position.Y);
        }

        public override void Update()
        {
            Step();

            if (Position == Room)
                //Visible = false;
            if (CheckingOut && Position == _Hotel.iRoom.Single(r => r.AreaType == "Lobby"))
                Die();
        }

        public void CheckOut()
        {
            FindRoom(_Hotel.iRoom.Single(r => r.AreaType == "Lobby"));
            Room.Dirty = true;
            CheckingOut = true;

        }

        public void Die()
        {
            Visible = false;
            //_Hotel.Guests.Remove(this);
        }
    }
}
