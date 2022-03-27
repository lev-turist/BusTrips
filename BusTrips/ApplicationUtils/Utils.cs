namespace BusTrips.ApplicationUtils
{
    public static class Utils
    {
        public enum CalculationType
        {
            Cheap,
            ShortTime
        }

        public static int FromStringToMinutes(String time)
        {
            return Int32.Parse(time.Split(':')[0]) * 60 + Int32.Parse(time.Split(':')[1]);

        }
    }
}
