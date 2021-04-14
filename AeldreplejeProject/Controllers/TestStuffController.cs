using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeldreplejeCore.Core.Application;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestStuffController : Controller
    {
        private IUserService _userService;
        private IShiftService _shiftService;
        private IPendingShiftService _pendingShiftService;

        public TestStuffController(IUserService userService, IShiftService shiftService, IPendingShiftService pendingShiftService)
        {
            _userService = userService;
            _shiftService = shiftService;
            _pendingShiftService = pendingShiftService;
        }


        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            NotificationService ns = new NotificationService();

            var shift = _pendingShiftService.GetAllPendingShift().First();

            var users = _userService.GetAllUsers();

            var validUsers = ns.GetValidUsers(shift, users, 3);


            return Ok(validUsers);
        }
    }
}
