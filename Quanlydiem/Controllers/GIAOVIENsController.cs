using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quanlydiem.Models;

namespace Quanlydiem.Controllers
{
    public class GIAOVIENsController : Controller
    {
        private QuanlydiemDbContext db = new QuanlydiemDbContext();
        [Authorize]
        // GET: GIAOVIENs
        public ActionResult Index()
        {
            var gIAOVIENS = db.GIAOVIENS.Include(g => g.LOP).Include(g => g.MONHOC);
            return View(gIAOVIENS.ToList());
        }

        // GET: GIAOVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENS.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            return View(gIAOVIEN);
        }

        // GET: GIAOVIENs/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.LOPS, "MaLop", "TenLop");
            ViewBag.MaMon = new SelectList(db.MONHOCS, "MaMon", "TenMon");
            return View();
        }

        // POST: GIAOVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGV,HoTenGV,NamSinh,MaMon,SoDT,MaLop")] GIAOVIEN gIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.GIAOVIENS.Add(gIAOVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.LOPS, "MaLop", "TenLop", gIAOVIEN.MaLop);
            ViewBag.MaMon = new SelectList(db.MONHOCS, "MaMon", "TenMon", gIAOVIEN.MaMon);
            return View(gIAOVIEN);
        }

        // GET: GIAOVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENS.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.LOPS, "MaLop", "TenLop", gIAOVIEN.MaLop);
            ViewBag.MaMon = new SelectList(db.MONHOCS, "MaMon", "TenMon", gIAOVIEN.MaMon);
            return View(gIAOVIEN);
        }

        // POST: GIAOVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,HoTenGV,NamSinh,MaMon,SoDT,MaLop")] GIAOVIEN gIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIAOVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.LOPS, "MaLop", "TenLop", gIAOVIEN.MaLop);
            ViewBag.MaMon = new SelectList(db.MONHOCS, "MaMon", "TenMon", gIAOVIEN.MaMon);
            return View(gIAOVIEN);
        }

        // GET: GIAOVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENS.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            return View(gIAOVIEN);
        }

        // POST: GIAOVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GIAOVIEN gIAOVIEN = db.GIAOVIENS.Find(id);
            db.GIAOVIENS.Remove(gIAOVIEN);
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
