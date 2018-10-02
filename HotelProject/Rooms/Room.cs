using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Rooms
{
    class Room : IRoom
    {
        public string AreaType { get; set; }

        public Room()
        {
            AreaType = "Room";
        }
    }
}
