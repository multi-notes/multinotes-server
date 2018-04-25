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
            _userCollection = CollectionsManager.GetUserCollection();
        }

        public bool CheckIfEmailAvailable(string emailAddress)
        {
            var user = _userCollection
                .FindSync(x => x.Email.Equals(emailAddress))
                .FirstOrDefault();
            return user == null;
        }

        public User GetUserById(Guid id)
        {
            return _userCollection
                .FindSync(x => x.Id.Equals(id))
                .SingleOrDefault();
        }
    }
}
