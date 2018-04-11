using System;

namespace MultiNotes.Server.Common.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message = "Item not found!") : base(message)
        { }
    }
}
