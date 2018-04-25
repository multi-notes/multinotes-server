using MultiNotes.Server.Users.DataAccess.MongoDB.Config;

namespace MultiNotes.Server.Users.DataAccess.MongoDB.Test.Integration
{
    public class UserIntegrationTests
    {
        public UserIntegrationTests()
        {
            MongoDbConfig.Configure("mongodb://localhost:27017", "MultiNotes");
            var db = MongoDbConfig.Database
        }
    }
}
