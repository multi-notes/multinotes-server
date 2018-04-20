using System;
using Autofac;
using AutoMapper;
using MultiNotes.Server.Users.Config;
using MultiNotes.Server.Users.DataAccess.MongoDB.Config;

namespace MultiNotes.Server.Users
{
    class Program
    {
        private static IContainer Container { get; set; }
        private static IMapper Mapper { get; set; }

        static void Main(string[] args)
        {
            Mapper = AutoMapperConfig.ConfigureMapper();
            Container = AutofacConfig.ConfigureContainer(Mapper);
            MongoDbConfig.Configure("test", "MultiNotes");

            throw new NotImplementedException();
        }
    }
}
