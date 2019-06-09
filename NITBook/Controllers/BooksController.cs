using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NITBook.Models;
using System.IO;

namespace NITBook.Controllers
{
    public class BooksController : Controller
    {
        private NITBookContext db = new NITBookContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookName,imageUrl,ISBN,publicName,publicTime,author,sort,number,borrowNumber,info")] Book book, HttpPostedFileBase imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    string path = Path.Combine(Server.MapPath("~/BookImage"), Path.GetFileName(imageUrl.FileName)); // 文件保存路径
                    imageUrl.SaveAs(path); // 文件保存至服务器指定路径
                    book.imageUrl = "/BookImage/"+imageUrl.FileName;
                }
                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookID,bookName,imageUrl,ISBN,publicName,publicTime,author,sort,number,borrowNumber,info")] Book book, HttpPostedFileBase imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    string path = Path.Combine(Server.MapPath("~/BookImage"), Path.GetFileName(imageUrl.FileName)); // 文件保存路径
                    imageUrl.SaveAs(path); // 文件保存至服务器指定路径
                    book.imageUrl = "/BookImage/" + imageUrl.FileName;
                }
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
