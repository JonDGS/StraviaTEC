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
        public List<Athlete> searchTerm()
        {

            string searchTerm = Request.Form["term"].ToString();

            string password = Request.Form["password"];

            List<Athlete> test = null;

            if (password.Equals("12345"))
            {
                test = Connector.searchAthleteBasedOnTerm(searchTerm);
            }

            return test;
        }
    }
}
