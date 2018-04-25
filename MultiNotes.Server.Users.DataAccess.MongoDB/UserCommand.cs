using System;
using MongoDB.Driver;
using MultiNotes.Server.Users.DataAccess.Interfaces;
using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.MongoDB
{
    public class UserCommand : IUserCommand
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserCommand()
        {
            _userCollection = CollectionsManager.GetUserCollection();
        }

        public void AddUser(User user)
        {
            _userCollection.InsertOne(user);
        }

        public void DeleteUser(User user)
        {
            _userCollection.DeleteOne(x => x.Equals(user));
        }

        public void UpdateUser(User user)
        {
            _userCollection.ReplaceOne(x => x.Id.Equals(user.Id), user);
        }
    }
}
