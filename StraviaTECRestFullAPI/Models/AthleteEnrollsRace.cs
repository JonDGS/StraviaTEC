using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    [Table("athleteenrollsrace")]
    public class AthleteEnrollsRace
    {
        public string id_race { get; set; }
        public string id_athlete { get; set; }
        public string status { get; set; }
        public string receipt { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

    }
}
