using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistroBrController(IBrasilApi brasilApi, ILogger<RegistroBrController> logger)
    : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<RegistroBrController> _logger = logger;

    [HttpGet("{domain}")]
    [ProducesResponseType(typeof(DomainResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDomain(
        [Required]
        [StringLength(
            255,
            MinimumLength = 3,
            ErrorMessage = "Domain must be between 3 and 255 characters"
        )]
        [RegularExpression(
            @"^[a-zA-Z0-9]([a-zA-Z0-9-]*[a-zA-Z0-9])?(\.[a-zA-Z0-9]([a-zA-Z0-9-]*[a-zA-Z0-9])?)*\.br$",
            ErrorMessage = "Invalid .br domain format"
        )]
            string domain
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid domain format: {Domain}", domain);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Checking domain availability: {Domain}", domain);
        var response = await _brasilApi.GetDomainAsync(domain);

        if (response == null)
        {
            _logger.LogWarning("Domain not found or error occurred: {Domain}", domain);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved information for domain: {Domain}", domain);
        return Ok(response);
    }
}
