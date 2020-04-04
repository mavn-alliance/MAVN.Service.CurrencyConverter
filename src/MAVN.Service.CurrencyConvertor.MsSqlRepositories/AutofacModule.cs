using Autofac;
using Lykke.Common.MsSql;
using Lykke.Service.CurrencyConvertor.Domain.Repositories;
using Lykke.Service.CurrencyConvertor.MsSqlRepositories.Repositories;

namespace Lykke.Service.CurrencyConvertor.MsSqlRepositories
{
    public class AutofacModule : Module
    {
        private readonly string _connectionString;

        public AutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMsSql(
                _connectionString,
                connString => new CurrencyContext(connString, false),
                dbConn => new CurrencyContext(dbConn));

            builder.RegisterType<CurrencyRateRepository>()
                .As<ICurrencyRateRepository>()
                .SingleInstance();

            builder.RegisterType<GlobalCurrencyRateRepository>()
                .As<IGlobalCurrencyRateRepository>()
                .SingleInstance();
        }
    }
}
