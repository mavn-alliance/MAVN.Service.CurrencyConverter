using AutoMapper;
using MAVN.Service.CurrencyConverter;
using Xunit;

namespace MAVN.Service.CurrencyConvertor.Tests
{
    public class AutoMapperProfileTests
    {
        [Fact]
        public void Mapping_Configuration_Is_Correct()
        {
            // arrange

            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfile()); });
            var mapper = mockMapper.CreateMapper();

            // act

            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            // assert

            Assert.True(true);
        }
    } 
}
