using System;
using System.Collections.Generic;
using System.Text;

namespace MultiNotes.Server.Users.ObjectModel.Dto
{
    public class UserAddEditDto
    {
        public UserAddEditDto()
        {
            throw new NotImplementedException();
            //todo: use Automapper
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
