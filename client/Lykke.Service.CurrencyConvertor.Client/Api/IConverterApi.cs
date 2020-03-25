using System.Threading.Tasks;
using JetBrains.Annotations;
using Falcon.Numerics;
using Lykke.Service.CurrencyConvertor.Client.Models.Responses;
using Refit;

namespace Lykke.Service.CurrencyConvertor.Client.Api
{
    /// <summary>
    /// Provides methods to work with converter.
    /// </summary>
    [PublicAPI]
    public interface IConverterApi
    {
        /// <summary>
        /// Converts amount from <paramref name="fromAsset"/> to <paramref name="toAsset"/>.
        /// </summary>
        /// <param name="fromAsset">The asset name of the currency that should be converted from.</param>
        /// <param name="toAsset">The asset name of the currency that should be converted to.</param>
        /// <param name="amount">The amount to be converted.</param>
        /// <returns>The result of convert.</returns>
        [Get("/api/converter")]
        Task<ConverterResponse> ConvertAsync(string fromAsset, string toAsset, decimal amount);

        /// <summary>
        /// Converts tokens to BaseCurrency using global currency rate.
        /// </summary>
        /// <param name="amount">The amount to be converted.</param>
        /// <returns>The result of convert.</returns>
        [Get("/api/converter/tokens/baseCurrency")]
        Task<ConverterResponse> ConvertTokensToBaseCurrencyAsync(Money18 amount);
    }
}
