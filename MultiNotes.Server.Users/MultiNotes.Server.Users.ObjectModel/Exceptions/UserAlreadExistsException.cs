using System;
using System.Collections.Generic;
using System.Text;
using MultiNotes.Server.Common.Exceptions;

namespace MultiNotes.Server.Users.ObjectModel.Exceptions
{
    public class UserAlreadExistsException : ItemAlreadyExistsException
    {
        public UserAlreadExistsException(string message = "User with specified data already exists!") : base(message)
        { }
    }
}
