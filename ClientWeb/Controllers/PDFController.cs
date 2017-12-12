using ClientWeb.Models;
using Domain;
using SelectPdf;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    public class PDFController : Controller
    {
        CV resume;
        CVService CVS = new CVService();
        // GET: PDF
        public ActionResult Index()
        {
            //var currentcandidate = Session["currentCandidate"] as Candidate;
            var cv = CVS.GetAll().Last();
            //if(null==currentcandidate)
            //    return RedirectToAction("Index", "Login");
            //if (currentcandidate.name.Equals(cv.candidate.name))
            return View(cv);
            //return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Index(FormCollection FC)
        {
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url 
            PdfDocument doc = converter.ConvertUrl("http://localhost:8009/PDF");
            // save pdf document 
            byte[] pdf = doc.Save();

            // close pdf document 
            doc.Close();

            // return resulted pdf document 
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "CV.pdf";
            return fileResult;
            //return RedirectToAction("Index");
        }

        // GET: PDF/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PDF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDF/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PDF/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PDF/Edit/5
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

        // GET: PDF/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PDF/Delete/5
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
        public ActionResult save()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult save(CV cv)
        {
            CVService CVS = new CVService();
            List<Education> LE = new List<Education>();
            List<Experience> LEx = new List<Experience>();
            List<Languages> LL = new List<Languages>();
            Candidate C = new Candidate();
            C = Session["Candidate"] as Candidate;
            LE = Session["EducationSession"] as List<Education>;
            LEx = Session["ExperienceSession"] as List<Experience>;
            LL = Session["LanguagesSession"] as List<Languages>;
            cv.educations = LE;
            cv.experiences = LEx;
            cv.candidate = C;
            cv.languages = LL;
            resume = cv;
            return RedirectToAction("Index");
            //CVS.Add(cv);
            //CVS.Commit();
            //Session.Abandon();
            //return null;
        }
    }
}
