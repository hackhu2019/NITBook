using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NITBook.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookSort()
        {
            return View();
        }
        public ActionResult Info()
        {
            ViewBag.Message = "NIT图书馆信息";

            return View();
        }

        public ActionResult Sort()
        {
            ViewBag.Message = "NIT图书分类";

            return View();
        }

        public ActionResult List()
        {
            ViewBag.Message = "NIT图书排行";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "联系我们";

            return View();
        }
    }
}