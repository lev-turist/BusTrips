using BusTrips.ApplicationUtils;

namespace BusTrips.Models
{
    public class BusPark
    {
        private List<Bus> _buses = new List<Bus>();
        public List<Bus> Buses { get { return _buses; } }
        private int _startMinute = 0;
        Dictionary<int, BusPath> _paths = new Dictionary<int, BusPath>();

        public BusPark(List<Bus> buses, int startMinute)
        {
            _startMinute = startMinute;
            _buses = buses;
        }

        public IEnumerator<Dictionary<int, BusPath>> GetEnumerator()
        {
            for (int i = _startMinute; i < Utils.MinutesInDay; i++)
            {
                foreach (Bus bus in _buses)
                {
                    if (bus.StartMinute <= i)
                    {
                        if (!_paths.ContainsKey(bus.Number))
                        {
                            BusPath busPath = new BusPath();
                            int curMinute = i - bus.StartMinute - ((i - bus.StartMinute) / bus.AllPathMinutes) * bus.AllPathMinutes;
                            int pathMinutes = 0;
                            foreach (var stop in bus.BusStops)
                            {
                                pathMinutes += stop.Value.MinutesMove;
                                if (pathMinutes > curMinute)
                                {
                                    busPath.Bus = bus;
                                    busPath.MinutesToNextStop = pathMinutes - curMinute;
                                    busPath.FromStopNumber = stop.Key;
                                    busPath.ToStopNumber = stop.Value.NextBusStopNumber;
                                    busPath.IsStandOnBusStop = true;
                                    break;
                                }
                            }
                            _paths.Add(bus.Number, busPath);
                        }
                        else if (_paths[bus.Number].MinutesToNextStop == 1)
                        {
                            BusPath path = _paths[bus.Number];
                            path.FromStopNumber = path.ToStopNumber;
                            path.ToStopNumber = bus.BusStops[path.FromStopNumber].NextBusStopNumber;
                            path.MinutesToNextStop = bus.BusStops[path.FromStopNumber].MinutesMove;
                            path.IsStandOnBusStop = true;
                        }
                        else
                        {
                            _paths[bus.Number].MinutesToNextStop -= 1;
                            _paths[bus.Number].IsStandOnBusStop = false;

                        }
                    }
                }
                yield return _paths;
            }
        }
    }
}

