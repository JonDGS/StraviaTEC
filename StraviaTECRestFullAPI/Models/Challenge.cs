using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StraviaTECRestFullAPI.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Key]
        public string id_challenge { get; set; }
        public string name { get; set; }
        public DateTime startdate { get; set; }
        public DateTime finishdate { get; set; }
        public string activity_type { get; set; }
        public string id_organizer { get; set; }
        public string challengetype { get; set; }
        public int distancetravelled { get; set; }
    }
}
