using System.Threading.Tasks;
using JetBrains.Annotations;
using MAVN.Service.CurrencyConvertor.Client.Models.Requests;
using MAVN.Service.CurrencyConvertor.Client.Models.Responses;
using Refit;

namespace MAVN.Service.CurrencyConvertor.Client.Api
{
    /// <summary>
    /// Provides methods to work with global currency rates.
    /// </summary>
    [PublicAPI]
    public interface IGlobalCurrencyRatesApi
    {
        /// <summary>
        /// Returns global currency rate.
        /// </summary>
        /// <returns>A global currency rate.</returns>
        [Get("/api/globalCurrencyRates")]
        Task<GlobalCurrencyRateModel> GetAsync();

        /// <summary>
        /// Updates global currency rate.
        /// </summary>
        /// <param name="request">The global currency rate request.</param>
        /// <returns>The global currency rate operation result.</returns>
        [Put("/api/globalCurrencyRates")]
        Task UpdateAsync([Body] GlobalCurrencyRateRequest request);
    }
}
