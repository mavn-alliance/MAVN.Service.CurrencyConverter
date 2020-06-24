using Autofac;
using JetBrains.Annotations;
using Lykke.SettingsReader;
using MAVN.Service.CurrencyConverter.Domain.Services;
using MAVN.Service.CurrencyConverter.Settings;
using Refit;

namespace MAVN.Service.CurrencyConverter
{
    [UsedImplicitly]
    public class AutofacModule : Module
    {
        private readonly AppSettings _appSettings;

        public AutofacModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings.CurrentValue;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DomainServices.AutofacModule());

            builder.RegisterModule(
                new MsSqlRepositories.AutofacModule(_appSettings.CurrencyConvertorService.Db.DataConnString));

            builder.RegisterInstance(RestService.For<IExchangeRatesApi>(_appSettings.CurrencyConvertorService.ExchangeRatesApiUrl))
                .SingleInstance();

            builder.RegisterInstance(RestService.For<IRatesApi>(_appSettings.CurrencyConvertorService.RatesApiUrl))
                .SingleInstance();
        }
    }
}
