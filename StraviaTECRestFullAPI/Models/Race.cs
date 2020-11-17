using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    [Table("race")]
    public class Race
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public int cost { get; set; }

        public string gpx { get; set; }

        public string country { get; set; }
        
        [Key]
        public string id_race { get; set; }

        public string id_organizer { get; set; }
    }
}
