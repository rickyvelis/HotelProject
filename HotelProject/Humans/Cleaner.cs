﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotelProject.Rooms;
using HotelProject.Properties;

namespace HotelProject
{
    public class Cleaner : Human
    {
        private Hotel _Hotel { get; }

        public override string Name { get; set; }
        public override bool Visible { get; set; }
        public override List<IRoom> Path { get; set; }
        public override IRoom Position { get; set; }
        public override Point SpritePosition { get; set; }
        public override int Wait { get; set; }
        public override Image Img { get; set; }

        private Room RoomToClean {get;set;}
        public bool Cleaning { get; set; }
        public int CleaningTime { get; set; }

        private int Timer { get; set; }

        public Cleaner()
        {
            _Hotel = Hotel.GetInstance();
            Visible = false;
            Img = Resources.Cleaner;
            SetPosition(1, 0);
            SpritePosition = new Point(Position.Position.X, Position.Position.Y);
            Timer = 0;
            CleaningTime = _Hotel.CleaningTime;
        }
        
        public override void Update()
        {
            Step();

            if (Cleaning == true && Position == RoomToClean)
                Clean();
        }

        /// <summary>
        /// Cleaner goes to given room and cleans it.
        /// </summary>
        /// <param name="room">Room to be cleaned.</param>
        public void GoCleanRoom(Room room)
        {
            RoomToClean = room;
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
                RoomToClean.Available = true;
                Cleaning = false;
                Visible = true;
                FindRoom(_Hotel.iRoom.OfType<Lobby>().First());
            }
        }


    }
}