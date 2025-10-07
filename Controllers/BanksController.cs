using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class BanksController(IBrasilApi brasilApi, ILogger<BanksController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<BanksController> _logger = logger;

    [HttpGet("")]
    [ProducesResponseType(typeof(List<Bank>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBanks()
    {
        _logger.LogInformation("Fetching all banks");
        var banks = await _brasilApi.GetBanksAsync();
        if (banks == null || banks.Count == 0)
        {
            _logger.LogWarning("No banks found");
            return NotFound("No banks found.");
        }
        _logger.LogInformation("Successfully retrieved {Count} banks", banks.Count);
        return Ok(banks);
    }

    [HttpGet("{code}")]
    [ProducesResponseType(typeof(Bank), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBankByCode([Required] string code)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for bank code: {Code}", code);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching bank with code: {Code}", code);
        var bank = await _brasilApi.GetBankByCodeAsync(code);
        if (bank == null)
        {
            _logger.LogWarning("Bank with code {Code} not found", code);
            return NotFound($"Bank with code {code} not found.");
        }
        _logger.LogInformation("Successfully retrieved bank with code: {Code}", code);
        return Ok(bank);
    }
}
