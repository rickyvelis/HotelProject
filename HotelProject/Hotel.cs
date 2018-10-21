using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using HotelProject.Rooms;
using HotelProject.Humans;

namespace HotelProject
{
    public class Hotel
    {
        public List<IRoom> iRoom { get; set; }
        private List<IRoom> iRoom2 { get; set; }
        public List<Human> Humans { get; set; }
        public List<Room> DirtyRooms { get; set; }
        private static Hotel Instance { get; set; }
        private RoomFactory RFactory { get; set; }
        private HumanFactory HFactory { get; set; }
        public Elevator Elevator { get; set; }
        public int CleanDuration { get; set; }
        public int EatDuration { get; set; }
        public bool Evacuating { get; set; }

        private Hotel()
        {
            DirtyRooms = new List<Room>();
            iRoom = new List<IRoom>();
            JSONreader();
            Humans = new List<Human>();
            AddLiftAndStairs();
            CreateHalls();
            SetNeighbours();
        }

        /// <summary>
        /// If no instance of Hotel exists, create Hotel.
        /// </summary>
        /// <returns>Returns the instance of Hotel.</returns>
        public static Hotel GetInstance()
        {
            if (Instance == null)
                Instance = new Hotel();
            return Instance;
        }

        /// <summary>
        /// Creates an elevator for the hotel. This is not done in the constructor as this would cause erros bc Hotel is a singleton and elevator also creates hotel.
        /// </summary>
        public void CreateElevator(int elevatorDelay)
        {
            Elevator = new Elevator(elevatorDelay);
        }

        /// <summary>
        /// Reads the layout file and uses the room factory to create the rooms of the hotel
        /// </summary>
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
        /// <returns>Width of the hotel</returns>
        private int GetMaxX()
        {
            int x = 0;
            foreach (IRoom room in iRoom)
            {
                if (room.Position.X + room.Dimension.X - 1 > x)
                    x = room.Position.X + room.Dimension.X - 1;
            }

            return x;
        }

        /// <summary>
        /// get the amount of floors of the hotel
        /// </summary>
        /// <returns>amount of floors of the hotel</returns>
        public int GetMaxY()
        {
            int y = 0;
            foreach (IRoom room in iRoom)
            {
                if (room.Position.Y + room.Dimension.Y - 1 > y)
                    y = room.Position.Y;
            }

            return y + 1;
        }

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
            int x = GetMaxX();
            int y = GetMaxY();
            dynamic room = new ExpandoObject();

            for (int i = 0; i < y; i++)
            {
                room.AreaType = "Elevator";
                room.Position = i;
                IRoom elevator = RFactory.CreateRoom(room);
                iRoom.Add(elevator);

                room.AreaType = "Stairs";
                room.Position = ((x + 1) + ", " + i);
                IRoom stairs = RFactory.CreateRoom(room);
                iRoom.Add(stairs);
            }
            room.AreaType = "Lobby";
            room.Dimension = x;
            IRoom lobby = RFactory.CreateRoom(room);
            iRoom.Add(lobby);
        }
        
        /// <summary>
        /// sets the neighbours of each room.
        /// </summary>
        private void SetNeighbours()
        {
            foreach (IRoom room in iRoom)
            {
                foreach (IRoom room2 in iRoom)
                {
                    if (room.AreaType == "Elevator" && room2.AreaType == "Elevator" &&
                        room.Position.Y + 1 == room2.Position.Y)
                    {
                        room.Neighbours.Add(room2, 1);
                        room2.Neighbours.Add(room, 1);
                    }

                    if (room.AreaType == "Stairs" && room2.AreaType == "Stairs" &&
                        room.Position.Y + 1 == room2.Position.Y)
                    {
                        room.Neighbours.Add(room2, 2);
                        room2.Neighbours.Add(room, 2);
                    }

                    if (room.Position.X + 1 == room2.Position.X && room.Position.Y == room2.Position.Y)
                    {
                        room.Neighbours.Add(room2, 1);
                        room2.Neighbours.Add(room, 1);
                    }
                }
            }
        }

        /// <summary>
        /// Creates Hallways in the hotel at the right locations using the dimensions of rooms
        /// </summary>
        private void CreateHalls()
        {
            iRoom2 = new List<IRoom>();
            foreach (IRoom room in iRoom)
            {
                for (int i = room.Dimension.X; i > 0; i--)
                {
                    for (int j = room.Dimension.Y; j > 0; j--)
                    {
                        if (i != 1 || j != 1)
                        {                            
                            dynamic hall = new ExpandoObject();                            
                            hall.AreaType = "Hall";
                            hall.Position = ((i + room.Position.X - 1) + ", " + (j + room.Position.Y - 1)); 
                            iRoom2.Add(RFactory.CreateRoom(hall));
                        }
                    }
                }
            }

            foreach (IRoom room in iRoom2)
            {
                iRoom.Add(room);
            }
        }

        /// <summary>
        /// Sets the amount of cleaners and how many HTE it takes to clean a room
        /// </summary>
        /// <param name="amount">amount of cleaners</param>
        /// <param name="cleaningTime">amount of HTE it takes to clean a room</param>
        public void SetCleaners(int amount, int cleaningTime)
        {
            CleanDuration = cleaningTime;
            for (int i = 1; i <= amount; i++)
            {
                HFactory = new HumanFactory();
                Human cleaner = HFactory.CreateHuman("cleaner");
                cleaner.Name = "Cleaner" + i;
                Humans.Add(cleaner);
            }
        }

        /// <summary>
        /// Sets the screening time for each Cinema in the Hotel
        /// </summary>
        /// <param name="screeningTime"></param>
        public void SetScreeningTime(int screeningTime)
        {
            foreach (Cinema c in iRoom.OfType<Cinema>())
                c.ScreeningTime = screeningTime;
        }

        /// <summary>
        /// When all evacuees have evacuated (reached the Lobby), each guest gets sent back to their room and cleaners will continue cleaning
        /// </summary>
        public void EvacuatingDone()
        {            
            if (Humans.TrueForAll(r => r.Position.AreaType == "Lobby") && Evacuating)
            {
                Evacuating = false;
                foreach (Guest guest in Humans.OfType<Guest>())
                {
                    guest.Evacuating = false;
                    guest.Go_Back();
                }
            }
        }

        /// <summary>
        /// Updates the object behaviour and property values
        /// </summary>
        public void Update()
        {
            CheckDirtyRooms();
            Elevator.DoEvents();
        }

        /// <summary>
        /// Checks the first dirty room in the DirtyRooms list, finds the nearest available cleaner and notifies that cleaner
        /// </summary>
        private void CheckDirtyRooms()
        {
            if (DirtyRooms.Count > 0 && Humans.OfType<Cleaner>().Where(c => !c.Cleaning) != null && !Evacuating)
            {
                try
                {
                    GetNearestCleaner().GoCleanRoom(DirtyRooms[0]);
                    DirtyRooms.Remove(DirtyRooms[0]);
                    CheckDirtyRooms();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// Gets the nearest Cleaner to next room in the dirty rooms list.
        /// </summary>
        /// <returns>closest available cleaner</returns>
        private Cleaner GetNearestCleaner()
        {
            Dictionary<Cleaner, int> availableCleaners = new Dictionary<Cleaner, int>();
            int nearest = Int32.MaxValue / 2;

            foreach (Cleaner c in Humans.OfType<Cleaner>().Where(c => !c.Cleaning))
                availableCleaners.Add(c, c.GetDistanceToRoom(DirtyRooms[0]));
            
            foreach (KeyValuePair<Cleaner, int> c in availableCleaners)
                if (c.Value < nearest)
                    nearest = c.Value;

            if (availableCleaners.Count > 0)
                return availableCleaners.First(c => c.Value == nearest).Key;

            return null;
        }
    }
}
