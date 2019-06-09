using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NITBook.Models;
using System.Net;

namespace NITBook.Controllers
{
    public class SortController : Controller
    {
        private NITBookContext db = new NITBookContext();

        // GET: Sort
        public ActionResult Index()
        {
            return View(db.BookSort.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SortId,Name")] BookSort sort)
        {
            if (ModelState.IsValid)
            {
                db.BookSort.Add(sort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sort);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSort sort = db.BookSort.Find(id);
            if (sort == null)
            {
                return HttpNotFound();
            }
            return View(sort);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSort sort = db.BookSort.Find(id);
            if (sort == null)
            {
                return HttpNotFound();
            }
            return View(sort);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SortId,Name")] BookSort sort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sort).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sort);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSort sort = db.BookSort.Find(id);
            if (sort == null)
            {
                return HttpNotFound();
            }
            return View(sort);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookSort sort = db.BookSort.Find(id);
            db.BookSort.Remove(sort);
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