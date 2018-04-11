using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.Interfaces
{
    public interface IUserCommand
    {
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
