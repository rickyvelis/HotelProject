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
        private Hotel _Hotel { get; set; }

        public HEListener()
        {
            _Hotel = Hotel.GetInstance();
        }

        public void Notify(HotelEvent Event)
        {
            Console.WriteLine("TYPE: " + Event.EventType);
            Console.WriteLine("MESSAGE: " + Event.Message);
            if (Event.Data != null)
            {
                foreach (KeyValuePair<string, string> data in Event.Data)
                {
                    Console.WriteLine("KEY: " + data.Key);
                    Console.WriteLine("VALUE: " + data.Value);
                    Console.WriteLine("_____________________________________________________________");
                }
            }

            switch (Event.EventType)
            {
                case HotelEventType.CHECK_IN:

                    //check if guest exists if not:

                    //spawn guest at lobby
                    //go through list of rooms, check for asked star rating and if available.
                    //check higher star rating and if available (repeat through 5 star) if no upgrade available let guest leave
                    if (Event.Data != null)
                    {
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {                           
                        }
                    }

                    break;
                case HotelEventType.CHECK_OUT:
                    //guests goes to lobby and dies
                    //room becomes available
                    //room becomes dirty
                    //more things?
                    break;
                case HotelEventType.CLEANING_EMERGENCY:
                    //clean things
                    break;
                case HotelEventType.EVACUATE:
                    //evacuate uhhhhh
                    break;
                case HotelEventType.GODZILLA:
                    //GOJIRA
                    //BREAK STUFF
                    break;
                case HotelEventType.GOTO_CINEMA:
                    //guest goes to cinema
                    break;
                case HotelEventType.GOTO_FITNESS:
                    //guest goes to gym
                    break;
                case HotelEventType.NEED_FOOD:
                    //guest hungry and goes to restaurant
                    break;
                case HotelEventType.STAR_CINEMA:
                    //??????
                    break;
                default:
                    //doe iets
                    break;
            }
        }
    }
}
