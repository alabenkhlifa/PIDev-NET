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
            if (Session["User"] != null)
                return View(CVS.GetAll());
            return RedirectToAction("Index", "Login");
        }

        // GET: CV/Details/5
        public ActionResult Details(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Index", "Login");
            else { 
                EducationService ES = new EducationService();
                CV c = CVS.GetById(id);

                CvModel CVVM = new CvModel();
                CVVM.candidate = c.candidate;
                CVVM.departement = c.departement;
                if (c.educations != null)
                    CVVM.educations = c.educations;
                if(c.experiences!=null)
                    CVVM.experiences = c.experiences.ToList();
                CVVM.hobbies = c.hobbies;
                if (c.languages != null)
                    CVVM.languages = c.languages.ToList();
                CVVM.linkedInLink = c.linkedInLink;
                CVVM.typeofjob = c.typeofjob;
                return View(CVVM);
            }
            
        }
    

        // GET: CV/Create
        public ActionResult Create()
        {
            ViewData["Candidate"] = Session["Candidate"];
            ViewData["EducationSession"] = Session["EducationSession"];
            ViewData["ExperienceSession"] = Session["ExperienceSession"];
            ViewData["LanguagesSession"] = Session["LanguagesSession"];
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
                List<Languages> LL = Session["LanguagesSession"] as List<Languages>;
                cv.educations = LE;
                cv.experiences = LEx;
                cv.candidate = C;
                cv.candidateId=C.id;
                cv.languages = LL;
                CVS.Add(cv);
                CVS.Commit();
                Session["Candidate"] = null;
                Session["EducationSession"] = null;
                Session["ExperienceSession"] = null;
                Session["Languages"] = null;
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
