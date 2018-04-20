using System;
using MongoDB.Driver;
using MultiNotes.Server.Users.DataAccess.Interfaces;
using MultiNotes.Server.Users.DataAccess.MongoDB.Mappings;
using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.MongoDB
{
    public class UserCommand : IUserCommand
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<UserMapping> _userCollection; //todo: check if type is ok here

        public UserCommand(IMongoDatabase database)
        {
            _database = database;
            _userCollection = _database.GetCollection<UserMapping>(UserMapping.UserCollectionName);
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
