using AMS.Domain.LocationAggregate;

namespace AMS.Infrastructure.Persistence
{
    public class LocationRepository : ILocationRepository
    {
        private static readonly List<Location> locations;
        public void Add(Location location)
        {
            locations.Add(location);
        }
    }
}
