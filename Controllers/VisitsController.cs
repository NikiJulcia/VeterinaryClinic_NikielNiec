using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinaryClinic.Models;
using VeterinaryClinic.Models.DBModels;
using VeterinaryClinic.Models.ViewModels;

namespace VeterinaryClinic.Controllers.Data
{
    public class VisitsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Visits
        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Patient).Include(v => v.Vet);
            return View(visits.ToList());
        }

        // GET: Visits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            Vet vet = new Vet();
            Patient patient = new Patient();
            foreach (Patient p in db.Patients)
            {
                if (p.Id == visit.PatientFK)
                {
                    patient = p;
                }
            }
            foreach (Vet v in db.Vets)
            {
                if (v.Id == visit.VetFK)
                {
                    vet = v;
                }
            }
            VisitPatientVet visitPatient = new VisitPatientVet(visit, patient, vet);
            return View(visitPatient);
        }

        // GET: Visits/Create
        public ActionResult Create()
        {
            ViewBag.PatientFK = new SelectList(db.Patients, "Id", "Name");
            ViewBag.VetFK = new SelectList(db.Vets, "Id", "Surname");
            return View();
        }

        // POST: Visits/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,PatientFK,VetFK,Diagnosis")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientFK = new SelectList(db.Patients, "Id", "Name", visit.PatientFK);
            ViewBag.VetFK = new SelectList(db.Vets, "Id", "Name", visit.VetFK);
            return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientFK = new SelectList(db.Patients, "Id", "Name", visit.PatientFK);
            ViewBag.VetFK = new SelectList(db.Vets, "Id", "Name", visit.VetFK);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,PatientFK,VetFK,Diagnosis")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientFK = new SelectList(db.Patients, "Id", "Name", visit.PatientFK);
            ViewBag.VetFK = new SelectList(db.Vets, "Id", "Name", visit.VetFK);
            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            Vet vet = new Vet();
            Patient patient = new Patient();
            foreach (Patient p in db.Patients)
            {
                if (p.Id == visit.PatientFK)
                {
                    patient = p;
                }
            }
            foreach (Vet v in db.Vets)
            {
                if (v.Id == visit.VetFK)
                {
                    vet = v;
                }
            }
            VisitPatientVet visitPatient = new VisitPatientVet(visit, patient, vet);
            return View(visitPatient);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
