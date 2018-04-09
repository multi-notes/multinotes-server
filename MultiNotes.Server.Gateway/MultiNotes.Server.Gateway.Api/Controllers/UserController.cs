using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiNotes.Server.Gateway.Api.Controllers
{
    //todo: add authorization
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
    }
}