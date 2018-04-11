using MultiNotes.Server.Users.ObjectModel;
using MultiNotes.Server.Users.ObjectModel.Dto;

namespace MultiNotes.Server.Users.Services.Interfaces
{
    public interface IUserService
    {
        User AddUser(UserAddEditDto userAddEditDto);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        User UpdateUser(int userId, UserAddEditDto userDto);
    }
}
