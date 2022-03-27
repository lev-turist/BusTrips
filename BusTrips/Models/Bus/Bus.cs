namespace BusTrips.Models
{
    public class Bus
    {
        public int Number { get { return _number; } }
        private int _number;
        private Dictionary<int, BusStop> _busStops;
        public Dictionary<int, BusStop> BusStops { get { return _busStops; } }
        public int Price { get { return _price; } }
        private int _price;
        public int StartMinute { get { return _startMinute; } }
        private int _startMinute;
        public int AllPathMinutes { get { return _allPathMinutes; } }
        private int _allPathMinutes;

        public Bus(int number, int price, int startMinute, Dictionary<int, BusStop> stops)
        {
            _number = number;
            _price = price;
            _startMinute = startMinute;
            _busStops = stops;
            _allPathMinutes = _busStops.Sum(s => s.Value.MinutesMove);
        }
    }
}
