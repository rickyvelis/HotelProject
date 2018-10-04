using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Properties;

namespace HotelProject.Rooms
{
    class Room : IRoom
    {
        public Room(string classification)
        {
            AreaType = "Room";
            Previous = null;
            Distance = Int32.MaxValue / 2;
            Neighbours = new Dictionary<IRoom, int>();
            Classification = classification;
            SetImage(classification);
        }

        private void SetImage(string classification)
        {
            switch (classification)
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
        }
    }
}
