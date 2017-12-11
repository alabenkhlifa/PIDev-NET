using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Appointement
    {
        [Key]
        public int id { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("candidate")]
        public int candidateid { get; set; }

        public virtual Candidate candidate { get; set; }
    }
}
