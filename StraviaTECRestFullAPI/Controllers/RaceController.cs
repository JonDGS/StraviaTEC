using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.DataAccess;
using StraviaTECRestFullAPI.Models;
using StraviaTECRestFullAPI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    public class RaceController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public RaceController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Race> Get()
        {
            return _dataAccessProvider.GetRaceRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Race race)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                race.id_race = obj.ToString();
                _dataAccessProvider.AddRaceRecord(race);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Race Details(string id)
        {
            return _dataAccessProvider.GetRaceSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Race race)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateRaceRecord(race);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetRaceSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteRaceRecord(id);
            return Ok();
        }
    }
}
