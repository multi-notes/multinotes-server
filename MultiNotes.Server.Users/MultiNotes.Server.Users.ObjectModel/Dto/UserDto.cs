using System;
using System.Collections.Generic;
using System.Text;

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
