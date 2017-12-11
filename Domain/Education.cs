using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Education
    {
        [Display(Name = "education_id")]
        [Key]
        public int id { get; set; }
        [Display(Name = "education_from")]
        [Column(TypeName = "Date")]
        public DateTime from { get; set; }
        [Display(Name = "education_to")]
        [Column(TypeName = "Date")]
        public DateTime to { get; set; }
        [Display(Name = "education_title")]
        [StringLength(30)]
        public string title { get; set; }
        public Organisation organisation { get; set; }


    }
}