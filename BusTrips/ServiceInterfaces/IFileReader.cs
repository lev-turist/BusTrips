using BusTrips.Models;

namespace BusTrips.ServiceInterfaces
{
    public interface IFileReader
    {
        public List<Bus> Read(String text);
    }
}
