using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using HotelProject.Rooms;
using HotelEvents;

namespace HotelProject
{
    //TODO Code maken zodat er hallen worden toegevoegd!
    public class Hotel
    {
        public List<IRoom> iRoom { get; set; }
        public List<Guest> Guests { get; set; }
        public List<Cleaner> Cleaners { get; set; }
        private static Hotel Instance { get; set; }

        private Hotel()
        {
            iRoom = JSONreader();
            Guests = new List<Guest>();
            AddLiftAndStairs();
            SetNeighbours();
        }

        //TODO Summary schrijven
        public static Hotel GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Hotel();
            }
            return Instance;
        }

        //TODO Summary schrijven
        private List<IRoom> JSONreader()
        {
            List<IRoom> rooms;

            try
            {
                using (StreamReader r = new StreamReader("Resources\\Hotel.layout"))
                {
                    string json = r.ReadToEnd();
                    rooms = JsonConvert.DeserializeObject<List<IRoom>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            #region asdf
            //foreach (IRoom r in rooms)
            //{
            //    if (r.AreaType == "Cinema")
            //    {
            //        rooms.Add(new Cinema() {
            //            AreaType = r.AreaType,
            //            Position = r.Position,
            //            Dimension = r.Dimension,
            //            Capacity = r.Capacity
            //        });
            //    }
            //    else if (r.AreaType == "Restaurant")
            //    {
            //        rooms.Add(new Restaurant()
            //        {
            //            AreaType = r.AreaType,
            //            Position = r.Position,
            //            Dimension = r.Dimension,
            //            Capacity = r.Capacity
            //        });
            //    }
            //    else if (r.AreaType == "Fitness")
            //    {
            //        rooms.Add(new Fitness()
            //        {
            //            AreaType = r.AreaType,
            //            Position = r.Position,
            //            Dimension = r.Dimension,
            //            Capacity = r.Capacity
            //        });
            //    }
            //    else if (r.AreaType == "Room")
            //    {
            //        rooms.Add(new Room(r.Classification)
            //        {
            //            AreaType = r.AreaType,
            //            Position = r.Position,
            //            Dimension = r.Dimension,
            //            Capacity = r.Capacity
            //        });
            //    }
            //    rooms.Remove(r);
            //}
            #endregion
            return rooms;
        }

        /// <summary>
        /// Get the width of the hotel
        /// </summary>
        /// <param name="rooms">the list of all the rooms in the hotel</param>
        /// <returns>Width of the hotel</returns>
        private int GetMaxX(List<IRoom> rooms)
        {
            int x = 0;
            foreach (IRoom room in rooms)
            {
                if (room.Position.X + room.Dimension.X - 1 > x)
                    x = room.Position.X + room.Dimension.X - 1;
            }

            return x;
        }

        /// <summary>
        /// get the amount of floors of the hotel
        /// </summary>
        /// <param name="rooms">list of rooms in the hotel</param>
        /// <returns>amount of floors of the hotel</returns>
        private int GetMaxY(List<IRoom> rooms)
        {
            int y = 0;
            foreach (IRoom room in rooms)
            {
                if (room.Position.Y + room.Dimension.Y - 1 > y)
                    y = room.Position.Y;
            }

            return y + 1;
        }

        //TODO kijken of deze methode op een andere plek moet in Form1.
        /// <summary>
        /// gets the maximum height of the hotel (is different from amount of floors if there are rooms on the top floor that take up 2 floors)
        /// </summary>
        /// <returns>maximum height</returns>
        public int GetMaxHeight()
        {
            int y = 0;
            foreach (IRoom room in iRoom)
            {
                if (room.Position.Y + room.Dimension.Y - 1 > y)
                    y = room.Position.Y + room.Dimension.Y - 1;
            }

            return y;
        }

        /// <summary>
        /// adds the lobby, Lift and Stairs to iRoom
        /// </summary>
        private void AddLiftAndStairs()
        {
            int x = GetMaxX(iRoom);
            int y = GetMaxY(iRoom);

            for (int i = 0; i < y; i++)
            {
                IRoom elevator = new IRoom();
                elevator.Position = new Point(0, i);
                elevator.Dimension = new Point(1, 1);
                elevator.AreaType = "Elevator";
                iRoom.Add(elevator);

                IRoom stairs = new IRoom();
                stairs.Position = new Point(x + 1, i);
                stairs.Dimension = new Point(1,1);
                stairs.AreaType = "Stairs";
                iRoom.Add(stairs);
            }

            IRoom lobby = new IRoom();
            lobby.Position = new Point(1, 0);
            lobby.Dimension = new Point(x, 1);
            lobby.AreaType = "Lobby";
            iRoom.Add(lobby);
        }
        
        //TODO Wordt herschreven want hallen zullen worden toegevoegd als rooms voor betere pathfinding
        /// <summary>
        /// sets the neighbours of each room.
        /// </summary>
        private void SetNeighbours()
        {
            foreach (IRoom room in iRoom)
            {
                foreach (IRoom room2 in iRoom)
                {
                    //TODO distance van trap en lift instelbaar maken.
                    //TODO trap 2 keer zo langzaam maken als de lift
                    if (((room.AreaType == "Elevator" && room2.AreaType == "Elevator") ||
                         (room.AreaType == "Stairs" && room2.AreaType == "Stairs")) &&
                        (room.Position.Y - room2.Position.Y == 1 || room2.Position.Y - room.Position.Y == 1))
                    {
                        room.Neighbours.Add(room2, 1);
                    }

                    if (room.Position.X + room.Dimension.X == room2.Position.X && room.Position.Y == room2.Position.Y)
                    {
                        room.Neighbours.Add(room2, room.Dimension.X);
                        room2.Neighbours.Add(room, room.Dimension.X);
                        break;
                    }
                }

                CheckBelow(1, iRoom, room);
            }
        }

        //TODO nagaan van logica hier. lijkt iets mis te gaan
        //TODO Summary schrijven
        private static void CheckBelow(int offset, List<IRoom> rooms, IRoom room)
        {
            for (int i = room.Position.Y - 1; i > 0; i--)
            {
                foreach (IRoom room2 in rooms)
                {
                    if (room.Position.X + room.Dimension.X - 1 + offset == room2.Position.X && i == room2.Position.Y && room.Position.Y - room2.Position.Y < room2.Dimension.Y)
                    {
                        offset += room2.Dimension.X;
                        foreach (IRoom room3 in rooms)
                        {
                            if (room.Position.X + room.Dimension.X - 1 + offset == room3.Position.X && room.Position.Y == room3.Position.Y && !room.Neighbours.ContainsKey(room3))
                            {
                                room.Neighbours.Add(room3, offset);
                                room3.Neighbours.Add(room, offset);
                                return;
                            }
                        }
                        CheckBelow(offset, rooms, room);
                    }
                }
            }
        }

        public void SetCleanerAmount(int amount)
        {
            Cleaners = new List<Cleaner>();
            for (int i = 1; i <= amount; i++)
            {
                Cleaner cleaner = new Cleaner();
                cleaner.Name = "Cleaner" + i;
                Cleaners.Add(cleaner);
            }

        }
    }
}
