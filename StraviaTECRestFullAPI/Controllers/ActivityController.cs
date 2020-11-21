using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.DataAccess;
using StraviaTECRestFullAPI.Models;
using StraviaTECRestFullAPI.Utilities;
using System;
using System.Collections.Generic;

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public ActivityController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _dataAccessProvider.GetActivityRecords();
        }

        [HttpPost("{token}")]
        public IActionResult Create([FromBody] Activity activity, string token)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                activity.id_activity = obj.ToString();
                _dataAccessProvider.AddActivityRecord(activity,token);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Activity Details(string id)
        {
            return _dataAccessProvider.GetActivitySingleRecord(id);
        }
        [HttpGet("GetActivityBy/{token}")]
        public List<Activity> activityDetailsByToken(string token)
        {
            return _dataAccessProvider.GetActivityByToken(token);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateActivityRecord(activity);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{token}")]
        public IActionResult DeleteConfirmed(string token)
        {
            var data = _dataAccessProvider.GetActivitySingleRecord(token);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteActivityRecord(token);
            return Ok();
        }

    }
}
