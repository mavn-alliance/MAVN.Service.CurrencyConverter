using System.Threading.Tasks;
using Lykke.Service.CurrencyConvertor.Domain.Models;

namespace Lykke.Service.CurrencyConvertor.Domain.Services
{
    public interface IGlobalCurrencyRateService
    {
        /// <summary>
        /// Returns Token/BaseCurrency rate 
        /// </summary>
        /// <returns></returns>
        Task<GlobalCurrencyRate> GetAsync();

        Task UpdateAsync(GlobalCurrencyRate globalCurrencyRate);
    }
}
