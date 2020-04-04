using AutoMapper;
using Lykke.Service.CurrencyConvertor.Domain.Models;
using Lykke.Service.CurrencyConvertor.MsSqlRepositories.Entities;

namespace Lykke.Service.CurrencyConvertor.MsSqlRepositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CurrencyRate, CurrencyRateEntity>(MemberList.Source);
            CreateMap<CurrencyRateEntity, CurrencyRate>(MemberList.Destination);

            CreateMap<GlobalCurrencyRateEntity, GlobalCurrencyRate>(MemberList.Destination)
                .ForSourceMember(src => src.Id, opt => opt.DoNotValidate());

            CreateMap<GlobalCurrencyRate, GlobalCurrencyRateEntity>(MemberList.Source)
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.Rate, opt => opt.DoNotValidate());
        }
    }
}
