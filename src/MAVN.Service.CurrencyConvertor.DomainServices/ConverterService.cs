using System;
using System.Threading.Tasks;
using Falcon.Numerics;
using Lykke.Service.CurrencyConvertor.Domain.Exceptions;
using Lykke.Service.CurrencyConvertor.Domain.Services;

namespace Lykke.Service.CurrencyConvertor.DomainServices
{
    public class ConverterService : IConverterService
    {
        private readonly ICurrencyRateService _currencyRateService;
        private readonly IGlobalCurrencyRateService _globalCurrencyRateService;

        public ConverterService(
            ICurrencyRateService currencyRateService,
            IGlobalCurrencyRateService globalCurrencyRateService)
        {
            _currencyRateService = currencyRateService;
            _globalCurrencyRateService = globalCurrencyRateService;
        }

        public async Task<decimal> ConvertAsync(string fromAsset, string toAsset, decimal amount)
        {
            if (fromAsset == toAsset)
            {
                return amount;
            }

            var currencyRate = await _currencyRateService.GetByIdAsync(fromAsset, toAsset);

            if (currencyRate == null)
                throw new EntityNotFoundException();

            return amount * currencyRate.Rate;
        }

        public async Task<decimal> ConvertTokensToBaseCurrencyAsync(Money18 amount)
        {
            var globalCurrencyRate = await _globalCurrencyRateService.GetAsync();
            
            if (globalCurrencyRate.Rate.Equals(0))
                throw new InvalidOperationException("Base currency rate is 0, can't convert to tokens.");

            return (decimal) (amount * (1 / globalCurrencyRate.Rate));
        }
    }
}
