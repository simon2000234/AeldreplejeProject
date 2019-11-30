using System;
using System.Collections.Generic;
using AeldreplejeCore.Core.Application;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AeldreplejeAPI.Controllers
{
    public class PendingShiftController : Controller
    {
        private IPendingShiftService _pendingShiftService;

            public PendingShiftController(IPendingShiftService pendingShiftService)
            {
                _pendingShiftService = pendingShiftService;
            }

            // GET api/pendingShifts
            [HttpGet]
            public ActionResult<IEnumerable<PendingShift>> Get()
            {
                try
                {
                    return _pendingShiftService.GetAllPendingShift();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // POST api/pendingShifts
            [HttpPost]
            public ActionResult<PendingShift> Post([FromBody] PendingShift pendingShift)
            {
                try
                {
                    return Ok(_pendingShiftService.CreatePendingShift(pendingShift));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // GET api/pendingShifts/5
            [HttpGet("{id}")]
            public ActionResult<PendingShift> Get(int id)
            {
                try
                {
                    return Ok(_pendingShiftService.GetPendingShift(id));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // PUT api/pendingShifts/5
            [HttpPut("{id}")]
            public ActionResult<PendingShift> Put(int id, [FromBody] PendingShift pendingShift)
            {
                try
                {
                    return Ok(_pendingShiftService.UpdatePendingShift(pendingShift));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // DELETE api/pendingShifts/5
            [HttpDelete("{id}")]
            public ActionResult<PendingShift> Delete(int id)
            {
                try
                {
                    return Ok(_pendingShiftService.DeletePendingShift(id));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
