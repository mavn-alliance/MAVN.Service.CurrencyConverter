using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MAVN.Service.CurrencyConvertor.Client.Models.Requests;
using MAVN.Service.CurrencyConvertor.Client.Models.Responses;
using Refit;

namespace MAVN.Service.CurrencyConvertor.Client.Api
{
    /// <summary>
    /// Provides methods to work with rates.
    /// </summary>
    [PublicAPI]
    public interface ICurrencyRatesApi
    {
        /// <summary>
        /// Returns all currency rates.
        /// </summary>
        /// <returns>A collection of currency rates.</returns>
        [Get("/api/currencyRates")]
        Task<IReadOnlyList<CurrencyRateModel>> GetAllAsync();

        /// <summary>
        /// Creates new currency rate.
        /// </summary>
        /// <param name="request">The currency rate request.</param>
        /// <returns>The currency rate operation result.</returns>
        [Post("/api/currencyRates")]
        Task<CurrencyRateResponse> CreateAsync([Body] CurrencyRateRequest request);

        /// <summary>
        /// Updates currency rate.
        /// </summary>
        /// <param name="request">The currency rate request.</param>
        /// <returns>The currency rate operation result.</returns>
        [Put("/api/currencyRates")]
        Task<CurrencyRateResponse> UpdateAsync([Body] CurrencyRateRequest request);

        /// <summary>
        /// Deletes currency rate by base and quote asset names.
        /// </summary>
        /// <param name="fromAsset">The asset name of the currency that should be converted from.</param>
        /// <param name="toAsset">The asset name of the currency that should be converted to.</param>
        [Delete("/api/currencyRates")]
        Task DeleteAsync(string fromAsset, string toAsset);
    }
}
