using ClientWeb.Helpers;
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
    public class CollectController : Controller
    {
        ICollectService service = null;

        public CollectController()
        {
            service = new CollectService();

        }
        // GET: Collect
        public ActionResult Index(string searchString)
        {

            var ev = service.GetAllEvent();
            List<CollectViewModel> eVM = new List<CollectViewModel>();
            
            foreach (var item in ev)
            {

                eVM.Add(
                        new CollectViewModel
                        {
                            CollectID = item.CollectID,
                            CollectName = item.CollectName,
                            CollectDescription = item.CollectDescription,
                            CollectType = item.CollectType,
                            



                        });
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                eVM = eVM.Where(m => m.CollectName.Contains(searchString)).ToList();

                return View(eVM);
            }

            return View(eVM);
        }

        // GET: Collect/Details/5
        public ActionResult Details(int id)
        {
            var colectDetail = (Collect)service.GetByIdCollect(id);
            CollectViewModel item = new CollectViewModel();
            item.CollectName = colectDetail.CollectName;
            item.CollectDescription = colectDetail.CollectDescription;
            item.CollectType = colectDetail.CollectType;
       


            return View(item);
        }

        // GET: Collect/Create
        public ActionResult Create()
        {
            var eventVM = new CollectViewModel();
            List<string> types = new List<string> { "Charity", "Food", "Collect" };
            eventVM.CollectTypes = types.ToSelectListItems();

            return View(eventVM);

        }

        // POST: Collect/Create
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Create(CollectViewModel e, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            // TODO: Add insert logic here
            //  e.EventImg = Image.FileName;

            Collect ev = new Collect
            {
                CollectID = e.CollectID,
                CollectName = e.CollectName,
                CollectDescription = e.CollectDescription,
                CollectType = e.CollectType,
              
            };

            service.AddCollect(ev);
            service.SaveChange();
            //Sms
            new SsmsService().SendSms(new Sms("+216"+ev.CollectType, "We have a donation for you"));

            return RedirectToAction("Index");

        }

        // GET: Collect/Edit/5
        public ActionResult Edit(int id)
        {
            var eventVM = new CollectViewModel();
            List<string> types = new List<string> { "Charity", "Food", "Collect" };
            eventVM.CollectTypes = types.ToSelectListItems();
            Collect e = (Collect   )service.GetByIdCollect(id);
            // Event ev = new Event
            CollectViewModel em = new CollectViewModel();

            {
                em.CollectName = e.CollectName;
                em.CollectDescription = e.CollectDescription;
                em.CollectType = e.CollectType;


            };
            return View(em);

        }

        // POST: Collect/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CollectViewModel collection)
        {
            var eventVM = new CollectViewModel();
            List<string> types = new List<string> { "Charity", "Food", "Collect" };
            eventVM.CollectTypes = types.ToSelectListItems();
            Collect e = (Collect)service.GetByIdCollect(id);

            e.CollectName = collection.CollectName;
            e.CollectDescription = collection.CollectDescription;
            e.CollectType = collection.CollectType;

            service.UpdateCollect(e);
            service.SaveChange();
            return RedirectToAction("Index");
        }

        // GET: Collect/Delete/5
        public ActionResult Delete(int id)
        {
            var collection = (Collect)service.GetByIdCollect(id);
            CollectViewModel item = new CollectViewModel();
            item.CollectName = collection.CollectName;
            item.CollectDescription = collection.CollectDescription;
            item.CollectType = collection.CollectType;
            return View(item);
        }

        // POST: Collect/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Collect ev = (Collect)service.GetByIdCollect(id);
            service.DeleteCollect(ev);
            service.SaveChange();
            return RedirectToAction("Index");
        }
    }
}
