using Falcon.Numerics;

namespace Lykke.Service.CurrencyConvertor.Domain.Models
{
    /// <summary>
    /// Represents global currency rate.
    /// </summary>
    public class GlobalCurrencyRate
    {
        /// <summary>
        /// The amount in tokens to calculate rate.
        /// </summary>
        public Money18 AmountInTokens { get; set; }

        /// <summary>
        /// The amount in currency to calculate rate.
        /// </summary>
        public decimal AmountInCurrency { get; set; }

        public decimal Rate
            => AmountInTokens > 0 && AmountInCurrency > 0
                ? (decimal) (AmountInTokens / AmountInCurrency)
                : 1;
    }
}
