﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelProject.Rooms;
using HotelProject.Properties;
using HotelEvents;
using System.Timers;

namespace HotelProject
{
    public partial class Form1 : Form
    {
        private Hotel _Hotel { get; }
        private HEListener hel;
        private int Test { get; set; }
        private List<Human> HumanList { get; set; }
        private System.Timers.Timer timer { get; set; }
        private Stopwatch stopwatch { get; }
        private float HTE_Factor { get; set; }

        delegate void Form1Callback();
        delegate void SetTextCallback();

        public Form1(float hte, int cleaners, int cleaningTime, int elevatorCapacity, int movieDuration, int eatDuration)
        {
            InitializeComponent();
            hotelStatus_label.Text = "Running";
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            _Hotel = Hotel.GetInstance();
            _Hotel.CreateElevator();
            hel = new HEListener();
            Paint += DrawHotel;

            HotelEventManager.Register(hel);
            HTE_Factor = hte;
            HotelEventManager.HTE_Factor = HTE_Factor;

            _Hotel.SetCleaners(cleaners, cleaningTime);
            _Hotel.SetScreeningTime(movieDuration);
            _Hotel.EatDuration = eatDuration;

            timer = new System.Timers.Timer(1000 / HotelEventManager.HTE_Factor) {Enabled = true};
            timer.Start();
            stopwatch = new Stopwatch();
            stopwatch.Start();

            HotelEventManager.Start();

            timer.Elapsed += TimerHandler;
            Console.WriteLine(timer.Interval);
            
            KeyUp += KeyListener;
        }

        private void DrawHotel(object sender, PaintEventArgs e)
        {
            Render(e);
        }

        /// <summary>
        /// Draws everything
        /// </summary>
        /// <param name="e"></param>
        private void Render(PaintEventArgs e)
        {
            HumanList = new List<Human>(_Hotel.Humans);
            Bitmap bitmap;
            int height = _Hotel.GetMaxHeight();

            foreach (IRoom room in _Hotel.iRoom)
            {
                bitmap = new Bitmap(room.Img);               
                e.Graphics.DrawImage(bitmap, room.Position.X * bitmap.Width + 100, (height - room.Position.Y) * bitmap.Height);
            }

            foreach (Human human in HumanList)
            {
                if (human.Visible)
                {
                    bitmap = new Bitmap(human.Img);
                    e.Graphics.DrawImage(bitmap, human.SpritePosition.X * Resources.Error.Width + 100,
                        (_Hotel.GetMaxHeight() - human.SpritePosition.Y + 1) * Resources.Error.Height - 25);
                }
            }
        }

        private void TimerHandler(object source, ElapsedEventArgs e)
        {
            timer.Interval = 1000 / HotelEventManager.HTE_Factor;
            stopwatch.Restart();
            
            _Hotel.Update();

            foreach (Human human in _Hotel.Humans.Reverse<Human>())
                human.Update();

            foreach (Cinema cinema in _Hotel.iRoom.OfType<Cinema>())
                cinema.Update();


            _Hotel.EvacuatingDone();

            _Hotel.elevator.DoEvents();

            UpdateStats();

            UpdateForm();

        }

        private void KeyListener(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                Pause();
        }

        /// <summary>
        /// Pauses the simulation
        /// </summary>
        private void Pause()
        {
            HotelEventManager.Pauze();
            if (HotelEventManager.Pauzed)
                hotelStatus_label.Text = "Pauzed";
            else
                hotelStatus_label.Text = "Running";
            timer.Enabled = !HotelEventManager.Pauzed;
            //if (timer.Enabled)
            //{
            //    timer.Interval -= stopwatch.ElapsedMilliseconds;
            //    stopwatch.Restart();
            //}
        }

        /// <summary>
        /// Speeds up the simulation
        /// </summary>
        /// <param name="amount">Amount of HTE to be added to the HTE_Factor</param>
        public void SpeedUp(int amount)
        {
            if (!speedUp_checkBox.Checked)
                HotelEventManager.HTE_Factor = this.HTE_Factor;
            else
                HotelEventManager.HTE_Factor = this.HTE_Factor + amount;
        }

        //TODO nog goed kijken naar werking code.
        public void UpdateForm()
        {
            if (InvokeRequired)
            {
                Form1Callback d = UpdateForm;
                Invoke(d);
            }
            else
            {                
                Refresh();
            }
        }

        protected override void OnFormClosed(System.Windows.Forms.FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpdateStats()
        {
            SetTextLabel();
            SetTextTBox();
        }

        private void SetTextLabel()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (guestAmount_Label.InvokeRequired)
            {
                SetTextCallback d = SetTextLabel;
                Invoke(d);
            }
            else
            {
                guestAmount_Label.Text = "Guests: " + _Hotel.Humans.OfType<Guest>().Count();
            }
        }

        private void SetTextTBox()
        {
            if (stats.InvokeRequired)
            {
                SetTextCallback d = SetTextTBox;
                Invoke(d);
            }
            else
            {
                string info = "";
                foreach (Human human in _Hotel.Humans)
                {
                    info += (human.Name + " is at position " + human.Position.Position.X + " " + human.Position.Position.Y + "\n");
                }

                stats.Text = info;
            }
        }

        private void PlayPause_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Pause();
            if (HotelEventManager.Pauzed)
                playPause_checkBox.Text = "⏵";
            else
                playPause_checkBox.Text = "⏸";
        }

        private void SpeedUp_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SpeedUp(5);
        }

    }
}
