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
    public class SponsorshipController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public SponsorshipController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet("RaceSponsorship")]
        public IEnumerable<RaceSponsorship> Get()
        {
            return _dataAccessProvider.GetRaceSponsorshipRecords();
        }

        [HttpPost("RaceSponsorship")]
        public IActionResult Create([FromBody] RaceSponsorship rsponsorship)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                rsponsorship.id = obj.ToString();
                _dataAccessProvider.AddRaceSponsorshipRecord(rsponsorship);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("RaceSponsorship/{id}")]
        public RaceSponsorship Details(string id)
        {
            return _dataAccessProvider.GetRaceSponsorshipSingleRecord(id);
        }
        [HttpGet("RaceSponsorship/{idrace}")]
        public List<RaceSponsorship> GetSponsorshipByIdRace(string idrace)
        {
            return _dataAccessProvider.GetRaceSponsorshipByIDRace(idrace);
        }

        [HttpPut("RaceSponsorship")]
        public IActionResult Edit([FromBody] RaceSponsorship rsponsorship)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateRaceSponsorshipRecord(rsponsorship);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("RaceSponsorship/{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetRaceSponsorshipSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteRaceSponsorshipRecord(id);
            return Ok();
        }
        [HttpGet("ChallengeSponsorship")]
        public IEnumerable<ChallengeSponsorship> GetChS()
        {
            return _dataAccessProvider.GetChallengeSponsorshipRecords();
        }

        [HttpPost("ChallengeSponsorship")]
        public IActionResult Create([FromBody] ChallengeSponsorship chsponsorship)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                chsponsorship.id = obj.ToString();
                _dataAccessProvider.AddChallengeSponsorshipRecord(chsponsorship);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("ChallengeSponsorship/{id}")]
        public ChallengeSponsorship DetailsChallenges(string id)
        {
            return _dataAccessProvider.GetChallengeSponsorshipSingleRecord(id);
        }
        [HttpGet("ChallengeSponsorship/{idrace}")]
        public List<ChallengeSponsorship> GetSponsorshipByIdChallenge(string idch)
        {
            return _dataAccessProvider.GetChallengeSponsorshipByIDChallenge(idch);
        }

        [HttpPut("ChallengeSponsorship")]
        public IActionResult Edit([FromBody] ChallengeSponsorship chsponsorship)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateChallengeSponsorshipRecord(chsponsorship);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("ChallengeSponsorship/{id}")]
        public IActionResult DeleteConfirmedChallenge(string id)
        {
            var data = _dataAccessProvider.GetChallengeSponsorshipSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteChallengeSponsorshipRecord(id);
            return Ok();
        }


    }
}
