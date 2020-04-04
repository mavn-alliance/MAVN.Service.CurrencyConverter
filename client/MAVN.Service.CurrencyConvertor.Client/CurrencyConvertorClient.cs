using JetBrains.Annotations;
using Lykke.HttpClientGenerator;
using Lykke.Service.CurrencyConvertor.Client.Api;

namespace Lykke.Service.CurrencyConvertor.Client
{
    /// <inheritdoc />
    [PublicAPI]
    public class CurrencyConvertorClient : ICurrencyConvertorClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CurrencyConvertorClient"/> with <param name="httpClientGenerator"></param>.
        /// </summary> 
        public CurrencyConvertorClient(IHttpClientGenerator httpClientGenerator)
        {
            Converter = httpClientGenerator.Generate<IConverterApi>();
            CurrencyRates = httpClientGenerator.Generate<ICurrencyRatesApi>();
            GlobalCurrencyRates = httpClientGenerator.Generate<IGlobalCurrencyRatesApi>();
        }

        /// <inheritdoc />
        public IConverterApi Converter { get; }

        /// <inheritdoc />
        public ICurrencyRatesApi CurrencyRates { get; }

        /// <inheritdoc />
        public IGlobalCurrencyRatesApi GlobalCurrencyRates { get; }
    }
}
