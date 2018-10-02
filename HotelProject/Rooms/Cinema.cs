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
        public Dictionary<IRoom, int> Neighbours { get; set; }
        public IRoom Previous { get; set; }
        public int Distance { get; set; }
        
        public Cinema()
        {
            AreaType = "Cinema";
            Previous = null;
            Distance = Int32.MaxValue / 2;
            Neighbours = new Dictionary<IRoom, int>();
        }
    }
}
