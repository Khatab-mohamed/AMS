namespace AMS.Domain.IncidentAggregate.Entities;

public sealed class IncidentType : AggregateRoot<LocationId>
{
    public IncidentType(LocationId id) : base(id)
    {

    }

    public string Name { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }
}
