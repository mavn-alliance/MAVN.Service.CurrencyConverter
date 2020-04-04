using AutoMapper;
using MAVN.Service.CurrencyConverter.Domain.Models;
using MAVN.Service.CurrencyConvertor.Client.Models.Requests;
using MAVN.Service.CurrencyConvertor.Client.Models.Responses;

namespace MAVN.Service.CurrencyConverter
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CurrencyRate, CurrencyRateModel>(MemberList.Source);

            CreateMap<GlobalCurrencyRate, GlobalCurrencyRateModel>(MemberList.Source)
                .ForSourceMember(src => src.Rate, opt => opt.DoNotValidate());
            CreateMap<GlobalCurrencyRateRequest, GlobalCurrencyRate>(MemberList.Destination)
                .ForMember(dest => dest.Rate, opt => opt.Ignore());
        }
    }
}
