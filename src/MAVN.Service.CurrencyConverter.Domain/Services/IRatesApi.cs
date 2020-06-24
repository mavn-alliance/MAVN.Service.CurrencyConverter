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
        Task<ExchangeRatesModel> GetLatestExchangeRates([Query] [AliasAs("base")] string baseCurrency);
    }
}
