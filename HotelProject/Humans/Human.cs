using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using HotelProject.Rooms;

namespace HotelProject.Humans
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

        public abstract void Update();
        public abstract void Evacuate();

        /// <summary>
        /// Sets the Position of the Human object
        /// </summary>
        /// <param name="x">The X coördinate</param>
        /// <param name="y">The X coördinate</param>
        public void SetPosition(int x, int y)
        {
            Position = _Hotel.iRoom.Single(r => r.Position.X == x && r.Position.Y == y);
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
                List<IRoom> roomsToSearch = new List<IRoom>(_Hotel.iRoom);

                foreach (IRoom room in roomsToSearch)
                    room.Distance = Int32.MaxValue / 2;

                IRoom current = Position;
                while (!Visit(current, destination, roomsToSearch)) //Do this until the destination node has been visited
                    current = roomsToSearch.Aggregate((l, r) => l.Distance < r.Distance ? l : r); //if(l.Distance < r.Distance) { return l; } else { return r; }

                return MakePath(destination);
            }
            return null;
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
            if (current == end) //Checks if the destination is visited
                return true;
            if (roomsToSearch.Contains(current))
                roomsToSearch.Remove(current); //Every visited room will be removed from the list of all the rooms
            foreach (KeyValuePair<IRoom, int> x in current.Neighbours) //This checks every neighbouring room
            {
                int newDistance = x.Value;
                if (current != Position)
                    newDistance = current.Distance + x.Value;
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

            while (previous != null)
            {
                Path.Add(previous);

                if (previous == Position)
                    break;

                previous = previous.Previous;
            }

            int countShafts = 0;

            var first = Path.FindIndex(r => r.AreaType == "Elevator");

            for (int i = 0; i < Path.Count - 1; i++)
            {
                if (Path[i].AreaType == "Elevator")
                    countShafts++;
            }

            if (countShafts > 0)
                Path.RemoveRange(first, countShafts - 1);

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
            if (Path != null && Path.Count > 0)
            {
                if (Wait != 0)
                    Wait--;
                else if (Path[Path.Count - 1].AreaType == "Stairs")
                    Wait++;

                if (Wait == 0)
                {
                    if ((Position.AreaType != "Elevator" && Path[Path.Count - 1].AreaType != "Elevator") ||
                        (Position.AreaType != "Elevator" && Path[Path.Count - 1].AreaType == "Elevator" &&
                         _Hotel.Elevator.CurrentFloor == Path[Path.Count - 1].Position.Y &&
                         _Hotel.Elevator.DoorsOpen) ||
                        (Position.AreaType == "Elevator" &&
                         _Hotel.Elevator.CurrentFloor == Path[Path.Count - 1].Position.Y && _Hotel.Elevator.DoorsOpen))
                    {
                        if (Position.AreaType != "Elevator" && Path[Path.Count - 1].AreaType == "Elevator" &&
                            _Hotel.Elevator.CurrentFloor == Path[Path.Count - 1].Position.Y && _Hotel.Elevator.DoorsOpen)
                            InElevator = true;

                        if (Position.AreaType == "Elevator" &&
                            _Hotel.Elevator.CurrentFloor == Path[Path.Count - 1].Position.Y && _Hotel.Elevator.DoorsOpen)
                            InElevator = false;

                        SetPosition(Path[Path.Count - 1].Position.X, Path[Path.Count - 1].Position.Y);
                        Path.Remove(Path[Path.Count - 1]);
                        Wait = 0;
                    }
                    else if (Position.AreaType != "Elevator" && Path.Count > 0 && Path[Path.Count - 1].AreaType == "Elevator")
                    {
                        if (TargetFloor > Position.Position.Y)
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, Position.Position.Y)).UpPressed = true;

                        if (TargetFloor < Position.Position.Y)
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, Position.Position.Y)).DownPressed = true;
                    }
                }  
            }
        }
    }
}
