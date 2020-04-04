namespace Lykke.Service.CurrencyConvertor.Domain.Models
{
    /// <summary>
    /// Represents currency rate.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class CurrencyRate
    {
        /// <summary>
        /// The base asset name.
        /// </summary>
        public string BaseAsset { get; set; }

        /// <summary>
        /// The quote asset name.
        /// </summary>
        public string QuoteAsset { get; set; }

        /// <summary>
        /// The asset pair rate.
        /// </summary>
        public decimal Rate { get; set; }
    }
}
