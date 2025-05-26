using Microsoft.AspNetCore.Mvc;
using Task11.DTOs;
using Task11.Services;

namespace Task11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] CreatePrescriptionDto dto)
    {
        try
        {
            await _dbService.AddPrescription(dto);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound();
        }
        catch (ArgumentException e)
        {
            return BadRequest();
        }
    }
}