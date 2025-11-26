using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class IbgeController(IBrasilApi brasilApi, ILogger<IbgeController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<IbgeController> _logger = logger;

    [HttpGet("estados")]
    [ProducesResponseType(typeof(List<Estado>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEstados()
    {
        _logger.LogInformation("Fetching all Brazilian states");
        var response = await _brasilApi.GetEstadosAsync();
        _logger.LogInformation("Successfully retrieved {Count} states", response.Count);
        return Ok(response);
    }

    [HttpGet("estados/{code}")]
    [ProducesResponseType(typeof(Estado), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEstadoByCode(
        [Required]
        [MinLength(1, ErrorMessage = "State code or abbreviation is required")]
            string code
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid state code: {Code}", code);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching state by code: {Code}", code);
        var response = await _brasilApi.GetEstadoByCodeAsync(code);

        if (response == null)
        {
            _logger.LogWarning("State not found: {Code}", code);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved state: {Code}", code);
        return Ok(response);
    }

    [HttpGet("municipios/{siglaUF}")]
    [ProducesResponseType(typeof(List<Municipio>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMunicipios(
        [Required]
        [StringLength(
            2,
            MinimumLength = 2,
            ErrorMessage = "State abbreviation must be exactly 2 characters"
        )]
            string siglaUF,
        [FromQuery] string? providers = null
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid state abbreviation: {SiglaUF}", siglaUF);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching municipalities for state: {SiglaUF}", siglaUF);
        var response = await _brasilApi.GetMunicipiosAsync(siglaUF.ToUpper(), providers);
        _logger.LogInformation(
            "Successfully retrieved {Count} municipalities for state: {SiglaUF}",
            response.Count,
            siglaUF
        );
        return Ok(response);
    }
}
