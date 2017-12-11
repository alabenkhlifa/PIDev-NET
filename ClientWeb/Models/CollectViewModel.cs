using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Models
{
    public class CollectViewModel
    {
        //[Display(Name = "Collect_id")]
        [Key]
        public int CollectID { get; set; }
        // public byte[] EventImg { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "photo")]
        public string CollectImg { get; set; }
        [Required(ErrorMessage = "name required")]
        public string CollectName { get; set; }
        [DataType(DataType.MultilineText), Display(Name = "Description")]
        public string CollectDescription { get; set; }
        [ Display(Name = "Phone number")]
        public string CollectType { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CollectDateD { get; set; }//Date début
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CollectTime { get; set; }// Date fin
        [Display(Name = "NB participants")]
        public int NombreParticiapant { get; set; }

        public IEnumerable<SelectListItem> CollectTypes { get; set; }

    }
}