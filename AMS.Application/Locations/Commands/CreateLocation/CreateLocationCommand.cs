﻿namespace AMS.Application.Locations.Commands.CreateLocation;

public record CreateLocationCommand(
    string Name,
    DateTime StartDate,
    DateTime EndDate,
    double Latitude,
    double Longitude,
    int AllowedDistance,
    bool IsPublic
    ): IRequest<ErrorOr<Location>>;