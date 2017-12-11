using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Languages
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="language_name")]
        [StringLength(20)]
        public string name { get; set; }
        [Display(Name = "language_level")]
        [StringLength(6)]
        public string level { get; set; }
        [ForeignKey("cv")]
        public int cv_id { get; set; }
        public CV cv { get; set; }
    }
}