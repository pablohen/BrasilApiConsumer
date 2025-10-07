using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Enums;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CambioController(IBrasilApi brasilApi, ILogger<CambioController> logger)
    : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<CambioController> _logger = logger;

    [HttpGet("moedas")]
    [ProducesResponseType(typeof(List<Moeda>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMoedas()
    {
        _logger.LogInformation("Fetching all available currencies");
        var moedas = await _brasilApi.GetMoedasAsync();
        if (moedas == null || moedas.Count == 0)
        {
            _logger.LogWarning("No currencies found");
            return NotFound("No currencies found.");
        }
        _logger.LogInformation("Successfully retrieved {Count} currencies", moedas.Count);
        return Ok(moedas);
    }

    [HttpGet("cotacao/{currencyCode}/{date}")]
    [ProducesResponseType(typeof(Cotacoes), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCotacoes(
        [Required] CurrencyCode currencyCode,
        [Required] DateOnly date
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning(
                "Invalid request for currency {Currency} on date {Date}",
                currencyCode,
                date
            );
            return BadRequest(ModelState);
        }

        if (date > DateOnly.FromDateTime(DateTime.UtcNow))
        {
            _logger.LogWarning("Future date requested: {Date}", date);
            return BadRequest("Cannot retrieve exchange rates for future dates");
        }

        _logger.LogInformation(
            "Fetching exchange rates for {Currency} on {Date}",
            currencyCode,
            date
        );
        var cotacoes = await _brasilApi.GetCotacoesAsync(currencyCode, date);
        if (cotacoes == null || cotacoes.ListaCotacoes.Count == 0)
        {
            _logger.LogWarning(
                "No exchange rates found for {Currency} on {Date}",
                currencyCode,
                date
            );
            return NotFound("No cotacoes found.");
        }
        _logger.LogInformation(
            "Successfully retrieved exchange rates for {Currency} on {Date}",
            currencyCode,
            date
        );
        return Ok(cotacoes);
    }
}
