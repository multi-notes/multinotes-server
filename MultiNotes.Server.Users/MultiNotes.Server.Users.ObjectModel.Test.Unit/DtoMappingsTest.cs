using AutoMapper;
using MultiNotes.Server.Users.ObjectModel.Dto;
using Xunit;

namespace MultiNotes.Server.Users.ObjectModel.Test.Unit
{
    public class DtoMappingsTest
    {
        [Fact]
        public void AllMappingsAreCorrect()
        {
            var expression = MappingConfig.GetMappingExpression();
            var config = new MapperConfiguration(expression);

            config.AssertConfigurationIsValid();
        }
    }
}
