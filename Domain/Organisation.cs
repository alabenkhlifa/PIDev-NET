using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Organisation
    {
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string City { get; set; }
        [MaxLength(25)]
        public string Country { get; set; }
    }
}