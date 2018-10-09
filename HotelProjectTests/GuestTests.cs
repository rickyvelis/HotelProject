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
    public class GuestTests
    {
        Hotel _Hotel = Hotel.GetInstance();
        HEListener hel = new HEListener();
        HotelEvent hotelEvent;

        [TestMethod]
        public void New_Guest_Gets_Assigned_A_Room()
        {
            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast", "Checkin 2stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 2stars",
                Time = 2000
            };
            
            hel.Notify(hotelEvent);
            
            Assert.IsNotNull(_Hotel.guests.Single(g => g.Name == "Gast").Room);
        }

        [TestMethod]
        public void New_Guest_Gets_Upgraded_Room_When_Pref_Room_Unavailable()
        {
            foreach (IRoom r in _Hotel.iRoom.Where(r => r.Available == true && r.AreaType == "Room" && r.Classification == "2 stars"))
                r.Available = false;

            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast1", "Checkin 2stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 2stars",
                Time = 2000
            };
            
            hel.Notify(hotelEvent);

            string actualResult = _Hotel.guests.Single(g => g.Name == "Gast1").Room.Classification;
            string expectedResult = "3 stars";
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Guests_When_Unable_To_Upgrade_Room()
        {
            foreach (IRoom r in _Hotel.iRoom.Where(
                r => r.Available == true 
                && r.AreaType == "Room" 
                && r.Classification == "2 stars" 
                || r.Classification == "3 stars"
                || r.Classification == "4 stars"
                || r.Classification == "5 stars"
                ))
            {
                r.Available = false;
            }

            hotelEvent = new HotelEvent()
            {
                Data = new Dictionary<string, string> { { "Gast2", "Checkin 2stars" } },
                EventType = HotelEventType.CHECK_IN,
                Message = "Checkin 2stars",
                Time = 2000
            };

            hel.Notify(hotelEvent);

            bool actualResult = _Hotel.guests.Exists(g => g.Name == "Gast2");
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Guests_Take_Quickest_Path_To_Destination()
        {
            Guest guest = new Guest(new Point(200, 200));
            guest.SetPosition(1, 0);
            IRoom destination = _Hotel.iRoom.Single(r => r.Position.X == 9 && r.Position.Y == 5);

            List<Point> path = new List<Point>();
            foreach (IRoom r in guest.FindRoom(destination))
                path.Add(r.Position);

            List<Point> actualResult = path;
            List<Point> expectedResult = new List<Point>()
            {
                new Point(1, 0),
                new Point(9, 0),
                new Point(9, 1),
                new Point(9, 2),
                new Point(9, 3),
                new Point(9, 4),
                new Point(9, 5),
            };
            expectedResult.Reverse();

            for (int i = 0; i < path.Count; i++)
            {
                Assert.AreEqual(actualResult[i], expectedResult[i]);
            }
        }
    }
}
