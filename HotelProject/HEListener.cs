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
    public class HEListener : HotelEventListener
    {
        private Hotel _Hotel { get; set; }

        public HEListener()
        {
            _Hotel = Hotel.GetInstance();
        }

        public void Notify(HotelEvent Event)
        {
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("TYPE: " + Event.EventType);
            Console.WriteLine("MESSAGE: " + Event.Message);
            Console.WriteLine("TIME: " + Event.Time);
            if (Event.Data != null)
            {
                foreach (KeyValuePair<string, string> data in Event.Data)
                {
                    Console.WriteLine("KEY: " + data.Key);
                    Console.WriteLine("VALUE: " + data.Value);
                    Console.WriteLine("----------------------");
                }
            }

            switch (Event.EventType)
            {
                case HotelEventType.CHECK_IN:
                    if (Event.Data != null)
                    {
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (!_Hotel.Guests.Exists(r => r.Name == data.Key))
                            {
                                bool roomFound = false;
                                Guest guest = new Guest(1, 0);
                                guest.Name = data.Key;
                                _Hotel.Guests.Add(guest);

                                switch (data.Value)
                                {
                                    case ("Checkin 1stars"):
                                        foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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

                                        if(!roomFound)
                                            _Hotel.Guests.Remove(guest);

                                        break;

                                    case ("Checkin 2stars"):
                                        foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                        if(!roomFound)
                                            _Hotel.Guests.Remove(guest);

                                        break;

                                    case ("Checkin 3stars"):
                                        foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                        
                                        if(!roomFound)
                                            _Hotel.Guests.Remove(guest);

                                        break;

                                    case ("Checkin 4stars"):
                                        foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                            foreach (Room room in _Hotel.iRoom.OfType<Room>())
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
                                        
                                        if(!roomFound)
                                            _Hotel.Guests.Remove(guest);

                                        break;

                                    case ("Checkin 5stars"):
                                        foreach (Room room in _Hotel.iRoom.OfType<Room>())
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

                                        if(!roomFound)
                                            _Hotel.Guests.Remove(guest);
                                        break;
                                }                                
                            }
                        }
                    }

                    break;
                case HotelEventType.CHECK_OUT:
                    if (Event.Data != null)
                    {
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (_Hotel.Guests.Exists(g => g.Name == data.Key))
                            {
                                _Hotel.Guests.Single(g => g.Name == data.Key).CheckOut();

                                if (_Hotel.Cleaners != null)
                                {
                                    //TODO maybe make this line shorter and more understandable
                                    //gets cleaner with shortest queue and adds the to-be-cleaned room to its queue
                                    _Hotel.Cleaners.Aggregate((l, r) => l.Queue.Count < r.Queue.Count ? l : r).Queue.Add(_Hotel.Guests.Single(g => g.Name == data.Key).Room);
                                }
                            }
                        }
                    }
                        break;
                case HotelEventType.CLEANING_EMERGENCY:
                    foreach (Room room in _Hotel.iRoom.OfType<Room>())
                    {
                        room.Dirty = true;
                    }
                    //TODO: Send out all the Cleaners to clean all the dirty rooms
                    //TODO: Send all guests to Lobby
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
