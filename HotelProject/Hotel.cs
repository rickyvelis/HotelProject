using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace HotelProject
{

    class Hotel
    {
        public Form1 Form { get; set; }

        public Hotel(Form1 Form)
        {
            List<Unit> units = JSONreader();
        }

        public List<Unit> JSONreader()
        {
            List<Unit> units;

            try
            {
                using(StreamReader r = new StreamReader("Hotel.layout"))
                {
                    string json = r.ReadToEnd();
                    units = JsonConvert.DeserializeObject<List<Unit>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return units;
        }
    }
}
