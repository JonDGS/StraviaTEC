using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    public class OnlineUser
    {
        public string id_athlete_fk { get; set; }
        public string id_organizer_fk { get; set; }
        [Key]
        public string token { get; set; }
        public DateTime entry { get; set; }
        public DateTime expiryDate { get; set; }

    }
}
