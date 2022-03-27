using BusTrips.ServiceInterfaces;
using BusTrips.ApplicationUtils;
using BusTrips.TripCalculator;
using BusTrips.Models;

namespace BusTrips.Services
{
    public class TripCalculatorFactory: ITripCalculatorFactory
    {
        public ITripCalculator Create(Utils.CalculationType type)
        {
            if (type == Utils.CalculationType.ShortTime)
            {
                return new ShortTripCalculator();
            }
            else if (type == Utils.CalculationType.Cheap)
            {
                return new CheapTripCalculator();
            }
            else
            {
                return null;
            }
        }
    }
}
