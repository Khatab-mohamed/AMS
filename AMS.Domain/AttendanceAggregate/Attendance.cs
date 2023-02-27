using AMS.Domain.AttendanceAggregate.ValueObjects;

namespace AMS.Domain.AttendanceAggregate;
public sealed class Attendance :AggregateRoot<AttendanceId>
{
    public Attendance(AttendanceId id) : base(id)
    {
        
    }

    public Guid UserId { get; set; }
    public string Type { get; set; }

    public Guid LocationId { get; set; }
    public Location Location { get; set; }

    public DateTime CreatedOn { get; set; }

}
 