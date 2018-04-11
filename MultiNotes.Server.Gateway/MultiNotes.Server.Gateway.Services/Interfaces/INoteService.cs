using System;
using System.Collections.Generic;
using System.Text;
using MultiNotes.Server.Notes.ObjectModel;
using MultiNotes.Server.Notes.ObjectModel.Dto;

namespace MultiNotes.Server.Gateway.Services.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetAllUsersNotes(int userId);
        NoteDto GetUserNote(int userId, int noteId);
        NoteDto AddUserNote(int userId, NoteToAddDto noteToAddDto);
        NoteDto UpdateUserNote(int userId, int noteId, NoteDto noteDto);
        void DeleteUserNote(int userId, int noteId);      
    }
}
