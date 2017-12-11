using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Collect
    {
        //[Display(Name = "collect_id")]
        [Key]
        public int CollectID { get; set; }
        // public byte[] EventImg { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Picture")]
        public string CollectImg { get; set; }
        [Required(ErrorMessage = "name required")]
        public string CollectName { get; set; }
        [DataType(DataType.MultilineText)]
        public string CollectDescription { get; set; }
        public string CollectType { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CollectDateD { get; set; }//Date début

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CollectTime { get; set; }// Date fin
        [Display(Name = "NB participants")]
        public int NombreParticiapant { get; set; }




    }
}
