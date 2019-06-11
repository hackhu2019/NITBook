using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NITBook.Models;
using NITBook.Filter;

namespace NITBook.Controllers
{
    [IsAdmin]
    public class BookSortsController : Controller
    {
        private NITBookContext db = new NITBookContext();

        // GET: BookSorts
        public ActionResult Index()
        {
            return View(db.BookSort.ToList());
        }

        // GET: BookSorts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSort bookSort = db.BookSort.Find(id);
            if (bookSort == null)
            {
                return HttpNotFound();
            }
            return View(bookSort);
        }

        // GET: BookSorts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookSorts/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SortId,Name")] BookSort bookSort)
        {
            if (ModelState.IsValid)
            {
                db.BookSort.Add(bookSort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookSort);
        }

        // GET: BookSorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSort bookSort = db.BookSort.Find(id);
            if (bookSort == null)
            {
                return HttpNotFound();
            }
            return View(bookSort);
        }

        // POST: BookSorts/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SortId,Name")] BookSort bookSort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookSort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookSort);
        }

        // GET: BookSorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSort bookSort = db.BookSort.Find(id);
            if (bookSort == null)
            {
                return HttpNotFound();
            }
            return View(bookSort);
        }

        // POST: BookSorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookSort bookSort = db.BookSort.Find(id);
            db.BookSort.Remove(bookSort);
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
