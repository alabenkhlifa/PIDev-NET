using ClientWeb.Models;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    public class CVController : Controller
    {
        CVService CVS = new CVService();
        CandidateService CS = new CandidateService();
        // GET: CV
        public ActionResult Index()
        {
            return View(CVS.GetAll());
        }

        // GET: CV/Details/5
        public ActionResult Details(int id)
        {
            EducationService ES = new EducationService();
            CV c = CVS.GetById(id);

            CvModel CVVM = new CvModel();
            CVVM.candidate = c.candidate;
            CVVM.departement = c.departement;
            //List<Education> educs = new List<Education>();
            //foreach(var idedu in c.educations)
            //{
            //    educs.Add(ES.GetById(idedu.id));
            //}
            CVVM.educations = c.educations;
            CVVM.experiences = c.experiences.ToList();
            CVVM.hobbies = c.hobbies;
            CVVM.languages = c.languages.ToList();
            CVVM.linkedInLink = c.linkedInLink;
            CVVM.typeofjob = c.typeofjob;
            

            return View(CVVM);
        }

        // GET: CV/Create
        public ActionResult Create()
        {
            ViewData["Candidate"] = Session["Candidate"];
            ViewData["EducationSession"] = Session["EducationSession"];
            ViewData["ExperienceSession"] = Session["ExperienceSession"];
            return View();
        }

        // POST: CV/Create
        [HttpPost]
        public ActionResult Create(CV cv)
        {
            try
            {
                Candidate C = Session["Candidate"] as Candidate;
                List<Education> LE = Session["EducationSession"] as List<Education>;
                List<Experience> LEx = Session["ExperienceSession"] as List<Experience>;
                cv.educations = LE;
                cv.experiences = LEx;
                cv.candidate = C;
                cv.candidateId=C.id;
                CVS.Add(cv);
                CVS.Commit();
                Session["Candidate"] = null;
                Session["EducationSession"] = null;
                Session["ExperienceSession"] = null;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CV/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CV/Edit/5
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

        // GET: CV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CV/Delete/5
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
