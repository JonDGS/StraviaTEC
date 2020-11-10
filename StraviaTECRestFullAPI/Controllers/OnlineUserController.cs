using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.DataAccess;
using StraviaTECRestFullAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    public class OnlineUserController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public OnlineUserController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }


        [HttpPost]
        [Route("LogIn")]
        public IActionResult Create([FromBody] LogInUserMsg userInfo)
        {
            if (ModelState.IsValid)
            {
                if (_dataAccessProvider.AddOnlineUserRecord(userInfo) == "Succes") {
                    return Ok();
                }
               return Ok();
            }
            return BadRequest();
        }
    }
}
