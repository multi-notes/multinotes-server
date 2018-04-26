using MongoDB.Driver;
using MultiNotes.Server.Users.DataAccess.MongoDB.Config;
using MultiNotes.Server.Users.ObjectModel;
using System;
using System.Threading;
using MultiNotes.Server.Users.DataAccess.Interfaces;
using Xunit;

namespace MultiNotes.Server.Users.DataAccess.MongoDB.Test.Integration
{
    public class DatabaseFixture
    {
        private const string TestDatabaseName = "MultiNotes-Test";

        public DatabaseFixture()
        {
            Database = MongoDbConfig.Configure("mongodb://localhost:27017", TestDatabaseName);
        }

        public IMongoDatabase Database { get; }
    }

    public class CommandQueryTests : IClassFixture<DatabaseFixture>, IDisposable
    {
        private readonly DatabaseFixture _dbFixture;     
        private readonly IUserQuery _userQuery;
        private readonly IUserCommand _userCommand;
        private readonly User _exampleUser;

        public CommandQueryTests(DatabaseFixture dbFixture)
        {
            _dbFixture = dbFixture;
            _userQuery = new UserQuery(_dbFixture.Database);
            _userCommand = new UserCommand(_dbFixture.Database);

            _exampleUser = new User("testowy", "test@test.com", "dfadfadfafa");
        }

        public void Dispose()
        {
            var collection = _dbFixture.Database.GetCollection<User>(nameof(User));

            var oldUser = collection
                .FindSync(x => x.Email.Equals(_exampleUser.Email))
                .SingleOrDefault();

            if (oldUser != null)
                collection.DeleteOne(x => x.Id.Equals(oldUser.Id));
        }

        [Fact]
        public void AddAndGetSameItemInResult()
        {
            var userBeforeAdding = _exampleUser;
            var userId = userBeforeAdding.Id;

            _userCommand.AddUser(userBeforeAdding);

            var userFromDb = _userQuery.GetUserById(userId);

            Assert.Equal(userBeforeAdding, userFromDb);
        }

        [Fact]
        public void AddUserAndDeleteSuccessfully()
        {
            var userBeforeAdding = _exampleUser;
            var userId = userBeforeAdding.Id;

            _userCommand.DeleteUser(userBeforeAdding);

            var retrievedUser = _userQuery.GetUserById(userId);

            Assert.Null(retrievedUser);
        }

        [Fact]
        public void AddUserAndUpdateSuccessfully()
        {
            var user = _exampleUser;
            _userCommand.AddUser(user);
            var userId = user.Id;

            var userRetrievedBeforeUpdate = _userQuery.GetUserById(userId);

            Assert.Equal(user, userRetrievedBeforeUpdate);

            user.Username = "testowyAfterUpdate";
            _userCommand.UpdateUser(user);

            var userRetrievedAfterUpdate = _userQuery.GetUserById(userId);

            Assert.Equal(userRetrievedAfterUpdate, user);
            Assert.NotEqual(userRetrievedAfterUpdate, userRetrievedBeforeUpdate);
        }
    }
}
