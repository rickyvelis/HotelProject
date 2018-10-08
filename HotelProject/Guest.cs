using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using HotelProject.Rooms;

namespace HotelProject
{
    class Guest
    {
        List<IRoom> Path { get; set; }
        public string Name { get; set; }
        public IRoom Room { get; set; }
        public IRoom Position { get; set; }
        public Point SpritePosition { get; set; }
        private Image Img { get; set; }
        private Hotel _Hotel { get; }

        public Guest(Point startPos)
        {
            SpritePosition = startPos;
            _Hotel = Hotel.GetInstance();
        }

        /// <summary>
        /// Uses the Dijkstra-algorithm to give a list of rooms which a Guest needs to traverse in order to reach the given destination
        /// </summary>
        /// <param name="destination">Destination</param>
        /// <param name="roomsToSearch">List of all the rooms of the hotel</param>
        /// <returns></returns>
        public List<IRoom> FindRoom(IRoom destination)
        {
            List<IRoom> test = new List<IRoom>(_Hotel.iRoom);
            IRoom current = Position;
            while (!Visit(current, destination, test)) //Voer dit uit totdat de end node is bezocht
            {
                current = test.Aggregate((l, r) => l.Distance < r.Distance ? l : r); //if(l.Distance < r.Distance) { return l; } else { return r; }
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
    }
}
