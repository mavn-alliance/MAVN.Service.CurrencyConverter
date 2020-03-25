using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Common.MsSql;
using Lykke.Service.CurrencyConvertor.Domain.Models;
using Lykke.Service.CurrencyConvertor.Domain.Repositories;
using Lykke.Service.CurrencyConvertor.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lykke.Service.CurrencyConvertor.MsSqlRepositories.Repositories
{
    // ReSharper disable once InconsistentNaming
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly MsSqlContextFactory<CurrencyContext> _contextFactory;
        private readonly IMapper _mapper;

        public CurrencyRateRepository(MsSqlContextFactory<CurrencyContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CurrencyRate>> GetAllAsync()
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entities = await context.CurrencyRates.ToListAsync();

                return _mapper.Map<List<CurrencyRate>>(entities);
            }
        }

        public async Task<CurrencyRate> GetByIdAsync(string baseAsset, string quoteAsset)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.CurrencyRates
                    .FirstOrDefaultAsync(o => o.BaseAsset == baseAsset && o.QuoteAsset == quoteAsset);

                return _mapper.Map<CurrencyRate>(entity);
            }
        }

        public async Task InsertAsync(CurrencyRate currencyRate)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = _mapper.Map<CurrencyRateEntity>(currencyRate);

                context.CurrencyRates.Add(entity);

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(CurrencyRate currencyRate)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.CurrencyRates
                    .FirstOrDefaultAsync(o => o.BaseAsset == currencyRate.BaseAsset &&
                                              o.QuoteAsset == currencyRate.QuoteAsset);

                if (entity == null)
                    return;

                entity.Rate = currencyRate.Rate;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string baseAsset, string quoteAsset)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.CurrencyRates
                    .FirstOrDefaultAsync(o => o.BaseAsset == baseAsset && o.QuoteAsset == quoteAsset);

                if (entity == null)
                    return;
                
                context.CurrencyRates.Remove(entity);

                await context.SaveChangesAsync();
            }
        }
    }
}
