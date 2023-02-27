using AMS.Domain.LocationAggregate;

namespace AMS.Infrastructure.Persistence
{
    public class LocationRepository : ILocationRepository
    {
        private static readonly List<Location> locations = new List<Location>();
        public void Add(Location location)
        {
            locations.Add(location);
        }
    }
}
