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
    public class AthleteEnrollmentController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public AthleteEnrollmentController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet("ChallengeEnrollment")]
        public IEnumerable<AthleteEnrollsChallenge> GetChallengeEnrollment()
        {
            return _dataAccessProvider.GetChallengeEnrollmentRecords();
        }

        [HttpPost("ChallengeEnrollment/{token}")]
        public IActionResult CreateChallengeEnrollment([FromBody] AthleteEnrollsChallenge challengeEnrollment, string token)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddChallengeEnrollmentRecord(challengeEnrollment, token);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("ChallengeEnrollment/{id}")]
        public AthleteEnrollsChallenge DetailsAthleteEnrollsChallenge(int id)
        {
            return _dataAccessProvider.GetChallengeEnrollmentSingleRecord(id);
        }

        [HttpPut("ChallengeEnrollment")]
        public IActionResult EditAthleteEnrollsChallenge([FromBody] AthleteEnrollsChallenge challengeEnrollment)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateChallengeEnrollmentRecord(challengeEnrollment);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("ChallengeEnrollment/{id}")]
        public IActionResult DeleteAthleteEnrollsChallengeConfirmed(int id)
        {
            var data = _dataAccessProvider.GetChallengeEnrollmentSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteChallengeEnrollmentRecord(id);
            return Ok();
        }
        [HttpGet("ChallengeEnrollment/GetChallenges/{token}")]
        public List<Challenge> DetailChallengeEnrolled(string token)
        {
            return _dataAccessProvider.GetChallengeEnrollmentByToken(token);
        }

        [HttpGet("RaceEnrollment")]
        public IEnumerable<AthleteEnrollsRace> GetRaceEnrollment()
        {
            return _dataAccessProvider.GetRaceEnrollmentRecords();
        }

        [HttpPost("RaceEnrollment/{token}")]
        public IActionResult CreateRaceEnrollment([FromBody] AthleteEnrollsRace raceEnrollment, string token)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddRaceEnrollmentRecord(raceEnrollment, token);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("RaceEnrollment/{id}")]
        public AthleteEnrollsRace DetailsAthleteEnrollsRace(int id)
        {
            return _dataAccessProvider.GetRaceEnrollmentSingleRecord(id);
        }

        [HttpGet("RaceEnrollment/GetRaces/{token}")]
        public List<Race> DetailRaceEnrolled(string token)
        {
            return _dataAccessProvider.GetRaceEnrollmentByToken(token);
        }

        [HttpPut("RaceEnrollment")]
        public IActionResult EditAthleteEnrollsRace([FromBody] AthleteEnrollsRace RaceEnrollment)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateRaceEnrollmentRecord(RaceEnrollment);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("RaceEnrollment/{id}")]
        public IActionResult DeleteAthleteEnrollsRaceConfirmed(int id)
        {
            var data = _dataAccessProvider.GetRaceEnrollmentSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteRaceEnrollmentRecord(id);
            return Ok();
        }

    }
}
