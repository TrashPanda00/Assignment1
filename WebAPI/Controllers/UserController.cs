using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserData userData;

        public UserController(IUserData userData)
        {
            this.userData = userData;
        }

        [HttpGet]
        public async Task<ActionResult<User>> getUsers()
        {
            try
            {
                IList<User> users = await userData.getUsers();
                return Ok(users);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> Add([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userData.AddUser(user);
                return Created($"/{user.Username}", user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}