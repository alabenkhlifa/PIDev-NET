using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Languages
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="language_name")]
        [MaxLength(25)]
        public string name { get; set; }
        [Display(Name = "language_level")]
        [MaxLength(25)]
        public string level { get; set; }
        [ForeignKey("cv")]
        public int cv_id { get; set; }
        public CV cv { get; set; }
    }
}