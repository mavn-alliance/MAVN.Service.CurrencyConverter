using System.Threading.Tasks;
using Lykke.Service.CurrencyConvertor.Domain.Models;

namespace Lykke.Service.CurrencyConvertor.Domain.Repositories
{
    public interface IGlobalCurrencyRateRepository
    {
        Task<GlobalCurrencyRate> GetAsync();

        Task InsertOrUpdateAsync(GlobalCurrencyRate globalCurrencyRate);
    }
}
