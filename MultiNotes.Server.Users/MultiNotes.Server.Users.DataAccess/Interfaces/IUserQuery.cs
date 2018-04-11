namespace MultiNotes.Server.Users.DataAccess.Interfaces
{
    public interface IUserQuery
    {
        int GetNextUserId();
        bool CheckIfEmailAvailable(string emailAddress);
    }
}
