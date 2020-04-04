using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.CurrencyConvertor.Domain.Exceptions;
using Lykke.Service.CurrencyConvertor.Domain.Models;
using Lykke.Service.CurrencyConvertor.Domain.Repositories;
using Lykke.Service.CurrencyConvertor.Domain.Services;

namespace Lykke.Service.CurrencyConvertor.DomainServices
{
    // ReSharper disable once InconsistentNaming
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;

        public CurrencyRateService(ICurrencyRateRepository currencyRateRepository)
        {
            _currencyRateRepository = currencyRateRepository;
        }

        public Task<IReadOnlyList<CurrencyRate>> GetAllAsync()
        {
            return _currencyRateRepository.GetAllAsync();
        }

        public Task<CurrencyRate> GetByIdAsync(string baseAsset, string quoteAsset)
        {
            return _currencyRateRepository.GetByIdAsync(baseAsset, quoteAsset);
        }

        public async Task CreateAsync(string baseAsset, string quoteAsset, decimal rate)
        {
            var currencyRate = await _currencyRateRepository.GetByIdAsync(baseAsset, quoteAsset);

            if (currencyRate != null)
                throw new EntityAlreadyExistsException();

            await _currencyRateRepository.InsertAsync(new CurrencyRate
            {
                BaseAsset = baseAsset, QuoteAsset = quoteAsset, Rate = rate
            });
        }

        public async Task UpdateAsync(string baseAsset, string quoteAsset, decimal rate)
        {
            var currencyRate = await _currencyRateRepository.GetByIdAsync(baseAsset, quoteAsset);

            if (currencyRate == null)
                throw new EntityNotFoundException();

            await _currencyRateRepository.UpdateAsync(new CurrencyRate
            {
                BaseAsset = baseAsset, QuoteAsset = quoteAsset, Rate = rate
            });
        }

        public Task DeleteAsync(string fromAsset, string toAsset)
        {
            return _currencyRateRepository.DeleteAsync(fromAsset, toAsset);
        }
    }
}
