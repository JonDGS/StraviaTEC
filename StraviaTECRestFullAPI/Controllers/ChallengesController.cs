using Microsoft.AspNetCore.Mvc;
using StraviaTECRestFullAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTECRestFullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        [HttpPut("CreateChallenge")]
        public bool createChallenge()
        {
            string token = Request.Form["token"].ToString();
            string name = Request.Form["name"].ToString();
            string startdate = Request.Form["startdate"].ToString();
            string finishdate = Request.Form["finishdate"].ToString();
            string activity_type = Request.Form["activity_type"].ToString();
            string challengetype = Request.Form["challengetype"].ToString();
            int distancetravelled = int.Parse(Request.Form["distancetravelled"].ToString());

            return Connector.createChallenge(token, name, startdate, finishdate, activity_type, challengetype, distancetravelled);
        }
    }
}
