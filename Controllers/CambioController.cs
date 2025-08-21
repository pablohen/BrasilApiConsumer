using System.ComponentModel.DataAnnotations;
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

    [HttpGet("cotacao/{moeda}/{data}")]
    [ProducesResponseType(typeof(Cotacoes), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCotacoes([Required] string moeda, [Required] string data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var cotacoes = await _brasilApi.GetCotacoesAsync(moeda, data);
        if (cotacoes == null || cotacoes.ListaCotacoes.Count == 0)
        {
            return NotFound("No cotacoes found.");
        }
        return Ok(cotacoes);
    }
}
