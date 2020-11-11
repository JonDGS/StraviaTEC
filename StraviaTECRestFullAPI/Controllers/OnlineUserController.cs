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
                if (_dataAccessProvider.AddOnlineUserRecord(userInfo) == "Success") {
                    return Ok("Success");
                } else if (_dataAccessProvider.AddOnlineUserRecord(userInfo) == "BadPassword") {
                    return NotFound("Incorrect username or password");
                } else if (_dataAccessProvider.AddOnlineUserRecord(userInfo) == "NotRegistered") {
                    return NotFound("Not Registered");
                }
               
            }
            return BadRequest();
        }
        [HttpGet]
        public IEnumerable<OnlineUser> Get()
        {
            return _dataAccessProvider.GetOnlineUserRecords();
        }

        [HttpGet("{token}")]
        public OnlineUser Details(string token)
        {
            return _dataAccessProvider.GetOnlineUserSingleRecord(token);
        }


        [HttpDelete]
        [Route("LogOut/{token}")]
        public IActionResult DeleteConfirmed(string token)
        {
            var data = _dataAccessProvider.GetOnlineUserSingleRecord(token);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteOnlineUserRecord(token);
            return Ok();
        }
    }
}
