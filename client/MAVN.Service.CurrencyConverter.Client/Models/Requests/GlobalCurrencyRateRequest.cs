using MAVN.Numerics;
using JetBrains.Annotations;

namespace MAVN.Service.CurrencyConvertor.Client.Models.Requests
{
    /// <summary>
    /// Represents a global currency rate request.
    /// </summary>
    [PublicAPI]
    public class GlobalCurrencyRateRequest
    {
        /// <summary>
        /// The amount in tokens to calculate rate.
        /// </summary>
        public Money18 AmountInTokens { get; set; }

        /// <summary>
        /// The amount in currency to calculate rate.
        /// </summary>
        public decimal AmountInCurrency { get; set; }
    }
}
