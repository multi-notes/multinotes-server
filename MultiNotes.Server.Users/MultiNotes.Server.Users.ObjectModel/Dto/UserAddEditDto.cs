using System;

namespace MultiNotes.Server.Users.ObjectModel.Dto
{
    //todo: check if webapi controllers require setters in props
    public sealed class UserAddEditDto
    {
        public UserAddEditDto(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public string Username { get; }
        public string Email { get; }
        public string Password { get; }
    }
}
