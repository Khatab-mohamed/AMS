using MediatR;

namespace AMS.Application.Locations.Commands.CreateLocation;

public class CreateLocationCommandHandler :IRequestHandler<CreateLocationCommand, ErrorOr<Location>>
{
    private readonly ILocationRepository _locationRepository;

    public CreateLocationCommandHandler(ILocationRepository locationRepository) => _locationRepository = locationRepository;

    public async Task<ErrorOr<Location>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
            // Create Location
            

            var location = Location.Create(
                request.Name,
                request.StartDate,
                request.EndDate,
                request.Latitude,
                request.Longitude,
                request.AllowedDistance,
                request.IsPublic
            );
            // Persist Location

            _locationRepository.Add(location);
            // Return Location

        return location!;
    }
}