using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.MongoDB.Config
{
    public static class MongoDbConfig
    {
        private static IMongoDatabase _db;

        public static IMongoDatabase Database
        {
            get
            {
                if (_db == null)
                    throw new NullReferenceException("DB has not been configured yet!");
                return _db;
            }
        }       

        public static void Configure(string connectionString, string dbName)
        {
            ConfigureDatabase(connectionString, dbName);
            CreateMappings();
            CreateIndexes();
        }

        private static void ConfigureDatabase(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            _db = db ?? throw new NullReferenceException("DB instance is null!");
        }

        private static void CreateMappings()
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(x => new User(x.Username, x.Email, x.PasswordHash));
                cm.MapIdMember(x => x.Id)
                    .SetIdGenerator(CombGuidGenerator.Instance);
                cm.MapMember(x => x.RegistrationDateTime)
                    .SetSerializer(new DateTimeSerializer(DateTimeKind.Local));
            });
        }

        private static void CreateIndexes()
        {
            var userCollection = CollectionsManager.GetUserCollection();
            var uniqueIndexOptions = new CreateIndexOptions() { Unique = true };
            userCollection.Indexes.CreateOneAsync(Builders<User>.IndexKeys.Ascending(x => x.Email), uniqueIndexOptions);
        }
    }
}
