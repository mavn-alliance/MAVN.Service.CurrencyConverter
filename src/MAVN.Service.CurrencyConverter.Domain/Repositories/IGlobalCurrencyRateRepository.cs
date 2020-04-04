using System.Threading.Tasks;
using MAVN.Service.CurrencyConverter.Domain.Models;

namespace MAVN.Service.CurrencyConverter.Domain.Repositories
{
    public interface IGlobalCurrencyRateRepository
    {
        Task<GlobalCurrencyRate> GetAsync();

        Task InsertOrUpdateAsync(GlobalCurrencyRate globalCurrencyRate);
    }
}
