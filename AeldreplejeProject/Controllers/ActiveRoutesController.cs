using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeldreplejeCore.Core.Application;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeldreplejeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveRoutesController : ControllerBase
    {
        private IActiveRouteService arService;
        public ActiveRoutesController(IActiveRouteService activeRouteService)
        {
            arService = activeRouteService;
        }

        // GET api/activeroutes
        [HttpGet]
        public ActionResult<IEnumerable<ActiveRoute>> Get()
        {
            try
            {
                return arService.GetAllActiveRoutes();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/activeroutes
        [HttpPost]
        public ActionResult<ActiveRoute> Post([FromBody] ActiveRoute activeRoute)
        {
            try
            {
                return Ok(arService.CreateActiveRoute(activeRoute));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/activeroutes/5
        [HttpGet("{id}")]
        public ActionResult<ActiveRoute> Get(int id)
        {
            try
            {
                return Ok(arService.GetActiveRoute(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/activeroutes/5
        [HttpPut("{id}")]
        public ActionResult<ActiveRoute> Put(int id, [FromBody] ActiveRoute activeRoute)
        {
            try
            {
                return Ok(arService.UpdateActiveRoute(activeRoute));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/activeroutes/5
        [HttpDelete("{id}")]
        public ActionResult<ActiveRoute> Delete(int id)
        {
            try
            {
                return Ok(arService.DeleteActiveRoute(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}