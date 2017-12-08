using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    public class EducationController : Controller
    {
        EducationService ES = new EducationService();
        List<Education> LE = new List<Education>();
        // GET: Education
        public ActionResult Index()
        {
            return View(Session["EducationSession"] as List<Education>);
        }

        // GET: Education/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Education/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Education/Create
        [HttpPost]
        public ActionResult Create(Education education)
        {
            try
            {
                if (Session["EducationSession"] == null) { 
                    LE.Add(education);
                    Session["EducationSession"] = LE;
                }
                else
                {
                    LE = Session["EducationSession"] as List<Education>;
                    LE.Add(education);
                    Session["EducationSession"] = LE;
                }

                return RedirectToAction("Create", "CV");
            }
            catch
            {
                return View();
            }
        }

        // GET: Education/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Education/Edit/5
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

        // GET: Education/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Education/Delete/5
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
