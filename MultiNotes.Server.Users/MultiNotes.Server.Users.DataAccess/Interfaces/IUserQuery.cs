using System;
using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.Interfaces
{
    public interface IUserQuery
    {
        bool CheckIfEmailAvailable(string emailAddress);

        User GetUserById(Guid id);
    }
}
