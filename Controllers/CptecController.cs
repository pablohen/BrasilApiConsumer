using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CptecController(IBrasilApi brasilApi, ILogger<CptecController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<CptecController> _logger = logger;

    [HttpGet("cidades")]
    [ProducesResponseType(typeof(List<CptecCity>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCidades()
    {
        _logger.LogInformation("Fetching all CPTEC cities");
        var response = await _brasilApi.GetCptecCitiesAsync();
        _logger.LogInformation("Successfully retrieved {Count} CPTEC cities", response.Count);
        return Ok(response);
    }

    [HttpGet("cidades/{cityName}")]
    [ProducesResponseType(typeof(List<CptecCity>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SearchCidades(
        [Required]
        [MinLength(3, ErrorMessage = "City name must have at least 3 characters")]
            string cityName
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid city name: {CityName}", cityName);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Searching CPTEC cities by name: {CityName}", cityName);
        var response = await _brasilApi.SearchCptecCitiesAsync(cityName);
        _logger.LogInformation(
            "Found {Count} cities matching: {CityName}",
            response.Count,
            cityName
        );
        return Ok(response);
    }

    [HttpGet("clima/capitais")]
    [ProducesResponseType(typeof(List<ClimaCapital>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClimaCapitais()
    {
        _logger.LogInformation("Fetching weather conditions for all state capitals");
        var response = await _brasilApi.GetClimaCapitaisAsync();
        _logger.LogInformation(
            "Successfully retrieved weather for {Count} capitals",
            response.Count
        );
        return Ok(response);
    }

    [HttpGet("clima/aeroporto/{icaoCode}")]
    [ProducesResponseType(typeof(ClimaAeroporto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetClimaAeroporto(
        [Required]
        [StringLength(
            4,
            MinimumLength = 4,
            ErrorMessage = "ICAO code must be exactly 4 characters"
        )]
            string icaoCode
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid ICAO code: {IcaoCode}", icaoCode);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching weather conditions for airport: {IcaoCode}", icaoCode);
        var response = await _brasilApi.GetClimaAeroportoAsync(icaoCode);

        if (response == null)
        {
            _logger.LogWarning("Airport not found: {IcaoCode}", icaoCode);
            return NotFound();
        }

        _logger.LogInformation("Successfully retrieved weather for airport: {IcaoCode}", icaoCode);
        return Ok(response);
    }

    [HttpGet("clima/previsao/{cityCode}")]
    [ProducesResponseType(typeof(PrevisaoClima), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPrevisaoClima(
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "City code must be a positive integer")]
            int cityCode
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid city code: {CityCode}", cityCode);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching weather forecast for city code: {CityCode}", cityCode);
        var response = await _brasilApi.GetPrevisaoClimaAsync(cityCode);

        if (response == null)
        {
            _logger.LogWarning("City not found: {CityCode}", cityCode);
            return NotFound();
        }

        _logger.LogInformation(
            "Successfully retrieved weather forecast for city code: {CityCode}",
            cityCode
        );
        return Ok(response);
    }

    [HttpGet("clima/previsao/{cityCode}/{days}")]
    [ProducesResponseType(typeof(PrevisaoClima), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPrevisaoClimaDays(
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "City code must be a positive integer")]
            int cityCode,
        [Required][Range(1, 6, ErrorMessage = "Days must be between 1 and 6")] int days
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning(
                "Invalid parameters - City code: {CityCode}, Days: {Days}",
                cityCode,
                days
            );
            return BadRequest(ModelState);
        }

        _logger.LogInformation(
            "Fetching {Days}-day weather forecast for city code: {CityCode}",
            days,
            cityCode
        );
        var response = await _brasilApi.GetPrevisaoClimaDaysAsync(cityCode, days);

        if (response == null)
        {
            _logger.LogWarning("City not found: {CityCode}", cityCode);
            return NotFound();
        }

        _logger.LogInformation(
            "Successfully retrieved {Days}-day weather forecast for city code: {CityCode}",
            days,
            cityCode
        );
        return Ok(response);
    }

    [HttpGet("ondas/{cityCode}")]
    [ProducesResponseType(typeof(PrevisaoOndas), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPrevisaoOndas(
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "City code must be a positive integer")]
            int cityCode
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid city code: {CityCode}", cityCode);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching ocean forecast for city code: {CityCode}", cityCode);
        var response = await _brasilApi.GetPrevisaoOndasAsync(cityCode);

        if (response == null)
        {
            _logger.LogWarning("City not found: {CityCode}", cityCode);
            return NotFound();
        }

        _logger.LogInformation(
            "Successfully retrieved ocean forecast for city code: {CityCode}",
            cityCode
        );
        return Ok(response);
    }

    [HttpGet("ondas/{cityCode}/{days}")]
    [ProducesResponseType(typeof(PrevisaoOndas), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPrevisaoOndasDays(
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "City code must be a positive integer")]
            int cityCode,
        [Required][Range(1, 6, ErrorMessage = "Days must be between 1 and 6")] int days
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning(
                "Invalid parameters - City code: {CityCode}, Days: {Days}",
                cityCode,
                days
            );
            return BadRequest(ModelState);
        }

        _logger.LogInformation(
            "Fetching {Days}-day ocean forecast for city code: {CityCode}",
            days,
            cityCode
        );
        var response = await _brasilApi.GetPrevisaoOndasDaysAsync(cityCode, days);

        if (response == null)
        {
            _logger.LogWarning("City not found: {CityCode}", cityCode);
            return NotFound();
        }

        _logger.LogInformation(
            "Successfully retrieved {Days}-day ocean forecast for city code: {CityCode}",
            days,
            cityCode
        );
        return Ok(response);
    }
}
