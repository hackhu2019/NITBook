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
    public class BorrowInfoesController : Controller
    {
        private NITBookContext db = new NITBookContext();

        // GET: BorrowInfoes
        public ActionResult Index()
        {
            return View(db.BorrowInfo.ToList());
        }

        // GET: BorrowInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowInfo borrowInfo = db.BorrowInfo.Find(id);
            if (borrowInfo == null)
            {
                return HttpNotFound();
            }
            return View(borrowInfo);
        }

        // GET: BorrowInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BorrowInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "borrow_Id,bookName,readerId,borrowTime,backTime,isBeyond")] BorrowInfo borrowInfo)
        {
            if (ModelState.IsValid)
            {
                db.BorrowInfo.Add(borrowInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(borrowInfo);
        }

        // GET: BorrowInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowInfo borrowInfo = db.BorrowInfo.Find(id);
            if (borrowInfo == null)
            {
                return HttpNotFound();
            }
            return View(borrowInfo);
        }

        // POST: BorrowInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "borrow_Id,bookName,readerId,borrowTime,backTime,isBeyond")] BorrowInfo borrowInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrowInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(borrowInfo);
        }

        // GET: BorrowInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowInfo borrowInfo = db.BorrowInfo.Find(id);
            if (borrowInfo == null)
            {
                return HttpNotFound();
            }
            return View(borrowInfo);
        }

        // POST: BorrowInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BorrowInfo borrowInfo = db.BorrowInfo.Find(id);
            db.BorrowInfo.Remove(borrowInfo);
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
