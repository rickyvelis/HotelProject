using System;
using System.Linq;
using HotelEvents;
using HotelProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelProjectTests
{
    [TestClass]
    public class CleanerTests
    {
        Hotel _Hotel = Hotel.GetInstance();
        HEListener hel = new HEListener();
    }
}
