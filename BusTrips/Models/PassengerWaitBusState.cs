namespace BusTrips.Models
{
    public class PassengerWaitBusState : IPassengerState
    {
        public Int32 BusStop
        {
            get
            {
                return _busStopNumber;
            }
        }

        public Int32 Price
        {
            get
            {
                return _price;
            }
        }

        public Boolean IsOnBusStop
        {
            get
            {
                return true;
            }
        }

        public Int32 BusNumber
        {
            get
            {
                return 0;
            }
        }

        private int _busStopNumber = 0;
        private int _price;

        public PassengerWaitBusState(int busStopNumber, int price)
        {
            _busStopNumber = busStopNumber;
            _price = price;
        }

        public List<IPassengerState> MinuteTick(IPassenger passenger, Dictionary<int, BusPath> paths)
        {
            List<IPassengerState> newStates = new List<IPassengerState>() { this };
            if (paths.Values.Any(w => w.FromStopNumber == _busStopNumber && w.IsStandOnBusStop))
            {
                foreach (var path in paths.Values.Where(w => w.FromStopNumber == _busStopNumber && w.IsStandOnBusStop))
                {
                    newStates.Add(new PassengerMoveState(path, _price));
                }
            }
            return newStates;
        }
    }
}
