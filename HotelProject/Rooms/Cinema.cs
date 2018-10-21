using System;
using System.Collections.Generic;
using System.Drawing;
using HotelProject.Humans;
using HotelProject.Properties;

namespace HotelProject.Rooms
{    
    public class Cinema : IRoom
    {
        public override string AreaType { get; set; }
        public override int ID { get; set; }
        public override Point Dimension { get; set; }
        public override Point Position { get; set; }
        public override int Distance { get; set; }
        public override Dictionary<IRoom, int> Neighbours { get; set; }
        public override Image Img { get; set; }

        public List<Guest> Visitors { get; set; }
        public bool IsScreening { get; set; }
        public int ScreeningTime { get; set; }
        private int Timer { get; set; }

        public Cinema(int dimX, int dimY, int posX, int posY, int iD)
        {
            AreaType = "Cinema";
            Dimension = new Point(dimX, dimY);
            Position = new Point(posX, posY);
            Img = Resources.Cinema1;
            ID = iD;

            IsScreening = false;
            Timer = 0;
            Visitors = new List<Guest>();
        }

        /// <summary>
        /// Updates the object behaviour and property values
        /// </summary>
        public void Update()
        {
            if (IsScreening)
                Screening();
        }

        /// <summary>
        /// Starts the movie.
        /// </summary>
        public void Start()
        {
            Img = Resources.Cinema_Start;
            IsScreening = true;
            Screening();
        }

        /// <summary>
        /// Checks if the movie is over, if so it stops playing and everybody who was in the cinema at the time will return to their rooms.
        /// </summary>
        private void Screening()
        {
            if (Timer < ScreeningTime)
                Timer++;
            else
            {
                Img = Resources.Cinema1;
                Timer = 0;
                IsScreening = false;
                foreach (Guest visitor in Visitors)
                {
                    visitor.NeedMovie = false;
                    visitor.Busy = false;
                    if (!visitor.Evacuating)
                        visitor.Go_Back();
                }
                Visitors.Clear();
            }
        }
    }
}
