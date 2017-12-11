using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Service
{
    public class SsmsService 
    {
        public static String accountSid = "ACeec8f23a9daf546ebf9ff23f1041890e";
        public static String authToken = "34c877f2b81d820acbd26bdb2ca378da";

        public void SendSms(Sms sms)
        {
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
            to: new PhoneNumber(sms.NumPhone),
            from: new PhoneNumber("+12517322684"),
            body: sms.MessagePhone);
        }
    }
}
