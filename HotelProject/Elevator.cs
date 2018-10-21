using System;
using System.Drawing;
using System.Linq;
using HotelProject.Humans;
using HotelProject.Rooms;
using HotelProject.Properties;

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

        public int ElevatorDelay { get; set; }
        private int ElevatorDelayTimer { get; set; }
       
        public Elevator(int elevatorDelay)
        {
            _Hotel = Hotel.GetInstance();
            UpperTargetFloor = null;
            LowerTargetFloor = null;
            CurrentFloor = _Hotel.GetMaxY() / 2;
            RestPosition = CurrentFloor;
            Useable = true;
            DoorsOpen = false;
            Direction = null;
            ElevatorDelay = elevatorDelay;
        }

        /// <summary>
        /// Runs the elevator as long as there is no evacuation happening, if so it stops and opens it doors.
        /// </summary>
        public void DoEvents()
        {
            if (!_Hotel.Evacuating)
            {
                if (DoorsOpen)
                    DoorsOpen = false;
                else
                {
                    Move();
                    Scan();
                    Check();
                    SwitchDirection();
                }
            }
            else
                DoorsOpen = true;
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

                if (floor.Position.Y == CurrentFloor && DoorsOpen)
                {
                    floor.Img = Resources.Elevator_Open;
                }
                else if (floor.Position.Y == CurrentFloor)
                {
                    floor.Img = Resources.Elevator_Atfloor;
                }
                else
                {
                    floor.Img = Resources.Elevator;
                }
            }
        }

        /// <summary>
        /// Moves the elevator up or down after x Amount of hte has passed.
        /// </summary>
        private void Move()
        {
            if (ElevatorDelayTimer == 0)
            {
                switch (Direction)
                {
                    case "UP":
                        if (!DoorsOpen)
                        {
                            CurrentFloor++;
                            foreach (Human human in _Hotel.Humans)
                            {

                                if (human.InElevator)
                                {
                                    //human.Position = _Hotel.iRoom.Single(r => r.Position == new Point(human.Position.Position.X, CurrentFloor));
                                    human.SetPosition(human.Position.Position.X, CurrentFloor);

                                    if (CurrentFloor == human.TargetFloor)
                                        DoorsOpen = true;
                                }
                            }
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
                        }
                        break;

                    case "DOWN":
                        if (!DoorsOpen)
                        {
                            CurrentFloor--;

                            foreach (Human human in _Hotel.Humans)
                            {
                                if (human.InElevator)
                                {
                                    //human.Position = _Hotel.iRoom.Single(r => r.Position == new Point(human.Position.Position.X, CurrentFloor));
                                    human.SetPosition(human.Position.Position.X, CurrentFloor);

                                    if (CurrentFloor == human.TargetFloor)
                                        DoorsOpen = true;
                                }
                            }
                        }

                        if (_Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor)).UpPressed || _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor)).DownPressed)
                        {
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .UpPressed = false;
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .DownPressed = false;
                            DoorsOpen = true;
                        }
                        break;
                }
                ElevatorDelayTimer = ElevatorDelay;
            }
            else
            {
                ElevatorDelayTimer--;
            }
        }

        /// <summary>
        /// Checks requests of all guests in the elevator/that have just entered the elevator to see if theres a new higher or lower floor.
        /// </summary>
        private void Check()
        {
            foreach (Human human in _Hotel.Humans)
            {
                if (human.TargetFloor > CurrentFloor &&
                    (UpperTargetFloor == null || human.TargetFloor > UpperTargetFloor) && human.InElevator)
                    UpperTargetFloor = human.TargetFloor;

                if (human.TargetFloor < CurrentFloor &&
                    (LowerTargetFloor == null || human.TargetFloor < LowerTargetFloor) && human.InElevator)
                    LowerTargetFloor = human.TargetFloor;
            }
        }

        /// <summary>
        /// Checks if the elevator needs to switch directions and/or should return to its resting floor.
        /// </summary>
        private void SwitchDirection()
        {
            if (Direction == "UP" && CurrentFloor == UpperTargetFloor)
            {
                UpperTargetFloor = null;
                if (LowerTargetFloor != null)
                    Direction = "DOWN";
                else
                {
                    if (RestPosition < CurrentFloor)
                    {
                        Direction = "DOWN";
                        LowerTargetFloor = RestPosition;
                    }
                    else if (RestPosition == CurrentFloor)
                        Direction = null;
                    else
                        UpperTargetFloor = RestPosition;
                }
            }
            else if (Direction == "DOWN" && CurrentFloor == LowerTargetFloor)
            {
                LowerTargetFloor = null;
                if (UpperTargetFloor != null)
                    Direction = "UP";
                else
                {
                    if (RestPosition > CurrentFloor)
                    {
                        Direction = "UP";
                        UpperTargetFloor = RestPosition;
                    }
                    else if (RestPosition == CurrentFloor)
                        Direction = null;
                    else
                        LowerTargetFloor = RestPosition;
                }
            }

            if (Direction == null)
            {
                if (UpperTargetFloor != null)
                    Direction = "UP";
                else if (LowerTargetFloor != null)
                    Direction = "DOWN";
            }
        }
    }
}
