using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace StraviaTECRestFullAPI.Models
{
    [Table("athletes")]
    public class Athlete
    {
        public string id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public float age { get; set; }
        public string gender { get; set; }
    }
}
