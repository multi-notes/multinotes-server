using System;
using System.Collections.Generic;
using System.Text;

namespace MultiNotes.Server.Users.Services.Interfaces
{
    public interface IPasswordService
    {
        string GetPasswordHash(string password);
        bool VerifyPassword(string password, string hash);
    }
}
