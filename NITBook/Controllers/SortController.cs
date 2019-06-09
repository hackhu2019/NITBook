using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NITBook.Models;

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