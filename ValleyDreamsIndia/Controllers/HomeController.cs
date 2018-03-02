using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ValleyDreamsIndia.Controllers
{
    public class HomeController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;

        public HomeController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ErrorMessage = false;
            return View();
        }

        [HttpGet]
        public ActionResult achievers()
        {
            return View();
        }

        [HttpGet]
        public ActionResult plan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            UsersDetail userDetail = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == Username && x.Password == Password && x.Deleted == 0).FirstOrDefault();
            if(userDetail != null)
            {
                    FormsAuthentication.SetAuthCookie(userDetail.UserName, false);
                    var authTicket = new FormsAuthenticationTicket(1, userDetail.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, userDetail.Id.ToString());
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Dashboard");
                    
            }
            else
            {
                ViewBag.ErrorMessage = true;
                return View("Index");
            }
        }


        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}   