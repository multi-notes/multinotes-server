using System;

namespace MultiNotes.Server.Users.ObjectModel
{
    public class User
    {
        public User(Guid id, string username, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            RegistrationDateTime = DateTime.Now;
        }

        public User(string username, string email, string passwordHash) : this(Guid.NewGuid(), username, email, passwordHash)
        {
        }

        public Guid Id { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDateTime { get; }
    }
}
