using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    public class IRoom
    {
        public string AreaType { get; set; }
        public Dictionary<IRoom, int> Neighbours { get; set; }
        public IRoom Previous { get; set; }
        public int Distance { get; set; }
        public Point Position { get; set; }
        public Point Dimension { get; set; }
        public string Classification { get; set; }
        public int Capacity { get; set; }
        public Image Img { get; set; }
        public bool Available { get; set; }
        public bool Dirty { get; set; }

        public IRoom()
        {
            Neighbours = new Dictionary<IRoom, int>();
            Distance = Int32.MaxValue / 2;
            Available = true;
            //SetImage(AreaType);
        }

        private void SetImage(string areatype)
        {
            switch (areatype)
            {
                case "Fitness":
                    Img = Resources.Hallway;
                    break;
                case "Cinema":
                    Img = Resources.Cinema1;
                    break;
                case "Restaurant":
                    Img = Resources.Hallway2;
                    break;
                case "Room":
                    switch (Classification)
                    {
                        case "1 star":
                            Img = Resources.Room1;
                            break;
                        case "2 stars":
                            Img = Resources.Room2;
                            break;
                        case "3 stars":
                            Img = Resources.Room3;
                            break;
                        case "4 stars":
                            Img = Resources.Room4;
                            break;
                        case "5 stars":
                            Img = Resources.Room5;
                            break;
                    }
                    break;
            }
        }
    }
}
