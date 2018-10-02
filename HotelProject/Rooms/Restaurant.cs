using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Rooms
{
    class Restaurant : IRoom
    {
        public string AreaType { get; set; }

        public Restaurant()
        {
            AreaType = "Restaurant";
        }

    }
}
