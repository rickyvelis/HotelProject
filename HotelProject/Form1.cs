﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelProject.Rooms;
using HotelProject.Properties;
using HotelEvents;

namespace HotelProject
{
    public partial class Form1 : Form
    {
        private Hotel _Hotel { get; set; }

        delegate void Form1Callback();

        public Form1()
        {
            InitializeComponent();
            _Hotel = Hotel.GetInstance();
            Paint += new PaintEventHandler(DrawHotel);
            HEListener hel = new HEListener();
            HotelEventManager.Register(hel);
            HotelEventManager.HTE_Factor = 1.0f;
            System.Timers.Timer timer = new System.Timers.Timer(1000 / HotelEventManager.HTE_Factor);
            timer.Enabled = true;
            timer.Elapsed += Timer;


            HotelEventManager.Start();

            //Guest guest1 = new Guest(1, 0);
            //_Hotel.Guests.Add(guest1);
            //IRoom destination = _Hotel.iRoom.Single(r => r.Position.X == 9 && r.Position.Y == 5);
            //guest1.FindRoom(destination);
        }

        private void DrawHotel(object sender, PaintEventArgs e)
        {
            Render(e);
        }

        /// <summary>
        /// Draws the rooms in the hotel
        /// </summary>
        /// <param name="rooms">list of rooms in the hotel</param>
        /// <param name="e"></param>
        private void Render(PaintEventArgs e)
        {
            Bitmap bitmap;
            int height = _Hotel.GetMaxHeight();

            foreach (IRoom room in _Hotel.iRoom)
            {
                bitmap = new Bitmap(room.Img);
                e.Graphics.DrawImage(bitmap, room.Position.X * 128, (height - room.Position.Y) * 89);
            }

            foreach (Guest guest in _Hotel.Guests)
            {
                bitmap = new Bitmap(Resources.Guest1);
                e.Graphics.DrawImage(bitmap, guest.SpritePosition.X * 128,
                    (_Hotel.GetMaxHeight() - guest.SpritePosition.Y + 1) * 89 - 25);
            }
        }

        private void Timer(object source, System.Timers.ElapsedEventArgs e)
        {
            foreach (Guest guest in _Hotel.Guests)
            {
                guest.Step();
            }
            UpdateForm();
        }

        //TODO nog goed kijken naar werking code.
        //TODO zorgen dat het hotel niet continue knippert
        public void UpdateForm()
        {
            if (this.InvokeRequired)
            {
                Form1Callback d = new Form1Callback(UpdateForm);
                this.Invoke(d);
            }
            else
            {

                Refresh();
            }
        }
    }
}
