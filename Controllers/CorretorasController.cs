using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CorretorasController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet("")]
    [ProducesResponseType(typeof(List<Corretora>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCorretoras()
    {
        var corretoras = await _brasilApi.GetCorretorasAsync();

        if (corretoras == null || corretoras.Count == 0)
        {
            return NotFound();
        }

        return Ok(corretoras);
    }

    [HttpGet("{cnpj}")]
    [ProducesResponseType(typeof(Corretora), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCorretoraByCnpj([Required] string cnpj)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var corretora = await _brasilApi.GetCorretoraByCnpjAsync(cnpj);

        if (corretora == null)
        {
            return NotFound();
        }

        return Ok(corretora);
    }
}
