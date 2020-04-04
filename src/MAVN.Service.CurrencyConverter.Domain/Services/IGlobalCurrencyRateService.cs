using System.Threading.Tasks;
using MAVN.Service.CurrencyConverter.Domain.Models;

namespace MAVN.Service.CurrencyConverter.Domain.Services
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
