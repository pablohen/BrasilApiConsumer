using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class FeriadosController(IBrasilApi brasilApi, ILogger<FeriadosController> logger)
    : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<FeriadosController> _logger = logger;

    [HttpGet("{ano}")]
    [ProducesResponseType(typeof(List<Holiday>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFeriados(
        [Required][Range(1900, 2199, ErrorMessage = "Year must be between 1900 and 2199")] int ano
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid year requested: {Year}", ano);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching holidays for year: {Year}", ano);
        var response = await _brasilApi.GetFeriadosAsync(ano);

        if (response == null || response.Count == 0)
        {
            _logger.LogWarning("No holidays found for year: {Year}", ano);
            return NotFound();
        }

        _logger.LogInformation(
            "Successfully retrieved {Count} holidays for year: {Year}",
            response.Count,
            ano
        );
        return Ok(response);
    }
}
