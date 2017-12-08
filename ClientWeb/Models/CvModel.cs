using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWeb.Models
{
    public class CvModel
    {
        public IEnumerable<Education> educations { get; set; }
        public IEnumerable<Experience> experiences { get; set; }
        public IEnumerable<Languages> languages { get; set; }
        public string hobbies { get; set; }
        public string linkedInLink { get; set; }
        public string departement { get; set; }
        public string typeofjob { get; set; }
        public Candidate candidate { get; set; }
    }
}