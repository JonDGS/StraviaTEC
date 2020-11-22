using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.Models;
using StraviaTECRestFullAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using StraviaTECRestFullAPI.DataAccess;
using System.IO;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public ChallengesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpPut("CreateChallenge")]
        public bool createChallenge([FromBody] CreateChallengeObject createChallengeObject)
        {

            return Connector.createChallenge(createChallengeObject.token, createChallengeObject.name, createChallengeObject.startdate, createChallengeObject.finishdate,
                createChallengeObject.activity_type, createChallengeObject.challengetype, createChallengeObject.distancetravelled);
        }

        [HttpGet("Challenges")]
        public List<FoundChallenge> getChallenges()
        {
            List<FoundChallenge> found = Connector.getChallenges();

            return found;
        }
        [HttpGet("{token}")]
        public List<Challenge> getChallengesByOrganizerToken(string token)
        {
            var challengesList = _dataAccessProvider.GetChallengeByOrganizerToken(token);

            return challengesList;
        }
        [HttpGet("GetChallengeById/{id}")]
        public Challenge getChallengesByID(string id)
        {
            var challengesList = _dataAccessProvider.GetChallengeSingleRecord(id);

            return challengesList;
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetChallengeSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteChallengeRecord(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateChallengeRecord(challenge)    ;
                return Ok();
            }
            return BadRequest();
        }
    }
}
