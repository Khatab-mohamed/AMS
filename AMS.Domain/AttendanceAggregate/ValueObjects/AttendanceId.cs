namespace AMS.Domain.AttendanceAggregate.ValueObjects;
public sealed class AttendanceId :ValueObject
{
    private AttendanceId(Guid value)
    {
        Id = value;
    }

    public Guid Id { get;  }

    public static AttendanceId CreateUnique()
    {
        return new AttendanceId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}