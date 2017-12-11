using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Address
    {
        [StringLength(30)]
        public string country { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        [StringLength(30)]
        public string city { get; set; }
    }
}