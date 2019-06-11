using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NITBook.Filter;
using NITBook.Models;
using System.Data.Entity;

namespace NITBook.Controllers
{
    public class ReaderController : Controller
    {
        private NITBookContext db = new NITBookContext();
        // GET: Reader
        public ActionResult Index()
        {
            User user = (User)HttpContext.Session["user"];
            ViewBag.id = user.Id;
            ViewBag.name = user.userName;
            ViewBag.time = user.LoginTime;
            return View(user);
        }

        public ActionResult SearchBook()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Result(string name)
        {
            ViewBag.Search = name;
            var books = db.Books
                .Where(a => a.bookName.Contains(name))
                .ToList();
            return View(books);
        }

        public ActionResult bookDetails(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return RedirectToAction("BooksList");
            }
            return View(book);
        }

        
        public ActionResult BooksList()
        {
            ViewBag.Sort = "文学";
            return View(db.Books.ToList());
        }

        [HttpGet]
        public ActionResult BooksList(string sort)
        {
            if (sort == null)
            {
                sort = "文学";
            }
            ViewBag.Sort = sort;
            return View(db.Books.Where(a => a.sort == sort).ToList());
        }

        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return Redirect("Index");
            }
            return View(db.Users.Find(id));
        }

        public ActionResult EditInfo(int? id)
        {
            if (id == null)
            {
                return Redirect("Index");
            }
            return View(db.Users.Find(id));
        }

        [HttpPost]
        public ActionResult EditInfo(int id, string password)
        {
            User user = db.Users.Where(a=>a.Id==id).First() ;
            db.Configuration.ValidateOnSaveEnabled = false;
            user.password = password;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return Json("edit_success");
        }

        public ActionResult Cancellation() // 注销登陆，清空 Session
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }

        public ActionResult BorrowInfoes(int id)
        {
            return View(db.BorrowInfo.Where(a=>a.readerId==id).ToList());
        }

        [HttpPost]
        public ActionResult borrowBook(int readId,int bookId)
        {
            Book book = db.Books.Find(bookId);
            User user = db.Users.Find(readId);

            if (book == null)
            {
                return Json("bookNoExist");
            }
            else if (user==null)
            {
                return Json("userNoExist");
            }
            else if (book.number<=0)
            {
                return Json("noEnough");
            }

            BorrowInfo info = new BorrowInfo(); // 新增借阅记录
            info.bookName = book.bookName;
            info.readerId = user.Id;
            info.borrowTime = DateTime.Now;
            info.isBeyond = false;

            db.Configuration.ValidateOnSaveEnabled = false;
            book.number -= 1; // 同时扣除库存和增加借阅数
            book.borrowNumber += 1;
            db.BorrowInfo.Add(info);
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return Json("borrow_success");
            // return RedirectToAction("BorrowInfoes", new {id=readId });
        }

        public ActionResult returnBook(int borrowId)
        {
            
            BorrowInfo info = db.BorrowInfo.Find(borrowId);  // 获取指定的借阅的数据
            Book book = db.Books.Where(a=>a.bookName==info.bookName).First();
            if (info == null)
            {
                return Json("NoExit");
            }
            TimeSpan day = DateTime.Now - db.BorrowInfo.Find(borrowId).borrowTime; // 计算借阅时间

            db.Configuration.ValidateOnSaveEnabled = false;
            if (day.Days > 30)
            {
                info.isBeyond = true;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                return Json("ToLong");
            }
            info.backTime = DateTime.Now;
            book.number += 1; // 同时增加库存和减少借阅数
            book.borrowNumber -= 1;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return RedirectToAction("BorrowInfoes", new { id = info.readerId });
        }

       
    }
}