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
                                _Hotel.Humans.OfType<Guest>().Single(g => g.Name == data.Key + data.Value).CheckOut();
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
                    if (Event.Data != null)
                    {
                        _Hotel.Evacuating = true;
                        foreach (Human guest in _Hotel.Humans)
                        {
                            guest.Evacuate();
                        }
                    }
                    break;
                case HotelEventType.GODZILLA:
                    if (Event.Data != null)
                    {
                        //GOJIRA
                        //BREAK STUFF
                        //NIET MEER NODIG
                    }
                    break;
                case HotelEventType.GOTO_CINEMA:
                    if (Event.Data != null)
                    {
                        string guestName = "";
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (data.Key == "Gast")
                            {
                                guestName = data.Key + data.Value;
                                if (_Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).NeedFood
                                    || _Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).NeedWorkout)
                                    break;

                                Dictionary<Cinema, int> cinemaDistances = new Dictionary<Cinema, int>();

                                //Goes through every cinema which hasn't started yet
                                foreach (Cinema c in _Hotel.iRoom.OfType<Cinema>().Where(c => !c.IsScreening))
                                    //saves all the distances to the cinemaDistances dictionary
                                    cinemaDistances.Add(c, _Hotel.Humans.Single(g => g.Name == guestName).GetDistanceToRoom(c));

                                //Sends the specified Guest to the nearest Cinema
                                Cinema nearestCinema = cinemaDistances.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

                                nearestCinema.Visitors.Add(_Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName));

                                _Hotel.Humans.Single(g => g.Name == guestName).FindRoom(nearestCinema);
                                _Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).NeedMovie = true;
                            }
                        }
                    }
                    break;
                case HotelEventType.GOTO_FITNESS:
                    //Given guest goes to nearest gym and stays there for a given amount of HTE
                    if (Event.Data != null)
                    {
                        string guestName = "";
                        foreach(KeyValuePair<string, string> data in Event.Data)
                        {
                            if (data.Key == "Gast")
                            {
                                guestName = data.Key + data.Value;
                                if (_Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).NeedFood
                                    || _Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).NeedMovie)
                                    break;
                                
                                Dictionary<Fitness, int> gymDistances = new Dictionary<Fitness, int>(); 
                                
                                //Goes through every restaurant
                                foreach (Fitness gym in _Hotel.iRoom.OfType<Fitness>())
                                    //saves all the distances to the cinemaDistances dictionary
                                    gymDistances.Add(gym, _Hotel.Humans.Single(g => g.Name == guestName).GetDistanceToRoom(gym));
                                
                                _Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).NeedWorkout = true;

                                //Sends the specified Guest to the nearest Restaurant
                                _Hotel.Humans.Single(g => g.Name == guestName).
                                    FindRoom(gymDistances.Aggregate((l, r) => l.Value < r.Value ? l : r).Key);
                            }
                            else if (data.Key == "HTE")
                            {
                                _Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).FitnessDuration = int.Parse(data.Value);
                            }
                        }

                    }
                    break;
                case HotelEventType.NEED_FOOD:
                    //Given guest goes to nearest restaurant and stays there for some time (HOW LONG???)
                    if (Event.Data != null)
                    {
                        string guestName = "";
                        foreach (KeyValuePair<string, string> data in Event.Data)
                        {
                            if (data.Key == "Gast")
                            {
                                guestName = data.Key + data.Value;
                                if (_Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).NeedWorkout
                                    || _Hotel.Humans.OfType<Guest>().Single(g => g.Name == guestName).NeedMovie)
                                    break;

                                Dictionary<Restaurant, int> restaurantDistances = new Dictionary<Restaurant, int>();

                                //Goes through every restaurant
                                foreach (Restaurant rest in _Hotel.iRoom.OfType<Restaurant>())
                                    //saves all the distances to the cinemaDistances dictionary
                                    restaurantDistances.Add(rest, _Hotel.Humans.Single(g => g.Name == data.Key + data.Value).GetDistanceToRoom(rest));

                                _Hotel.Humans.OfType<Guest>().Single(g => g.Name == data.Key + data.Value).NeedFood = true;

                                //Sends the specified Guest to the nearest Restaurant
                                _Hotel.Humans.Single(g => g.Name == data.Key + data.Value).
                                    FindRoom(restaurantDistances.Aggregate((l, r) => l.Value < r.Value ? l : r).Key);
                            }
                        }
                    }
                    break;
                case HotelEventType.START_CINEMA:
                    //Starts the given cinema and throws out guests after the movie is over
                    if (Event.Data != null)
                    {
                        foreach (KeyValuePair<string, string> data in Event.Data)
                            if(data.Key == "ID" && _Hotel.iRoom.Exists(r => r.ID == int.Parse(data.Value) && r is Cinema))
                                _Hotel.iRoom.OfType<Cinema>().Single(r => r.ID == int.Parse(data.Value)).Start();
                    }
                    break;
                default:
                    //doe (n)iets
                    break;
            }
        }
    }
}
