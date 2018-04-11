using System;
using System.Collections.Generic;
using System.Text;
using MultiNotes.Server.Users.ObjectModel;

namespace MultiNotes.Server.Users.DataAccess.Interfaces
{
    public interface IUserCommand
    {
        void AddUser(User user);
    }
}
