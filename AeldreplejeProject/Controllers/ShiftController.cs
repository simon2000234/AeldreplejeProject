using System;
using System.Collections.Generic;
using AeldreplejeCore.Core.Application;
using AeldreplejeCore.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AeldreplejeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }
        // GET api/shifts
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Shift>> Get()
        {
            try
            {
                return _shiftService.GetAllShifts();               
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/shifts
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Shift> Post([FromBody] Shift shift)
        {
            try
            {
                return Ok(_shiftService.CreateShift(shift));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/shifts/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Shift> Get(int id)
        {
            try
            {
                return Ok(_shiftService.GetShift(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/shifts/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Shift> Put(int id, [FromBody] Shift shift)
        {
            try
            {
                return Ok(_shiftService.UpdateShift(shift));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/shifts/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Shift> Delete(int id)
        {
            try
            {
                return Ok(_shiftService.DeleteShift(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}