using System.Collections.Generic;
using System.Drawing;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    public class Room : IRoom
    {
        public override string AreaType { get; set; }
        public override int ID { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public string Classification { get; set; }
        public bool Dirty { get; set; }
        public bool Available { get; set; }
        public override Image Img { get; set; }

        public Room(string classification, int dimX, int dimY, int posX, int posY, int iD)
        {
            AreaType = "Room";
            Classification = classification;
            Dimension = new Point(dimX, dimY);
            Position = new Point(posX, posY);
            Dirty = false;
            Available = true;
            ID = iD;
            switch (Classification)
            {
                case ("1 Star"):
                    Img = Resources.Room1;
                    break;
                case ("2 stars"):
                    Img = Resources.Room2;
                    break;
                case ("3 stars"):
                    Img = Resources.Room3;
                    break;
                case ("4 stars"):
                    Img = Resources.Room4;
                    break;
                case ("5 stars"):
                    Img = Resources.Room5;
                    break;
            }
        }
    }
}
