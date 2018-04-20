using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MultiNotes.Server.Users.DataAccess.MongoDB.Config;
using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.MongoDB
{
    internal class CollectionsManager
    {
        public const string UserCollectionName = "Users";

        public static IMongoCollection<User> GetUserCollection()
        {
            return MongoDbConfig.Database.GetCollection<User>(UserCollectionName);
        }        
    }
}
