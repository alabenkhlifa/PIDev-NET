using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Address
    {
        [MaxLength(25)]
        public string country { get; set; }
        [MaxLength(25)]
        public string address { get; set; }
        [MaxLength(25)]
        public string city { get; set; }
    }
}