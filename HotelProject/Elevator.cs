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
    public class Elevator
    {
        private int? UpperTargetFloor { get; set; }
        private int? LowerTargetFloor { get; set; }
        public int CurrentFloor { get; set; }
        private int RestPosition { get; set; }
        private string Direction { get; set; }
        public bool Useable { get; set; }
        public bool DoorsOpen { get; set; }
        private Hotel _Hotel { get; }
        private List<Human> humans { get; set; }
        

        public Elevator()
        {
            _Hotel = Hotel.GetInstance();
            UpperTargetFloor = null;
            LowerTargetFloor = null;
            CurrentFloor = _Hotel.GetMaxY() / 2;
            RestPosition = CurrentFloor;
            Useable = true;
            DoorsOpen = false;
            Direction = null;

            humans = new List<Human>();

            //TODO ZORGEN DAT MENSEN BEWEGEN MET DE LIFT EN NIET ZELF
        }

        public void DoEvents()
        {
            //TODO wanneer rij checken of mensen erin/eruit willen
            DoorsOpen = false;
            Scan();
            Check();
            Move();
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
                if (floor.Position.Y == CurrentFloor && (floor.UpPressed || floor.DownPressed))
                {
                    DoorsOpen = true;
                }

                if (floor.Position.Y > CurrentFloor && (UpperTargetFloor == null || floor.Position.Y > UpperTargetFloor) && (floor.UpPressed || floor.DownPressed))
                {
                    UpperTargetFloor = floor.Position.Y;
                    if (Direction == null)
                        Direction = "UP";
                }

                if (floor.Position.Y < CurrentFloor && (LowerTargetFloor == null || floor.Position.Y < LowerTargetFloor) && (floor.UpPressed || floor.DownPressed))
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
                    if (!DoorsOpen)
                    {
                        CurrentFloor++;

                        //TODO Check toevoegen of er iemand uitwilt
                        if (_Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .UpPressed || _Hotel.iRoom.OfType<ElevatorShaft>()
                                .First(r => r.Position == new Point(0, CurrentFloor)).DownPressed)
                        {
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .UpPressed = false;
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .DownPressed = false;
                            DoorsOpen = true;
                        }
                        SwitchDirection();
                    }
                    break;

                case "DOWN":
                    if (!DoorsOpen)
                    {
                        CurrentFloor--;

                        //TODO Check toevoegen of er iemand uitwilt
                        if (_Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor)).UpPressed || _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor)).DownPressed)
                        {
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .UpPressed = false;
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .DownPressed = false;
                            DoorsOpen = true;
                        }
                        SwitchDirection();
                    }
                    break;
            }
        }

        /// <summary>
        /// Checks requests of all guests in the elevator/that have just entered the elevator to see if theres a new higher or lower floor.
        /// </summary>
        private void Check()
        {
            foreach (Human human in humans)
            {
                if (human.TargetFloor > CurrentFloor &&
                    (UpperTargetFloor == null || human.TargetFloor > UpperTargetFloor))
                    UpperTargetFloor = human.TargetFloor;

                if (human.TargetFloor < CurrentFloor &&
                    (LowerTargetFloor == null || human.TargetFloor < LowerTargetFloor))
                    LowerTargetFloor = human.TargetFloor;
            }
        }

        private void SwitchDirection()
        {
            if (Direction == "UP" && CurrentFloor == UpperTargetFloor)
            {
                if (LowerTargetFloor != null)
                {
                    Direction = "Down";
                }
                else
                {
                    if (RestPosition < CurrentFloor)
                    {
                        Direction = "DOWN";
                        LowerTargetFloor = RestPosition;
                    }
                    else if (RestPosition == CurrentFloor)
                    {
                        Direction = null;
                    }
                    else
                    {
                        UpperTargetFloor = RestPosition;
                    }
                }
            }
            else if (Direction == "DOWN" && CurrentFloor == LowerTargetFloor)
            {
                if (UpperTargetFloor != null)
                {
                    Direction = "UP";
                }
                else
                {
                    if (RestPosition > CurrentFloor)
                    {
                        Direction = "UP";
                        UpperTargetFloor = RestPosition;
                    }
                    else if (RestPosition == CurrentFloor)
                    {
                        Direction = null;
                    }
                    else
                    {
                        LowerTargetFloor = RestPosition;
                    }
                }
            }
        }
    }
}
