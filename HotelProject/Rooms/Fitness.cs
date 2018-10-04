using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Rooms
{
    class Fitness : IRoom
    {
        public Fitness()
        {
            AreaType = "Cinema";
            Previous = null;
            Distance = Int32.MaxValue / 2;
            Neighbours = new Dictionary<IRoom, int>();
            Capacity = 0;
        }
    }
}
