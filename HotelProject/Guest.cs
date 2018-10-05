using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Rooms;

namespace HotelProject
{
    public class Guest
    {
        List<IRoom> Path { get; set; }
        public string Name { get; set; }
        IRoom Room { get; set; }
        Point Position { get; set; }
        private Image Img { get; set; }

        public Guest(string name)
        {
            Name = name;
        }
    }
}
