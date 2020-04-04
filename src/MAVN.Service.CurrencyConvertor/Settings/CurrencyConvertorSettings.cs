using JetBrains.Annotations;

namespace Lykke.Service.CurrencyConvertor.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CurrencyConvertorSettings
    {
        public DbSettings Db { get; set; }
    }
}
