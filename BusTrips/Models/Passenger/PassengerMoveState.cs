namespace BusTrips.Models
{
    public class PassengerMoveState : IPassengerState
    {
        public Int32 BusStop
        {
            get
            {
                return _busPath.FromStopNumber;
            }
        }

        public Int32 Price
        {
            get
            {
                return _price;
            }
        }

        public Int32 BusNumber
        {
            get
            {
                return _busPath.Bus.Number;
            }
        }

        public Boolean IsOnBusStop
        {
            get
            {
                return _minutesInState == 0;
            }
        }

        private int _minutesInState;
        private int _minutesToNextStop;
        private int _price;
        private BusPath _busPath;

        public PassengerMoveState(BusPath path, int price)
        {
            _busPath = new BusPath() { ToStopNumber = path.ToStopNumber, Bus = path.Bus, FromStopNumber = path.FromStopNumber, IsStandOnBusStop = path.IsStandOnBusStop, MinutesToNextStop = path.MinutesToNextStop };
            _minutesToNextStop = path.MinutesToNextStop;
            _price = price + path.Bus.Price;
        }

        public List<IPassengerState> MinuteTick(IPassenger passenger, Dictionary<int, BusPath> paths)
        {
            ++_minutesInState;
            --_minutesToNextStop;
            List<IPassengerState> newStates = new List<IPassengerState>();
            if (_minutesToNextStop > 0)
            {
                newStates.Add(this);
            }
            else
            {
                newStates.Add(new PassengerWaitBusState(_busPath.ToStopNumber, _price));
                foreach (var path in paths.Values.Where(w => w.FromStopNumber == _busPath.ToStopNumber && w.IsStandOnBusStop))
                {
                    if (_busPath.Bus.Number == path.Bus.Number)
                    {
                        newStates.Add(new PassengerMoveState(path, _price - _busPath.Bus.Price));
                    }
                    else
                    {
                        newStates.Add(new PassengerMoveState(path, _price));
                    }
                }
            }
            return newStates;
        }
    }
}
