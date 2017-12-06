using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientWeb.Models
{
    public class CandidateModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthDate { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string sex { get; set; }

    }
}