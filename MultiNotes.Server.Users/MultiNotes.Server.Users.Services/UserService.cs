using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using MultiNotes.Server.Users.DataAccess.Interfaces;
using MultiNotes.Server.Users.ObjectModel;
using MultiNotes.Server.Users.ObjectModel.Dto;
using MultiNotes.Server.Users.ObjectModel.Exceptions;
using MultiNotes.Server.Users.Services.Interfaces;

namespace MultiNotes.Server.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserQuery _userQuery;
        private readonly IUserCommand _userCommand;
        private object userBeingAdded;

        public UserService(IPasswordService passwordService, IUserQuery userQuery, IUserCommand userCommand)
        {
            _passwordService = passwordService;
            _userQuery = userQuery;
            _userCommand = userCommand;
        }

        public User AddUser(UserToAddDto userToAddDto)
        {
            //todo: think about encoding password by base64

            if (!ValidateEmail(userToAddDto.Email))
            {
                throw new ArgumentException("Invalid email address!");
            }

            if (!_userQuery.CheckIfEmailAvailable(userToAddDto.Email))
            {
                throw new UserAlreadExistsException($"User with email address {userToAddDto.Email} already exists!");
            }

            var passwordHash = _passwordService.GetPasswordHash(userToAddDto.Password);

            User newUser;
            lock (userBeingAdded)
            {
                var userId = _userQuery.GetNextUserId();
                newUser = new User(userId, userToAddDto.Username, userToAddDto.Email, passwordHash);
                _userCommand.AddUser(newUser);
            }

            return newUser;
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        private static bool ValidateEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
