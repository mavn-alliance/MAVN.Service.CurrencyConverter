using JetBrains.Annotations;

namespace Lykke.Service.CurrencyConvertor.Client.Models.Enums
{
    /// <summary>
    /// Specifies currency rate error codes.
    /// </summary>
    [PublicAPI]
    public enum RateErrorCode
    {
        /// <summary>
        /// Unspecified error.
        /// </summary>
        None,

        /// <summary>
        /// Indicates that the currency rate already exists.
        /// </summary>
        RateAlreadyExists,

        /// <summary>
        /// Indicates that the currency rate does not exist.
        /// </summary>
        RateDoesNotExist
    }
}
