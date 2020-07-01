using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MAVN.Persistence.PostgreSQL.Legacy;
using MAVN.Service.CurrencyConverter.Domain.Models;
using MAVN.Service.CurrencyConverter.Domain.Repositories;
using MAVN.Service.CurrencyConverter.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.CurrencyConverter.MsSqlRepositories.Repositories
{
    // ReSharper disable once InconsistentNaming
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly PostgreSQLContextFactory<CurrencyContext> _contextFactory;
        private readonly IMapper _mapper;

        public CurrencyRateRepository(PostgreSQLContextFactory<CurrencyContext> contextFactory, IMapper mapper)
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
