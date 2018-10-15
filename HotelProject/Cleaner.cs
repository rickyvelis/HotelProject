using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotelProject.Rooms;

namespace HotelProject
{
    public class Cleaner : Human
    {
        private Hotel _Hotel { get; }
        public bool Cleaning { get; set; }
        public int CleaningTime { get; set; }
        private int Timer { get; set; }
        public List<Room> Queue { get; set; }

        public Cleaner(int cleaningTime)
        {
            _Hotel = Hotel.GetInstance();
            Visible = false;
            SetPosition(1, 0);
            SpritePosition = new Point(Position.Position.X, Position.Position.Y);
            Queue = new List<Room>();
            Timer = 0;
            CleaningTime = cleaningTime;
        }
        
        public void Update()
        {
            CheckQueue();
            Step();
        }

        /// <summary>
        /// Checks if there is a room to be cleaned and cleans the first room in the queue.
        /// </summary>
        public void CheckQueue()
        {
            if (Queue.Count != 0 && Cleaning == false)
            {
                //TODO Maybe compare the distances to all Queued rooms to determine what room to clean next
                GoCleanRoom(Queue[0]);
            }
            if (Cleaning == true && Position == Queue[0])
            {
                Clean();
            }
        }

        /// <summary>
        /// Cleaner goes to given room and cleans it.
        /// </summary>
        /// <param name="room">Room to be cleaned.</param>
        public void GoCleanRoom(Room room)
        {
            //TODO Implement amount of time it takes to clean a room
            Cleaning = true;
            Visible = true;
            FindRoom(room);
        }

        private void Clean()
        {
            if (Timer < CleaningTime)
            {
                Visible = false;
                Timer++;
            }
            else
            {
                Timer = 0;
                Queue[0].Dirty = false;
                Queue[0].Available = true;
                Queue.Remove(Queue[0]);
                Cleaning = false;
                Visible = true;
                if (Queue.Count == 0)
                {
                    FindRoom(_Hotel.iRoom.Single(r => r.AreaType == "Lobby"));
                }
            }
        }
    }
}
