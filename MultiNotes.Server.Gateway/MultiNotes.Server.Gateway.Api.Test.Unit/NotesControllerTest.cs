using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MultiNotes.Server.Gateway.Api.Controllers;
using MultiNotes.Server.Gateway.Services.Interfaces;
using MultiNotes.Server.Notes.ObjectModel;
using MultiNotes.Server.Notes.ObjectModel.Dto;
using MultiNotes.Server.Notes.ObjectModel.Exceptions;
using MultiNotes.Server.Users.ObjectModel.Exceptions;
using Xunit;

namespace MultiNotes.Server.Gateway.Api.Test.Unit
{
    public class NotesControllerTest
    {
        private readonly NotesController _notesController;
        private readonly Mock<INoteService> _noteServiceMock;

        public NotesControllerTest()
        {
            _noteServiceMock = new Mock<INoteService>();
            _notesController = new NotesController(_noteServiceMock.Object);
        }

        [Fact]
        public void GetAllNotesReturns200IfServiceReturnsData()
        {
            var exampleNotesList = new List<NoteDto>(){new NoteDto()};
            const int exampleUserId = 1;

            _noteServiceMock
                .Setup(x => x.GetAllUsersNotes(It.IsAny<int>()))
                .Returns(exampleNotesList);

            var result = _notesController.GetAllNotes(exampleUserId);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllNotesReturns400IfServiceThrowsUserNotFoundException()
        {
            const int exampleUserId = 1;

            _noteServiceMock
                .Setup(x => x.GetAllUsersNotes(It.IsAny<int>()))
                .Throws(new UserNotFoundException());

            var result = _notesController.GetAllNotes(exampleUserId);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetNoteByIdReturnsOkIfServiceReturnsData()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;

            var exampleNoteDto = new NoteDto();

            _noteServiceMock
                .Setup(x => x.GetUserNote(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(exampleNoteDto);

            var result = _notesController.GetNoteById(exampleUserId, exampleNoteId);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetNoteByIdReturns400IfServiceThrowsUserNotFoundException()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;

            var exampleNoteDto = new NoteDto();

            _noteServiceMock
                .Setup(x => x.GetUserNote(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new UserNotFoundException());

            var result = _notesController.GetNoteById(exampleUserId, exampleNoteId);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetNoteByIdReturns404IfServiceThrowsNoteNotFoundException()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;

            var exampleNoteDto = new NoteDto();

            _noteServiceMock
                .Setup(x => x.GetUserNote(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new NoteNotFoundException());

            var result = _notesController.GetNoteById(exampleUserId, exampleNoteId);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void AddNoteReturns200IfServiceReturnsData()
        {
            const int exampleUserId = 1;
            var exampleNoteToAddDto = new NoteToAddDto();
            var exampleNoteDto = new NoteDto();

            _noteServiceMock
                .Setup(x => x.AddUserNote(It.IsAny<int>(), It.IsAny<NoteToAddDto>()))
                .Returns(exampleNoteDto);

            var result = _notesController.AddNote(exampleUserId, exampleNoteToAddDto);

            Assert.NotNull(result);;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddNoteReturns400IfServiceThrowsUserNotFoundException()
        {
            const int exampleUserId = 1;
            var exampleNoteToAddDto = new NoteToAddDto();

            _noteServiceMock
                .Setup(x => x.AddUserNote(It.IsAny<int>(), It.IsAny<NoteToAddDto>()))
                .Throws(new UserNotFoundException());

            var result = _notesController.AddNote(exampleUserId, exampleNoteToAddDto);

            Assert.NotNull(result); ;
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateNoteReturns200IfServiceReturnsData()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;
            var exampleNoteDto = new NoteDto();

            _noteServiceMock
                .Setup(x => x.UpdateUserNote(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<NoteDto>()))
                .Returns(exampleNoteDto);

            var result = _notesController.UpdateNote(exampleUserId, exampleNoteId, exampleNoteDto);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateNoteReturns400IfServiceThrowsUserNotFoundException()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;
            var exampleNoteDto = new NoteDto();

            _noteServiceMock
                .Setup(x => x.UpdateUserNote(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<NoteDto>()))
                .Throws(new UserNotFoundException());

            var result = _notesController.UpdateNote(exampleUserId, exampleNoteId, exampleNoteDto);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateNoteReturns404IfServiceThrowsNoteNotFoundException()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;
            var exampleNoteDto = new NoteDto();

            _noteServiceMock
                .Setup(x => x.UpdateUserNote(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<NoteDto>()))
                .Throws(new NoteNotFoundException());

            var result = _notesController.UpdateNote(exampleUserId, exampleNoteId, exampleNoteDto);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void UpdateNoteReturns400IfServiceThrowsArgumentException()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;
            var exampleNoteDto = new NoteDto();

            _noteServiceMock
                .Setup(x => x.UpdateUserNote(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<NoteDto>()))
                .Throws(new ArgumentException());

            var result = _notesController.UpdateNote(exampleUserId, exampleNoteId, exampleNoteDto);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteNoteReturns204IfServiceDoesntThrowExceptions()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;


            _noteServiceMock
                .Setup(x => x.DeleteUserNote(It.IsAny<int>(), It.IsAny<int>()));

            var result =_notesController.DeleteNote(exampleUserId, exampleNoteId);

            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteNoteReturns400IfServiceThrowsUserNotFoundException()
        {
            const int exampleUserId = 1;
            const int exampleNoteId = 2;


            _noteServiceMock
                .Setup(x => x.DeleteUserNote(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new UserNotFoundException());

            var result = _notesController.DeleteNote(exampleUserId, exampleNoteId);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
