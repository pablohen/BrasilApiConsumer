using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CambioController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet("moedas")]
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
    public async Task<IActionResult> GetCotacoes(string moeda, string data)
    {
        var cotacoes = await _brasilApi.GetCotacoesAsync(moeda, data);
        if (cotacoes == null || cotacoes.ListaCotacoes.Count == 0)
        {
            return NotFound("No cotacoes found.");
        }
        return Ok(cotacoes);
    }
}
