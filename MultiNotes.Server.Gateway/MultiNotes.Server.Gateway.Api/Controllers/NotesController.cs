using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiNotes.Server.Gateway.Services.Interfaces;
using MultiNotes.Server.Notes.ObjectModel.Dto;
using MultiNotes.Server.Notes.ObjectModel.Exceptions;
using MultiNotes.Server.Users.ObjectModel.Exceptions;

namespace MultiNotes.Server.Gateway.Api.Controllers
{
    //todo: add authorization
    //todo: error handling for generic exception
    [Produces("application/json")]
    [Route("api")]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        [Route("Users/{userId}/Notes")]
        public IActionResult GetAllNotes(int userId)
        {
            try
            {
                var notes = _noteService.GetAllUsersNotes(userId);
                return Ok(notes);
            }
            catch (UserNotFoundException unfe)
            {
                return BadRequest(unfe.Message); //maybe 404 is better?
            }
        }

        [HttpGet]
        [Route("Users/{userId}/Notes/{noteId}")]
        public IActionResult GetNoteById(int userId, int noteId)
        {
            try
            {
                var note = _noteService.GetUserNote(userId, noteId);
                return Ok(note);
            }
            catch (UserNotFoundException unfe)
            {
                return BadRequest(unfe.Message); //maybe 404 is better?
            }
            catch (NoteNotFoundException nnfe)
            {
                return NotFound(nnfe.Message);
            }
        }

        [HttpPost]
        [Route("Users/{userId}/Notes")]
        public IActionResult AddNote(int userId, [FromBody]NoteToAddDto noteToAddDto)
        {
            try
            {
                var note = _noteService.AddUserNote(userId, noteToAddDto);
                return Ok(note);
            }
            catch (UserNotFoundException unfe)
            {
                return BadRequest(unfe.Message); //maybe 404 is better?
            }
        }

        [HttpPut]
        [Route("Users/{userId}/Notes/{noteId}")]
        public IActionResult UpdateNote(int userId, int noteId, [FromBody] NoteDto noteToUpdate)
        {
            try
            {
                var note = _noteService.UpdateUserNote(userId, noteId, noteToUpdate);
                return Ok(note);
            }
            catch (UserNotFoundException unfe)
            {
                return BadRequest(unfe.Message); //maybe 404 is better?
            }
            catch (NoteNotFoundException nnfe)
            {
                return NotFound(nnfe.Message);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        [HttpDelete]
        [Route("Users/{userId}/Notes/{noteId}")]
        public IActionResult DeleteNote(int userId, int noteId)
        {
            try
            {
                _noteService.DeleteUserNote(userId, noteId);
                return NoContent();
            }
            catch (UserNotFoundException unfe)
            {
                return BadRequest(unfe.Message); //maybe 404 is better?
            }
            catch (NoteNotFoundException nnfe)
            {
                return NotFound(nnfe.Message);
            }
        }
    }
}