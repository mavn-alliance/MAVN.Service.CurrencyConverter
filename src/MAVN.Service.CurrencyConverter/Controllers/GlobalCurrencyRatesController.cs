using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MAVN.Service.CurrencyConverter.Domain.Models;
using MAVN.Service.CurrencyConverter.Domain.Services;
using MAVN.Service.CurrencyConvertor.Client.Api;
using MAVN.Service.CurrencyConvertor.Client.Models.Requests;
using MAVN.Service.CurrencyConvertor.Client.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.CurrencyConverter.Controllers
{
    [ApiController]
    [Route("api/globalCurrencyRates")]
    public class GlobalCurrencyRatesController : ControllerBase, IGlobalCurrencyRatesApi
    {
        private readonly IGlobalCurrencyRateService _globalCurrencyRateService;
        private readonly IMapper _mapper;

        public GlobalCurrencyRatesController(
            IGlobalCurrencyRateService globalCurrencyRateService,
            IMapper mapper)
        {
            _globalCurrencyRateService = globalCurrencyRateService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns global currency rate.
        /// </summary>
        /// <returns>
        /// 200 - A global currency rate..
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(GlobalCurrencyRateModel), (int) HttpStatusCode.OK)]
        public async Task<GlobalCurrencyRateModel> GetAsync()
        {
            var globalCurrencyRate = await _globalCurrencyRateService.GetAsync();

            return _mapper.Map<GlobalCurrencyRateModel>(globalCurrencyRate);
        }

        /// <summary>
        /// Updates global currency rate.
        /// </summary>
        /// <param name="request">The global currency rate request.</param>
        [HttpPut]
        [ProducesResponseType(typeof(CurrencyRateResponse), (int) HttpStatusCode.OK)]
        public Task UpdateAsync([FromBody] GlobalCurrencyRateRequest request)
        {
            var globalCurrencyRate = _mapper.Map<GlobalCurrencyRate>(request);

            return _globalCurrencyRateService.UpdateAsync(globalCurrencyRate);
        }
    }
}
