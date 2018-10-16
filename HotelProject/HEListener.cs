﻿using System;
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
        private HumanFactory HFactory { get; set; }

        public HEListener()
        {
            _Hotel = Hotel.GetInstance();
            HFactory = new HumanFactory();
        }

        public void Notify(HotelEvent Event)
        {
            #region MyRegion Printing out stuff for us for checks
            
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
                            if (!_Hotel.Humans.Exists(r => r.Name == data.Key))
                            {
                                string search = data.Value;
                                Guest guest = HFactory.CreateHuman("guest");
                                guest.Name = data.Key;
                                _Hotel.Humans.Add(guest);

                                if (search == "Checkin 1stars")
                                {
                                    foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                    {
                                        if (room.Available && room.Classification == "1 Star")
                                        {
                                            guest.Room = room;
                                            room.Available = false;
                                            guest.FindRoom(room);
                                            return;
                                        }
                                    }
                                    search = "Checkin 2stars";
                                }

                                if (search == "Checkin 2stars")
                                {
                                    foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                    {
                                        if (room.Available && room.Classification == "2 stars")
                                        {
                                            guest.Room = room;
                                            room.Available = false;
                                            guest.FindRoom(room);
                                            return;
                                        }
                                    }
                                    search = "Checkin 3stars";
                                }

                                if (search == "Checkin 3stars")
                                {
                                    foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                    {
                                        if (room.Available && room.Classification == "3 stars")
                                        {
                                            guest.Room = room;
                                            room.Available = false;
                                            guest.FindRoom(room);
                                            return;
                                        }
                                    }
                                    search = "Checkin 4stars";
                                }

                                if (search == "Checkin 4stars")
                                {
                                    foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                    {
                                        if (room.Available && room.Classification == "4 stars")
                                        {
                                            guest.Room = room;
                                            room.Available = false;
                                            guest.FindRoom(room);
                                            return;
                                        }
                                    }
                                    search = "Checkin 5stars";
                                }

                                if (search == "Checkin 5stars")
                                {
                                    foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                    {
                                        if (room.Available && room.Classification == "5 stars")
                                        {
                                            guest.Room = room;
                                            room.Available = false;
                                            guest.FindRoom(room);
                                            return;
                                        }
                                    }
                                }

                                _Hotel.Humans.Remove(guest);
                                #region oude code                               
                                //switch (data.Value)
                                //{
                                //    case ("Checkin 1stars"):
                                //        foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //        {
                                //            if (room.Available && room.Classification == "1 Star")
                                //            {
                                //                guest.Room = room;
                                //                room.Available = false;
                                //                roomFound = true;
                                //                guest.FindRoom(room);
                                //                break;
                                //            }                                            
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "2 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "3 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "4 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "5 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if(!roomFound)
                                //            _Hotel.Humans.Remove(guest);

                                //        break;

                                //    case ("Checkin 2stars"):
                                //        foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //        {
                                //            if (room.Available && room.Classification == "2 stars")
                                //            {
                                //                guest.Room = room;
                                //                room.Available = false;
                                //                roomFound = true;
                                //                guest.FindRoom(room);
                                //                break;
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "3 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "4 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "5 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }
                                //        if(!roomFound)
                                //            _Hotel.Humans.Remove(guest);

                                //        break;

                                //    case ("Checkin 3stars"):
                                //        foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //        {
                                //            if (room.Available && room.Classification == "3 stars")
                                //            {
                                //                guest.Room = room;
                                //                room.Available = false;
                                //                roomFound = true;
                                //                guest.FindRoom(room);
                                //                break;
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "4 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "5 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if(!roomFound)
                                //            _Hotel.Humans.Remove(guest);

                                //        break;

                                //    case ("Checkin 4stars"):
                                //        foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //        {
                                //            if (room.Available && room.Classification == "4 stars")
                                //            {
                                //                guest.Room = room;
                                //                room.Available = false;
                                //                roomFound = true;
                                //                guest.FindRoom(room);
                                //                break;
                                //            }
                                //        }

                                //        if (!roomFound)
                                //        {
                                //            foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //            {
                                //                if (room.Available && room.Classification == "5 stars")
                                //                {
                                //                    guest.Room = room;
                                //                    room.Available = false;
                                //                    roomFound = true;
                                //                    guest.FindRoom(room);
                                //                    break;
                                //                }
                                //            }
                                //        }

                                //        if(!roomFound)
                                //            _Hotel.Humans.Remove(guest);

                                //        break;

                                //    case ("Checkin 5stars"):
                                //        foreach (Room room in _Hotel.iRoom.OfType<Room>())
                                //        {
                                //            if (room.Available && room.Classification == "5 stars")
                                //            {
                                //                guest.Room = room;
                                //                room.Available = false;
                                //                roomFound = true;
                                //                guest.FindRoom(room);
                                //                break;
                                //            }
                                //        }

                                //        if(!roomFound)
                                //            _Hotel.Humans.Remove(guest);
                                //        break;
                                //}      

                                #endregion
                            }
                        }
                    }
                    break;
                case HotelEventType.CHECK_OUT:
                    if (Event.Data != null)
                    {
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (_Hotel.Humans.Exists(g => g.Name == data.Key + data.Value))
                            {
                                _Hotel.Humans.OfType<Guest>().Single(g => g.Name == data.Key + data.Value).CheckOut();

                                /*
                                if (_Hotel.Humans.OfType<Cleaner>() != null) 
                                    //TODO maybe make this line shorter and more understandable
                                    //TODO kijken of cleaner zelf bezig is??

                                    //gets cleaner with shortest queue and adds the to-be-cleaned room to its queue
                                    _Hotel.Cleaners.Aggregate((l, r) => l.Queue.Count < r.Queue.Count ? l : r)
                                        .Queue.Add(_Hotel.Guests.Single(g => g.Name == data.Key + data.Value).Room);
                                        */
                            }
                        }
                    }
                    break;
                case HotelEventType.CLEANING_EMERGENCY:
                    //TODO Reset CleaningTime to standard value after CLEANING_EMERGENCY is over
                    if (Event.Data != null)
                    {
                        //TODO cleaning time later pas setten/laten aflopen als ze bij de goede kamer zijn
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (data.Key == "kamer")
                                _Hotel.DirtyRooms.Insert(0,
                                    _Hotel.iRoom.OfType<Room>().Single(r => r.ID == int.Parse(data.Value)));
                            //if (data.Key == "HTE")
                            //    cleaner.CleaningTime = int.Parse(data.Value);
                        }
                    }

                    break;
                case HotelEventType.EVACUATE:
                    //Every human object goes to the lobby within a certain given timeframe
                    _Hotel.Evacuating = true;
                    foreach (Human guest in _Hotel.Humans)
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
                    if (Event.Data != null)
                    {
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (data.Key == "Gast")
                            {
                                Dictionary<Cinema, int> cinemaDistances = new Dictionary<Cinema, int>();

                                //Goes through every cinema which hasn't started yet
                                foreach (Cinema c in _Hotel.iRoom.OfType<Cinema>().Where(c => !c.IsScreening))
                                    //saves all the distances to the cinemaDistances dictionary
                                    cinemaDistances.Add(c, _Hotel.Humans.Single(g => g.Name == data.Key + data.Value).GetDistanceToRoom(c));

                                //Sends the specified Guest to the nearest Cinema
                                Cinema nearestCinema = cinemaDistances.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                                nearestCinema.Visitors.Add(_Hotel.Humans.OfType<Guest>().Single(g => g.Name == data.Key + data.Value));
                                _Hotel.Humans.Single(g => g.Name == data.Key + data.Value).FindRoom(nearestCinema);
                            }
                        }
                    }
                    break;
                case HotelEventType.GOTO_FITNESS:
                    //Given guest goes to nearest gym and stays there for a given amount of HTE
                    break;
                case HotelEventType.NEED_FOOD:
                    //Given guest goes to nearest restaurant and stays there for some time (HOW LONG???)
                    break;
                case HotelEventType.START_CINEMA:
                    //Starts the given cinema and throws out guests after the movie is over
                    if (Event.Data != null)
                    {
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if(data.Key == "ID" && _Hotel.iRoom.Exists(r => r.ID == int.Parse(data.Value) && r is Cinema))
                            {
                                _Hotel.iRoom.OfType<Cinema>().Single(r => r.ID == int.Parse(data.Value)).Start();
                            }
                        }
                    }
                    break;
                default:
                    //doe (n)iets
                    break;
            }
        }
    }
}
