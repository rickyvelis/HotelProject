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
        private Hotel _Hotel { get; }

        public HEListener()
        {
            _Hotel = Hotel.GetInstance();
        }

        public void Notify(HotelEvent Event)
        {
            #region MyRegion Printing out stuff for us fofr checks
            
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
                }
            }
            #endregion

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

                                //TODO code verkorten.
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
                            if (_Hotel.Guests.Exists(g => g.Name == data.Key + data.Value))
                            {
                                _Hotel.Guests.Single(g => g.Name == data.Key + data.Value).CheckOut();

                                if (_Hotel.Cleaners != null)
                                {
                                    //TODO maybe make this line shorter and more understandable
                                    //TODO kijken of cleaner zelf bezig is??
                                    /*
                                    //gets cleaner with shortest queue and adds the to-be-cleaned room to its queue
                                    _Hotel.Cleaners.Aggregate((l, r) => l.Queue.Count < r.Queue.Count ? l : r)
                                        .Queue.Add(_Hotel.Guests.Single(g => g.Name == data.Key + data.Value).Room);*/

                                }

                                _Hotel.DirtyRooms.Add(_Hotel.Guests.Single(g => g.Name == data.Key + data.Value).Room);
                            }
                        }
                    }
                    break;
                case HotelEventType.CLEANING_EMERGENCY:
                    Cleaner cleaner = _Hotel.Cleaners.Aggregate((l, r) => l.Queue.Count < r.Queue.Count ? l : r);
                    if (Event.Data != null)
                    {
                        //TODO cleaning time later pas setten/laten aflopen als ze bij de goede kamer zijn
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (data.Key == "kamer")
                                _Hotel.DirtyRooms.Insert(0,
                                    _Hotel.iRoom.OfType<Room>().Single(r => r.ID == int.Parse(data.Value)));
                            if (data.Key == "HTE")
                                cleaner.CleaningTime = int.Parse(data.Value);
                        }
                    }

                    break;
                case HotelEventType.EVACUATE:
                    //evacuate uhhhhh
                    foreach (Guest guest in _Hotel.Guests)
                    {
                        guest.Evacuate();
                    }
                    break;
                case HotelEventType.GODZILLA:
                        //GOJIRA
                        //BREAK STUFF
                        //NIET MEER NODIG
                    break;
                case HotelEventType.GOTO_CINEMA:
                    //foreach (KeyValuePair<string, string> data in Event.Data)
                    //{
                    //    if (data.Key == "Gast")
                    //    {
                    //        _Hotel.Guests.Single(g => g.Name == data.Key + data.Value).FindRoom();
                    //    }
                    //}
                    break;
                case HotelEventType.GOTO_FITNESS:
                    //guest goes to gym
                    break;
                case HotelEventType.NEED_FOOD:
                    //guest hungry and goes to restaurant
                    break;
                case HotelEventType.START_CINEMA:
                    //starts the movie, cinema cant be entered anymore, cinema timer starts running
                    break;
                default:
                    //doe iets
                    break;
            }
        }
    }
}
