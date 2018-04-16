using Autofac;
using AutoMapper;
using MultiNotes.Server.Users.Services;
using MultiNotes.Server.Users.Services.Interfaces;

namespace MultiNotes.Server.Users.Config
{
    internal class AutofacConfig
    {
        public static IContainer ConfigureContainer(IMapper mapper = null)
        {
            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            var container = builder.Build();

            return container;
        }

        private static void RegisterTypes(ContainerBuilder builder, IMapper mapper = null)
        {
            //todo: register daos

            if (mapper != null)
                builder.RegisterInstance(mapper)
                    .ExternallyOwned();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerDependency();

            builder.RegisterType<PasswordService>()
                .As<IPasswordService>()
                .SingleInstance();
        }
    }
}
