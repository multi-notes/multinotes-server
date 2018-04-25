using System;
using AutoMapper;
using Moq;
using MultiNotes.Server.Users.DataAccess.Interfaces;
using MultiNotes.Server.Users.ObjectModel;
using MultiNotes.Server.Users.ObjectModel.Dto;
using MultiNotes.Server.Users.ObjectModel.Exceptions;
using MultiNotes.Server.Users.Services.Interfaces;
using Xunit;

namespace MultiNotes.Server.Users.Services.Test.Unit
{
    public class UserServiceTest
    {
        private readonly Mock<IPasswordService> _passwordServiceMock;
        private readonly Mock<IUserQuery> _userQueryMock;
        private readonly Mock<IUserCommand> _userCommandMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _passwordServiceMock = new Mock<IPasswordService>();
            _userQueryMock = new Mock<IUserQuery>();
            _userCommandMock = new Mock<IUserCommand>();
            _mapperMock = new Mock<IMapper>();

            _userService = new UserService(_passwordServiceMock.Object, _userQueryMock.Object, _userCommandMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void AddUserReturnsUser()
        {
            const string exampleUsername = "Jon";
            const string exampleValidEmail = "test@test.com";
            const string examplePassword = "qwerty";

            var exampleUserAddEditDto = new UserAddEditDto(exampleUsername, exampleValidEmail, examplePassword);

            _userQueryMock
                .Setup(x => x.CheckIfEmailAvailable(It.IsAny<string>()))
                .Returns(true);
            _userCommandMock.Setup(x => x.AddUser(It.IsAny<User>()));

            _userService.AddUser(exampleUserAddEditDto);
        }

        [Fact]
        public void AddUserThrowsArgumentExceptionWhenEmailNotValid()
        {
            const string exampleUsername = "Jon";
            const string exampleInvalidEmail = "qwe";
            const string examplePassword = "qwerty";

            var exampleUserAddEditDto = new UserAddEditDto(exampleUsername, exampleInvalidEmail, examplePassword);

            _userCommandMock.Setup(x => x.AddUser(It.IsAny<User>()));

            Assert.Throws<ArgumentException>(() => _userService.AddUser(exampleUserAddEditDto));
        }

        [Fact]
        public void AddUserThrowsUserAlreadyExistExceptionWhenEmailAlreadyTaken()
        {
            const string exampleUsername = "Jon";
            const string exampleValidEmail = "test@test.com";
            const string examplePassword = "qwerty";

            var exampleUserAddEditDto = new UserAddEditDto(exampleUsername, exampleValidEmail, examplePassword);

            _userQueryMock
                .Setup(x => x.CheckIfEmailAvailable(It.IsAny<string>()))
                .Returns(false);
            _userCommandMock.Setup(x => x.AddUser(It.IsAny<User>()));

            Assert.Throws<UserAlreadExistsException>(() => _userService.AddUser(exampleUserAddEditDto));
        }

        [Fact]
        public void GetUserByIdReturnsUserIfUserExists()
        {
            var exampleUserId = Guid.NewGuid();
            var expectedUser = new User(exampleUserId, "test", "test@test.com", "dfadsfads");

            _userQueryMock
                .Setup(x => x.GetUserById(It.IsAny<Guid>()))
                .Returns(expectedUser);

            var result = _userService.GetUserById(exampleUserId);

            Assert.NotNull(result);
            Assert.IsType<User>(result);
        }

        [Fact]
        public void GetUserByIdThrowsUserNotFoundExceptionIfUserNotExists()
        {
            var exampleUserId = Guid.NewGuid();

            _userQueryMock
                .Setup(x => x.GetUserById(It.IsAny<Guid>()))
                .Returns<User>(null);

            Assert.Throws<UserNotFoundException>(()=> _userService.GetUserById(exampleUserId));
        }

        [Fact]
        public void DeleteUserDoesntThrowExceptionsWhenUserExists()
        {
            var exampleUserId = Guid.NewGuid();

            var expectedUser = new User(exampleUserId, "test", "test@test.com", "dfadsfads");

            _userQueryMock
                .Setup(x => x.GetUserById(It.IsAny<Guid>()))
                .Returns(expectedUser);

            _userCommandMock
                .Setup(x => x.DeleteUser(It.IsAny<User>()));

            _userService.DeleteUser(exampleUserId);
        }

        [Fact]
        public void DeleteUserThrowsUserNotFoundExceptionWhenUserWithGivenItDoesntExist()
        {
            var exampleUserId = Guid.NewGuid();

            _userQueryMock
                .Setup(x => x.GetUserById(It.IsAny<Guid>()))
                .Returns<User>(null);

            Assert.Throws<UserNotFoundException>(() => _userService.DeleteUser(exampleUserId));
        }

        [Fact]
        public void UpdateUserReturnsUser()
        {
            var exampleUserId = Guid.NewGuid();
            var exampleUserAddEditDto = new UserAddEditDto("dfadsf", "fadsf@fdasfd.com", "fdad");
            var userBeingUpdated = new User(exampleUserId, "test", "test@test.com", "dfadsfads");
            var userBeforeUpdate = new User(exampleUserId, "test", "test@test.com", "dfadsfads");

            _userQueryMock
                .Setup(x => x.GetUserById(It.IsAny<Guid>()))
                .Returns(userBeingUpdated);

            _userCommandMock
                .Setup(x=>x.UpdateUser(It.IsAny<User>()));

            var result = _userService.UpdateUser(exampleUserId, exampleUserAddEditDto);

            Assert.NotNull(result);
            Assert.NotEqual(result, userBeforeUpdate);
            Assert.Equal(result, userBeingUpdated);
        }

        [Fact]
        public void UpdateUserThrowsUserNotFoundExceptionWhenUserWithGivenIdDoesntExist()
        {
            var exampleUserId = Guid.NewGuid();
            var exampleUserAddEditDto = new UserAddEditDto("dfadsf", "fadsf@fdasfd.com", "fdad");

            _userQueryMock
                .Setup(x => x.GetUserById(It.IsAny<Guid>()))
                .Returns<User>(null);

            Assert.Throws<UserNotFoundException>(() => _userService.UpdateUser(exampleUserId, exampleUserAddEditDto));
        }
    }
}
