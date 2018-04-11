using System;
using System.Collections.Generic;
using System.Text;

namespace MultiNotes.Server.Common.Exceptions
{
    public class ItemAlreadyExistsException : Exception
    {
        public ItemAlreadyExistsException(string message = "Specified item already exists!") : base(message)
        { }
    }
}
