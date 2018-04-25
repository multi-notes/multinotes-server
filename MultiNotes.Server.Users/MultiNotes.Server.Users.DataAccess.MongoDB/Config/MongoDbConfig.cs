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

        public static IMongoDatabase Configure(string connectionString, string dbName)
        {
            ConfigureDatabase(connectionString, dbName);
            CreateMappings();
            CreateIndexes();
            return _db;
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
                cm.MapCreator(x => new User(x.Id, x.Username, x.Email, x.PasswordHash, x.RegistrationDateTime));
                cm.MapIdMember(x => x.Id)
                    .SetIdGenerator(CombGuidGenerator.Instance);
                cm.MapMember(x => x.RegistrationDateTime)
                    .SetSerializer(new DateTimeSerializer(DateTimeKind.Local, BsonType.Document));
            });
        }

        private static void CreateIndexes()
        {
            var userCollection = _db.GetCollection<User>(nameof(User));
            var uniqueIndexOptions = new CreateIndexOptions() { Unique = true };
            userCollection.Indexes.CreateOneAsync(Builders<User>.IndexKeys.Ascending(x => x.Email), uniqueIndexOptions);
        }
    }
}
