﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    public class HospitalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hospitals
        public ActionResult Index()
        {
            return View(db.Hospitals.ToList());
        }

        // GET: Hospitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // GET: Hospitals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Adress,ImageUrl")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital);
        }

        // GET: Hospitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Adress,ImageUrl")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital);
        }

        // GET: Hospitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            db.Hospitals.Remove(hospital);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddDoctor(int id)
        {
            var hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }

            /*  var model = new AddDoctorViewModel
              {
                  HospitalId = id,
                  Doctors = db.Doctors.Where(d => d.HospitalId == null).ToList()
              };*/
            var model = new AddDoctorViewModel();
            model.HospitalId = id;
            model.Doctors=db.Doctors.Where(d=>d.HospitalId==null).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctor(AddDoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doctor = db.Doctors.Find(model.SelectedDoctorId);
                if (doctor == null)
                {
                    return HttpNotFound();
                }

                doctor.HospitalId = model.HospitalId;
                db.SaveChanges();

                return RedirectToAction("Details", new { id = model.HospitalId });
            }

            model.Doctors = db.Doctors.Where(d => d.HospitalId == null).ToList();
            return View(model);
        }


        public ActionResult RemoveDoctor(int? hospitalId, int? doctorId)
        {
            if (hospitalId == null || doctorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var doctor = db.Doctors.Find(doctorId);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            // Dissociate the doctor from the hospital
            doctor.HospitalId = null;
            db.SaveChanges();

            return RedirectToAction("Details", new { id = hospitalId });
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
