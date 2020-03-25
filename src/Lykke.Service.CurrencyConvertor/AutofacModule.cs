using Autofac;
using JetBrains.Annotations;
using Lykke.Service.CurrencyConvertor.DomainServices;
using Lykke.Service.CurrencyConvertor.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.CurrencyConvertor
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
        }
    }
}
