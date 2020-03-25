using System.Threading.Tasks;
using Falcon.Numerics;

namespace Lykke.Service.CurrencyConvertor.Domain.Services
{
    public interface IConverterService
    {
        Task<decimal> ConvertAsync(string fromAsset, string toAsset, decimal amount);

        Task<decimal> ConvertTokensToBaseCurrencyAsync(Money18 amount);
    }
}
