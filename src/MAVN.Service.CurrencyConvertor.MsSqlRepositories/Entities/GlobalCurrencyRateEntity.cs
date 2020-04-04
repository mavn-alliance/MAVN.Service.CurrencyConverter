using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Falcon.Numerics;

namespace Lykke.Service.CurrencyConvertor.MsSqlRepositories.Entities
{
    [Table("global_currency_rates")]
    public class GlobalCurrencyRateEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("amount_in_tokens", TypeName = "nvarchar(64)")]
        public Money18 AmountInTokens { get; set; }

        [Column("amount_in_currency")]
        public decimal AmountInCurrency { get; set; }
    }
}
