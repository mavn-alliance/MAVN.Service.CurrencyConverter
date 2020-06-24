using JetBrains.Annotations;

namespace MAVN.Service.CurrencyConverter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CurrencyConvertorSettings
    {
        public DbSettings Db { get; set; }
        public DistributedCacheSettings CacheSettings { get; set; }
        public string ExchangeRatesApiUrl { get; set; }
        public string RatesApiUrl { get; set; }
    }
}
