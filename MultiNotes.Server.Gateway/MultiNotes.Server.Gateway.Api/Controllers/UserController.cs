using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiNotes.Server.Common.Exceptions;
using MultiNotes.Server.Gateway.Services.Interfaces;
using MultiNotes.Server.Users.ObjectModel.Dto;
using MultiNotes.Server.Users.ObjectModel.Exceptions;

namespace MultiNotes.Server.Gateway.Api.Controllers
{
    //todo: add authorization
    //todo: generic error handling
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
        public IActionResult Get(int userId)
        {
            try
            {
                var user = _userService.GetUser(userId);
                return Ok(user);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserToAddDto userToAddDto)
        {
            try
            {
                var user = _userService.AddUser(userToAddDto);
                return Ok(user);
            }
            catch (ItemAlreadyExistsException iaee)
            {
                return BadRequest(iaee.Message);
            }
        }

        [HttpPut]
        [Route("{userId}")]
        public IActionResult Update(int userId, [FromBody] UserDto userDto)
        {
            try
            {
                var user = _userService.UpdateUser(userId, userDto);
                return Ok(user);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
        }

        [HttpDelete]
        [Route("{userId")]
        public IActionResult Delete(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return NoContent();
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
        }
    }
}