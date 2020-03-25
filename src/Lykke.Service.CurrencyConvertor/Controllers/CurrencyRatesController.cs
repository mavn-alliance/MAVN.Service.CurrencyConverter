using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.CurrencyConvertor.Client.Api;
using Lykke.Service.CurrencyConvertor.Client.Models.Enums;
using Lykke.Service.CurrencyConvertor.Client.Models.Requests;
using Lykke.Service.CurrencyConvertor.Client.Models.Responses;
using Lykke.Service.CurrencyConvertor.Domain.Exceptions;
using Lykke.Service.CurrencyConvertor.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.CurrencyConvertor.Controllers
{
    [ApiController]
    [Route("api/currencyRates")]
    // ReSharper disable once InconsistentNaming
    public class CurrencyRatesController : ControllerBase, ICurrencyRatesApi
    {
        private readonly ICurrencyRateService _currencyRateService;
        private readonly IMapper _mapper;

        public CurrencyRatesController(
            ICurrencyRateService currencyRateService,
            IMapper mapper)
        {
            _currencyRateService = currencyRateService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all currency rates.
        /// </summary>
        /// <returns>
        /// 200 - A collection of currency rates.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<CurrencyRateModel>), (int) HttpStatusCode.OK)]
        public async Task<IReadOnlyList<CurrencyRateModel>> GetAllAsync()
        {
            var currencyRates = await _currencyRateService.GetAllAsync();

            return _mapper.Map<List<CurrencyRateModel>>(currencyRates);
        }

        /// <summary>
        /// Creates new currency rate.
        /// </summary>
        /// <param name="request">The currency rate request.</param>
        /// <remarks>
        /// Error codes:
        /// - **RateAlreadyExists**
        /// </remarks>
        /// <returns>
        /// 200 - The currency rate operation result.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(CurrencyRateResponse), (int) HttpStatusCode.OK)]
        public async Task<CurrencyRateResponse> CreateAsync([FromBody] CurrencyRateRequest request)
        {
            try
            {
                await _currencyRateService.CreateAsync(request.BaseAsset, request.QuoteAsset, request.Rate);
            }
            catch (EntityAlreadyExistsException)
            {
                return new CurrencyRateResponse {ErrorCode = RateErrorCode.RateAlreadyExists};
            }

            return new CurrencyRateResponse
            {
                BaseAsset = request.BaseAsset,
                QuoteAsset = request.QuoteAsset,
                Rate = request.Rate,
                ErrorCode = RateErrorCode.None
            };
        }

        /// <summary>
        /// Updates currency rate.
        /// </summary>
        /// <param name="request">The currency rate request.</param>
        /// <remarks>
        /// Error codes:
        /// - **RateDoesNotExist**
        /// </remarks>
        /// <returns>
        /// 200 - The currency rate operation result.
        /// </returns>
        [HttpPut]
        [ProducesResponseType(typeof(CurrencyRateResponse), (int) HttpStatusCode.OK)]
        public async Task<CurrencyRateResponse> UpdateAsync([FromBody] CurrencyRateRequest request)
        {
            try
            {
                await _currencyRateService.UpdateAsync(request.BaseAsset, request.QuoteAsset, request.Rate);
            }
            catch (EntityNotFoundException)
            {
                return new CurrencyRateResponse {ErrorCode = RateErrorCode.RateDoesNotExist};
            }

            return new CurrencyRateResponse
            {
                BaseAsset = request.BaseAsset,
                QuoteAsset = request.QuoteAsset,
                Rate = request.Rate,
                ErrorCode = RateErrorCode.None
            };
        }

        /// <summary>
        /// Deletes currency rate by base and quote asset names.
        /// </summary>
        /// <param name="fromAsset">The asset name of the currency that should be converted from.</param>
        /// <param name="toAsset">The asset name of the currency that should be converted to.</param>
        [HttpDelete]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public Task DeleteAsync(string fromAsset, string toAsset)
        {
            return _currencyRateService.DeleteAsync(fromAsset, toAsset);
        }
    }
}
