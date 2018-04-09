using System;
using System.Collections.Generic;
using System.Text;

namespace MultiNotes.Server.Notes.ObjectModel
{
    public class Note
    {
        public int Id { get; }
        public string Topic { get; set; }
        public string TextContent { get; set; }
    }
}
