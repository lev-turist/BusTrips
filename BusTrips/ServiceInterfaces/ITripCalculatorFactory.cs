using BusTrips.ApplicationUtils;
using BusTrips.Models;

namespace BusTrips.ServiceInterfaces
{
    public interface ITripCalculatorFactory
    {
        public ITripCalculator Create(Utils.CalculationType type);
    }
}
