using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    public class FoundChallenge
    {
        public string name { get; set; }
        public int period { get; set; }
        public string challenge { get; set; }
        public string activity_type { get; set; }
        public int distancetravelled { get; set; }
        public string id_challenge { get; set; }

        public FoundChallenge(string name, int period, string challenge, string activity_type, int distancetravelled, string id_challenge)
        {
            this.name = name;
            this.period = period;
            this.challenge = challenge;
            this.activity_type = activity_type;
            this.distancetravelled = distancetravelled;
            this.id_challenge = id_challenge;
        }
    }
}
