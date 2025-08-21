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

    [Get("/cambio/v1/cotacao/{moeda}/{data}")]
    Task<Cotacoes> GetCotacoesAsync(string moeda, DateOnly data);
}
