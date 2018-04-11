using System;
using System.Collections.Generic;
using System.Text;
using MultiNotes.Server.Gateway.Services.Interfaces;
using MultiNotes.Server.Notes.ObjectModel.Dto;

namespace MultiNotes.Server.Gateway.Services
{
    public class NoteService: INoteService
    {
        public IEnumerable<NoteDto> GetAllUsersNotes(int userId)
        {
            throw new NotImplementedException();
        }

        public NoteDto GetUserNote(int userId, int noteId)
        {
            throw new NotImplementedException();
        }

        public NoteDto AddUserNote(int userId, NoteToAddDto noteToAddDto)
        {
            throw new NotImplementedException();
        }

        public NoteDto UpdateUserNote(int userId, int noteId, NoteDto noteDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserNote(int userId, int noteId)
        {
            throw new NotImplementedException();
        }
    }
}
