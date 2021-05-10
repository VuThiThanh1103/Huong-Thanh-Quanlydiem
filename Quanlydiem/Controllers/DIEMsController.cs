using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quanlydiem.Models;

namespace Quanlydiem.Controllers
{
    public class DIEMsController : Controller
    {
        private QuanlydiemDbContext db = new QuanlydiemDbContext();

        // GET: DIEMs
        public ActionResult Index()
        {
            return View(db.Diems.ToList());
        }

        // GET: DIEMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEM dIEM = db.Diems.Find(id);
            if (dIEM == null)
            {
                return HttpNotFound();
            }
            return View(dIEM);
        }

        // GET: DIEMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DIEMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bangdiem,MaHS,MaMon,DiemMieng,DiemMotTiet")] DIEM dIEM)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(dIEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dIEM);
        }

        // GET: DIEMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEM dIEM = db.Diems.Find(id);
            if (dIEM == null)
            {
                return HttpNotFound();
            }
            return View(dIEM);
        }

        // POST: DIEMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bangdiem,MaHS,MaMon,DiemMieng,DiemMotTiet")] DIEM dIEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dIEM);
        }

        // GET: DIEMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEM dIEM = db.Diems.Find(id);
            if (dIEM == null)
            {
                return HttpNotFound();
            }
            return View(dIEM);
        }

        // POST: DIEMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIEM dIEM = db.Diems.Find(id);
            db.Diems.Remove(dIEM);
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
