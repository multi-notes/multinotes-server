using System;

namespace MultiNotes.Server.Users.ObjectModel.Dto
{
    public class UserDto
    {
        public UserDto()
        {
            throw new NotImplementedException();
            //todo: use Automapper
        }

        public int Id { get; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
