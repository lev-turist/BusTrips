using BusTrips.ApplicationUtils;
using BusTrips.Models;
using BusTrips.ServiceInterfaces;

namespace BusTrips.Services
{
    public class BusFileReader: IFileReader
    {
        public List<Bus> Read(String text)
        {
            List<Bus> buses = new List<Bus>();
            string[] textAsArray = text.Split("\r\n");
            Int32 busCount = Int32.Parse(textAsArray[0]);
            string[] timesStartString = textAsArray[2].Split(' ');
            string[] pricesString = textAsArray[3].Split(' ');
            for (int i = 0; i < busCount; i++)
            {
                string[] stopsString = textAsArray[i + 4].Split(' ');
                Int32 stopsCount = Int32.Parse(stopsString[0]); 
                Dictionary<int, BusStop> busStops = new Dictionary<int, BusStop>();
                for (int j = 0; j < stopsCount; j++)
                {
                    if (j == stopsCount - 1)
                    {
                        busStops.Add(Int32.Parse(stopsString[j + 1]), new BusStop() { MinutesMove = Int32.Parse(stopsString[j + 1 + stopsCount]), NextBusStopNumber = Int32.Parse(stopsString[1]) });
                    }
                    else
                    {
                        busStops.Add(Int32.Parse(stopsString[j + 1]), new BusStop() { MinutesMove = Int32.Parse(stopsString[j + 1 + stopsCount]), NextBusStopNumber = Int32.Parse(stopsString[j + 2]) });
                    }
                }

                Bus bus = new Bus(i+1, Int32.Parse(pricesString[i]), Utils.FromStringToMinutes(timesStartString[i]), busStops);
                buses.Add(bus);
            }
            return buses;
        }
    }
}
