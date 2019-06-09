using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NITBook.Models;

namespace NITBook.Controllers
{
    public class SearchController : Controller
    {
        public NITBookContext db = new NITBookContext();
        // GET: Search
        public ActionResult Index()
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