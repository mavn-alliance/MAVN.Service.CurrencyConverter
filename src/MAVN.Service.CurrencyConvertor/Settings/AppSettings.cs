using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.CurrencyConvertor.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public CurrencyConvertorSettings CurrencyConvertorService { get; set; }
    }
}
