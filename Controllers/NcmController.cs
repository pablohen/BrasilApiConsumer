using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class NcmController(IBrasilApi brasilApi, ILogger<NcmController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<NcmController> _logger = logger;

    [HttpGet]
    [ProducesResponseType(typeof(List<Ncm>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNcms([FromQuery] string? search = null)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            _logger.LogInformation("Searching NCM codes with query: {Search}", search);
            var searchResponse = await _brasilApi.SearchNcmsAsync(search);
            _logger.LogInformation(
                "Found {Count} NCM codes matching: {Search}",
                searchResponse.Count,
                search
            );
            return Ok(searchResponse);
        }

        _logger.LogInformation("Fetching all NCM codes");
        var response = await _brasilApi.GetNcmsAsync();
        _logger.LogInformation("Successfully retrieved {Count} NCM codes", response.Count);
        return Ok(response);
    }

    [HttpGet("{code}")]
    [ProducesResponseType(typeof(Ncm), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNcmByCode(
        [Required]
        [RegularExpression(@"^\d{2,8}$", ErrorMessage = "NCM code must be between 2 and 8 digits")]
            string code
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid NCM code format: {Code}", code);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching NCM information for code: {Code}", code);
        var response = await _brasilApi.GetNcmByCodeAsync(code);

        if (response == null)
        {
            _logger.LogWarning("NCM code not found: {Code}", code);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved NCM information for code: {Code}", code);
        return Ok(response);
    }
}
