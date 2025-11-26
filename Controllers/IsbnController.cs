using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class IsbnController(IBrasilApi brasilApi, ILogger<IsbnController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<IsbnController> _logger = logger;

    [HttpGet("{isbn}")]
    [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetLivroByIsbn(
        [Required]
        [RegularExpression(
            @"^[\d\-]{10,17}$",
            ErrorMessage = "ISBN must be a valid ISBN-10 or ISBN-13"
        )]
            string isbn,
        [FromQuery] string? providers = null
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid ISBN format: {Isbn}", isbn);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching book information for ISBN: {Isbn}", isbn);
        var response = await _brasilApi.GetLivroByIsbnAsync(isbn, providers);

        if (response == null)
        {
            _logger.LogWarning("Book not found for ISBN: {Isbn}", isbn);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved book information for ISBN: {Isbn}", isbn);
        return Ok(response);
    }
}
