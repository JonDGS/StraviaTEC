using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StraviaTECRestFullAPI.Models
{
    [Table("racehassponsor")]
    public class RaceSponsorship
    {
        [Key]
        public string id { get; set; }
        public string id_sponsor { get; set; }
        public string id_race{ get; set; }
    }
}
