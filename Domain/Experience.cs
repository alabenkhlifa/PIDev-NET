using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Experience
    {
        [Key]
        [Display(Name = "experience_id")]
        public int id { get; set; }
        [Display(Name = "experience_from")]
        [Column(TypeName = "Date")]
        public DateTime from { get; set; }
        [Display(Name = "experience_to")]
        [Column(TypeName = "Date")]
        public DateTime to { get; set; }
        [Display(Name = "experience_poste")]
        public string poste { get; set; }
        public string company { get; set; }
        [ForeignKey("cv")]
        public int cv_id { get; set; }
        public CV cv { get; set; }
    }
}