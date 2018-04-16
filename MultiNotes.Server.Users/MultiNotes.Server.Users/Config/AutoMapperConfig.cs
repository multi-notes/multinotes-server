using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace MultiNotes.Server.Users.Config
{
    static class AutoMapperConfig
    {
        public static IMapper ConfigureMapper()
        {
            var mappingExpression = Users.ObjectModel.Dto.MappingConfig.GetMappingExpression();

            var mapperConfig = new MapperConfiguration(mappingExpression);
            var mapper = mapperConfig.CreateMapper();

            return mapper;
        }
    }
}
