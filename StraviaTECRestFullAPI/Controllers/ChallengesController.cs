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
    }
}
