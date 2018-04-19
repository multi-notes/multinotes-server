using System;
using System.Net.Mail;
using AutoMapper;
using MultiNotes.Server.Users.DataAccess.Interfaces;
using MultiNotes.Server.Users.ObjectModel;
using MultiNotes.Server.Users.ObjectModel.Dto;
using MultiNotes.Server.Users.ObjectModel.Exceptions;
using MultiNotes.Server.Users.Services.Interfaces;

namespace MultiNotes.Server.Users.Services
{
    //todo: add locks and single instance in DI while adding and editing if DB doesn't support transactions and unique indexes
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IUserQuery _userQuery;
        private readonly IUserCommand _userCommand;

        public UserService(IPasswordService passwordService, IUserQuery userQuery, IUserCommand userCommand, IMapper mapper)
        {
            _passwordService = passwordService;
            _userQuery = userQuery;
            _userCommand = userCommand;
            _mapper = mapper;
        }

        public User AddUser(UserAddEditDto userAddEditDto)
        {
            //todo: think about encoding password by base64

            if (!ValidateEmail(userAddEditDto.Email))
            {
                throw new ArgumentException("Invalid email address!");
            }

            if (!_userQuery.CheckIfEmailAvailable(userAddEditDto.Email))
            {
                throw new UserAlreadExistsException($"User with email address {userAddEditDto.Email} already exists!");
            }

            var passwordHash = _passwordService.GetPasswordHash(userAddEditDto.Password);

            var userId = _userQuery.GetNextUserId();
            var newUser = new User(userId, userAddEditDto.Username, userAddEditDto.Email, passwordHash);
            _userCommand.AddUser(newUser);

            return newUser;
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            _userCommand.DeleteUser(user);
        }

        public User GetUserById(int userId)
        {
            var user = _userQuery.GetUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException("User with given id doesn't exist!");
            }

            return user;
        }

        public User UpdateUser(int userId, UserAddEditDto userDto)
        {
            var user = GetUserById(userId);

            if (!user.Username.Equals(userDto.Email))
                ChangeUsername(user, userDto.Username);
            if (!user.Email.Equals(userDto.Email))
                ChangeEmailAddress(user, userDto.Email);
            if (!_passwordService.VerifyPassword(userDto.Password, user.PasswordHash))
                ChangePassword(user, userDto.Username);

            _userCommand.UpdateUser(user);

            return user;
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                new MailAddress(email);
                _userQuery.CheckIfEmailAvailable(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ChangeUsername(User user, string newUsername)
        {
            user.Username = newUsername;
        }

        private void ChangeEmailAddress(User user, string newEmailAddress)
        {
            if (!ValidateEmail(newEmailAddress))
            {
                throw new UserAlreadExistsException($"User with email address {newEmailAddress} already exists!");
            }

            user.Email = newEmailAddress;
        }

        private void ChangePassword(User user, string newPassword)
        {
            var newHash = _passwordService.GetPasswordHash(newPassword);
            user.PasswordHash = newHash;
        }
    }
}
