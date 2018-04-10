using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MultiNotes.Server.Common.Exceptions;
using MultiNotes.Server.Gateway.Api.Controllers;
using MultiNotes.Server.Gateway.Services.Interfaces;
using MultiNotes.Server.Users.ObjectModel;
using MultiNotes.Server.Users.ObjectModel.Dto;
using MultiNotes.Server.Users.ObjectModel.Exceptions;
using Xunit;

namespace MultiNotes.Server.Gateway.Api.Test.Unit
{
    public class UserControllerTest
    {
        private readonly UserController _userController;
        private readonly Mock<IUserService> _userServiceMock;

        public UserControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public void GetReturns200IfServiceReturnsUser()
        {
            var exampleUserDto = new UserDto();
            const int exampleUserId = 1;

            _userServiceMock
                .Setup(x => x.AddUser(It.IsAny<UserToAddDto>()))
                .Returns(exampleUserDto);

            var result = _userController.Get(exampleUserId);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetReturns404IfServiceThrowsUserNotFoundException()
        {
            var exampleUserDto = new UserDto();
            const int exampleUserId = 1;

            _userServiceMock
                .Setup(x => x.AddUser(It.IsAny<UserToAddDto>()))
                .Throws(new UserNotFoundException());

            var result = _userController.Get(exampleUserId);

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostReturns200IfServiceReturnsUserDto()
        {
            var exampleUserAddDto = new UserToAddDto();
            var exampleUserDto = new UserDto();

            _userServiceMock
                .Setup(x => x.AddUser(It.IsAny<UserToAddDto>()))
                .Returns(exampleUserDto);

            var result = _userController.Post(exampleUserAddDto);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PostReturns400IfServiceThrowsUserAlreadyExistsException()
        {
            var exampleUserAddDto = new UserToAddDto();
            var exampleUserDto = new UserDto();

            _userServiceMock
                .Setup(x => x.AddUser(It.IsAny<UserToAddDto>()))
                .Returns(exampleUserDto);

            var result = _userController.Post(exampleUserAddDto);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateReturns200IfServiceReturnsUser()
        {
            var exampleUserDto = new UserDto();
            const int exampleUserId = 1;

            _userServiceMock
                .Setup(x => x.UpdateUser(It.IsAny<int>(), It.IsAny<UserDto>()))
                .Returns(exampleUserDto);

            var result = _userController.Update(exampleUserId, exampleUserDto);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void DeleteUserReturns204IfServiceDoesntThrowExceptions()
        {
            const int exampleUserId = 1;

            _userServiceMock
                .Setup(x=>x.DeleteUser(It.IsAny<int>()));

            _userController.Delete(exampleUserId);
        }
    }
}
