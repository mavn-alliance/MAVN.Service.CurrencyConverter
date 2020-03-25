using AutoMapper;
using Lykke.Service.CurrencyConvertor.Client.Models.Requests;
using Lykke.Service.CurrencyConvertor.Client.Models.Responses;
using Lykke.Service.CurrencyConvertor.Domain.Models;

namespace Lykke.Service.CurrencyConvertor
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
