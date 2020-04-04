using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.CurrencyConverter.Domain.Models;

namespace MAVN.Service.CurrencyConverter.Domain.Services
{
    public interface ICurrencyRateService
    {
        Task<IReadOnlyList<CurrencyRate>> GetAllAsync();

        Task<CurrencyRate> GetByIdAsync(string baseAsset, string quoteAsset);

        Task CreateAsync(string baseAsset, string quoteAsset, decimal rate);

        Task UpdateAsync(string baseAsset, string quoteAsset, decimal rate);

        Task DeleteAsync(string fromAsset, string toAsset);
    }
}
