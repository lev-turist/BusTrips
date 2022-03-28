using BusTrips.Controllers;
using BusTrips.Models;
using BusTrips.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusTripsTests
{
    [TestClass]
    public class PostTests
    {
        private const string Expected = "{ ShortTrip = 22 мин., CheapTrip = 11 руб. }";
        [TestMethod]
        public void TestMethod1()
        {
            BusTripController controller = new BusTripController(new TripCalculatorFactory(), new BusFileReader());
            var res = controller.Post(new InputData() { BusStopStart = "1", BusStopEnd = "5", StartTime = "00:30", FileData = "3\r\n5\r\n00:30 00:30 00:10\r\n10 20 1\r\n3 1 3 2 12 13 8\r\n3 4 3 2 20 1 49\r\n2 5 2 1 1" });
            Assert.AreEqual(Expected, ((JsonResult)res).Value.ToString());
        }

        private const string Expected2 = "{ ShortTrip = 59 мин., CheapTrip = 11 руб. }";
        [TestMethod]
        public void TestMethod2()
        {
            BusTripController controller = new BusTripController(new TripCalculatorFactory(), new BusFileReader());
            var res = controller.Post(new InputData() { BusStopStart = "1", BusStopEnd = "5", StartTime = "00:31", FileData = "3\r\n5\r\n00:30 00:30 00:10\r\n10 20 1\r\n3 1 3 2 12 13 8\r\n3 4 3 2 20 1 49\r\n2 5 2 1 1" });
            Assert.AreEqual(Expected2, ((JsonResult)res).Value.ToString());
        }

        private const string Expected3 = "{ ShortTrip = 100 мин., CheapTrip = 21 руб. }";
        [TestMethod]
        public void TestMethod3()
        {
            BusTripController controller = new BusTripController(new TripCalculatorFactory(), new BusFileReader());
            var res = controller.Post(new InputData() { BusStopStart = "5", BusStopEnd = "4", StartTime = "00:00", FileData = "3\r\n5\r\n00:30 00:30 00:10\r\n10 20 1\r\n3 1 3 2 12 13 8\r\n3 4 3 2 20 1 49\r\n2 5 2 1 1" });
            Assert.AreEqual(Expected3, ((JsonResult)res).Value.ToString());
        }

        private const string Expected4 = "{ ShortTrip = 11 мин., CheapTrip = 1 руб. }";
        [TestMethod]
        public void TestMethod4()
        {
            BusTripController controller = new BusTripController(new TripCalculatorFactory(), new BusFileReader());
            var res = controller.Post(new InputData() { BusStopStart = "5", BusStopEnd = "2", StartTime = "00:00", FileData = "3\r\n5\r\n00:30 00:30 00:10\r\n10 20 1\r\n3 1 3 2 12 13 8\r\n3 4 3 2 20 1 49\r\n2 5 2 1 1" });
            Assert.AreEqual(Expected4, ((JsonResult)res).Value.ToString());
        }

        private const string Expected5 = "{ ShortTrip = 46 мин., CheapTrip = 10 руб. }";
        [TestMethod]
        public void TestMethod5()
        {
            BusTripController controller = new BusTripController(new TripCalculatorFactory(), new BusFileReader());
            var res = controller.Post(new InputData() { BusStopStart = "2", BusStopEnd = "3", StartTime = "00:29", FileData = "3\r\n5\r\n00:30 00:30 00:10\r\n10 20 1\r\n3 1 3 2 12 13 8\r\n3 4 3 2 20 1 49\r\n2 5 2 1 1" });
            Assert.AreEqual(Expected5, ((JsonResult)res).Value.ToString());
        }

        private const string Expected6 = "{ ShortTrip = 1 мин., CheapTrip = 1 руб. }";
        [TestMethod]
        public void TestMethod6()
        {
            BusTripController controller = new BusTripController(new TripCalculatorFactory(), new BusFileReader());
            var res = controller.Post(new InputData() { BusStopStart = "2", BusStopEnd = "5", StartTime = "23:59", FileData = "3\r\n5\r\n00:30 00:30 00:10\r\n10 20 1\r\n3 1 3 2 12 13 8\r\n3 4 3 2 20 1 49\r\n2 5 2 1 1" });
            Assert.AreEqual(Expected6, ((JsonResult)res).Value.ToString());
        }

        private const string Expected7 = "{ ShortTrip = Нет доступных маршрутов, CheapTrip = Нет доступных маршрутов }";
        [TestMethod]
        public void TestMethod7()
        {
            BusTripController controller = new BusTripController(new TripCalculatorFactory(), new BusFileReader());
            var res = controller.Post(new InputData() { BusStopStart = "5", BusStopEnd = "2", StartTime = "23:59", FileData = "3\r\n5\r\n00:30 00:30 00:10\r\n10 20 1\r\n3 1 3 2 12 13 8\r\n3 4 3 2 20 1 49\r\n2 5 2 1 1" });
            Assert.AreEqual(Expected7, ((JsonResult)res).Value.ToString());
        }
    }
}