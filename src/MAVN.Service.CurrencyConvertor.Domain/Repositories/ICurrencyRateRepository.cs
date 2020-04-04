using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.CurrencyConvertor.Domain.Models;

namespace Lykke.Service.CurrencyConvertor.Domain.Repositories
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
