using System;
using System.Collections.Generic;
using System.Text;
using MultiNotes.Server.Users.ObjectModel;
using MultiNotes.Server.Users.ObjectModel.Dto;

namespace MultiNotes.Server.Users.Services.Interfaces
{
    public interface IUserService
    {
        User AddUser(UserToAddDto userToAddDto);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        User UpdateUser(UserDto userDto);
    }
}
