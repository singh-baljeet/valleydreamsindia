﻿using System;
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
        public ActionResult Login()
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
                    if(userDetail.SponsoredId == userDetail.Id)
                    {
                        return RedirectToAction("CreateMember", "SuperAdmin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return RedirectToAction("Login");
            }
        }


        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}   