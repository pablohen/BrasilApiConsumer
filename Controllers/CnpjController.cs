using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CnpjController(IBrasilApi brasilApi, ILogger<CnpjController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<CnpjController> _logger = logger;

    [HttpGet("{cnpj}")]
    [ProducesResponseType(typeof(CnpjResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetCnpj(
        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ must be 14 digits")]
            string cnpj
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid CNPJ format: {Cnpj}", cnpj);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching company information for CNPJ: {Cnpj}", cnpj);
        var response = await _brasilApi.GetCnpjAsync(cnpj);

        if (response == null)
        {
            _logger.LogWarning("CNPJ not found: {Cnpj}", cnpj);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved company information for CNPJ: {Cnpj}", cnpj);
        return Ok(response);
    }
}
