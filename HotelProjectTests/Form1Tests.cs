using System;
using HotelEvents;
using HotelProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelProjectTests
{
    [TestClass]
    public class Form1Tests
    {
        Hotel _Hotel = Hotel.GetInstance();
        Form1 form = new Form1(1.0f, 1, 1, 1, 1, 1);

        [TestMethod]
        public void HTEFactor_Gets_Adjusted()
        {
            //form.SpeedUp(5);
            HotelEventManager.HTE_Factor += 5;

            _Hotel.Update();

            float expectedResult = 6.0f;
            float actualResult = HotelEventManager.HTE_Factor;
            
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
