using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using HotelEvents;
using HotelProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelProjectTests
{
    [TestClass]
    public class HotelEventTests
    {
        Hotel _Hotel = Hotel.GetInstance();
        HEListener hel = new HEListener();
        HotelEvent hotelEvent;

        [TestMethod]
        public void NEED_FOOD_Guest_Gets_Notified()
        {
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast5", "Checkin 1stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 1stars",
                Time = 2000
            };
            hel.Notify(hotelEvent);
            
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "5" } },
                EventType = HotelEventType.NEED_FOOD,
                Message = "",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            bool expectedResult = true;
            bool actualResult = _Hotel.Humans.OfType<Guest>().Single(g => g.Name == "Gast5").NeedFood;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void NEED_FOOD_Guest_Goes_To_Restaurant()
        {
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast6", "Checkin 1stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 1stars",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "6" } },
                EventType = HotelEventType.NEED_FOOD,
                Message = "",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            string expectedResult = "Restaurant";
            string actualResult = _Hotel.Humans.OfType<Guest>().Single(g => g.Name == "Gast6").Path.First().AreaType;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GOTO_FITNESS_Guest_Gets_Notified()
        {
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast7", "Checkin 1stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 1stars",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "7" }, { "HTE", "10" } },
                EventType = HotelEventType.GOTO_FITNESS,
                Message = "",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            bool expectedResult = true;
            bool actualResult = _Hotel.Humans.OfType<Guest>().Single(g => g.Name == "Gast7").NeedWorkout;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GOTO_FITNESS_Guest_Goes_To_Gym()
        {
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast8", "Checkin 1stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 1stars",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "8" }, { "HTE", "10" } },
                EventType = HotelEventType.GOTO_FITNESS,
                Message = "",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            string expectedResult = "Fitness";
            string actualResult = _Hotel.Humans.OfType<Guest>().Single(g => g.Name == "Gast8").Path.First().AreaType;
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GOTO_CINEMA_Guest_Gets_Notified()
        {
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast9", "Checkin 1stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 1stars",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "9" } },
                EventType = HotelEventType.GOTO_CINEMA,
                Message = "",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            bool expectedResult = true;
            bool actualResult = _Hotel.Humans.OfType<Guest>().Single(g => g.Name == "Gast9").NeedMovie;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GOTO_CINEMA_Guest_Goes_To_Cinema()
        {
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast10", "Checkin 1stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 1stars",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "10" } },
                EventType = HotelEventType.GOTO_CINEMA,
                Message = "",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            string expectedResult = "Cinema";
            string actualResult = _Hotel.Humans.OfType<Guest>().Single(g => g.Name == "Gast10").Path.First().AreaType;

            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [TestMethod]
        public void EVACUATE_Everyone_Gets_Notified()
        {
            hotelEvent = new HotelEvent()
            {
                EventType = HotelEventType.EVACUATE,
                Message = "Fire on floor 3",
                Time = 2000
            };
            hel.Notify(hotelEvent);

            bool expectedResult = true;
            bool actualResult = true;

            foreach (Guest guest in _Hotel.Humans.OfType<Guest>())
            {
                if (!guest.CheckingOut)
                {
                    if (!guest.Evacuating)
                    {
                        actualResult = guest.Evacuating;
                    }
                }
            }
            Assert.AreEqual(expectedResult, actualResult);
        }

        //[TestMethod]
        //public void START_CINEMA_Cinema_Gets_Started()
        //{
        //    hotelEvent = new HotelEvent()
        //    {
        //        EventType = HotelEventType.START_CINEMA,
        //        Message = "Fire on floor 3",
        //        Time = 2000
        //    };
        //    hel.Notify(hotelEvent);

        //    bool expectedResult = true;
        //    bool actualResult = true;

        //    foreach (Guest guest in _Hotel.Humans.OfType<Guest>())
        //    {
        //        if (!guest.CheckingOut)
        //        {
        //            if (!guest.Evacuating)
        //            {
        //                actualResult = guest.Evacuating;
        //            }
        //        }
        //    }
        //    Assert.AreEqual(expectedResult, actualResult);
        //}
    }
}
