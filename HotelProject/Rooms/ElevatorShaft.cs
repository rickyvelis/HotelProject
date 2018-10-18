using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    class ElevatorShaft : IRoom
    {
        public override string AreaType { get; set; }
        public override int ID { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public override Image Img { get; set; }
        public bool UpPressed { get; set; }
        public bool DownPressed { get; set; }
        public bool CanEnter { get; set; }

        public ElevatorShaft(int posY)
        {
            AreaType = "Elevator";
            Dimension = new Point(1, 1);
            Position = new Point(0, posY);
            Img = Resources.Elevator;
            ID = 1;
            UpPressed = false;
            DownPressed = false;
            CanEnter = false;
        }
    }
}
