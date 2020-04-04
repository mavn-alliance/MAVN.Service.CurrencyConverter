using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAVN.Service.CurrencyConverter.MsSqlRepositories.Entities
{
    [Table("currency_rates")]
    // ReSharper disable once InconsistentNaming
    public class CurrencyRateEntity
    {
        [Required]
        [Column("base_asset")]
        public string BaseAsset { get; set; }

        [Required]
        [Column("quote_asset")]
        public string QuoteAsset { get; set; }

        [Column("rate")]
        public decimal Rate { get; set; }
    }
}
