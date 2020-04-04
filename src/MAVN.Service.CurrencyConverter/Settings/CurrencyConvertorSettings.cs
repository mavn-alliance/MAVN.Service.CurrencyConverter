using JetBrains.Annotations;

namespace MAVN.Service.CurrencyConverter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CurrencyConvertorSettings
    {
        public DbSettings Db { get; set; }
    }
}
