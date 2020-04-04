using JetBrains.Annotations;

namespace MAVN.Service.CurrencyConvertor.Client.Models.Requests
{
    /// <summary>
    /// Represents a rate request.
    /// </summary>
    [PublicAPI]
    // ReSharper disable once InconsistentNaming
    public class CurrencyRateRequest
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
