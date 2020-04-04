using JetBrains.Annotations;
using Lykke.Service.CurrencyConvertor.Client.Models.Enums;

namespace Lykke.Service.CurrencyConvertor.Client.Models.Responses
{
    /// <summary>
    /// Represents a rate response.
    /// </summary>
    [PublicAPI]
    public class CurrencyRateResponse
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

        /// <summary>
        /// The rate operation error code.
        /// </summary>
        public RateErrorCode ErrorCode { get; set; }
    }
}
