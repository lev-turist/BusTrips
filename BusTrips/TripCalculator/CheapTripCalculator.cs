using BusTrips.Models;
using BusTrips.ServiceInterfaces;

namespace BusTrips.TripCalculator
{
    public class CheapTripCalculator: ITripCalculator
    {
        public String Calculate(List<Bus> buses, int startMinute, int startBusStop, int finishBusStop)
        {
            int cheapPrice = -1;            
            BusPark busPark = new BusPark(buses, startMinute);
            Passenger passenger = new Passenger(new List<IPassengerState>() { new PassengerWaitBusState(startBusStop, 0)});
            foreach (var busParkState in busPark)
            {
                passenger.MinuteTick(busParkState);
                foreach(var state in passenger.States.Where(a => a.BusStop == finishBusStop))
                {
                    if (cheapPrice == -1 || state.Price < cheapPrice)
                    {
                        cheapPrice = state.Price;
                    }
                }
            }

            return cheapPrice == -1 ? "Нет доступных маршрутов" : String.Format("{0} рублей", cheapPrice);
        }
    }
}