using HotelEvents;
using HotelProject;
using HotelProject.Rooms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace HotelProjectTests
{
    [TestClass]
    public class RoomTests
    {
        Hotel _Hotel = Hotel.GetInstance();
        HEListener hel = new HEListener();
        HotelEvent hotelEvent;

        [TestMethod]
        public void Can_Rooms_Get_Dirty()
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
                Data = new Dictionary<string, string> { { "Gast", "Check out" } },
                EventType = HotelEventType.CHECK_OUT,
                Message = "Check out",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            bool expectedResult = true;
            bool actualResult = _Hotel.Guests.Single(g => g.Name == "Gast").Room.Dirty;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Do_Cleaners_Get_Created()
        {
            _Hotel.SetCleanerAmount(5);

            int expectedResult = 5;
            int actualResult = _Hotel.Cleaners.Count();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
