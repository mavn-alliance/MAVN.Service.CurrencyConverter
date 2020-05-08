using System.Threading.Tasks;
using MAVN.Numerics;
using MAVN.Service.CurrencyConverter.Domain.Exceptions;
using MAVN.Service.CurrencyConverter.Domain.Services;
using MAVN.Service.CurrencyConvertor.Client.Api;
using MAVN.Service.CurrencyConvertor.Client.Models.Enums;
using MAVN.Service.CurrencyConvertor.Client.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.CurrencyConverter.Controllers
{
    [ApiController]
    [Route("api/converter")]
    public class ConverterController : ControllerBase, IConverterApi
    {
        private readonly IConverterService _converterService;

        public ConverterController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        /// <summary>
        /// Converts amount from <paramref name="fromAsset"/> to <paramref name="toAsset"/>.
        /// </summary>
        /// <param name="fromAsset">The asset name of the currency that should be converted from.</param>
        /// <param name="toAsset">The asset name of the currency that should be converted to.</param>
        /// <param name="amount">The amount to be converted.</param>
        /// <remarks>
        /// Error codes:
        /// - **NoRate**
        /// </remarks>
        /// <returns>
        /// 200 - The result of convert.
        /// </returns>
        [HttpGet]
        public async Task<ConverterResponse> ConvertAsync(string fromAsset, string toAsset, decimal amount)
        {
            try
            {
                var result = await _converterService.ConvertAsync(fromAsset, toAsset, amount);

                return new ConverterResponse {Amount = result, ErrorCode = ConverterErrorCode.None};
            }
            catch (EntityNotFoundException)
            {
                return new ConverterResponse {ErrorCode = ConverterErrorCode.NoRate};
            }
        }

        /// <summary>
        /// Converts tokens to BaseCurrency using global currency rate.
        /// </summary>
        /// <param name="amount">The amount to be converted.</param>
        /// <returns>The result of convert.</returns>
        [HttpGet("tokens/baseCurrency")]
        public async Task<ConverterResponse> ConvertTokensToBaseCurrencyAsync(Money18 amount)
        {
            var result = await _converterService.ConvertTokensToBaseCurrencyAsync(amount);

            return new ConverterResponse { Amount = result, ErrorCode = ConverterErrorCode.None };
        }
    }
}
