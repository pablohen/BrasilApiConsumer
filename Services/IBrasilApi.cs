using BrasilApiConsumer.Enums;
using BrasilApiConsumer.Models;
using Refit;

namespace BrasilApiConsumer.Services;

public interface IBrasilApi
{
    [Get("/banks/v1")]
    Task<List<Bank>> GetBanksAsync();

    [Get("/banks/v1/{code}")]
    Task<Bank> GetBankByCodeAsync(string code);

    [Get("/cambio/v1/moedas")]
    Task<List<Moeda>> GetMoedasAsync();

    [Get("/cambio/v1/cotacao/{currencyCode}/{date}")]
    Task<Cotacoes> GetCotacoesAsync(CurrencyCode currencyCode, DateOnly date);

    [Get("/cep/v2/{cep}")]
    Task<CepResponse> GetCepAsync(string cep);
}
