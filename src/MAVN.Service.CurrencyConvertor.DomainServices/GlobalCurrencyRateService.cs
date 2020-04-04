using System.Threading;
using System.Threading.Tasks;
using Lykke.Service.CurrencyConvertor.Domain.Models;
using Lykke.Service.CurrencyConvertor.Domain.Repositories;
using Lykke.Service.CurrencyConvertor.Domain.Services;

namespace Lykke.Service.CurrencyConvertor.DomainServices
{
    public class GlobalCurrencyRateService : IGlobalCurrencyRateService
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private readonly IGlobalCurrencyRateRepository _globalCurrencyRateRepository;

        private GlobalCurrencyRate _globalCurrencyRate;

        public GlobalCurrencyRateService(IGlobalCurrencyRateRepository globalCurrencyRateRepository)
        {
            _globalCurrencyRateRepository = globalCurrencyRateRepository;
        }

        public async Task<GlobalCurrencyRate> GetAsync()
        {
            if (_globalCurrencyRate != null)
                return _globalCurrencyRate;

            await _semaphore.WaitAsync();

            try
            {
                if (_globalCurrencyRate == null)
                {
                    _globalCurrencyRate = await _globalCurrencyRateRepository.GetAsync();

                    if (_globalCurrencyRate == null)
                        _globalCurrencyRate = new GlobalCurrencyRate {AmountInTokens = 1, AmountInCurrency = 1};
                }
            }
            finally
            {
                _semaphore.Release();
            }

            return _globalCurrencyRate;
        }

        public async Task UpdateAsync(GlobalCurrencyRate globalCurrencyRate)
        {
            await _semaphore.WaitAsync();

            try
            {
                await _globalCurrencyRateRepository.InsertOrUpdateAsync(globalCurrencyRate);

                _globalCurrencyRate = globalCurrencyRate;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
