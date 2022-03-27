namespace BusTrips.TripCalculator
{
    public interface ITripCalculator
    {
        public String Calculate(List<Bus> buses, int startMinute, int startBusStop, int finishBusStop);
    }
}
