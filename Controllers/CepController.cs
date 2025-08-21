using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CepController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet("{cep}")]
    [ProducesResponseType(typeof(CepResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCep([Required] string cep)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _brasilApi.GetCepAsync(cep);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}
