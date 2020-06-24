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
        Task<ExchangeRatesModel> GetLatestExchangeRate([Query(CollectionFormat.Csv)] [AliasAs("symbols")] string[] currencies, [Query] [AliasAs("base")] string baseCurrency);
    }
}
