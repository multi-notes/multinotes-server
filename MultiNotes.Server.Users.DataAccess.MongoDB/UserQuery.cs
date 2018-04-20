using System;
using MongoDB.Driver;
using MultiNotes.Server.Users.DataAccess.Interfaces;
using MultiNotes.Server.Users.DataAccess.MongoDB.Mappings;
using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.MongoDB
{
    public class UserQuery : IUserQuery
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<UserMapping> _userCollection; //todo: check if type is ok here

        public UserQuery(IMongoDatabase database)
        {
            _database = database;
            _userCollection = _database.GetCollection<UserMapping>(UserMapping.UserCollectionName);
        }

        public int GetNextUserId()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfEmailAvailable(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
