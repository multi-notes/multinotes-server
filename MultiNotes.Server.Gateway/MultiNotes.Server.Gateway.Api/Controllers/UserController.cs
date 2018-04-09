using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiNotes.Server.Gateway.Services.Interfaces;
using MultiNotes.Server.Users.ObjectModel.Dto;

namespace MultiNotes.Server.Gateway.Api.Controllers
{
    //todo: add authorization
    //todo: error handling
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userService.GetUser(userId);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserToAddDto userToAddDto)
        {
            var user = _userService.AddUser(userToAddDto);
            return Ok(user);
        }

        [HttpPut]
        [Route("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] UserDto userDto)
        {
            var user = _userService.UpdateUser(userId, userDto);
            return Ok(user);
        }
    }
}