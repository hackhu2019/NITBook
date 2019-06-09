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
    }
}