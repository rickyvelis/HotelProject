﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Rooms;

namespace HotelProject
{
    class RoomFactory
    {
        public IRoom CreateRoom(dynamic room)
        {
            switch (room.AreaType.ToString())
            {
                case ("Room"):
                    return new Room(room.Classification.ToString(),
                        Int32.Parse(room.Dimension.ToString().Split(',')[0]),
                        Int32.Parse(room.Dimension.ToString().Split(',')[1]),
                        Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]));
                case ("Fitness"):
                    return new Fitness(Int32.Parse(room.Dimension.ToString().Split(',')[0]),
                        Int32.Parse(room.Dimension.ToString().Split(',')[1]),
                        Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]));
                case ("Hall"):
                    return new Hall(Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]));
                        //return new Hall(room.Position.X, room.Position.Y);
                case ("Elevator"):
                    return new Elevator(room.Position);
                case ("Stairs"):
                    return new Stairs(Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]));
                case ("Cinema"):
                    return new Cinema(Int32.Parse(room.Dimension.ToString().Split(',')[0]),
                        Int32.Parse(room.Dimension.ToString().Split(',')[1]),
                        Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]));
                case ("Lobby"):
                    return new Lobby(room.Dimension);
                case ("Restaurant"):
                    return new Restaurant(Int32.Parse(room.Capacity.ToString()),
                        Int32.Parse(room.Dimension.ToString().Split(',')[0]),
                        Int32.Parse(room.Dimension.ToString().Split(',')[1]),
                        Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]));
                default:
                    return null;
            }
        }
    }
}