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

        public HEListener()
        {

        }

        public void Notify(HotelEvent Event)
        {
            Console.WriteLine("TYPE: " + Event.EventType);
            Console.WriteLine("MESSAGE: " + Event.Message);
            switch (Event.EventType)
            {
                case HotelEventType.CHECK_IN:
                    //spawn guest
                    //do things
                    break;
                case HotelEventType.CHECK_OUT:
                    //guests goes to lobby and dies
                    //room becomes available
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
