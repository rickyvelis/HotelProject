using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Rooms
{
    class Fitness : IRoom
    {
        public override string AreaType { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public Fitness(int dimX, int dimY, int posX, int posY)
        {
            AreaType = "Fitness";
            Dimension = new Point(dimX, dimY);
            Position = new Point(posX, posY);
        }
    }
}
