using System;
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
using System.Timers;
using Timer = System.Timers.Timer;

namespace HotelProject
{
    public partial class Form1 : Form
    {
        private Hotel _Hotel { get; set; }
        private HEListener hel;
        private int Test { get; set; }
        public Timer timer { get; set; }

        delegate void Form1Callback();

        public Form1(float hte, int cleaners, int cleaningTime, int elevatorCapacity)
        {
            InitializeComponent();
            _Hotel = Hotel.GetInstance();
            hel = new HEListener();
            Paint += new PaintEventHandler(DrawHotel);
            HotelEventManager.Register(hel);
            HotelEventManager.HTE_Factor = hte;
            _Hotel.SetCleanerAmount(cleaners, cleaningTime);
            //_Hotel.SetElevatorCapacity(elevatorCapacity);
            timer = new System.Timers.Timer(1000 * HotelEventManager.HTE_Factor);
            timer.Enabled = true;
            HotelEventManager.Start();
            timer.Elapsed += TimerHandler;

            KeyUp += new KeyEventHandler(Pause);




            HotelEvent hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "Checkin 1stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 1stars",
                Time = 2000
            };

            hel.Notify(hotelEvent);
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
                if (guest.Visible)
                {
                    bitmap = new Bitmap(Resources.Guest1);
                    e.Graphics.DrawImage(bitmap, guest.SpritePosition.X * 128,
                        (_Hotel.GetMaxHeight() - guest.SpritePosition.Y + 1) * 89 - 25);
                }
            }

            foreach (Cleaner cleaner in _Hotel.Cleaners)
            {
                if (cleaner.Visible)
                {
                    bitmap = new Bitmap(Resources.Cleaner);
                    e.Graphics.DrawImage(bitmap, cleaner.SpritePosition.X * 128,
                        (_Hotel.GetMaxHeight() - cleaner.SpritePosition.Y + 1) * 89 - 25);
                }
            }
        }

        private void TimerHandler(object source, System.Timers.ElapsedEventArgs e)
        {
            Test++;
            if (Test == 10)
            {
                HotelEvent hotelEvent = new HotelEvent()
                {
                    Data = new Dictionary<string, string> { { "Gast", "Check out" } },
                    EventType = HotelEventType.CHECK_OUT,
                    Message = "Check out",
                    Time = 2000
                };

                hel.Notify(hotelEvent);
            }

            foreach (Guest guest in _Hotel.Guests)
            {
                guest.Step();
            }
            foreach (Cleaner cleaner in _Hotel.Cleaners)
            {
                cleaner.Step();
                cleaner.CheckQueue();
            }

            UpdateForm();
        }

        private void Pause(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                HotelEventManager.Pauze();
                timer.Enabled = HotelEventManager.Running;
            }
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
