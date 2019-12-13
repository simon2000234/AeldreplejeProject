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
    public class TimeStartsController : ControllerBase
    {
        private ITimeStartService _tsService;

        public TimeStartsController(ITimeStartService timeStartService)
        {
            _tsService = timeStartService;
        }
        // GET api/timestarts
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<TimeStart>> Get()
        {
            try
            {
                return _tsService.GetAllTimeStarts();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/timestarts
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult<TimeStart> Post([FromBody] TimeStart timeStart)
        {
            try
            {
                return Ok(_tsService.CreateTimeStart(timeStart));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/timestarts/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<TimeStart> Get(int id)
        {
            try
            {
                return Ok(_tsService.GetTimeStart(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/timestarts/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<TimeStart> Put(int id, [FromBody] TimeStart timeStart)
        {
            try
            {
                return Ok(_tsService.UpdateTimeStart(timeStart));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/timestarts/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<TimeStart> Delete(int id)
        {
            try
            {
                return Ok(_tsService.DeleteTimeStart(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}