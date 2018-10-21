using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public void DoEvents()
        {
            //TODO wanneer rij checken of mensen erin/eruit willen
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
            {
                DoorsOpen = true;
            }


            Console.WriteLine("ELEVATOR AT FLOOR" + CurrentFloor);
            foreach (Human human in _Hotel.Humans)
            {
                if (human.InElevator)
                    Console.WriteLine(human.Name);
            }
            Console.WriteLine("UP " + UpperTargetFloor);
            Console.WriteLine("DOWN " + LowerTargetFloor);
            Console.WriteLine("RESTFLOOR: " + RestPosition);
            Console.WriteLine("DIRECTION " + Direction);
            if (DoorsOpen)
                Console.WriteLine("DOORS OPEN");
            else
                Console.WriteLine("DOORS CLOSED");
            Console.WriteLine("_______________________________________________________________________");

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

                        //TODO Check toevoegen of er iemand uitwilt
                        if (_Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor)).UpPressed || _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor)).DownPressed)
                        {
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .UpPressed = false;
                            _Hotel.iRoom.OfType<ElevatorShaft>().First(r => r.Position == new Point(0, CurrentFloor))
                                .DownPressed = false;
                            DoorsOpen = true;
                        }
                    }
                    break;
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

        private void SwitchDirection()
        {
            if (Direction == "UP" && CurrentFloor == UpperTargetFloor)
            {
                UpperTargetFloor = null;
                if (LowerTargetFloor != null)
                {
                    Direction = "DOWN";
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
                LowerTargetFloor = null;
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
