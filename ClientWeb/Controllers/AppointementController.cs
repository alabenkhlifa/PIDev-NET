using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return RedirectToAction("Index","CV");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
