using StraviaTECRestFullAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    public class FoundAthlete
    {

        public string username { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public int activities { get; set; }
        public int age {get; set;}

        public FoundAthlete(string username, string country, string state, int age)
        {
            this.username = username;
            this.country = country;
            this.state = state;
            this.age = age;
        }

        public void calculateAmountOfActivities()
        {
            this.activities = Connector.getNumberOfActivitiesByAthlete(username);
        }

    }
}
