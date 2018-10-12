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
        public float CleaningSpeed { get; set; }
        public List<Room> Queue { get; set; }

        public Cleaner()
        {
            _Hotel = Hotel.GetInstance();
            Visible = false;
            SetPosition(1, 0);
            SpritePosition = new Point(Position.Position.X, Position.Position.Y);
            Queue = new List<Room>();
        }
        
        /// <summary>
        /// Checks if there is a room to be cleaned and cleans the first room in the queue.
        /// </summary>
        public void CheckQueue()
        {
            if (Queue.Count != 0 && Cleaning == false)
            {
                //TODO Maybe compare the distances to all Queued rooms to determine what room to clean next
                CleanRoom(Queue[0]);
            }
        }

        /// <summary>
        /// Cleaner cleans the given room.
        /// </summary>
        /// <param name="room">Room to be cleaned.</param>
        public void CleanRoom(Room room)
        {
            //TODO Implement amount of time it takes to clean a room
            Cleaning = true;
            FindRoom(room);
            Visible = true;

            //TODO find another solution for this 
            while (Position != room)
            {
                
            }

            Queue.Remove(room);

            if (Queue.Count == 0)
            {
                FindRoom(_Hotel.iRoom.Single(r => r.AreaType == "Lobby"));
            }
            room.Dirty = false;
            room.Available = true;
            Cleaning = false;
        }
    }
}
