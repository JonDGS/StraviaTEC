using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    public class OnlineUser
    {
        public string id;
        public string token;
        public string type;
        public DateTime entry;
        public DateTime expiryDate;

    }
}
