using System;

namespace MultiNotes.Server.Users.ObjectModel
{
    public class User
    {
        public User(int id, string username, string email, string passwordHash)
        {
            Id = id;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            RegistrationDateTime = DateTime.Now;
        }

        public int Id { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDateTime { get; }
    }
}
