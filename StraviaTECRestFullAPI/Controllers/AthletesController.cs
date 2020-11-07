using Microsoft.AspNetCore.Cors;
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
    public class AthletesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public AthletesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Athlete> Get()
        {
            return _dataAccessProvider.GetAthleteRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                athlete.id = obj.ToString();
                _dataAccessProvider.AddAthleteRecord(athlete);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Athlete Details(string id)
        {
            return _dataAccessProvider.GetAthleteSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateAthleteRecord(athlete);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetAthleteSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteAthleteRecord(id);
            return Ok();
        }

    }
}
