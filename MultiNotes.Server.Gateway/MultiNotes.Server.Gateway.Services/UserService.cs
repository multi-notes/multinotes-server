using System;
using System.Collections.Generic;
using System.Text;
using MultiNotes.Server.Gateway.Services.Interfaces;
using MultiNotes.Server.Users.ObjectModel.Dto;

namespace MultiNotes.Server.Gateway.Services
{
    public class UserService: IUserService
    {
        public UserDto GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto AddUser(UserToAddDto noteToAddDto)
        {
            throw new NotImplementedException();
        }

        public UserDto UpdateUser(int userId, UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
