using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StraviaTECRestFullAPI.Models
{
    [Table("athletebelongsgroup")]
    public class AthleteBelongsGroup
    {
        [Key]
        public string id { get; set; }
        public string id_athlete { get; set; }
        public string id_group { get; set; }
    }
}
