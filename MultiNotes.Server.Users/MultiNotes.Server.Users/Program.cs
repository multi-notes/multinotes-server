using System;
using Autofac;
using AutoMapper;
using MongoDB.Driver;
using MultiNotes.Server.Users.Config;
using MultiNotes.Server.Users.DataAccess.MongoDB.Config;

namespace MultiNotes.Server.Users
{
    class Program
    {
        private static IMapper Mapper { get; set; }
        private static IMongoDatabase Database { get; set; }
        private static IContainer Container { get; set; }

        private static void Initialize()
        {
            Mapper = AutoMapperConfig.ConfigureMapper();
            Database = MongoDbConfig.Configure("mongodb://localhost:27017", "MultiNotes");

            var autofacBuilder = AutofacConfigBuilder.StartBuilding();
            autofacBuilder.RegisterMapperInstance(Mapper);
            autofacBuilder.RegisterDbInstance(Database);
            Container = autofacBuilder.FinishBuilding();
        }

        static void Main(string[] args)
        {
            Initialize();

            throw new NotImplementedException();
        }
    }
}
