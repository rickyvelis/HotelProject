using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelProject.Rooms;
using HotelProject.Properties;
using HotelEvents;
using System.Timers;
using HotelProject.Humans;

namespace HotelProject
{
    public partial class Form1 : Form
    {
        private Hotel _Hotel { get; }
        private List<Human> HumanList { get; set; }
        private System.Timers.Timer Timer { get; }
        private Stopwatch Stopwatch { get; }
        private float HTE_Factor { get; }

        delegate void Form1Callback();
        delegate void SetTextCallback();

        public Form1(float hte, int cleaners, int cleaningTime, int movieDuration, int eatDuration)
        {
            InitializeComponent();
            hotelStatus_label.Text = "Running";
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            _Hotel = Hotel.GetInstance();
            _Hotel.CreateElevator();
            var hel = new HEListener();
            Paint += DrawHotel;

            HotelEventManager.Register(hel);
            HTE_Factor = hte;
            HotelEventManager.HTE_Factor = HTE_Factor;

            _Hotel.SetCleaners(cleaners, cleaningTime);
            _Hotel.SetScreeningTime(movieDuration);
            _Hotel.EatDuration = eatDuration;

            Timer = new System.Timers.Timer(1000 / HotelEventManager.HTE_Factor) {Enabled = true};
            Timer.Start();
            Stopwatch = new Stopwatch();
            Stopwatch.Start();

            HotelEventManager.Start();

            Timer.Elapsed += TimerHandler;
            Console.WriteLine(Timer.Interval);
            
            KeyUp += SpacePress;
        }

        /// <summary>
        /// Calls Render using the PaintEventArgs
        /// </summary>
        private void DrawHotel(object sender, PaintEventArgs e)
        {
            Render(e);
        }

        /// <summary>
        /// Draws everything
        /// </summary>
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
                bitmap = new Bitmap(human.Img);
                e.Graphics.DrawImage(bitmap, human.SpritePosition.X * Resources.Error.Width + 150,
                    (_Hotel.GetMaxHeight() - human.SpritePosition.Y + 1) * Resources.Error.Height - 25);
            }
        }

        /// <summary>
        /// Occurs when one HTE has elapsed
        /// </summary>
        private void TimerHandler(object source, ElapsedEventArgs e)
        {
            Timer.Interval = 1000 / HotelEventManager.HTE_Factor;
            Stopwatch.Restart();
        
            _Hotel.Update();

            foreach (Human human in _Hotel.Humans.Reverse<Human>())
                human.Update();

            foreach (Cinema cinema in _Hotel.iRoom.OfType<Cinema>())
                cinema.Update();

            _Hotel.EvacuatingDone();
            _Hotel.Elevator.DoEvents();
            SetTextLabel();
            SetTextStatsBox();
            SetTextDirtyRoomsBox();
            SetTextElevatorBox();
            UpdateForm();
        }

        /// <summary>
        /// Responds to a press of the Space-key
        /// </summary>
        private void SpacePress(object sender, KeyEventArgs e)
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
            Timer.Enabled = !HotelEventManager.Pauzed;
        }

        /// <summary>
        /// Speeds up the simulation
        /// </summary>
        /// <param name="amount">Amount of HTE to be added to the HTE_Factor</param>
        public void SpeedUp(int amount)
        {
            if (!speedUp_checkBox.Checked)
                HotelEventManager.HTE_Factor = HTE_Factor;
            else
                HotelEventManager.HTE_Factor = HTE_Factor + amount;
        }

        /// <summary>
        /// Checks if an invoke is required (if the thread IDs are different) and updates the form itself.
        /// </summary>
        public void UpdateForm()
        {
            if (InvokeRequired)
            {
                Form1Callback d = UpdateForm;
                Invoke(d);
            }
            else             
                Refresh();
        }

        /// <summary>
        /// Exits the program on closing this form.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Checks if an invoke is required (if the thread IDs are different) and updates guestAmount_Label with the current amount of guests in the hotel.
        /// </summary>
        private void SetTextLabel()
        {
            if (guestAmount_Label.InvokeRequired)
            {
                SetTextCallback d = SetTextLabel;
                Invoke(d);
            }
            else
                guestAmount_Label.Text = "Guests: " + _Hotel.Humans.OfType<Guest>().Count();
        }

        /// <summary>
        /// Checks if an invoke is required (if the thread IDs are different) and updates statsBox with new text
        /// </summary>
        private void SetTextStatsBox()
        {
            if (statsBox.InvokeRequired)
            {
                SetTextCallback d = SetTextStatsBox;
                Invoke(d);
            }
            else
            {
                string info = "";
                foreach (Human human in _Hotel.Humans)
                {
                    info += (human.Name + " is at position " + human.Position.Position.X + " " + human.Position.Position.Y + "\n\n");
                }

                statsBox.Text = info;
            }
        }

        /// <summary>
        /// Checks if an invoke is required (if the thread IDs are different) and updates dirtyRoomsBox with new text
        /// </summary>
        private void SetTextDirtyRoomsBox()
        {
            if (statsBox.InvokeRequired)
            {
                SetTextCallback d = SetTextDirtyRoomsBox;
                Invoke(d);
            }
            else
            {
                string info = "";
                foreach (Room room in _Hotel.DirtyRooms)
                {
                    info += "Room at: " + room.Position.X + " " + room.Position.Y + " is dirty \n\n";
                }

                dirtyRoomsBox.Text = info;
            }
        }

        /// <summary>
        /// Checks if an invoke is required (if the thread IDs are different) and updates elevatorBox with new text
        /// </summary>
        private void SetTextElevatorBox()
        {
            if (statsBox.InvokeRequired)
            {
                SetTextCallback d = SetTextElevatorBox;
                Invoke(d);
            }
            else
            {
                string info = "";
                info += "The elevator currently is at floor " + _Hotel.Elevator.CurrentFloor;
                if (_Hotel.Elevator.DoorsOpen)
                    info += " and is currently opened. \n";
                else
                    info += " and is currently closed. \n";

                info += "The following people are currently using the elevator: \n";


                foreach (Human human in _Hotel.Humans)
                {
                    if (human.InElevator)
                        info += human.Name + " to go to floor: " + human.TargetFloor + "\n";
                }

                elevatorBox.Text = info;
            }
        }

        /// <summary>
        /// Occurs when the playPause_checkBox Check state has changed
        /// </summary>
        private void PlayPause_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Pause();
            if (HotelEventManager.Pauzed)
                playPause_checkBox.Text = "⏵";
            else
                playPause_checkBox.Text = "⏸";
        }

        /// <summary>
        /// Occurs when the speedUp_checkBox Check state has changed
        /// </summary>
        private void SpeedUp_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SpeedUp(5);
        }

    }
}
