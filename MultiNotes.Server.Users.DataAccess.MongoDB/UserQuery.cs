using System;
using MongoDB.Driver;
using MultiNotes.Server.Users.DataAccess.Interfaces;
using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.MongoDB
{
    public class UserQuery : IUserQuery
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserQuery()
        {
            _userCollection = CollectionsManager.GetUserCollection(); //todo: try to get rid of this static class
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
