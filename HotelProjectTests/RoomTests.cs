using HotelEvents;
using HotelProject;
using HotelProject.Rooms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using HotelProject.Humans;

namespace HotelProjectTests
{
    [TestClass]
    public class RoomTests
    {
        Hotel _Hotel = Hotel.GetInstance();
        HEListener hel = new HEListener();
        HotelEvent hotelEvent;

        [TestMethod]

        public void Dirty_Rooms_Get_Cleaned()
        {
            _Hotel.SetCleaners(5, 1);

            _Hotel.DirtyRooms.Add(_Hotel.iRoom.OfType<Room>().Single(r => r.Position == new Point(1, 1)));
            _Hotel.DirtyRooms.Add(_Hotel.iRoom.OfType<Room>().Single(r => r.Position == new Point(5, 1)));

            _Hotel.Update();

            int expectedResult = 2;
            int actualResult = _Hotel.Humans.OfType<Cleaner>().Where(c => c.Cleaning).Count();
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Rooms_Get_Dirty_After_Checkout()
        {
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "Checkin 2stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 2stars",
                Time = 2000
            };
            hel.Notify(hotelEvent);
            

            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "" } },
                EventType = HotelEventType.CHECK_OUT,
                Message = "Check out",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            bool expectedResult = true;
            var gasten = _Hotel.Humans.OfType<Guest>();
            bool actualResult = _Hotel.Humans.OfType<Guest>().Single(g => g.Name == "Gast").Room.Dirty;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
