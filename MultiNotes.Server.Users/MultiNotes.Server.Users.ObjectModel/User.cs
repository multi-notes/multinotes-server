using System;

namespace MultiNotes.Server.Users.ObjectModel
{
    public class User
    {
        public User(Guid id, string username, string email, string passwordHash, DateTime registrationDateTime)
        {
            Id = id;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            RegistrationDateTime = registrationDateTime;
        }

        public User(string username, string email, string passwordHash) : this(Guid.NewGuid(), username, email, passwordHash, DateTime.Now)
        {
        }

        public Guid Id { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDateTime { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;

            var user = obj as User;

            return Id.Equals(user.Id)
                   && Username.Equals(user.Username)
                   && Email.Equals(user.Email)
                   && PasswordHash.Equals(user.PasswordHash)
                   && RegistrationDateTime.Equals(user.RegistrationDateTime);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + RegistrationDateTime.GetHashCode();
        }
    }
}
