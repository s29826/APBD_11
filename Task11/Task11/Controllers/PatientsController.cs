using Microsoft.AspNetCore.Mvc;
using Task11.Services;

namespace Task11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        try
        {
            var patient = await _dbService.GetPatient(id);

            return Ok(patient);
        }
        catch (NullReferenceException e)
        {
            return NotFound();
        }
    }
}