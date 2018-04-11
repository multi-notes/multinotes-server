using System;

namespace MultiNotes.Server.Common.Exceptions
{
    public class ItemAlreadyExistsException : Exception
    {
        public ItemAlreadyExistsException(string message = "Specified item already exists!") : base(message)
        { }
    }
}
