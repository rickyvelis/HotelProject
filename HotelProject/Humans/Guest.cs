using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using HotelProject.Rooms;
using HotelProject.Properties;

namespace HotelProject
{
    public class Guest : Human
    {
        public override string Name { get; set; }
        public override bool Visible { get; set; }
        public override List<IRoom> Path { get; set; }
        public override IRoom Position { get; set; }
        public override Point SpritePosition { get; set; }
        public override int Wait { get; set; }
        public override Image Img { get; set; }
        public override int TargetFloor { get; set; }

        public Room Room { get; set; }
        private Hotel _Hotel { get; }

        public bool CheckingOut { get; set; }
        public bool NeedFood { get; set; }
        public bool NeedWorkout { get; set; }
        public bool NeedMovie { get; set; }
        public bool InElevator { get; set; }

        public int EatDuration { get; set; }
        public int FitnessDuration { get; set; }

        public int Timer { get; set; }

        public Guest(int posX, int posY)
        {
            _Hotel = Hotel.GetInstance();
            Img = Resources.Guest1;
            Visible = true;
            CheckingOut = false;
            InElevator = false;
            SetPosition(posX, posY);
            SpritePosition = new Point(Position.Position.X, Position.Position.Y);
            Timer = 0;
            EatDuration = _Hotel.EatDuration;
            FitnessDuration = 0;

            NeedFood = false;
            NeedMovie = false;
            NeedWorkout = false;
        }

        /// <summary>
        /// Updates the object behaviour and property values
        /// </summary>
        public override void Update()
        {
            Step();

            //if (Position == Room)
            //Visible = false;

            if (CheckingOut)
            {
                if (Position == _Hotel.iRoom.OfType<Lobby>())
                    Die();
            }
            else if (Evacuating)
            {
                NeedFood = false;
                NeedMovie = false;
                NeedWorkout = false;
                Timer = 0;
            }

            else if (NeedFood && Position.AreaType == "Restaurant")
                Eat();

            else if (NeedWorkout && Position.AreaType == "Fitness")
                Workout();
        }

        /// <summary>
        /// Lets this Guest Checkout of the Hotel
        /// </summary>
        public void CheckOut()
        {
            FindRoom(_Hotel.iRoom.Single(r => r.AreaType == "Lobby"));
            Room.Dirty = true;
            Room.Available = true;
            _Hotel.DirtyRooms.Add(Room);
            CheckingOut = true;
        }

        /// <summary>
        /// Makes the Guest go back to its Room
        /// </summary>
        public void Go_Back()
        {
                FindRoom(_Hotel.iRoom.Single(r => r.Position.X == Room.Position.X && r.Position.Y == Room.Position.Y));
        }

        /// <summary>
        /// Guest eats until Timer has reached the value of EatDuration
        /// </summary>
        private void Eat()
        {
            if (Timer < EatDuration)
            {
                //Visible = false;
                Timer++;
            }
            else
            {
                Timer = 0;
                NeedFood = false;
                Visible = true;
                FindRoom(Room);
            }
        }

        /// <summary>
        /// Guest spends time in the gym until Timer has reached the value of WorkoutDuration
        /// </summary>
        public void Workout()
        {
            if (Timer < FitnessDuration)
            {
                //Visible = false;
                Timer++;
            }
            else
            {
                Timer = 0;
                NeedWorkout = false;
                Visible = true;
                FindRoom(Room);
            }
        }
        
        /// <summary>
        /// Makes the Guest Die
        /// </summary>
        public void Die()
        {
            Visible = false;
            //_Hotel.Guests.Remove(this);
        }

        /// <summary>
        /// Makes the Guest evacuate to the Lobby
        /// </summary>
        public override void Evacuate()
        {
            if (!CheckingOut)
            {
                Wait = 0;
                Evacuating = true;
            }
            FindRoom(_Hotel.iRoom.Single(r => r.AreaType == "Lobby"));
        }
    }
}
