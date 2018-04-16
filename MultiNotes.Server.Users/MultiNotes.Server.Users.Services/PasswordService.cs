using MultiNotes.Server.Users.Services.Interfaces;

namespace MultiNotes.Server.Users.Services
{
    public class PasswordService: IPasswordService
    {
        public string GetPasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
