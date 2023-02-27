using AMS.Domain.UserAggregate;

namespace AMS.Domain.IncidentAggregate;
public sealed class Incident : AggregateRoot<LocationId>
{
    public Incident(LocationId id) : base(id)
    {
        
    }

    public string Title { get; set; }

    public string Description { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }
    public DateTime CreatedOn { get; set; }


}
 