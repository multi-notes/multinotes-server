namespace MultiNotes.Server.Users.Services.Interfaces
{
    public interface IPasswordService
    {
        string GetPasswordHash(string password);
        bool VerifyPassword(string password, string hash);
    }
}
