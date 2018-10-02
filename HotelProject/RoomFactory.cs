using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Rooms
{
    class RoomFactory
    {
        public static IRoom CreateRoom(string value)
        {
            if (value.Equals("Room"))
                return new Room();

            return null;
        }
    }
}
