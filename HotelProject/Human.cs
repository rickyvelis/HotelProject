using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Rooms;
using System.Drawing;

namespace HotelProject
{
    public class Human
    {
        public string Name { get; set; }
        public bool Visible { get; set; }
        public List<IRoom> Path { get; set; }
        public IRoom Position { get; set; }
        public Point SpritePosition { get; set; }
        private Hotel _Hotel { get; }

        public Human()
        {
            _Hotel = Hotel.GetInstance();
        }

        public void SetPosition(int X, int Y)
        {
            Position = _Hotel.iRoom.Single(r => r.Position.X == X && r.Position.Y == Y);
            SpritePosition = new Point(Position.Position.X * 128, (_Hotel.GetMaxHeight() - Position.Position.Y + 1) * 89 - 25);
        }

        #region Pathfinding code

        /// <summary>
        /// Uses the Dijkstra-algorithm to give a list of rooms which a Guest needs to traverse in order to reach the given destination
        /// </summary>
        /// <param name="destination">Destination</param>        
        /// <returns></returns>
        public List<IRoom> FindRoom(IRoom destination)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(Name + " GOES TO " + destination.AreaType + " " + destination.Position.ToString());

            List<IRoom> roomsToSearch = new List<IRoom>(_Hotel.iRoom);

            foreach (IRoom room in roomsToSearch)
            {
                room.Distance = Int32.MaxValue / 2;
            }

            IRoom current = Position;
            while (!Visit(current, destination, roomsToSearch)) //Voer dit uit totdat de end node is bezocht
            {
                current = roomsToSearch.Aggregate((l, r) => l.Distance < r.Distance ? l : r); //if(l.Distance < r.Distance) { return l; } else { return r; }
            }

            return MakePath(destination);
        }

        /// <summary>
        /// Method that visits a room for the Dijkstra-algorithm
        /// </summary>
        /// <param name="current">The room to be visited</param>
        /// <param name="end">Destination</param>
        /// <param name="roomsToSearch">List of all the rooms in the hotel</param>
        /// <returns></returns>
        private bool Visit(IRoom current, IRoom end, List<IRoom> roomsToSearch)
        {
            Console.WriteLine("Visiting " + current.AreaType + " at " + current.Position.ToString());
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
                if (newDistance < x.Key.Distance) //If the new distance of the neighbour is shorter than the distance it already had, the neighbour gets assigned the new distance
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
            Console.WriteLine("\n" + path + "\nDistance: " + end.Distance);

            return Path;
        }

        #endregion
        
        public void Step()
        {
            //TODO code iets verbeteren zodat ze niet direct lopen bij een distance groter dan 1
            //TODO If(Lift == vol && Path[Path.Count - 1].AreaType == "Lift"){ WACHTEN }
            if (Path != null && Path.Count > 0)
            {
                Position = Path[Path.Count - 1];
                SpritePosition = new Point(Position.Position.X, Position.Position.Y);
                Path.Remove(Path[Path.Count - 1]);
            }
        }
    }
}
