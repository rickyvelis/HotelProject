using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using HotelProject.Rooms;

namespace HotelProject
{

    class Hotel
    {
        public Form1 Form { get; set; }

        public Hotel(Form1 form)
        {
            Form = form;
            List<IRoom> iRoom = JSONreader();
            AddLiftAndStairs(iRoom);
            SetNeighbours(iRoom);
        }

        public List<IRoom> JSONreader()
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

            foreach (IRoom r in rooms)
            {
                if (r.AreaType == "Cinema")
                {
                    rooms.Add(new Cinema() {
                        AreaType = r.AreaType,
                        Position = r.Position,
                        Dimension = r.Dimension,
                        Capacity = r.Capacity
                    });
                }
                else if (r.AreaType == "Restaurant")
                {
                    rooms.Add(new Restaurant()
                    {
                        AreaType = r.AreaType,
                        Position = r.Position,
                        Dimension = r.Dimension,
                        Capacity = r.Capacity
                    });
                }
                else if (r.AreaType == "Fitness")
                {
                    rooms.Add(new Fitness()
                    {
                        AreaType = r.AreaType,
                        Position = r.Position,
                        Dimension = r.Dimension,
                        Capacity = r.Capacity
                    });
                }
                else if (r.AreaType == "Room")
                {
                    rooms.Add(new Room(r.Classification)
                    {
                        AreaType = r.AreaType,
                        Position = r.Position,
                        Dimension = r.Dimension,
                        Capacity = r.Capacity
                    });
                }
                rooms.Remove(r);
            }
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

            return y;
        }

        /// <summary>
        /// Adds the elevators and stairs to the rooms list
        /// </summary>
        /// <param name="rooms">list of all the rooms in the hotel</param>
        /// <returns>updated list of rooms with the elevators and stairs now included</returns>
        private List<IRoom> AddLiftAndStairs(List<IRoom> rooms)
        {
            int x = GetMaxX(rooms);
            int y = GetMaxY(rooms);

            for (int i = 0; i < y; i++)
            {
                IRoom elevator = new IRoom();
                elevator.Position = new Point {X = 0, Y = i};
                elevator.Dimension = new Point{X = 1, Y = 1};
                elevator.AreaType = "Elevator";
                rooms.Add(elevator);

                IRoom stairs = new IRoom();
                stairs.Position = new Point{X = x + 1, Y = i};
                stairs.Dimension = new Point{X = 1, Y = 1};
                stairs.AreaType = "Stairs";
                rooms.Add(stairs);
            }
            return rooms;
        }
            
        /// <summary>
        /// sets the neighbours for each room.
        /// </summary>
        /// <param name="iRoom">a list of all the rooms from the layout file</param>
        /// <returns>updated list with the neighbours set</returns>
        private List<IRoom> SetNeighbours(List<IRoom> iRoom)
        {
            foreach (IRoom room in iRoom)
            {
                foreach (IRoom room2 in iRoom)
                {
                    //TODO distance van trap en lift instelbaar maken
                    if (((room.AreaType == "Elevator" && room2.AreaType == "Elevator") ||
                         (room.AreaType == "Stairs" && room2.AreaType == "Stairs")) &&
                        (room.Position.Y - room2.Position.Y == 1 || room2.Position.Y - room.Position.Y == 1))
                    {
                        room.Neighbours.Add(room2, 1);
                    }

                    if (room.Position.X + room.Dimension.X == room2.Position.X && room.Position.Y == room2.Position.Y)
                    {
                        //TODO checks op hoogtes of er wel plek is om te lopen (bijv als y 2 is kan je er wel nog lopen).
                        room.Neighbours.Add(room2, room.Dimension.X);
                        room2.Neighbours.Add(room, room.Dimension.X);
                        break;
                    }

                    for (int i = room.Position.Y - 1; i > 0; i--)
                    {
                        if (room.Position.X + room.Dimension.X == room2.Position.X && i == room2.Position.Y &&
                            room.Position.Y - room2.Position.Y + 1 < room2.Dimension.Y)
                        {

                        }
                    }
                }
            }
            return iRoom;
        }
    }


}
