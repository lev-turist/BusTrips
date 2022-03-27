namespace BusTrips.Models
{
    public class Passenger : IPassenger
    {
        public List<IPassengerState> States { get { return _states; } }
        private List<IPassengerState> _states = new List<IPassengerState>();

        public Passenger(List<IPassengerState> states)
        {
            _states = states;
        }

        public void MinuteTick(Dictionary<int, BusPath> paths)
        {
            List<IPassengerState> newStates = new List<IPassengerState>();
            foreach (var state in _states)
            {
                foreach (var addState in state.MinuteTick(this, paths))
                {
                    IPassengerState? duplicate = newStates.FirstOrDefault(a => a.IsOnBusStop == addState.IsOnBusStop && a.BusStop == addState.BusStop && a.BusNumber == addState.BusNumber);
                    if (duplicate is null)
                    {
                        newStates.Add(addState);
                    }
                    else if (addState.Price < duplicate.Price)
                    {
                        newStates.Remove(duplicate);
                        newStates.Add(addState);
                    }
                }
            }
            _states = newStates;
        }
    }
}