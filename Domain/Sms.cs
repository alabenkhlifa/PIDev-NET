using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sms
    {
        public String NumPhone { get; set; }
        public String MessagePhone { get; set; }

        public Sms()
        {

        }

        public Sms(String NumPhone, String MessagePhone)
        {
            this.NumPhone = NumPhone;
            this.MessagePhone = MessagePhone;
        }
    }
}
