using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.DataAccess;
using StraviaTECRestFullAPI.Models;
using System;
using System.Collections.Generic;

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    public class AthleteGroupsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public AthleteGroupsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<AthleteBelongsGroup> Get()
        {
            return _dataAccessProvider.GetAthleteBelongsGroupRecords();
        }

        [HttpPost("{token}")]
        public IActionResult Create([FromBody] AthleteBelongsGroup athletebelongsgroup, string token)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                athletebelongsgroup.id = obj.ToString();
                _dataAccessProvider.AddAthleteBelongsGroupRecord(athletebelongsgroup, token);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public AthleteBelongsGroup DetailsByToken(string id)
        {
            return _dataAccessProvider.GetAthleteBelongsGroupSingleRecord(id);
        }
        [HttpPut]
        public IActionResult Edit([FromBody] AthleteBelongsGroup athletebelongsgroup)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateAthleteBelongsGroupRecord(athletebelongsgroup);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetAthleteBelongsGroupSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteAthleteBelongsGroupRecord(id);
            return Ok();
        }
        [HttpGet("GetAthletesGroups/{token}")]
        public List<Group> DetailGroupsJoined(string token)
        {
            return _dataAccessProvider.GetGroupsByAthleteToken(token);
        }
    }
}
