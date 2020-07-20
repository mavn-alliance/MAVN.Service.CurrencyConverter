using System;
using System.Threading.Tasks;
using AutoMapper;
using MAVN.Persistence.PostgreSQL.Legacy;
using MAVN.Service.CurrencyConverter.Domain.Models;
using MAVN.Service.CurrencyConverter.Domain.Repositories;
using MAVN.Service.CurrencyConverter.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.CurrencyConverter.MsSqlRepositories.Repositories
{
    public class GlobalCurrencyRateRepository : IGlobalCurrencyRateRepository
    {
        private readonly PostgreSQLContextFactory<CurrencyContext> _contextFactory;
        private readonly IMapper _mapper;

        public GlobalCurrencyRateRepository(PostgreSQLContextFactory<CurrencyContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<GlobalCurrencyRate> GetAsync()
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.GlobalCurrencyRates.FirstOrDefaultAsync();

                return _mapper.Map<GlobalCurrencyRate>(entity);
            }
        }

        public async Task InsertOrUpdateAsync(GlobalCurrencyRate globalCurrencyRate)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.GlobalCurrencyRates.FirstOrDefaultAsync();

                if (entity == null)
                {
                    entity = new GlobalCurrencyRateEntity {Id = Guid.NewGuid()};

                    context.GlobalCurrencyRates.Add(entity);
                }

                _mapper.Map(globalCurrencyRate, entity);

                await context.SaveChangesAsync();
            }
        }
    }
}
