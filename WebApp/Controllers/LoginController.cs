using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.DBIslemleri;
using WebApp.Models.Entity;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        WebDBEntities db = new WebDBEntities();
        User userDb = new User();
        
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(users u)
        {
            var user = userDb.getUyeByUsernameAndPassword(u);

            if (user != null)
            {   //session işlemleri
                FormsAuthentication.SetAuthCookie(user.username, false);
                Session["Email"] = user.email.ToString();
                Session["Id"] = user.userID.ToString();
                Session["Name"] = user.name.ToString();
                Session["Surname"] = user.surname.ToString();
                Session["Username"] = user.username.ToString();
                Session["UserStatus"] = user.statusName.ToString();
                TempData["AlertMessage"] = "my alert message";
                return RedirectToAction("Menu", "Home");//ana sayfaya yönlendirilecek
            }
            else
            {
                return Content("<dialog open><p> Greetings, one and all! </p><button href='/Login/Login'>Ok</button><button>Maybe</button><button>Cancel</button></dialog>");
                /*TempData["Message"] = "Böyle bir kullanıcı bulunamadı.";
                return RedirectToAction("Login", "Login");*/
            }
        }
        


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(users u)
        {
            if (!ModelState.IsValid)//sayfadan gelen değerler boş mu kontrolü
            {
                return View("Register");
            }
            if (userDb.uyeKayitKontrol(u) != null)//aynı kullanıcı adı veya email e sahip üye var mı diye bakılıyor
            {
                return View("Register");
            }

            u.statusId = 1;//DEĞİŞTİRİLECEK


            timestamp ts = new timestamp();
            ts.create_time = DateTime.Now;
            ts.update_time = DateTime.Now;
            db.timestamp.Add(ts);
            db.SaveChanges();
            int tsId = db.Database.SqlQuery<int>("SELECT MAX(timestampID) AS LastID FROM timestamp").FirstOrDefault();
            u.timestampId = tsId;

            userDb.addUye(u);
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}