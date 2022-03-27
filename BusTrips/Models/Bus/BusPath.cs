namespace BusTrips.Models
{
    public class BusPath
    {
        public int MinutesToNextStop { get; set; }
        public int FromStopNumber { get; set; }
        public int ToStopNumber { get; set; }
        public Bus Bus { get; set; }
        public Boolean IsStandOnBusStop { get; set; }
    }
}
