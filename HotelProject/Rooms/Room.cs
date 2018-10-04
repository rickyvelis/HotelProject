using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
        }

        private Image SetImage(string classification)
        {
            switch (classification)
            {
                case "1 star":
                    Img = Resources.Room1;

            }
        }
    }
}
