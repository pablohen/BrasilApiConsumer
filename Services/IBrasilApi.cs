using BrasilApiConsumer.Enums;
using BrasilApiConsumer.Models;
using Refit;

namespace BrasilApiConsumer.Services;

public interface IBrasilApi
{
    // Banks
    [Get("/banks/v1")]
    Task<List<Bank>> GetBanksAsync();

    [Get("/banks/v1/{code}")]
    Task<Bank> GetBankByCodeAsync(string code);

    // Cambio
    [Get("/cambio/v1/moedas")]
    Task<List<Moeda>> GetMoedasAsync();

    [Get("/cambio/v1/cotacao/{currencyCode}/{date}")]
    Task<Cotacoes> GetCotacoesAsync(CurrencyCode currencyCode, DateOnly date);

    // CEP
    [Get("/cep/v1/{cep}")]
    Task<CepResponse> GetCepV1Async(string cep);

    [Get("/cep/v2/{cep}")]
    Task<CepResponse> GetCepAsync(string cep);

    // CNPJ
    [Get("/cnpj/v1/{cnpj}")]
    Task<CnpjResponse> GetCnpjAsync(string cnpj);

    // Corretoras (CVM)
    [Get("/cvm/corretoras/v1")]
    Task<List<Corretora>> GetCorretorasAsync();

    [Get("/cvm/corretoras/v1/{cnpj}")]
    Task<Corretora> GetCorretoraByCnpjAsync(string cnpj);

    // CPTEC
    [Get("/cptec/v1/cidade")]
    Task<List<CptecCity>> GetCptecCitiesAsync();

    [Get("/cptec/v1/cidade/{cityName}")]
    Task<List<CptecCity>> SearchCptecCitiesAsync(string cityName);

    [Get("/cptec/v1/clima/capital")]
    Task<List<ClimaCapital>> GetClimaCapitaisAsync();

    [Get("/cptec/v1/clima/aeroporto/{icaoCode}")]
    Task<ClimaAeroporto> GetClimaAeroportoAsync(string icaoCode);

    [Get("/cptec/v1/clima/previsao/{cityCode}")]
    Task<PrevisaoClima> GetPrevisaoClimaAsync(int cityCode);

    [Get("/cptec/v1/clima/previsao/{cityCode}/{days}")]
    Task<PrevisaoClima> GetPrevisaoClimaDaysAsync(int cityCode, int days);

    [Get("/cptec/v1/ondas/{cityCode}")]
    Task<PrevisaoOndas> GetPrevisaoOndasAsync(int cityCode);

    [Get("/cptec/v1/ondas/{cityCode}/{days}")]
    Task<PrevisaoOndas> GetPrevisaoOndasDaysAsync(int cityCode, int days);

    // DDD
    [Get("/ddd/v1/{ddd}")]
    Task<DddResponse> GetDddAsync(string ddd);

    // Feriados
    [Get("/feriados/v1/{ano}")]
    Task<List<Holiday>> GetFeriadosAsync(int ano);

    // FIPE
    [Get("/fipe/marcas/v1/{tipoVeiculo}")]
    Task<List<FipeMarca>> GetFipeMarcasAsync(
        string tipoVeiculo,
        [Query] int? tabela_referencia = null
    );

    [Get("/fipe/preco/v1/{codigoFipe}")]
    Task<List<FipePreco>> GetFipePrecoAsync(
        string codigoFipe,
        [Query] int? tabela_referencia = null
    );

    [Get("/fipe/tabelas/v1")]
    Task<List<FipeTabela>> GetFipeTabelasAsync();

    [Get("/fipe/veiculos/v1/{tipoVeiculo}/{codigoMarca}")]
    Task<List<FipeVeiculo>> GetFipeVeiculosAsync(
        string tipoVeiculo,
        string codigoMarca,
        [Query] int? tabela_referencia = null
    );

    // IBGE
    [Get("/ibge/municipios/v1/{siglaUF}")]
    Task<List<Municipio>> GetMunicipiosAsync(string siglaUF, [Query] string? providers = null);

    [Get("/ibge/uf/v1")]
    Task<List<Estado>> GetEstadosAsync();

    [Get("/ibge/uf/v1/{code}")]
    Task<Estado> GetEstadoByCodeAsync(string code);

    // ISBN
    [Get("/isbn/v1/{isbn}")]
    Task<Livro> GetLivroByIsbnAsync(string isbn, [Query] string? providers = null);

    // NCM
    [Get("/ncm/v1")]
    Task<List<Ncm>> GetNcmsAsync();

    [Get("/ncm/v1")]
    Task<List<Ncm>> SearchNcmsAsync([Query] string search);

    [Get("/ncm/v1/{code}")]
    Task<Ncm> GetNcmByCodeAsync(string code);

    // PIX
    [Get("/pix/v1/participants")]
    Task<List<PixParticipant>> GetPixParticipantsAsync();

    // Registro BR
    [Get("/registrobr/v1/{domain}")]
    Task<DomainResponse> GetDomainAsync(string domain);

    // Taxas
    [Get("/taxas/v1")]
    Task<List<Taxa>> GetTaxasAsync();

    [Get("/taxas/v1/{sigla}")]
    Task<Taxa> GetTaxaBySiglaAsync(string sigla);
}
