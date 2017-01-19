using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PricingFormController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PricingForm
        public ActionResult Index()
        {
            return View(db.Price.ToList());
        }

        // GET: PricingForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PricingModel pricingModel = db.Price.Find(id);
            if (pricingModel == null)
            {
                return HttpNotFound();
            }
            return View(pricingModel);
        }

        // GET: PricingForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PricingForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Service,Price")] PricingModel pricingModel)
        {
            if (ModelState.IsValid)
            {
                db.Price.Add(pricingModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pricingModel);
        }

        // GET: PricingForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PricingModel pricingModel = db.Price.Find(id);
            if (pricingModel == null)
            {
                return HttpNotFound();
            }
            return View(pricingModel);
        }

        // POST: PricingForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Service,Price")] PricingModel pricingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricingModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pricingModel);
        }

        // GET: PricingForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PricingModel pricingModel = db.Price.Find(id);
            if (pricingModel == null)
            {
                return HttpNotFound();
            }
            return View(pricingModel);
        }

        // POST: PricingForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PricingModel pricingModel = db.Price.Find(id);
            db.Price.Remove(pricingModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
