using FluentValidation;
using JetBrains.Annotations;
using Lykke.Service.CurrencyConvertor.Client.Models.Requests;

namespace Lykke.Service.CurrencyConvertor.Validations
{
    [UsedImplicitly]
    public class GlobalCurrencyRateRequestValidator : AbstractValidator<GlobalCurrencyRateRequest>
    {
        public GlobalCurrencyRateRequestValidator()
        {
            RuleFor(o => o.AmountInTokens)
                .GreaterThan(0)
                .WithMessage("Amount in tokens should be greater than 0.");

            RuleFor(o => o.AmountInCurrency)
                .GreaterThan(0)
                .WithMessage("Amount in currency should be greater than 0.");
        }
    }
}
