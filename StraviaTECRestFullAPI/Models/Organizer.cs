using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
   
    [Table("organizers")]
   
    public class Organizer
    {

        public string username { get; set; }
        public string passwordHash { get; set; }
        public string id { get; set; }
        public string photo = null;
        public string name { get; set; }
        public string lastname_1 { get; set; }
        public string lastname_2 { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
}
