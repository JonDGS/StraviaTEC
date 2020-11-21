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
    public class FollowsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public FollowsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Follows> Get()
        {
            return _dataAccessProvider.GetFollowsRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] FollowRequest followrequest)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddFollowsRecord(followrequest);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("GetFollowees/{token}")]
        public List<Athlete> Details(string token)
        {
            FollowRequest followRequest = new FollowRequest();
            followRequest.token = token;
            return _dataAccessProvider.GetFolloweesRecord(followRequest);
        }

        [HttpGet("GetFollowers/{token}")]
        public List<Athlete> DetailsFollowers(string token)
        {
            FollowRequest followRequest = new FollowRequest();
            followRequest.token = token;
            return _dataAccessProvider.GetFollowersRecord(followRequest);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] FollowRequest followrequest)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateFollowsRecord(followrequest);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteConfirmed([FromBody] FollowRequest followrequest)
        {
            var data = _dataAccessProvider.GetFollowersRecord(followrequest);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteFollowsRecord(followrequest);
            return Ok();
        }
    }
}
