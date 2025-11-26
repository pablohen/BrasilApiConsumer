using System.ComponentModel.DataAnnotations;
using BrasilApiConsumer.Models;
using BrasilApiConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrasilApiConsumer.Controllers;

[ApiController]
[Route("[controller]")]
public class FipeController(IBrasilApi brasilApi, ILogger<FipeController> logger) : ControllerBase
{
    private readonly IBrasilApi _brasilApi = brasilApi;
    private readonly ILogger<FipeController> _logger = logger;

    private static readonly string[] ValidVehicleTypes = { "caminhoes", "carros", "motos" };

    [HttpGet("tabelas")]
    [ProducesResponseType(typeof(List<FipeTabela>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTabelas()
    {
        _logger.LogInformation("Fetching FIPE reference tables");
        var response = await _brasilApi.GetFipeTabelasAsync();
        _logger.LogInformation(
            "Successfully retrieved {Count} FIPE reference tables",
            response.Count
        );
        return Ok(response);
    }

    [HttpGet("marcas/{tipoVeiculo}")]
    [ProducesResponseType(typeof(List<FipeMarca>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMarcas(
        [Required] string tipoVeiculo,
        [FromQuery] int? tabela_referencia = null
    )
    {
        if (!ValidVehicleTypes.Contains(tipoVeiculo.ToLower()))
        {
            _logger.LogWarning(
                "Invalid vehicle type: {TipoVeiculo}. Valid types: caminhoes, carros, motos",
                tipoVeiculo
            );
            return BadRequest(
                $"Invalid vehicle type. Valid types: {string.Join(", ", ValidVehicleTypes)}"
            );
        }

        _logger.LogInformation("Fetching FIPE brands for vehicle type: {TipoVeiculo}", tipoVeiculo);
        var response = await _brasilApi.GetFipeMarcasAsync(
            tipoVeiculo.ToLower(),
            tabela_referencia
        );
        _logger.LogInformation(
            "Successfully retrieved {Count} brands for vehicle type: {TipoVeiculo}",
            response.Count,
            tipoVeiculo
        );
        return Ok(response);
    }

    [HttpGet("veiculos/{tipoVeiculo}/{codigoMarca}")]
    [ProducesResponseType(typeof(List<FipeVeiculo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetVeiculos(
        [Required] string tipoVeiculo,
        [Required] string codigoMarca,
        [FromQuery] int? tabela_referencia = null
    )
    {
        if (!ValidVehicleTypes.Contains(tipoVeiculo.ToLower()))
        {
            _logger.LogWarning(
                "Invalid vehicle type: {TipoVeiculo}. Valid types: caminhoes, carros, motos",
                tipoVeiculo
            );
            return BadRequest(
                $"Invalid vehicle type. Valid types: {string.Join(", ", ValidVehicleTypes)}"
            );
        }

        _logger.LogInformation(
            "Fetching FIPE vehicles for type: {TipoVeiculo}, brand: {CodigoMarca}",
            tipoVeiculo,
            codigoMarca
        );
        var response = await _brasilApi.GetFipeVeiculosAsync(
            tipoVeiculo.ToLower(),
            codigoMarca,
            tabela_referencia
        );
        _logger.LogInformation(
            "Successfully retrieved {Count} vehicles for type: {TipoVeiculo}, brand: {CodigoMarca}",
            response.Count,
            tipoVeiculo,
            codigoMarca
        );
        return Ok(response);
    }

    [HttpGet("preco/{codigoFipe}")]
    [ProducesResponseType(typeof(List<FipePreco>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPreco(
        [Required]
        [RegularExpression(
            @"^\d{6,7}-?\d$",
            ErrorMessage = "FIPE code must be in format 123456-7 or 1234567"
        )]
            string codigoFipe,
        [FromQuery] int? tabela_referencia = null
    )
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid FIPE code format: {CodigoFipe}", codigoFipe);
            return BadRequest(ModelState);
        }

        _logger.LogInformation("Fetching FIPE price for code: {CodigoFipe}", codigoFipe);
        var response = await _brasilApi.GetFipePrecoAsync(codigoFipe, tabela_referencia);

        if (response == null || response.Count == 0)
        {
            _logger.LogWarning("FIPE code not found: {CodigoFipe}", codigoFipe);
            return NotFound();
        }

        _logger.LogInformation(
            "Successfully retrieved price for FIPE code: {CodigoFipe}",
            codigoFipe
        );
        return Ok(response);
    }
}
