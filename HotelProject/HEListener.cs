using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEvents;
using HotelProject.Rooms;

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
                    //TODO gast hotel laten verlaten/gast verwijderen als er geen kamer beschikbaar is
                    if (Event.Data != null)
                    {
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (!_Hotel.guests.Exists(r => r.Name == data.Key))
                            {
                                bool roomFound = false;
                                Guest guest = new Guest(new Point(200, 200));
                                guest.Position = _Hotel.iRoom.Single(r => r.Position.X == 1 && r.Position.Y == 0);
                                guest.Name = data.Key;
                                _Hotel.guests.Add(guest);

                                switch (data.Value)
                                {
                                    case ("Checkin 1stars"):
                                        foreach (IRoom room in _Hotel.iRoom)
                                        {
                                            if (room.Available && room.Classification == "1 Star")
                                            {
                                                guest.Room = room;
                                                room.Available = false;
                                                roomFound = true;
                                                guest.FindRoom(room);
                                                break;
                                            }                                            
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "2 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "3 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "4 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "5 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        break;

                                    case ("Checkin 2stars"):
                                        foreach (IRoom room in _Hotel.iRoom)
                                        {
                                            if (room.Available && room.Classification == "2 stars")
                                            {
                                                guest.Room = room;
                                                room.Available = false;
                                                roomFound = true;
                                                guest.FindRoom(room);
                                                break;
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "3 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "4 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "5 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        break;

                                    case ("Checkin 3stars"):
                                        foreach (IRoom room in _Hotel.iRoom)
                                        {
                                            if (room.Available && room.Classification == "3 stars")
                                            {
                                                guest.Room = room;
                                                room.Available = false;
                                                roomFound = true;
                                                guest.FindRoom(room);
                                                break;
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "4 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "5 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        break;

                                    case ("Checkin 4stars"):
                                        foreach (IRoom room in _Hotel.iRoom)
                                        {
                                            if (room.Available && room.Classification == "4 stars")
                                            {
                                                guest.Room = room;
                                                room.Available = false;
                                                roomFound = true;
                                                guest.FindRoom(room);
                                                break;
                                            }
                                        }

                                        if (!roomFound)
                                        {
                                            foreach (IRoom room in _Hotel.iRoom)
                                            {
                                                if (room.Available && room.Classification == "5 stars")
                                                {
                                                    guest.Room = room;
                                                    room.Available = false;
                                                    roomFound = true;
                                                    guest.FindRoom(room);
                                                    break;
                                                }
                                            }
                                        }

                                        break;

                                    case ("Checkin 5stars"):
                                        foreach (IRoom room in _Hotel.iRoom)
                                        {
                                            if (room.Available && room.Classification == "5 stars")
                                            {
                                                guest.Room = room;
                                                room.Available = false;
                                                roomFound = true;
                                                guest.FindRoom(room);
                                                break;
                                            }
                                        }
                                        break;

                                    default:
                                        break;
                                }                                
                            }
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
