using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        private Hotel _Hotel { get; set; }
        private HEListener hel;
        private int Test { get; set; }
        private System.Timers.Timer timer { get; set; }
        private Stopwatch stopwatch { get; }

        delegate void Form1Callback();

        public Form1(float hte, int cleaners, int cleaningTime, int elevatorCapacity)
        {
            InitializeComponent();
            _Hotel = Hotel.GetInstance();
            hel = new HEListener();
            Paint += DrawHotel;
            
            HotelEventManager.Register(hel);
            HotelEventManager.HTE_Factor = hte;

            _Hotel.SetCleaners(cleaners, cleaningTime);
            //_Hotel.SetElevatorCapacity(elevatorCapacity);

            timer = new System.Timers.Timer(1000 / HotelEventManager.HTE_Factor) {Enabled = true};
            timer.Start();
            stopwatch = new Stopwatch();
            stopwatch.Start();

            HotelEventManager.Start();

            timer.Elapsed += TimerHandler;
            Console.WriteLine(timer.Interval);

            KeyUp += Pause;

            #region TestCode
            //HotelEvent hotelEvent = new HotelEvent()
            //{
            //    Data = new Dictionary<string, string> { { "Gast1", "Checkin 1stars" } },
            //    EventType = HotelEventType.CHECK_IN,
            //    Message = "Checkin 1stars",
            //    Time = 2000
            //};
            //hel.Notify(hotelEvent);
            #endregion
        }

        private void DrawHotel(object sender, PaintEventArgs e)
        {
            Render(e);
        }

        /// <summary>
        /// Draws the rooms in the hotel
        /// </summary>
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

            foreach (Human human in _Hotel.Humans)
            {
                if (human.Visible)
                {
                    bitmap = new Bitmap(human.Img);
                    e.Graphics.DrawImage(bitmap, human.SpritePosition.X * 128,
                        (_Hotel.GetMaxHeight() - human.SpritePosition.Y + 1) * 89 - 25);
                }
            }
        }

        private void TimerHandler(object source, ElapsedEventArgs e)
        {
            timer.Interval = 1000 / HotelEventManager.HTE_Factor;
            stopwatch.Restart();

            #region TestCode
            //Test++;
            //if (Test == 6)
            //{
            //    HotelEvent hotelEvent = new HotelEvent()
            //    {
            //        Data = new Dictionary<string, string> { { "Gast", "1" } },
            //        EventType = HotelEventType.CHECK_OUT,
            //        Message = "Check out",
            //        Time = 2000
            //    };

            //    hel.Notify(hotelEvent);
            //}
            #endregion
            
            foreach (Human human in _Hotel.Humans)
                human.Update();

            UpdateForm();
        }

        private void Pause(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                HotelEventManager.Pauze();
                timer.Enabled = HotelEventManager.Running;
                if (timer.Enabled)
                {
                    timer.Interval -= stopwatch.ElapsedMilliseconds;
                    stopwatch.Restart();
                }
            }
        }

        //TODO nog goed kijken naar werking code.
        //TODO zorgen dat het hotel niet continue knippert
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
        
    }
}
