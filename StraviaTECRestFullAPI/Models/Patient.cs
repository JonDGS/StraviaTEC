using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
   
    [Table("patients")]
   
    public class Patient
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public float age { get; set; }
        public string gender { get; set; }
    }
}
