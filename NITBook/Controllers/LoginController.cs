using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using NITBook.Models;
using System.Data.Entity;

namespace NITBook.Controllers
{
    public class LoginController : Controller
    {
        private NITBookContext db = new NITBookContext();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string userName, string password)
        {
            User user = await db.Users.Where(b => b.userName == userName).FirstOrDefaultAsync();
            if (user == null)
            {
                return Json("errorMSG1"); // 返回 Json 登录错误信息 1
            }
            else if (user.password != password)
            {
                return Json("errorMSG2"); // 返回 Json 登录错误信息 2
            }
            HttpContext.Session["root"] = user.isAdmin == true ? "admin" : "user";
            HttpContext.Session["user"] = user;

            db.Configuration.ValidateOnSaveEnabled = false;
            user.LoginTime = DateTime.Now;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return user.isAdmin == true ? Json("success_admin"):Json("success_reader");

           // return Json("Login Error"); // 返回 Json 登录成功信息
        }

        [ValidateAntiForgeryToken]
        private bool saveChange([Bind(Include = "userName,password")] User user)
        {
            if (ModelState.IsValid)
            {
                user.LoginTime = DateTime.Now;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(string userNameinput, string userPwdinput)
        {
            User user = await db.Users.Where(b => b.userName == userNameinput).FirstOrDefaultAsync();
            if (user != null)
            {
                return Json("errorMSG1-1");
            }
            user = new User();
            db.Configuration.ValidateOnSaveEnabled = false;
            user.userName = userNameinput;
            user.password = userPwdinput;
            user.isAdmin = false;
            user.createTime = DateTime.Now;
            db.Users.Add(user);
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return await Login(user.userName, user.password);
        }
    }
}