using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    class Hall : IRoom
    {
        public override string AreaType { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public override Image Img { get; set; }

        public Hall(int posX, int posY)
        {
            AreaType = "Hall";
            Dimension = new Point(1, 1);
            Position = new Point(posX, posY);
            Img = Resources.Hallway;
        }
    }
}
