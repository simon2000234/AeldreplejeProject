using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeldreplejeCore.Core.Application;
using AeldreplejeCore.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeldreplejeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEndsController : ControllerBase
    {
        private ITimeEndService _teService;

        public TimeEndsController(ITimeEndService timeEndService)
        {
            _teService = timeEndService;
        }
        // GET api/timeends
        [HttpGet]
        public ActionResult<IEnumerable<TimeEnd>> Get()
        {
            try
            {
                return _teService.GetAllTimeEnds();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/timeends
        [HttpPost]
        public ActionResult<TimeEnd> Post([FromBody] TimeEnd timeEnd)
        {
            try
            {
                return Ok(_teService.CreateTimeEnd(timeEnd));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/timeends/5
        [HttpGet("{id}")]
        public ActionResult<TimeEnd> Get(int id)
        {
            try
            {
                return Ok(_teService.GetTimeEnd(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/timeends/5
        [HttpPut("{id}")]
        public ActionResult<TimeEnd> Put(int id, [FromBody] TimeEnd timeEnd)
        {
            try
            {
                return Ok(_teService.UpdateTimeEnd(timeEnd));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/timeends/5
        [HttpDelete("{id}")]
        public ActionResult<TimeEnd> Delete(int id)
        {
            try
            {
                return Ok(_teService.DeleteTimeEnd(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}