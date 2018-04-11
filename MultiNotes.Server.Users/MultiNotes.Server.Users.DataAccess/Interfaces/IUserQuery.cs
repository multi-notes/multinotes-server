using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.Interfaces
{
    public interface IUserQuery
    {
        int GetNextUserId();
        bool CheckIfEmailAvailable(string emailAddress);

        User GetUserById(int id);
    }
}
