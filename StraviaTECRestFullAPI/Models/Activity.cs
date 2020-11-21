using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StraviaTECRestFullAPI.Models
{
    [Table("activity")]
    public class Activity
    {
        public string clasification { get; set;}
        public int closing_time { get; set;}
        public int starting_time { get; set;}
        public int duration { get; set;}
        public int d_day { get; set;}
        public int d_month { get; set;}
        public int d_year { get; set;}
        public int distance { get; set;}
        public string text { get; set;}
        public string id_athlete { get; set;}
        public string id_type { get; set;}
        [Key]
        public string id_activity { get; set;}


    }
}
