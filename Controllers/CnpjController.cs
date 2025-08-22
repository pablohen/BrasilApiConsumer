using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CnpjController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet("{cnpj}")]
    [ProducesResponseType(typeof(CnpjResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetCnpj([Required] string cnpj)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _brasilApi.GetCnpjAsync(cnpj);
        Console.WriteLine($"CNPJ: {cnpj}, Response: {response}");

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}
