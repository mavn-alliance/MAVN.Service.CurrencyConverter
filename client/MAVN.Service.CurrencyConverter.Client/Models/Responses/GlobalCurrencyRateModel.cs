using Falcon.Numerics;
using JetBrains.Annotations;

namespace MAVN.Service.CurrencyConvertor.Client.Models.Responses
{
    /// <summary>
    /// Represents global currency rate.
    /// </summary>
    [PublicAPI]
    public class GlobalCurrencyRateModel
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
