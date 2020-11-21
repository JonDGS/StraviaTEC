using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StraviaTECRestFullAPI.Models
{
    [Table("activity_type")]
    public class ActivityType
    {
        public string name { get; set; }
        [Key]
        public string id_type { get; set; }
    }
}
