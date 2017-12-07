using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Candidate
    {
        [Display(Name = "candidate_id")]
        [Key]
        public int id { get; set; }
        [Display(Name = "candidate_name")]
        [MaxLength(25)]
        public string name { get; set; }
        [Display(Name = "candidate_surname")]
        public string surname { get; set; }
        [Display(Name = "candidate_birthdate")]
        [Column(TypeName = "Date")]
        public DateTime birthDate { get; set; }
        [Display(Name = "candidate_age")]
        public int age { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string sex { get; set; }

    }
}