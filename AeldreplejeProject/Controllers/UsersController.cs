using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeldreplejeCore.Core.Application;
using AeldreplejeCore.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeldreplejeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
         private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                return _userService.GetAllUsers();               
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/users
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                return Ok(_userService.CreateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                return Ok(_userService.GetUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            try
            {
                return Ok(_userService.UpdateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<User> Delete(int id)
        {
            try
            {
                return Ok(_userService.DeleteUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}