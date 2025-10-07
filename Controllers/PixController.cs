using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class PixController(IBrasilApi brasilApi) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;

    [HttpGet("participants")]
    [ProducesResponseType(typeof(List<PixParticipant>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPixParticipants()
    {
        var response = await _brasilApi.GetPixParticipantsAsync();

        if (response == null)
        {
            return StatusCode(500, "Unable to retrieve PIX participants information");
        }

        return Ok(response);
    }
}
