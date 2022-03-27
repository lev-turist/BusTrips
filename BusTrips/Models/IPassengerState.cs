namespace BusTrips.Models
{
    public interface IPassengerState
    {
        public Int32 Price { get; }
        public Int32 BusStop { get; }
        public Boolean IsOnBusStop { get; }
        public Int32 BusNumber { get; }
        public List<IPassengerState> MinuteTick(IPassenger passenger, Dictionary<int, BusPath> paths);

        //    public List<IPassengerState> PassengerStates { get; set; }
        //    public IPassengerState? PrevPassengerState { get; set; }
    }
}
