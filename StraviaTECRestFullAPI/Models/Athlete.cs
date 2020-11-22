using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StraviaTECRestFullAPI.Models
{
    [Table("athletes")]
    public class Athlete
    {
        
        public string username { get; set; }
        public string passwordhash { get; set; }
        public string id { get; set; }
        public string photo { get; set;}
        public string name { get; set; }
        public string lastname_1{ get; set; }
        public string lastname_2 { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string nationality { get; set; }
        public int age { get; set; }
        public int birthday { get; set; }
        public int birthmonth { get; set; }
        public int birthyear { get; set; }
    }
}
