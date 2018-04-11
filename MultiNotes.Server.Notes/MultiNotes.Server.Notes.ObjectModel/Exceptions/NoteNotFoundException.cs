using System;
using System.Collections.Generic;
using System.Text;
using MultiNotes.Server.Common.Exceptions;

namespace MultiNotes.Server.Notes.ObjectModel.Exceptions
{
    public class NoteNotFoundException : ItemNotFoundException
    {
        public NoteNotFoundException(string message = "Note with specified id not found!") : base(message)
        { }
    }
}
