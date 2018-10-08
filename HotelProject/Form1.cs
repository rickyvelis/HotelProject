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

namespace HotelProject
{
    public partial class Form1 : Form
    {
        private Hotel _Hotel { get; set; }

        public Form1()
        {
            InitializeComponent();
            _Hotel = Hotel.GetInstance();
            Paint += new PaintEventHandler(DrawHotel);
            HEListener hel = new HEListener();
            HotelEventManager.Register(hel);
            HotelEventManager.HTE_Factor = 1.0f;
            //HotelEventManager.Start();

            Guest guest1 = new Guest(new Point(200, 200));
            guest1.Position = _Hotel.iRoom.Single(r => r.Position.X == 1 && r.Position.Y == 0);
            IRoom destination = _Hotel.iRoom.Single(r => r.Position.X == 9 && r.Position.Y == 5);
            //guest1.FindRoom(destination);
        }

        private void DrawHotel(object sender, PaintEventArgs e)
        {
            Render(_Hotel.iRoom, e);
        }

        /// <summary>
        /// Draws the rooms in the hotel
        /// </summary>
        /// <param name="rooms">list of rooms in the hotel</param>
        /// <param name="e"></param>
        private void Render(List<IRoom> rooms, PaintEventArgs e)
        {
            Bitmap bitmap;
            int height = _Hotel.GetMaxHeight();

            foreach (IRoom room in rooms)
            {
                switch (room.AreaType)
                {
                    case "Room":
                        switch (room.Classification)
                        {
                            case "1 Star":
                                bitmap = new Bitmap(Resources.Room1);
                                break;
                            case "2 stars":
                                bitmap = new Bitmap(Resources.Room2);
                                break;
                            case "3 stars":
                                bitmap = new Bitmap(Resources.Room3);
                                break;
                            case "4 stars":
                                bitmap = new Bitmap(Resources.Room4);
                                break;
                            case "5 stars":
                                bitmap = new Bitmap(Resources.Room5);
                                break;
                            default:
                                bitmap = new Bitmap(Resources.Room1);
                                break;   
                        }
                        break;
                    case "Fitness":
                        //TODO Fitness plaatje toevoegen
                        bitmap = new Bitmap(Resources.Cinema2);
                        break;
                    case "Cinema":
                        bitmap = new Bitmap(Resources.Cinema1);
                        break;
                    case "Restaurant":
                        //TODO Restaurant plaatje toevoegen
                        bitmap = new Bitmap(Resources.Cinema2);
                        break;
                    case "Elevator":
                        bitmap = new Bitmap(Resources.Elevator);
                        break;
                    case "Stairs":
                        bitmap = new Bitmap(Resources.Stairs);
                        break;
                    case "Lobby":
                        bitmap = new Bitmap(Resources.Entrance);
                        break;
                    default:
                        //TODO Error plaatje toevoegen
                        bitmap = new Bitmap(Resources.Cinema2);
                        break;
                }

                e.Graphics.DrawImage(bitmap, room.Position.X * 128, (height - room.Position.Y) * 89);
                for (int i = room.Dimension.X; i > 0; i--)
                {
                    for (int j = room.Dimension.Y; j > 0; j--)
                    {
                        if(i == 1 && j == 1)
                            break;
                        else
                        {
                            bitmap = new Bitmap(Resources.Hallway);
                            e.Graphics.DrawImage(bitmap, (room.Position.X + i - 1) * 128, (height - room.Position.Y - j + 1) * 89);
                        }
                    }
                }
            }
        }
    }
}
