using AutoMapper;
using AutoMapper.Configuration;

namespace MultiNotes.Server.Users.ObjectModel.Dto
{
    public static class MappingConfig
    {
        public static MapperConfigurationExpression GetMappingExpression()
        {
            var cfgExp = new MapperConfigurationExpression();

            cfgExp.AddProfile<UsersObjectModelToDto>();
            cfgExp.AddProfile<UsersDtoToObjectModel>();

            return cfgExp;
        }

        public class UsersObjectModelToDto : Profile
        {
            public UsersObjectModelToDto()
            {
                /*AddConditionalObjectMapper()
                    .Where((s, d) => s.Name == d.Name + "Dto");*/

                CreateMap<User, UserDto>();
            }
        }

        public class UsersDtoToObjectModel : Profile
        {
            public UsersDtoToObjectModel()
            {
                CreateMap<UserDto, User>();
            }
        }
    }
}
