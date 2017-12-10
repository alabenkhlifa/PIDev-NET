using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientWeb.Models
{
    public class LoginModel
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string  password { get; set; }
    }
}