using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Rooms;

namespace HotelProject
{
    class Guest
    {
        List<IRoom> Path { get; set; }
        public string Name { get; set; }
        IRoom Room { get; set; }
        public IRoom Position { get; set; }
        public Point SpritePosition { get; set; }
        private Image Img { get; set; }

        public Guest(Point startPos)
        {
            SpritePosition = startPos;
        }

        public string FindRoom(IRoom destination, List<IRoom> roomsToSearch)
        {
            IRoom current = Position;
            while (!Visit(current, destination, roomsToSearch)) //Voer dit uit totdat de end node is bezocht
            {
                current = roomsToSearch.Aggregate((l, r) => l.Distance < r.Distance ? l : r); //if(l.Distance < r.Distance) { return l; } else { return r; }
            }
            return MakePath(destination);
        }

        private bool Visit(IRoom current, IRoom end, List<IRoom> roomsToSearch)
        {
            Console.WriteLine("Visiting " + current.AreaType + " at " + current.Position.ToString());
            if (current == end) //Kijkt of de laatste Node wordt bezocht.
            {
                return true;
            }
            if (roomsToSearch.Contains(current))
            {
                roomsToSearch.Remove(current); //Elke bezochte Room wordt uit de lijst van Rooms gehaald.
            }
            foreach (KeyValuePair<IRoom, int> x in current.Neighbours) //Alle buren van de bezochte Room worden nagegaan.
            {
                int newDistance = current.Distance + x.Value;
                if (newDistance < x.Key.Distance) //Als de nieuwe afstand van de buur kleiner is dan de afstand die de buur al had, wordt de nieuwe afstand toegewezen aan de buur.
                {
                    x.Key.Distance = newDistance; //De huidige buur krijgt een Distance. Dat is dus de al afgelegde afstand + de afstand van huidige Node naar de buur.
                    x.Key.Previous = current; //De huidige buur krijgt de huidige bezochte Node als Previous.
                }
            }
            return false;
        }

        private string MakePath(IRoom end)
        {
            IRoom previous = end.Previous;
            string path = "" + end.AreaType + " " + end.Position.ToString();
            while (previous != null)
            {
                path = "" + previous.AreaType + " " + end.Position.ToString() + " -> " + path;
                previous = previous.Previous;
            }
            return "\n" + path + "\nDistance: " + end.Distance;
        }
    }
}
