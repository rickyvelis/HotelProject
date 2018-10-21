using System;
using HotelProject.Rooms;

namespace HotelProject
{
    class RoomFactory
    {
        /// <summary>
        /// Creates an IRoom object
        /// </summary>
        /// <param name="room">dynamic object that keeps track of all values from the layout file</param>
        /// <returns></returns>
        public IRoom CreateRoom(dynamic room)
        {
            switch (room.AreaType.ToString())
            {
                case ("Room"):
                    return new Room(room.Classification.ToString(),
                        Int32.Parse(room.Dimension.ToString().Split(',')[0]),
                        Int32.Parse(room.Dimension.ToString().Split(',')[1]),
                        Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]), Int32.Parse(room.ID.ToString()));
                case ("Fitness"):
                    return new Fitness(Int32.Parse(room.Dimension.ToString().Split(',')[0]),
                        Int32.Parse(room.Dimension.ToString().Split(',')[1]),
                        Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]), Int32.Parse(room.ID.ToString()));
                case ("Hall"):
                    return new Hall(Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]));
                case ("Elevator"):
                    return new ElevatorShaft(room.Position);
                case ("Stairs"):
                    return new Stairs(Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]));
                case ("Cinema"):
                    return new Cinema(Int32.Parse(room.Dimension.ToString().Split(',')[0]),
                        Int32.Parse(room.Dimension.ToString().Split(',')[1]),
                        Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]), Int32.Parse(room.ID.ToString()));
                case ("Lobby"):
                    return new Lobby(room.Dimension);
                case ("Restaurant"):
                    return new Restaurant(Int32.Parse(room.Capacity.ToString()),
                        Int32.Parse(room.Dimension.ToString().Split(',')[0]),
                        Int32.Parse(room.Dimension.ToString().Split(',')[1]),
                        Int32.Parse(room.Position.ToString().Split(',')[0]),
                        Int32.Parse(room.Position.ToString().Split(',')[1]), Int32.Parse(room.ID.ToString()));
                default:
                    return null;
            }
        }
    }
}
