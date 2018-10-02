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

        public Hotel(Form1 Form)
        {
            List<IRoom> iRoom = JSONreader();
        }

        public List<IRoom> JSONreader()
        {
            List<IRoom> iRoom;

            try
            {
                using(StreamReader r = new StreamReader("Hotel.layout"))
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
            return iRoom;
        }
    }
}
