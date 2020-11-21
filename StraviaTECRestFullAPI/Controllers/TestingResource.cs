using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECRestFullAPI.Utilities;
using StraviaTECRestFullAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingResource : ControllerBase
    {
        [HttpGet("TestingSearch")]
        public List<FoundAthlete> searchTerm()
        {

            string searchTerm = Request.Form["term"].ToString();

            string password = Request.Form["password"];

            List<FoundAthlete> test = null;

            if (password.Equals("12345"))
            {
                test = Connector.searchAthleteBasedOnTerm(searchTerm);
            }

            return test;
        }

        [HttpGet("CountActivies")]
        public int countActivities()
        {

            string user = Request.Form["user"].ToString();

            string password = Request.Form["password"];

            int test = -1;

            if (password.Equals("12345"))
            {
                test = Connector.getNumberOfActivitiesByAthlete(user);
            }

            return test;
        }

        [HttpPost("CreateChallenge")]
        public bool createChallenge()
        {
            string token = Request.Form["token"];
            string name = Request.Form["name"];
            string startDate = Request.Form["startDate"];
            string finishDate = Request.Form["finishDate"];
            string activity_type = Request.Form["activity_type"];

            return Connector.createChallenge(token, name, startDate, finishDate, activity_type);
        }
    }
}
