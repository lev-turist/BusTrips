namespace BusTrips.Models
{
    public interface IPassenger
    {
        public List<IPassengerState> States { get; }
        public void MinuteTick(Dictionary<int, BusPath> paths);
    }
}
