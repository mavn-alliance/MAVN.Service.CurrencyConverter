using AutoMapper;
using MAVN.Service.CurrencyConverter.Domain.Models;
using MAVN.Service.CurrencyConverter.MsSqlRepositories.Entities;

namespace MAVN.Service.CurrencyConverter.MsSqlRepositories
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
