using JetBrains.Annotations;

namespace MAVN.Service.CurrencyConvertor.Client.Models.Responses
{
    /// <summary>
    /// Represents currency rate.
    /// </summary>
    [PublicAPI]
    // ReSharper disable once InconsistentNaming
    public class CurrencyRateModel
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
