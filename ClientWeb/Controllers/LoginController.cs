using ClientWeb.Models;
using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel LM)
        {
            //login
            string json = "{\"username\":\""+LM.username+"\",\"password\":\""+LM.password+"\"}";
            var response = "";
            try
            {
                var client = new JsonServiceClient("http://127.0.0.1:18080/pidev-web/api");
                response = client.Post<string>("/users/auth", json);
                user u = JsonConvert.DeserializeObject<user>(response);
                Session["User"] = u;
            }
            catch (Exception E)
            {
                response = "failed";
            }
            if (!response.ToLower().Equals("failed"))
                return RedirectToAction("Index", "CV");
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }
    }
}
