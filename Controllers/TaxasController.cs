using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxasController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet]
    [ProducesResponseType(typeof(List<Taxa>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTaxas()
    {
        var response = await _brasilApi.GetTaxasAsync();

        if (response == null)
        {
            return StatusCode(500, "Unable to retrieve tax rates information");
        }

        return Ok(response);
    }

    [HttpGet("{sigla}")]
    [ProducesResponseType(typeof(Taxa), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTaxaBySigla([Required] string sigla)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _brasilApi.GetTaxaBySiglaAsync(sigla);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}
