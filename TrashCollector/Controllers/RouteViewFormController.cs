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
    public class RouteViewFormController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RouteViewForm
        public ActionResult Index()
        {
            var routeView = db.RouteView.Include(r => r.Customer).Include(r => r.Employee);
            return View(routeView.ToList());
        }

        // GET: RouteViewForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteViewModel routeViewModel = db.RouteView.Find(id);
            if (routeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(routeViewModel);
        }

        // GET: RouteViewForm/Create
        public ActionResult Create()
        {
            ViewBag.Customerid = new SelectList(db.Customer, "id", "FirstName");
            ViewBag.Employeeid = new SelectList(db.Employee, "id", "FirstName");
            return View();
        }

        // POST: RouteViewForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Customerid,Employeeid")] RouteViewModel routeViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RouteView.Add(routeViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customerid = new SelectList(db.Customer, "id", "FirstName", routeViewModel.Customerid);
            ViewBag.Employeeid = new SelectList(db.Employee, "id", "FirstName", routeViewModel.Employeeid);
            return View(routeViewModel);
        }

        // GET: RouteViewForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteViewModel routeViewModel = db.RouteView.Find(id);
            if (routeViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customerid = new SelectList(db.Customer, "id", "FirstName", routeViewModel.Customerid);
            ViewBag.Employeeid = new SelectList(db.Employee, "id", "FirstName", routeViewModel.Employeeid);
            return View(routeViewModel);
        }

        // POST: RouteViewForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Customerid,Employeeid")] RouteViewModel routeViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customerid = new SelectList(db.Customer, "id", "FirstName", routeViewModel.Customerid);
            ViewBag.Employeeid = new SelectList(db.Employee, "id", "FirstName", routeViewModel.Employeeid);
            return View(routeViewModel);
        }

        // GET: RouteViewForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteViewModel routeViewModel = db.RouteView.Find(id);
            if (routeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(routeViewModel);
        }

        // POST: RouteViewForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RouteViewModel routeViewModel = db.RouteView.Find(id);
            db.RouteView.Remove(routeViewModel);
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
