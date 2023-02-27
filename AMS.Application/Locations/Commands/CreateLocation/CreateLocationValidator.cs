namespace AMS.Application.Locations.Commands.CreateLocation;

public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationValidator()
    {
        RuleFor(l => l.Name).NotEmpty().MaximumLength(100);
        RuleFor(l => l.Latitude).NotNull();
        RuleFor(l => l.Longitude).NotNull();
    }
}