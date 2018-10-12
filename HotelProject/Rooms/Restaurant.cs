using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    class Restaurant : IRoom
    {
        public override string AreaType { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public int Capacity { get; set; }
        public override Image Img { get; set; }

        public Restaurant(int capacity, int dimX, int dimY, int posX, int posY)
        {
            AreaType = "Restaurant";
            Capacity = capacity;
            Dimension = new Point(dimX, dimY);
            Position = new Point(posX, posY);
            Img = Resources.Cinema2;
        }

    }
}
