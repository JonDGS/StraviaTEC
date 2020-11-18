using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    [Table("follows")]
    public class Follows
    {
        [Key]
        public string id_follows { get; set; }
        public string id_athlete { get; set; }
        public string id_followee { get; set; }
    }
}
