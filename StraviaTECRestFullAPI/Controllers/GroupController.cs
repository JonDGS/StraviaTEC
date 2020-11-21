using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.DataAccess;
using StraviaTECRestFullAPI.Models;
using StraviaTECRestFullAPI.Utilities;



namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public GroupController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return _dataAccessProvider.GetGroupRecords();
        }

        [HttpPost("{token}")]
        public IActionResult Create([FromBody] Group group, string token)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                group.id_group = obj.ToString();
                _dataAccessProvider.AddGroupRecord(group, token);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{token}")]
        public List<Group> DetailsByToken(string token)
        {
            return _dataAccessProvider.GetGroupByToken(token);
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Group  group)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateGroupRecord(group);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetGroupSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteGroupRecord(id);
            return Ok();
        }
    }
}
