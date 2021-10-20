using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstagramServices.Service;
using Repository.Models;

namespace Projekat_Luka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user")]
        public IActionResult AddUser([FromBody] User user)
        {
            _userService.Add(user);

            return Ok();
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers =await _userService.GetAll();

            return Ok(allUsers);
        }

        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            
            return Ok(user);
        }

        [HttpDelete("delete-user-by-id")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Remove(id);

            return Ok(id);
        }

        [HttpPut("edit-user")]
        public async Task<IActionResult> EditPost([FromBody] User user)
        {
            await _userService.Edit(user);

            return Ok(user);
        }
    }
}
