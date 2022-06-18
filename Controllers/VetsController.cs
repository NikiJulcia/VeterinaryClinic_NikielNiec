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

namespace VeterinaryClinic.Controllers
{

    public class VetsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        public ActionResult Index()
        {
            return View(db.Vets.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,PhoneNumber,Specjalization,Sex,Price")] Vet vet)
        {
            if (ModelState.IsValid)
            {
                db.Vets.Add(vet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vet);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,PhoneNumber,Specjalization,Sex,Price")] Vet vet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vet);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vet vet = db.Vets.Find(id);
            foreach (Visit v in db.Visits)
            {
                if (v.Vet == vet)
                {
                    db.Visits.Remove(v);
                }
            }
            db.Vets.Remove(vet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
