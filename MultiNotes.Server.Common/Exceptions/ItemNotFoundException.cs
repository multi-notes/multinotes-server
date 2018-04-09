using System;
using System.Collections.Generic;
using System.Text;

namespace MultiNotes.Server.Common.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message = "Item not found!") : base(message)
        { }
    }
}
