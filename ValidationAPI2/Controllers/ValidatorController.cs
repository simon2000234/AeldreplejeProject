using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationAPI.Core.Entity;
using ValidationAPI.Validators;

namespace ValidationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidatorController : ControllerBase
    {
        [HttpPost]
        [Route("GroupCreate")]
        public ActionResult ValidateGroupCreate([FromBody] Group group)
        {
            try
            {
                GroupServiceValidator.ValidateGroup(group);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("GroupUpdate")]
        public ActionResult ValidateGroupUpdate([FromBody] Group group)
        {
            try
            {
                GroupServiceValidator.ValidateUpdateGroup(group);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
