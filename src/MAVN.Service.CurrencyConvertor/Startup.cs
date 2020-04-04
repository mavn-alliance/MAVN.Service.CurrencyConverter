using AutoMapper;
using JetBrains.Annotations;
using Lykke.Sdk;
using Lykke.Service.CurrencyConvertor.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Lykke.Service.CurrencyConvertor
{
    [UsedImplicitly]
    public class Startup
    {
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "CurrencyConvertor API", ApiVersion = "v1"
        };

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
            {
                options.SwaggerOptions = _swaggerOptions;

                options.Logs = logs =>
                {
                    logs.AzureTableName = "CurrencyConvertorLog";
                    logs.AzureTableConnectionStringResolver =
                        settings => settings.CurrencyConvertorService.Db.LogsConnString;
                };

                options.Extend = (serviceCollection, settings) =>
                {
                    serviceCollection.AddAutoMapper(typeof(AutoMapperProfile),
                        typeof(MsSqlRepositories.AutoMapperProfile));
                };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfigurationProvider mapper)
        {
            mapper.AssertConfigurationIsValid();

            app.UseLykkeConfiguration(options => { options.SwaggerOptions = _swaggerOptions; });
        }
    }
}
