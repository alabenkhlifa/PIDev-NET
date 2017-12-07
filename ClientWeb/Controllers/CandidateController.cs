using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    public class CandidateController : Controller
    {
        public CandidateService CS = new CandidateService();
        // GET: Candidate
        public ActionResult Index()
        {
            return View(CS.GetAll());
        }

        // GET: Candidate/Details/5
        public ActionResult Details(int id)
        {
            Candidate c = CS.GetById(id);
            return View(c);
        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidate/Create
        [HttpPost]
        public ActionResult Create(Candidate C)
        {
            try
            {
                // TODO: Add insert logic here
                CS.Add(C);
                CS.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidate/Edit/5
        public ActionResult Edit(int id)
        {
            
            Candidate c = CS.GetById(id);
            
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // POST: Candidate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id , Candidate C)
        {
            try
            {
                // TODO: Add update logic here
                Candidate oldCandidate = CS.GetById(id);
                oldCandidate = C;
                CS.Update(oldCandidate);
                //Data.Context CT = new Data.Context();
                //CT.SaveChanges();
                CS.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
                //return RedirectToAction("Index");
            }
        }

        // GET: Candidate/Delete/5
        public ActionResult Delete(int id)
        {            
            return View(CS.GetById(id));
        }

        // POST: Candidate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CS.Delete(CS.GetById(id));
                CS.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
