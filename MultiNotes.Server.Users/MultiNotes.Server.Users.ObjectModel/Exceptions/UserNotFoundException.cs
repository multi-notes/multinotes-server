using MultiNotes.Server.Common.Exceptions;

namespace MultiNotes.Server.Users.ObjectModel.Exceptions
{
    public class UserNotFoundException : ItemNotFoundException
    {
        public UserNotFoundException(string message = "User with specified id not found!") : base(message)
        { }
    }
}
