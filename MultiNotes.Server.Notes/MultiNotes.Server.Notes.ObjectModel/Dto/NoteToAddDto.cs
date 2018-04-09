using System;
using System.Collections.Generic;
using System.Text;

namespace MultiNotes.Server.Notes.ObjectModel.Dto
{
    public class NoteToAddDto
    {
        public string Topic { get; set; }
        public string TextContent { get; set; }
    }
}
