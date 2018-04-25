using System;
using MultiNotes.Server.Users.ObjectModel;
using MultiNotes.Server.Users.ObjectModel.Dto;

namespace MultiNotes.Server.Users.Services.Interfaces
{
    public interface IUserService
    {
        User AddUser(UserAddEditDto userAddEditDto);
        void DeleteUser(Guid userId);
        User GetUserById(Guid userId);
        User UpdateUser(Guid userId, UserAddEditDto userDto);
    }
}
