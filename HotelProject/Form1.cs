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

namespace HotelProject
{
    public partial class Form1 : Form
    {
        private Hotel _Hotel { get; set; }

        public Form1()
        {
            InitializeComponent();

            _Hotel = new Hotel(this);
            //_Hotel = hotel;

           Paint += new PaintEventHandler(DrawHotel);
        }

        //NOTE: X = 128 Y = 89

        private void DrawHotel(object sender, PaintEventArgs e)
        {
            Render(_Hotel.iRoom, e);
        }
        private void Render(List<IRoom> rooms, PaintEventArgs e)
        {
            Bitmap bitmap;

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
                        //TODO fitness plaatje toevoegen
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
                    default:
                        bitmap = new Bitmap(Resources.Cinema2);
                        break;

                }

                e.Graphics.DrawImage(bitmap, room.Position.X * 128, (_Hotel.GetMaxHeight() - room.Position.Y) * 89);
                //e.Graphics.DrawImage(bitmap, room.Position.X * 128, room.Position.Y * 89);
            }
        }
    }
}
