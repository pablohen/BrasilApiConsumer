using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CorretorasController(IBrasilApi brasilApi, ILogger<CorretorasController> logger)
    : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<CorretorasController> _logger = logger;

    [HttpGet("")]
    [ProducesResponseType(typeof(List<Corretora>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCorretoras()
    {
        _logger.LogInformation("Fetching all brokers");
        var corretoras = await _brasilApi.GetCorretorasAsync();

        if (corretoras == null || corretoras.Count == 0)
        {
            _logger.LogWarning("No brokers found");
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved {Count} brokers", corretoras.Count);
        return Ok(corretoras);
    }

    [HttpGet("{cnpj}")]
    [ProducesResponseType(typeof(Corretora), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCorretoraByCnpj(
        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ must be 14 digits")]
            string cnpj
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid CNPJ format for broker: {Cnpj}", cnpj);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching broker with CNPJ: {Cnpj}", cnpj);
        var corretora = await _brasilApi.GetCorretoraByCnpjAsync(cnpj);

        if (corretora == null)
        {
            _logger.LogWarning("Broker with CNPJ {Cnpj} not found", cnpj);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved broker with CNPJ: {Cnpj}", cnpj);
        return Ok(corretora);
    }
}
