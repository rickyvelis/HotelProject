using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Rooms;

namespace HotelProject
{
    class Elevator
    {
        public int? UpperTargetFloor { get; set; }
        public int? LowerTargetFloor { get; set; }
        public int CurrentFloor { get; set; }
        public int RestPosition { get; set; }
        public IRoom CurrentShaft { get; set; }
        public IRoom RestShaft { get; set; }
        public string Direction { get; set; }
        public bool Useable { get; set; }
        public Hotel _Hotel { get; }

        public Elevator()
        {
            _Hotel = Hotel.GetInstance();
            UpperTargetFloor = null;
            LowerTargetFloor = null;
            CurrentFloor = _Hotel.GetMaxY() / 2;
            RestPosition = CurrentFloor;
            CurrentShaft = _Hotel.iRoom.First(r => r.Position == new Point(0, CurrentFloor));
            Useable = true;
            Direction = null;

            //TODO inplaats van een bool om gasten naar binnen te laten gaan een methode gebruiken om wachtende gasten in de lift te laten gaan
        }

        /// <summary>
        /// Scans if there is a request for the elevator on any floor.
        /// if the elevator is requested on a floor that is higher then the current UpperTargetFloor or lower then the LowerTargetFloor
        /// the request becomes the new Upper/LowerTargetFLoor.
        /// </summary>
        private void Scan()
        {
            foreach (ElevatorShaft floor in _Hotel.iRoom.OfType<ElevatorShaft>())
            {
                if ((UpperTargetFloor == null || floor.Position.Y > UpperTargetFloor) && floor.Position.Y > CurrentFloor)
                {
                    UpperTargetFloor = floor.Position.Y;
                    if (Direction == null)
                        Direction = "UP";
                }

                if ((LowerTargetFloor == null || floor.Position.Y < LowerTargetFloor) && floor.Position.Y < CurrentFloor)
                {
                    LowerTargetFloor = floor.Position.Y;
                    if (Direction == null)
                        Direction = "DOWN";
                }
            }
        }

        /// <summary>
        /// Moves the elevator up or down after x Amount of hte has passed.
        /// </summary>
        private void Move()
        {
            switch (Direction)
            {
                case "UP":
                    _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor)).CanEnter = false;
                    CurrentFloor++;

                    if (_Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                        .UpPressed)
                    {
                        /*
                        _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                            .CanEnter = true;
                            */
                        Check();
                        _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                            .UpPressed = false;
                    }
                    break;

                case "DOWN":
                    _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor)).CanEnter = false;
                    CurrentFloor--;
                    if (_Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                        .DownPressed)
                    {
                        /*
                        _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                            .CanEnter = true;
                            */
                        Check();
                        _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                            .DownPressed = false;
                    }

                    break;

            }
        }

        /// <summary>
        /// Checks requests of all guests in the elevator/that have just entered the elevator to see if theres a new higher or lower floor.
        /// </summary>
        private void Check()
        {

        }
    }
}
