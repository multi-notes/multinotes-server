using MultiNotes.Server.Users.Services.Interfaces;
using Xunit;

namespace MultiNotes.Server.Users.Services.Test.Unit
{
    public class PasswordServiceTest
    {
        [Fact]
        public void GetPasswordHashReturnsHashString()
        {
            IPasswordService service = new PasswordService();
            const string examplePassword = "terstestsetst";

            var hash = service.GetPasswordHash(examplePassword);

            Assert.NotNull(hash);
            Assert.NotEqual(hash, examplePassword);
        }

        [Fact]
        public void VerifyPasswordReturnsTrueIfComputedHashMatchesPassword()
        {
            IPasswordService service = new PasswordService();
            const string examplePassword = "terstestsetst";

            var hash = service.GetPasswordHash(examplePassword);

            Assert.True(service.VerifyPassword(examplePassword, hash));
        }
    }
}