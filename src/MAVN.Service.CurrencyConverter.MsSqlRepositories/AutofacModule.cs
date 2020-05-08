using Autofac;
using MAVN.Common.MsSql;
using MAVN.Service.CurrencyConverter.Domain.Repositories;
using MAVN.Service.CurrencyConverter.MsSqlRepositories.Repositories;

namespace MAVN.Service.CurrencyConverter.MsSqlRepositories
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
