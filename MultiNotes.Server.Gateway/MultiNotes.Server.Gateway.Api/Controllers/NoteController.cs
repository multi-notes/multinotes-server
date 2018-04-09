using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiNotes.Server.Gateway.Services.Interfaces;
using MultiNotes.Server.Notes.ObjectModel.Dto;

namespace MultiNotes.Server.Gateway.Api.Controllers
{
    //todo: add authorization
    //todo: error handling
    [Produces("application/json")]
    [Route("api")]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        [Route("User/{userId}/Note")]
        public IActionResult GetAllNotes(int userId)
        {
            var notes = _noteService.GetAllUsersNotes(userId);
            return Ok(notes);
        }

        [HttpGet]
        [Route("User/{userId}/Note/{noteId}")]
        public IActionResult GetNoteById(int userId, int noteId)
        {
            var note = _noteService.GetUserNote(userId, noteId);
            return Ok(note);
        }

        [HttpPost]
        [Route("User/{userId}/Note")]
        public IActionResult AddNote(int userId, [FromBody]NoteToAddDto noteToAddDto)
        {
            var note = _noteService.AddUserNote(userId, noteToAddDto);
            return Ok(note);
        }

        [HttpPut]
        [Route("User/{userId}/Note/{noteId}")]
        public IActionResult UpdateNote(int userId, int noteId, [FromBody] NoteDto noteToUpdate)
        {
            var note = _noteService.UpdateUserNote(userId, noteToUpdate);
            return Ok(note);
        }

        [HttpDelete]
        [Route("User/{userId}/Note/{noteId}")]
        public IActionResult DeleteNote(int userId, int noteId)
        {
            _noteService.DeleteUserNote(userId, noteId);
            return NoContent();
        }
    }
}