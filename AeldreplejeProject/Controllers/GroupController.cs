using System;
using System.Collections.Generic;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AeldreplejeAPI.Controllers
{
    public class GroupController : Controller
    {
        public class ShiftController : ControllerBase
        {
            private IGroupService _groupService;

            public ShiftController(IGroupService groupService)
            {
                _groupService = groupService;
            }
            // GET api/groups
            [HttpGet]
            public ActionResult<IEnumerable<Group>> Get()
            {
                try
                {
                    return _groupService.GetAllGroups();               
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // POST api/groups
            [HttpPost]
            public ActionResult<Group> Post([FromBody] Group group)
            {
                try
                {
                    return Ok(_groupService.CreateGroup(group));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // GET api/groups/5
            [HttpGet("{id}")]
            public ActionResult<Group> Get(int id)
            {
                try
                {
                    return Ok(_groupService.GetGroup(id));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // PUT api/groups/5
            [HttpPut("{id}")]
            public ActionResult<Group> Put(int id, [FromBody] Group group)
            {
                try
                {
                    return Ok(_groupService.UpdateGroup(group));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // DELETE api/groups/5
            [HttpDelete("{id}")]
            public ActionResult<Group> Delete(int id)
            {
                try
                {
                    return Ok(_groupService.DeleteGroup(id));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
    }
}