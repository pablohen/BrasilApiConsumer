using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class PixController(IBrasilApi brasilApi, ILogger<PixController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<PixController> _logger = logger;

    [HttpGet("participants")]
    [ProducesResponseType(typeof(List<PixParticipant>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPixParticipants()
    {
        _logger.LogInformation("Fetching all PIX participants");
        var response = await _brasilApi.GetPixParticipantsAsync();

        if (response == null || response.Count == 0)
        {
            _logger.LogError("Unable to retrieve PIX participants information");
            return StatusCode(500, "Unable to retrieve PIX participants information");
        }

        _logger.LogInformation("Successfully retrieved {Count} PIX participants", response.Count);
        return Ok(response);
    }
}
