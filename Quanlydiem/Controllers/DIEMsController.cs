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
            var diems = db.Diems.Include(d => d.HOCSINH).Include(d => d.MONHOC);
            return View(diems.ToList());
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
            ViewBag.MaHS = new SelectList(db.HOCSINHS, "MaHS", "TenHS");
            ViewBag.MaMon = new SelectList(db.MONHOCS, "MaMon", "TenMon");
            return View();
        }

        // POST: DIEMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bangdiem,MaHS,MaMon,DiemMieng,DiemMotTiet,Tong")] DIEM dIEM)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(dIEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHS = new SelectList(db.HOCSINHS, "MaHS", "TenHS", dIEM.MaHS);
            ViewBag.MaMon = new SelectList(db.MONHOCS, "MaMon", "TenMon", dIEM.MaMon);
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
            ViewBag.MaHS = new SelectList(db.HOCSINHS, "MaHS", "TenHS", dIEM.MaHS);
            ViewBag.MaMon = new SelectList(db.MONHOCS, "MaMon", "TenMon", dIEM.MaMon);
            return View(dIEM);
        }

        // POST: DIEMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bangdiem,MaHS,MaMon,DiemMieng,DiemMotTiet,Tong")] DIEM dIEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHS = new SelectList(db.HOCSINHS, "MaHS", "TenHS", dIEM.MaHS);
            ViewBag.MaMon = new SelectList(db.MONHOCS, "MaMon", "TenMon", dIEM.MaMon);
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
        public ActionResult TimKiem(string strceach)
        {
            //TH1:
            var DIEM = (from s in db.Diems select s).ToList();
            if (!String.IsNullOrEmpty(strceach))
            {
                DIEM = DIEM.Where(x => x.MaHS.Contains(strceach)).ToList();
            }

            return View(DIEM);
        }
    }
}
