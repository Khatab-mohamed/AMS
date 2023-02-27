using static System.Collections.Specialized.BitVector32;

namespace AMS.Domain.LocationAggregate;
public sealed class Location :AggregateRoot<LocationId>
{
    private Location(LocationId locationId,
        string name,
        DateTime startDate,
        DateTime endDate,
        double latitude,
        double longitude,
        int allowedDistance,
        bool isPublic) : base(locationId)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Latitude = latitude;
        Longitude = longitude;
        AllowedDistance = allowedDistance;
        IsPublic = isPublic;
}


    public string Name { get; set; }

    public DateTime StartDate { get;  }
    public DateTime EndDate { get;  }
    public double Latitude { get;  }
    public double Longitude { get;  }
    public int AllowedDistance { get;  }
    public bool IsPublic { get;  }

    public static Location Create(string name,
        DateTime startDate,
        DateTime endDate,
        double latitude,
        double longitude,
        int allowedDistance,
        bool isPublic)
    {

        return new(
            LocationId.CreateUnique(),
            name,
            startDate,
            endDate,
            latitude,
            longitude,
            allowedDistance,
            isPublic);
    }

}
