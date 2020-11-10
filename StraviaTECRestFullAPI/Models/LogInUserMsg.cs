using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    public class LogInUserMsg
    {
        public string username { get; set; }
        public string passwordHash { get; set; }
    }
}
