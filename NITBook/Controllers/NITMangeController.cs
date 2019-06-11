using NITBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NITBook.Filter;

namespace NITBook.Controllers
{
    [IsAdmin]
    public class NITMangeController : Controller
    {
        private NITBookContext db = new NITBookContext();
        // GET: NITMange
        public ActionResult Index()
        {
            User user =(User)HttpContext.Session["user"];
            ViewBag.id = user.Id;
            ViewBag.name = user.userName;
            ViewBag.time = user.LoginTime;
            return View(user);
        }

        public ActionResult Cancellation()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }

        public ActionResult Statistics()
        {
            DataViewModel data = new DataViewModel();
            data.adminNum = db.Users.Where(a => a.isAdmin == true).Count();
            data.readerNum = db.Users.Where(a => a.isAdmin == false).Count();
            data.bookNum = db.Books.Sum(a => a.number);
            data.borrowNum = db.Books.Sum(a => a.borrowNumber);
            data.bookSortNum = db.BookSort.Count();
            return View(data);
        }
    }
}