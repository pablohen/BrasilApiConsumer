using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class BanksController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet("")]
    public async Task<IActionResult> GetBanks()
    {
        var banks = await _brasilApi.GetBanksAsync();
        if (banks == null || banks.Count == 0)
        {
            return NotFound("No banks found.");
        }
        return Ok(banks);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetBankByCode(string code)
    {
        var bank = await _brasilApi.GetBankByCodeAsync(code);
        if (bank == null)
        {
            return NotFound($"Bank with code {code} not found.");
        }
        return Ok(bank);
    }
}
