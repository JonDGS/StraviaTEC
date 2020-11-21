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
        [HttpGet("GetTypes")]
        public IEnumerable<ActivityType> GetTypes()
        {
            return _dataAccessProvider.GetActivityTypes();
        }

        [HttpPost("{token}")]
        public IActionResult Create([FromBody] Activity activity, string token)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                activity.id_activity = obj.ToString();
                _dataAccessProvider.AddActivityRecord(activity, token);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetActivitySingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteActivityRecord(id);
            return Ok();
        }

        [HttpPost("uploadGPX")]
        public bool uploadGPX([FromQuery] string token, [FromQuery] string id, FileUPloadAPI gpx)
        {
            string result = FileManager.saveFile(gpx, token, id, "activity");

            if (!(result == null))
            {
                return true;
            }

            return false;
        }

        [HttpGet("GetGPX")]
        public IActionResult uploadGPX([FromQuery] string id_activity)
        {

            try
            {
                return new FileStreamResult(FileManager.getGPXActivity(id_activity), "application/octet-stream");
            }
            catch (Exception)
            {

                return NotFound("GPX was not found");
            }
        }

    }
}
