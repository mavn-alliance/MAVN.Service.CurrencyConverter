using System;
using System.Threading.Tasks;
using Common;
using MAVN.Numerics;
using MAVN.Service.CurrencyConverter.Domain.Models;
using MAVN.Service.CurrencyConverter.Domain.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace MAVN.Service.CurrencyConverter.DomainServices
{
    public class ConverterService : IConverterService
    {
        private readonly IExchangeRatesApi _exchangeRatesApi;
        private readonly IRatesApi _ratesApi;
        private readonly IDistributedCache _distributedCache;
        private readonly IGlobalCurrencyRateService _globalCurrencyRateService;

        public ConverterService(
            IExchangeRatesApi exchangeRatesApi,
            IRatesApi ratesApi,
            IDistributedCache distributedCache,
            IGlobalCurrencyRateService globalCurrencyRateService)
        {
            _exchangeRatesApi = exchangeRatesApi;
            _ratesApi = ratesApi;
            _distributedCache = distributedCache;
            _globalCurrencyRateService = globalCurrencyRateService;
        }

        public async Task<decimal> ConvertAsync(string fromAsset, string toAsset, decimal amount)
        {
            if (fromAsset == toAsset)
                return amount;

            var rate = await GetExchangeRate(fromAsset, toAsset);

            return amount / rate;
        }

        public async Task<decimal> ConvertTokensToBaseCurrencyAsync(Money18 amount)
        {
            var globalCurrencyRate = await _globalCurrencyRateService.GetAsync();

            if (globalCurrencyRate.Rate.Equals(0))
                throw new InvalidOperationException("Base currency rate is 0, can't convert to tokens.");

            return (decimal)(amount * (1 / globalCurrencyRate.Rate));
        }

        private async Task<decimal> GetExchangeRate(string fromAsset, string toAsset)
        {
            var cached = await GetCachedValue(toAsset);

            if (cached != null)
            {
                var value = cached.DeserializeJson<ExchangeRatesModel>();
                return (decimal)value.Rates[fromAsset];
            }

            ExchangeRatesModel ratesResponse;
            try
            {
                ratesResponse = await _exchangeRatesApi.GetLatestExchangeRates(toAsset);
            }
            catch (Exception)
            {
                // Use another API as fallback option
                ratesResponse = await _ratesApi.GetLatestExchangeRates(toAsset);
            }

            await SetCacheValueAsync(toAsset, ratesResponse);
            return (decimal)ratesResponse.Rates[fromAsset];
        }

        private static string BuildCacheKey(string baseCurrency)
        {
            return $"cc:exchange-rates:{baseCurrency}";
        }

        private async Task SetCacheValueAsync(string baseCurrency, ExchangeRatesModel value)
        {
            await _distributedCache.SetStringAsync(BuildCacheKey(baseCurrency),
                value.ToJson(),
                new DistributedCacheEntryOptions { AbsoluteExpiration = DateTime.UtcNow.Date.AddDays(1) });
        }

        private Task<string> GetCachedValue(string baseCurrency)
        {
            return _distributedCache.GetStringAsync(BuildCacheKey(baseCurrency));
        }
    }
}
