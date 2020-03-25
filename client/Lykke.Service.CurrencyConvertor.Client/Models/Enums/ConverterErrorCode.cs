using JetBrains.Annotations;

namespace Lykke.Service.CurrencyConvertor.Client.Models.Enums
{
    /// <summary>
    /// Specifies currency converter error codes.
    /// </summary>
    [PublicAPI]
    public enum ConverterErrorCode
    {
        /// <summary>
        /// Unspecified error.
        /// </summary>
        None,

        /// <summary>
        /// Indicates that the currency rate does not exist.
        /// </summary>
        NoRate
    }
}
