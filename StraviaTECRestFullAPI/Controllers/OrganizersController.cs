using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.DataAccess;
using StraviaTECRestFullAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    public class organizersController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public organizersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Organizer> Get()
        {
            return _dataAccessProvider.GetOrganizerRecords();
        }

        [HttpGet]
        [Route("GetNames")]
        public Array GetNames()
        {
           return _dataAccessProvider.GetOrganizersName();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                organizer.id = obj.ToString();
                _dataAccessProvider.AddOrganizerRecord(organizer);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Organizer Details(string id)
        {
            return _dataAccessProvider.GetOrganizerSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateOrganizerRecord(organizer);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetOrganizerSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteOrganizerRecord(id);
            return Ok();
        }
    }
}
