using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Rooms;
using System.Drawing;

namespace HotelProject
{
    public abstract class Human
    {
        public abstract string Name { get; set; }
        public abstract bool Visible { get; set; }
        public abstract List<IRoom> Path { get; set; }
        public abstract IRoom Position { get; set; }
        public abstract Point SpritePosition { get; set; }
        public abstract int Wait { get; set; }
        public abstract Image Img { get; set; }
        public abstract int TargetFloor { get; set; }
        public bool Evacuating { get; set; }
        public bool InElevator { get; set; }

        private Hotel _Hotel { get; }

        protected Human()
        {
            _Hotel = Hotel.GetInstance();
            Evacuating = false;
            InElevator = false;
            Wait = 0;
            TargetFloor = 0;
        }

        abstract public void Update();
        abstract public void Evacuate();

        /// <summary>
        /// Sets the Position of the Human object
        /// </summary>
        /// <param name="x">The X coördinate</param>
        /// <param name="y">The X coördinate</param>
        public void SetPosition(int x, int y)
        {
            Position = _Hotel.iRoom.Single(r => r.Position.X == x && r.Position.Y == y);
            //SpritePosition = new Point(Position.Position.X * 128, (_Hotel.GetMaxHeight() - Position.Position.Y + 1) * 89 - 25);
            SpritePosition = new Point(x, y);
        }

        #region Pathfinding code

        /// <summary>
        /// Uses the Dijkstra-algorithm to give a list of rooms which a Guest needs to traverse in order to reach the given destination
        /// </summary>
        /// <param name="destination">Destination</param>        
        /// <returns></returns>
        public List<IRoom> FindRoom(IRoom destination)
        {
            TargetFloor = destination.Position.Y;
            if (Position != destination)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(Name + " GOES FROM " + Position.AreaType + " " + Position.Position.ToString() + " " + Position.ID +
                    " TO " + destination.AreaType + " " + destination.Position.ToString() + " " + destination.ID);

                List<IRoom> roomsToSearch = new List<IRoom>(_Hotel.iRoom);

                foreach (IRoom room in roomsToSearch)
                    room.Distance = Int32.MaxValue / 2;

                IRoom current = Position;
                while (!Visit(current, destination, roomsToSearch)) //Do this until the destination node has been visited
                    current = roomsToSearch.Aggregate((l, r) => l.Distance < r.Distance ? l : r); //if(l.Distance < r.Distance) { return l; } else { return r; }

                return MakePath(destination);
            }
            else return null;
        }

        /// <summary>
        /// Method that visits a room for the Dijkstra-algorithm
        /// </summary>
        /// <param name="current">The room to be visited</param>
        /// <param name="end">Destination</param>
        /// <param name="roomsToSearch">List of all the rooms in the hotel</param>
        /// <returns></returns>
        public bool Visit(IRoom current, IRoom end, List<IRoom> roomsToSearch)
        {
            //Console.WriteLine("Visiting " + current.AreaType + " at " + current.Position.ToString());
            if (current == end) //Checks if the destination is visited
            {
                return true;
            }
            if (roomsToSearch.Contains(current))
            {
                roomsToSearch.Remove(current); //Every visited room will be removed from the list of all the rooms
            }
            foreach (KeyValuePair<IRoom, int> x in current.Neighbours) //This checks every neighbouring room
            {
                int newDistance = x.Value;
                if (current != Position)
                {
                    newDistance = current.Distance + x.Value;
                }
                if (newDistance < x.Key.Distance && ((_Hotel.Evacuating && x.Key.AreaType != "Elevator") || !_Hotel.Evacuating)) //If the new distance of the neighbour is shorter than the distance it already had, the neighbour gets assigned the new distance
                {
                    x.Key.Distance = newDistance; //THe current neighbour gets a distance, which is the already traversed distance + the distance of the current room to the neighbour
                    x.Key.Previous = current; //The current neighbour get the current room assigned ass Previous
                }
            }
            return false;
        }

        /// <summary>
        /// Gives the path a guest needs to take in order to reach the given room
        /// </summary>
        /// <param name="end">Destination</param>
        /// <returns></returns>
        private List<IRoom> MakePath(IRoom end)
        {
            IRoom previous = end.Previous;
            Path = new List<IRoom>();
            Path.Add(end);
            string path = "" + end.AreaType + " " + end.Position.ToString();

            while (previous != null)
            {
                Path.Add(previous);
                path = "" + previous.AreaType + " " + previous.Position.ToString() + " -> " + path;

                if (previous == Position)
                    break;

                previous = previous.Previous;
            }

            int First = 0;
            int CountShafts = 0;

            First = Path.FindIndex(r => r.AreaType == "Elevator");

            for (int i = 0; i < Path.Count - 1; i++)
            {
                if (Path[i].AreaType == "Elevator")
                {
                    CountShafts++;
                }
            }

            if (CountShafts > 0)
            {
                Path.RemoveRange(First, CountShafts - 1);
            }

            return Path;
        }

        #endregion


        /// <summary>
        /// Gets the distance from this Human to the given Room
        /// </summary>
        /// <param name="room">The given Room</param>
        /// <returns></returns>
        public int GetDistanceToRoom(IRoom room)
        {
            List<IRoom> roomsToSearch = new List<IRoom>(_Hotel.iRoom);

            foreach (IRoom r in roomsToSearch)
                r.Distance = Int32.MaxValue / 2;

            IRoom current = Position;
            while (!Visit(current, room, roomsToSearch)) //Voer dit uit totdat de end node is bezocht
                current = roomsToSearch.Aggregate((l, r) => l.Distance < r.Distance ? l : r); //if(l.Distance < r.Distance) { return l; } else { return r; }

            return room.Distance;
        }

        /// <summary>
        /// Makes this Human move on the Form and updates its Position
        /// </summary>
        public void Step()
        {
            //TODO code iets verbeteren zodat ze niet direct lopen bij een distance groter dan 1
            //TODO If(Lift == vol && Path[Path.Count - 1].AreaType == "Lift"){ WACHTEN }
            if (Path != null && Path.Count > 0)
            {

                if (Wait != 0)
                {
                    Wait--;
                }
                else if (Path[Path.Count - 1].AreaType == "Stairs")
                {
                    
                    Wait++;
                }

                //TODO if statement mogelijk schijden/opruimen
                if (Wait == 0)
                {
                    if ((Position.AreaType != "Elevator" && Path[Path.Count - 1].AreaType != "Elevator") ||
                        (Position.AreaType != "Elevator" && Path[Path.Count - 1].AreaType == "Elevator" &&
                         _Hotel.elevator.CurrentFloor == Path[Path.Count - 1].Position.Y &&
                         _Hotel.elevator.DoorsOpen) ||
                        (Position.AreaType == "Elevator" &&
                         _Hotel.elevator.CurrentFloor == Path[Path.Count - 1].Position.Y && _Hotel.elevator.DoorsOpen))
                    {
                        if (Position.AreaType != "Elevator" && Path[Path.Count - 1].AreaType == "Elevator" &&
                            _Hotel.elevator.CurrentFloor == Path[Path.Count - 1].Position.Y &&
                            _Hotel.elevator.DoorsOpen)
                        {
                            InElevator = true;
                        }

                        if (Position.AreaType == "Elevator" &&
                            _Hotel.elevator.CurrentFloor == Path[Path.Count - 1].Position.Y && _Hotel.elevator.DoorsOpen)
                        {
                            InElevator = false;
                        }

                        SetPosition(Path[Path.Count - 1].Position.X, Path[Path.Count - 1].Position.Y);
                        Path.Remove(Path[Path.Count - 1]);
                        Wait = 0;
                    }
                    else if (Position.AreaType != "Elevator" && Path.Count > 0 && Path[Path.Count - 1].AreaType == "Elevator")
                    {
                        if (TargetFloor > Position.Position.Y)
                        {
                            _Hotel.iRoom.OfType<ElevatorShaft>()
                                .First(r => r.Position == new Point(0, Position.Position.Y)).UpPressed = true;
                        }

                        if (TargetFloor < Position.Position.Y)
                        {
                            _Hotel.iRoom.OfType<ElevatorShaft>()
                                .First(r => r.Position == new Point(0, Position.Position.Y)).DownPressed = true;
                        }
                    }
                }  
            }
        }
    }
}
