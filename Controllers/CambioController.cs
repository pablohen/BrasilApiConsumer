using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Enums;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CambioController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet("moedas")]
    [ProducesResponseType(typeof(List<Moeda>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMoedas()
    {
        var moedas = await _brasilApi.GetMoedasAsync();
        if (moedas == null || moedas.Count == 0)
        {
            return NotFound("No currencies found.");
        }
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
            return BadRequest(ModelState);
        }

        var cotacoes = await _brasilApi.GetCotacoesAsync(currencyCode, date);
        if (cotacoes == null || cotacoes.ListaCotacoes.Count == 0)
        {
            return NotFound("No cotacoes found.");
        }
        return Ok(cotacoes);
    }
}
