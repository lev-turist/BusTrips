using BusTrips.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using BusTrips.ApplicationUtils;
using BusTrips.Models;

namespace BusTrips.Controllers
{
    [ApiController]
    public class BusTripController : Controller
    {
        private ITripCalculatorFactory _calculatorFactory;
        private IFileReader _fileReader;

        public BusTripController(ITripCalculatorFactory calculatorFactory, IFileReader fileReader)
        {
            _calculatorFactory = calculatorFactory;
            _fileReader = fileReader;
        }

        [HttpPost]
        [Route("BusTrip/Post")]
        public ActionResult Post([FromBody]InputData inputData)
        {
            List<Bus> buses= _fileReader.Read(inputData.FileData);
            ITripCalculator shortTripCalculator = _calculatorFactory.Create(Utils.CalculationType.ShortTime);
            Task<String> task1 = Task.Run(() => shortTripCalculator.Calculate(buses, Utils.FromStringToMinutes(inputData.StartTime), Int32.Parse(inputData.BusStopStart), Int32.Parse(inputData.BusStopEnd)));

            ITripCalculator cheapTripCalculator = _calculatorFactory.Create(Utils.CalculationType.Cheap);
            Task<String> task2 = Task.Run(() => cheapTripCalculator.Calculate(buses, Utils.FromStringToMinutes(inputData.StartTime), Int32.Parse(inputData.BusStopStart), Int32.Parse(inputData.BusStopEnd)));

            Task.WaitAll(new Task[] { task1, task2 });

            return new JsonResult(new { ShortTrip = task1.Result, CheapTrip = task2.Result });
        }
    }
}
