namespace AMS.Domain.IncidentAggregate.ValueObjects;
public sealed class IncidentTypeId : ValueObject
{
    private IncidentTypeId(Guid value)
    {
        Id = value;
    }

    public Guid Id { get; set; }

    public static IncidentTypeId CreateUnique()
    {
        return new IncidentTypeId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}