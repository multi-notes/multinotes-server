using System;
using MongoDB.Driver;

namespace MultiNotes.Server.Users.DataAccess.MongoDB
{
    public class DbConfig
    {
        public IMongoDatabase GetDatabase(string connectionString, string dbName)
        {
            var client = GetClient(connectionString);
            var db = client.GetDatabase(dbName);

            if(db==null)
                throw new NullReferenceException("DB instance is null!");

            return db;
        }


        //todo: change to singleton? or something better?
        private static IMongoClient GetClient(string connectionString)
        {
            return new MongoClient(connectionString);
        }
    }
}
