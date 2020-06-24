using System;
using System.Threading.Tasks;
using MAVN.Numerics;
using MAVN.Service.CurrencyConverter.Domain.Models;
using MAVN.Service.CurrencyConverter.Domain.Services;

namespace MAVN.Service.CurrencyConverter.DomainServices
{
    public class ConverterService : IConverterService
    {
        private readonly IExchangeRatesApi _exchangeRatesApi;
        private readonly IRatesApi _ratesApi;
        private readonly IGlobalCurrencyRateService _globalCurrencyRateService;

        public ConverterService(
            IExchangeRatesApi exchangeRatesApi,
            IRatesApi ratesApi,
            IGlobalCurrencyRateService globalCurrencyRateService)
        {
            _exchangeRatesApi = exchangeRatesApi;
            _ratesApi = ratesApi;
            _globalCurrencyRateService = globalCurrencyRateService;
        }

        public async Task<decimal> ConvertAsync(string fromAsset, string toAsset, decimal amount)
        {
            if (fromAsset == toAsset)
                return amount;

            var ratesResponse = await GetExchangeRates(fromAsset, toAsset);

            return amount / (decimal)ratesResponse.Rates[fromAsset];
        }

        public async Task<decimal> ConvertTokensToBaseCurrencyAsync(Money18 amount)
        {
            var globalCurrencyRate = await _globalCurrencyRateService.GetAsync();

            if (globalCurrencyRate.Rate.Equals(0))
                throw new InvalidOperationException("Base currency rate is 0, can't convert to tokens.");

            return (decimal)(amount * (1 / globalCurrencyRate.Rate));
        }

        private async Task<ExchangeRatesModel> GetExchangeRates(string fromAsset, string toAsset)
        {
            ExchangeRatesModel ratesResponse;
            try
            {
                ratesResponse = await _exchangeRatesApi.GetLatestExchangeRate(new[] { fromAsset }, toAsset);
            }
            catch (Exception)
            {
                // Use another API as fallback option
                ratesResponse = await _ratesApi.GetLatestExchangeRate(new[] { fromAsset }, toAsset);
            }

            return ratesResponse;
        }
    }
}
