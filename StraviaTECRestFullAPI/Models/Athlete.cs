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
        public string photo = null;
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


        public Athlete(string username, string passwordhash, string id, string photo, string name, string lastname_1, string lastname_2, string country, string state, string city,
           string nationality, int age, int birthday, int birthmonth, int birthyear)
        {
            this.username = username;
            this.passwordhash = passwordhash;
            this.id = id;
            this.photo = photo;
            this.name = name;
            this.lastname_1 = lastname_1;
            this.lastname_2 = lastname_2;
            this.country = country;
            this.state = state;
            this.city = city;
            this.nationality = nationality;
            this.age = age;
            this.birthday = birthday;
            this.birthmonth = birthmonth;
            this.birthyear = birthyear;
        }
    }
}
