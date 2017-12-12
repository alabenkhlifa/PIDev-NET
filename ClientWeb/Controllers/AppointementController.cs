using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    public class AppointementController : Controller
    {
        AppointementService AS = new AppointementService();
        // GET: Appointement
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appointement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CandidateService CS = new CandidateService();
                string appointementDateString = collection.Get("appdate");
                string candidateid = collection.Get("candidateid");
                Candidate c = CS.GetById(Convert.ToInt32(candidateid));
                string[] x = appointementDateString.Split('/');
                DateTime appointementDate = 
                    new DateTime(Convert.ToInt32(x[2]), Convert.ToInt32(x[1]), Convert.ToInt32(x[0]),8,30,0);
                Appointement appointement = new Appointement()
                {
                    candidateid = c.id,
                    date = appointementDate
                };
                AS.Add(appointement);
                AS.Commit();
                sendEmail(c.email, appointementDate);
                return RedirectToAction("Index","CV");
            }
            catch
            {
                return View();
            }
        }

        public void sendEmail(string Email,DateTime when)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("hu93ed@gmail.com");

            var toaddress = new MailAddress(Email);

            msg.To.Add(toaddress);
            msg.Subject = "Resumee Accepted ! ";
            msg.Body = "Interview On "+when;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("hu93ed@gmail.com", "Ala963348501");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                msg.Dispose();
            }
        }
        
    }
}
