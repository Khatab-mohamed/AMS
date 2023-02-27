namespace AMS.Contracts.Location;
public record CreateLocationRequest(
    string Name,
    DateTime StartDate,
    DateTime EndDate,
    double Latitude,
    double Longitude,
    int AllowedDistance,
    bool IsPublic
    );