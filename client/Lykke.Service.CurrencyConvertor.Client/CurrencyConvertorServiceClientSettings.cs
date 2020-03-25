using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.CurrencyConvertor.Client 
{
    /// <summary>
    /// CurrencyConvertor client settings.
    /// </summary>
    public class CurrencyConvertorServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
