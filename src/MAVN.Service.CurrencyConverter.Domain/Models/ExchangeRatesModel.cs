using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MAVN.Service.CurrencyConverter.Domain.Models
{
    public class ExchangeRatesModel
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
