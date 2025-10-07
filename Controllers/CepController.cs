using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CepController(IBrasilApi brasilApi, ILogger<CepController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<CepController> _logger = logger;

    [HttpGet("{cep}")]
    [ProducesResponseType(typeof(CepResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCep(
        [Required]
        [RegularExpression(
            @"^\d{5}-?\d{3}$",
            ErrorMessage = "CEP must be in format 12345-678 or 12345678"
        )]
            string cep
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid CEP format: {Cep}", cep);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching address for CEP: {Cep}", cep);
        var response = await _brasilApi.GetCepAsync(cep);

        if (response == null)
        {
            _logger.LogWarning("CEP not found: {Cep}", cep);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved address for CEP: {Cep}", cep);
        return Ok(response);
    }
}
