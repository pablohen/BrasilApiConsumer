using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistroBrController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet("{domain}")]
    [ProducesResponseType(typeof(DomainResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDomain([Required] string domain)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _brasilApi.GetDomainAsync(domain);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}
