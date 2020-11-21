using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    public class CreateChallengeObject
    {
        public string token { get; set; }
        public string name { get; set; }
        public string startdate { get; set; }
        public string finishdate { get; set; }
        public string activity_type { get; set; }
        public string challengetype { get; set; }
        public int distancetravelled { get; set; }
        
        
    }
}
