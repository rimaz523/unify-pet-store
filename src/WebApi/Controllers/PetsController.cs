using Application.Pets.Queries.GetPets;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PetsController : ApiControllerBase
{
    private readonly ILogger<PetsController> _logger;

    public PetsController(ILogger<PetsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<PetDto>>> GetAvailablePets([FromQuery] GetAvailablePetsQuery query)
    {
        try
        {
            return await Mediator.Send(query);
        } catch (Exception ex) 
        {
            return BadRequest(ex.Message);
        }
        
    }
}
