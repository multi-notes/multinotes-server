using System;

namespace MultiNotes.Server.Users.ObjectModel.Dto
{
    //todo: check if webapi controllers require setters in props
    public sealed class UserDto
    {
        public UserDto(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        public int Id { get; }
        public string Username { get; }
        public string Email { get; }
    }
}
