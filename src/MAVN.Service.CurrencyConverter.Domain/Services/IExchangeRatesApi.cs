using System.Diagnostics.SymbolStore;
using System.Threading.Tasks;
using MAVN.Service.CurrencyConverter.Domain.Models;
using Refit;

namespace MAVN.Service.CurrencyConverter.Domain.Services
{
    /// <summary>
    /// client for https://api.exchangeratesapi.io/
    /// </summary>
    public interface IExchangeRatesApi
    {
        [Get("/latest")]
        Task<ExchangeRatesModel> GetLatestExchangeRates([Query] [AliasAs("base")] string baseCurrency);
    }
}
