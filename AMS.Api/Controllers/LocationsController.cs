using AMS.Application.Locations.Commands.CreateLocation;
using AMS.Contracts.Location;
using Microsoft.AspNetCore.Authorization;

namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LocationsController : ControllerBase
{
    
    private  readonly IMapper _mapper;
    private  readonly ISender _mediator;

    public LocationsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    
    public async Task<IActionResult> CrateLocation(CreateLocationRequest request)
    {
        var command = _mapper.Map<CreateLocationCommand>(request);
        
        var createLocationResult =await  _mediator.Send(command);


        return Ok(request);
    }
}
