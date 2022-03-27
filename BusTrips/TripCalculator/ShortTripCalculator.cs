using BusTrips.Models;

namespace BusTrips.TripCalculator
{
    public class ShortTripCalculator: ITripCalculator
    {
        public String Calculate(List<Bus> buses, int startMinute, int startBusStop, int finishBusStop)
        {
            BusPark busPark = new BusPark(buses, startMinute);
            Passenger passenger = new Passenger(new List<IPassengerState>() { new PassengerWaitBusState(startBusStop, 0) });
            int i = 0;
            foreach (var busParkState in busPark)
            {
                ++i;
                passenger.MinuteTick(busParkState);
                if (passenger.States.Any(a => a.BusStop == finishBusStop))
                {
                    return String.Format("{0} минут", i);
                }
            }

            return "Нет доступных маршрутов";
        }
    }
}