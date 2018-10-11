using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;
using HotelProject.Rooms;
using HotelEvents;

namespace HotelProject
{
    //TODO Code maken zodat er hallen worden toegevoegd!
    public class Hotel
    {
        public List<IRoom> iRoom { get; set; }
        private List<IRoom> iRoom2 { get; set; }
        public List<Guest> Guests { get; set; }
        public List<Cleaner> Cleaners { get; set; }
        private static Hotel Instance { get; set; }
        private RoomFactory RFactory { get; set; }

        private Hotel()
        {
            iRoom = new List<IRoom>();
            JSONreader();
            Guests = new List<Guest>();
            AddLiftAndStairs();
            //CreateHalls();
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
        private void JSONreader()
        {
            try
            {
                using (StreamReader r = new StreamReader("Resources\\Hotel.layout"))
                {
                    string json = r.ReadToEnd();
                    RFactory = new RoomFactory();
                    foreach (dynamic room in JsonConvert.DeserializeObject<List<dynamic>>(json))
                    {
                        IRoom room2 = RFactory.CreateRoom(room);
                        iRoom.Add(room2);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }            
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
            dynamic room = new ExpandoObject();

            for (int i = 0; i < y; i++)
            {
                room.AreaType = "Elevator";
                room.Position = i;
                IRoom elevator = RFactory.CreateRoom(room);
                iRoom.Add(elevator);

                room.AreaType = "Stairs";
                room.Position = (x + ", " + i);
                IRoom stairs = RFactory.CreateRoom(room);
                iRoom.Add(stairs);
            }

            //IRoom lobby = new IRoom();

            room.AreaType = "Lobby";
            room.Dimension = x;
            IRoom lobby = RFactory.CreateRoom(room);
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


        //TODO code mogelijk verbeteren.
        private void CreateHalls()
        {
            iRoom2 = new List<IRoom>();
            foreach (IRoom room in iRoom)
            {
                for (int i = room.Dimension.X; i > 0; i--)
                {
                    for (int j = room.Dimension.Y; j > 0; j--)
                    {
                        if (room.Dimension.X != 1 && room.Dimension.Y != 1)
                        {
                            //IRoom hall = new Room();
                            //hall.AreaType = "Hall";
                            //hall.Dimension = new Point(1, 1);
                            //hall.Position = new Point(i + room.Position.X - 1, j + room.Position.Y - 1);
                            //iRoom2.Add(hall);
                        }
                    }
                }
            }

            foreach (IRoom room in iRoom2)
            {
                iRoom.Add(room);
            }
        }
    }


}
