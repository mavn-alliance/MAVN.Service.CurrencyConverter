using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.CurrencyConverter.Domain.Models;

namespace MAVN.Service.CurrencyConverter.Domain.Repositories
{
    public interface ICurrencyRateRepository
    {
        Task<IReadOnlyList<CurrencyRate>> GetAllAsync();

        Task<CurrencyRate> GetByIdAsync(string baseAsset, string quoteAsset);

        Task InsertAsync(CurrencyRate currencyRate);

        Task UpdateAsync(CurrencyRate currencyRate);

        Task DeleteAsync(string baseAsset, string quoteAsset);
    }
}
