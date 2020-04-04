using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace MAVN.Service.CurrencyConverter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public CurrencyConvertorSettings CurrencyConvertorService { get; set; }
    }
}
