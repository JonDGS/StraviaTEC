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

        [HttpPost("{token}")]
        public IActionResult Create([FromBody] Race race,string token)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                race.id_race = obj.ToString();
                _dataAccessProvider.AddRaceRecord(race, token);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{token}")]
        public List<Race> DetailsByToken(string token)
        {
            Console.WriteLine("Holaaa");
            return _dataAccessProvider.GetRacesByToken(token);
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
