using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Organisation
    {
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(30)]
        public string Country { get; set; }
    }
}