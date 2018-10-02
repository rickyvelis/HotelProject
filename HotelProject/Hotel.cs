using System;
using System.Collections.Generic;
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
        }

        public List<IRoom> JSONreader()
        {
            List<IRoom> iRoom;

            try
            {
                using (StreamReader r = new StreamReader("Resources\\Hotel.layout"))
                {
                    string json = r.ReadToEnd();
                    iRoom = JsonConvert.DeserializeObject<List<IRoom>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return SetNeighbours(iRoom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        public IRoom[,] MakeHotel(List<IRoom> rooms)
        {
            int maxX = 0;
            int maxY = 0;

            //Determine the size of the array by looking at the furthermost room at both the x- and y-axis
            foreach (IRoom r in rooms)
            {
                if (r.Position.X + r.Dimension.X - 1 > maxX)
                    maxX = r.Position.X + r.Dimension.X - 1;
                if (r.Position.Y + r.Dimension.Y - 1 > maxY)
                    maxY = r.Position.Y + r.Dimension.Y - 1;
            }

            IRoom[,] layout = new IRoom[maxX, maxY];

            foreach (IRoom r in rooms)
            {

            }
        }

        private List<IRoom> SetNeighbours(List<IRoom> iRoom)
        {
            foreach (IRoom room in iRoom)
            {
                foreach (IRoom room2 in iRoom)
                {
                    if (room.Position.X + room.Dimension.X == room2.Position.X && room.Position.Y == room2.Position.Y)
                    {
                        //TODO checks op hoogtes of er wel plek is om te lopen (bijv als y 2 is kan je er wel nog lopen).
                        room.Neighbours.Add(room2, room.Dimension.X);
                        room2.Neighbours.Add(room, room.Dimension.X);
                        break;
                    }
                }
            }

            return iRoom;
        }
    }
}
