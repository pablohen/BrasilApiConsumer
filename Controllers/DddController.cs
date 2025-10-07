using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class DddController(IBrasilApi brasilApi, ILogger<DddController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<DddController> _logger = logger;

    [HttpGet("{ddd}")]
    [ProducesResponseType(typeof(DddResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDdd(
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "DDD must be exactly 2 digits")]
        [RegularExpression(@"^[1-9][0-9]$", ErrorMessage = "DDD must be between 10 and 99")]
            string ddd
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid DDD format: {Ddd}", ddd);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching cities for DDD: {Ddd}", ddd);
        var response = await _brasilApi.GetDddAsync(ddd);

        if (response == null)
        {
            _logger.LogWarning("DDD not found: {Ddd}", ddd);
            return NotFound();
        }

        _logger.LogInformation(
            "Successfully retrieved {Count} cities for DDD: {Ddd}",
            response.Cities.Count,
            ddd
        );
        return Ok(response);
    }
}
