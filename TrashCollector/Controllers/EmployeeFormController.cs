﻿using System;
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
    public class EmployeeFormController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeeForm
        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        // GET: EmployeeForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.Employee.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // GET: EmployeeForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstName,LastName,Phone,Email,Street,Steet_2,Zip,City,State")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employeeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeModel);
        }

        // GET: EmployeeForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.Employee.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // POST: EmployeeForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Phone,Email,Street,Steet_2,Zip,City,State")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }

        // GET: EmployeeForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = db.Employee.Find(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // POST: EmployeeForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModel employeeModel = db.Employee.Find(id);
            db.Employee.Remove(employeeModel);
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
