using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEvents;

namespace HotelProject
{
    class HEListener : HotelEventListener
    {
        public Hotel _Hotel { get; set; }

        public HEListener(Hotel hotel)
        {
            _Hotel = hotel;
        }

        public void Notify(HotelEvent Event)
        {

        }
    }
}
