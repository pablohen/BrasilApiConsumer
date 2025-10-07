using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxasController(IBrasilApi brasilApi, ILogger<TaxasController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<TaxasController> _logger = logger;

    [HttpGet]
    [ProducesResponseType(typeof(List<Taxa>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTaxas()
    {
        _logger.LogInformation("Fetching all tax rates");
        var response = await _brasilApi.GetTaxasAsync();

        if (response == null || response.Count == 0)
        {
            _logger.LogError("Unable to retrieve tax rates information");
            return StatusCode(500, "Unable to retrieve tax rates information");
        }

        _logger.LogInformation("Successfully retrieved {Count} tax rates", response.Count);
        return Ok(response);
    }

    [HttpGet("{sigla}")]
    [ProducesResponseType(typeof(Taxa), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTaxaBySigla(
        [Required]
        [StringLength(
            50,
            MinimumLength = 2,
            ErrorMessage = "Tax rate code must be between 2 and 50 characters"
        )]
            string sigla
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid tax rate code format: {Sigla}", sigla);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching tax rate: {Sigla}", sigla);
        var response = await _brasilApi.GetTaxaBySiglaAsync(sigla);

        if (response == null)
        {
            _logger.LogWarning("Tax rate not found: {Sigla}", sigla);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved tax rate: {Sigla}", sigla);
        return Ok(response);
    }
}
