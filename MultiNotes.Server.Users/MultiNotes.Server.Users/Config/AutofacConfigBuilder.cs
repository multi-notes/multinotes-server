using Autofac;
using AutoMapper;
using MongoDB.Driver;
using MultiNotes.Server.Users.Services;
using MultiNotes.Server.Users.Services.Interfaces;

namespace MultiNotes.Server.Users.Config
{
    internal class AutofacConfigBuilder
    {
        private readonly ContainerBuilder _builder;
        private static AutofacConfigBuilder _instance;

        private AutofacConfigBuilder()
        {
            _builder = new ContainerBuilder();
        }

        public static AutofacConfigBuilder StartBuilding()
        {
            return _instance ?? (_instance = new AutofacConfigBuilder());
        }

        public void RegisterMapperInstance(IMapper mapperInstance)
        {
            if (mapperInstance != null)
                _builder.RegisterInstance(mapperInstance)
                    .ExternallyOwned();
        }

        public void RegisterDbInstance(IMongoDatabase dbInstance)
        {
            if (dbInstance != null)
                _builder.RegisterInstance(dbInstance)
                    .ExternallyOwned();
        }

        public void RegisterTypes()
        {
            //todo: register daos

            _builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerDependency();

            _builder.RegisterType<PasswordService>()
                .As<IPasswordService>()
                .SingleInstance();
        }

        public IContainer FinishBuilding()
        {
            var container = _builder.Build();
            return container;
        }
    }
}
