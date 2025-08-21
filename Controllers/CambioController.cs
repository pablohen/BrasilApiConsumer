using BrasilApiConsumer.Interfaces;
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
        return Ok(moedas);
    }

    [HttpGet("cotacao/{moeda}/{data}")]
    public async Task<IActionResult> GetCotacoes(string moeda, string data)
    {
        var cotacoes = await _brasilApi.GetCotacoesAsync(moeda, data);
        return Ok(cotacoes);
    }
}
