using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StraviaTECRestFullAPI.Models
{
    [Table("groups")]
    public class Group
    {
        [Key]
        public string id_group { get; set; }
        public string name { get; set; }
        public string admin { get; set; }
        public string id_organizer{ get; set; }

    }
}
