using System;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Common.MsSql;
using Lykke.Service.CurrencyConvertor.Domain.Models;
using Lykke.Service.CurrencyConvertor.Domain.Repositories;
using Lykke.Service.CurrencyConvertor.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lykke.Service.CurrencyConvertor.MsSqlRepositories.Repositories
{
    public class GlobalCurrencyRateRepository : IGlobalCurrencyRateRepository
    {
        private readonly MsSqlContextFactory<CurrencyContext> _contextFactory;
        private readonly IMapper _mapper;

        public GlobalCurrencyRateRepository(MsSqlContextFactory<CurrencyContext> contextFactory, IMapper mapper)
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
