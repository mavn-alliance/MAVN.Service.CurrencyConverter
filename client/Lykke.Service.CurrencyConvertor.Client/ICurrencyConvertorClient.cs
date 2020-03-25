using JetBrains.Annotations;
using Lykke.Service.CurrencyConvertor.Client.Api;

namespace Lykke.Service.CurrencyConvertor.Client
{
    /// <summary>
    /// Currency convertor service client.
    /// </summary>
    [PublicAPI]
    public interface ICurrencyConvertorClient
    {
        /// <summary>
        /// Converter API.
        /// </summary>
        IConverterApi Converter { get; }

        /// <summary>
        /// Currency rates API.
        /// </summary>
        ICurrencyRatesApi CurrencyRates { get; }
        
        /// <summary>
        /// Currency rates API.
        /// </summary>
        IGlobalCurrencyRatesApi GlobalCurrencyRates { get; }
    }
}
