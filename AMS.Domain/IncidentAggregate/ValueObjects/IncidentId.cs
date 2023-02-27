namespace AMS.Domain.IncidentAggregate.ValueObjects;
public sealed class IncidentId :ValueObject
{
    private IncidentId(Guid value)
    {
        Id = value;
    }

    public Guid Id { get; set; }

    public static IncidentId CreateUnique()
    {
        return new IncidentId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}