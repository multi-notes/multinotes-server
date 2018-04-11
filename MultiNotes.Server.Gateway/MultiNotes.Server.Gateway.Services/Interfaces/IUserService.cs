using System;
using System.Collections.Generic;
using System.Text;
using MultiNotes.Server.Users.ObjectModel.Dto;

namespace MultiNotes.Server.Gateway.Services.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(int userId);
        UserDto AddUser(UserToAddDto noteToAddDto);
        UserDto UpdateUser(int userId, UserDto userDto);
        void DeleteUser(int userId);
    }
}
