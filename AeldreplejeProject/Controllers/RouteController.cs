using System;
using System.Collections.Generic;
using AeldreplejeCore.Core.Application;
using AeldreplejeCore.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AeldreplejeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : Controller
    {
       
        private IRouteService _routeService;

            public RouteController(IRouteService routeService )
            {
                _routeService = routeService;
            }

            // GET api/routes
            [HttpGet]
            public ActionResult<IEnumerable<Route>> Get()
            {
                try
                {
                    return _routeService.GetAllRoute();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // POST api/routes
            [HttpPost]
            public ActionResult<Route> Post([FromBody] Route route)
            {
                try
                {
                    return Ok(_routeService.CreateRoute(route));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // GET api/routes/5
            [HttpGet("{id}")]
            public ActionResult<Route> Get(int id)
            {
                try
                {
                    return Ok(_routeService.GetRoute(id));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // PUT api/routes/5
            [HttpPut("{id}")]
            public ActionResult<Route> Put(int id, [FromBody] Route route)
            {
                try
                {
                    return Ok(_routeService.UpdateRoute(route));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // DELETE api/routes/5
            [HttpDelete("{id}")]
            public ActionResult<Route> Delete(int id)
            {
                try
                {
                    return Ok(_routeService.DeleteRoute(id));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        
    }
}