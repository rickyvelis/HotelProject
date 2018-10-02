using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Rooms
{
    class Cinema : IRoom
    {
        public string AreaType { get; set; }

        public Cinema()
        {
            AreaType = "Cinema";
        }
    }
}
