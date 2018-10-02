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

            //try
            //{
                using(StreamReader r = new StreamReader("Resources\\Hotel.layout"))
                {
                    string json = r.ReadToEnd();
                    iRoom = JsonConvert.DeserializeObject<List<IRoom>>(json);
                }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    return null;
            //}
            return SetNeighbours(iRoom);
        }

        private List<IRoom> SetNeighbours(List<IRoom> iRoom)
        {
            foreach (IRoom room in iRoom)
            {
                foreach (IRoom room2 in iRoom)
                {
                    if (room.Position.X + room.Dimention.X == room2.Position.X && room.Position.Y == room2.Position.Y)
                    {
                        room.Neighbours.Add(room2, room.Dimention.X);
                        room2.Neighbours.Add(room, room.Dimention.X);
                        break;
                    }
                }
            }
            return iRoom;
        }
    }
}
