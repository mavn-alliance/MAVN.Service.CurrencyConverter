using Autofac;
using JetBrains.Annotations;
using MAVN.Service.CurrencyConverter.Domain.Services;

namespace MAVN.Service.CurrencyConverter.DomainServices
{
    [UsedImplicitly]
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyRateService>()
                .As<ICurrencyRateService>()
                .SingleInstance();

            builder.RegisterType<GlobalCurrencyRateService>()
                .As<IGlobalCurrencyRateService>()
                .SingleInstance();

            builder.RegisterType<ConverterService>()
                .As<IConverterService>()
                .SingleInstance();
        }
    }
}
