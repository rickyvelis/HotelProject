using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    class Lobby : IRoom
    {
        public override string AreaType { get; set; }
        public override int ID { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public override Image Img { get; set; }

        public Lobby(int dimX)
        {
            AreaType = "Lobby";
            Dimension = new Point(dimX, 1);
            Position = new Point(1, 0);
            Img = Resources.Entrance;
            ID = 0;
        }
    }
}
