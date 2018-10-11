using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    public class Room : IRoom
    {
        public override string AreaType { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public string Classification { get; set; }
        public bool Dirty { get; set; }
        public bool Available { get; set; }

        public Room(string classification, int dimX, int dimY, int posX, int posY)
        {
            AreaType = "Room";
            Classification = classification;
            Dimension = new Point(dimX, dimY);
            Position = new Point(posX, posY);
            Dirty = false;
            Available = true;
        }
    }
}
