using System.Threading.Tasks;
using MAVN.Service.CurrencyConverter.Domain.Models;
using Refit;

namespace MAVN.Service.CurrencyConverter.Domain.Services
{
    /// <summary>
    /// Client for https://api.ratesapi.io
    /// </summary>
    public interface IRatesApi
    {
        [Get("/latest")]
        Task<ExchangeRatesModel> GetLatestExchangeRate([Query(CollectionFormat.Csv)] [AliasAs("symbols")] string[] currencies, [Query] [AliasAs("base")] string baseCurrency);
    }
}
