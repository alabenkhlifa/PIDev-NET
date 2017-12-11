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
        AppointementService AS = new AppointementService();
        
        // GET: CV
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                var candlist = new List<int>();
                var applist = AS.GetAll().ToList();
                foreach(var app in applist)
                {
                    candlist.Add(app.candidateid);
                }
                ViewData["AcceptedList"] = candlist;
                return View(CVS.GetAll());
            }
            return RedirectToAction("Index", "Login");
        }

        // GET: CV/Details/5
        public ActionResult Details(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Index", "Login");
            else {
                var applist = AS.GetAll().ToList();
                var candlist = new List<int>();
                foreach (var app in applist)
                {
                    candlist.Add(app.candidateid);
                }
                bool approuved = false;
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
                if (candlist.Contains(c.candidateId))
                    approuved = true;
                ViewBag.approuved = approuved;
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

        //GET : CV/Refuse/5
        //id du candidat
        public ActionResult Refuse(int id)
        {
            LanguageService LS = new LanguageService();
            EducationService ES = new EducationService();
            ExperienceService EXS = new ExperienceService();
            CandidateService CAS = new CandidateService();
            CV cv = CVS.GetAll().Where(c => (c.candidate.id == id)).FirstOrDefault() ;
            var listOfLanguages = cv.languages;
            var listOfEducations = cv.educations;
            var listOfExperiences = cv.experiences;
            if (listOfLanguages != null) { 
                foreach(var l in listOfLanguages)
                {
                    LS.Delete(x=>x.id==l.id);
                }
                LS.Commit();
            }
            if (listOfEducations != null)
            {
                foreach (var e in listOfEducations)
                {
                    ES.Delete(x => x.id == e.id);
                }
                ES.Commit();
            }
            if (listOfExperiences != null)
            {
                foreach (var ex in listOfExperiences)
                {
                    EXS.Delete(x => x.id == ex.id);
                }
                EXS.Commit();
            }
            Candidate candidate = CAS.GetById(cv.candidate.id);
            CAS.Delete(candidate);
            CAS.Commit();
            return RedirectToAction("Index", "CV");
        }
    }
}
