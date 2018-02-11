using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValleyDreamsIndia.Controllers.Members
{
    public class UsersController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;

        public UsersController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditPassword()
        {
            try
            {
                return View("User/Edit");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditPassword(string OldPassword, string NewPassword, string ConfirmNewPassword)
        {
            try
            {
                int userDetailsId = 2;
                if (NewPassword == ConfirmNewPassword)
                {
                    UsersDetail usersDetail = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == userDetailsId && x.Deleted == 0);
                    if (usersDetail.Password == OldPassword)
                    {
                        usersDetail.Password = NewPassword;
                        usersDetail.UpdatedOn = DateTime.Now;
                        _valleyDreamsIndiaDBEntities.Entry(usersDetail).State = EntityState.Modified;
                        _valleyDreamsIndiaDBEntities.SaveChanges();
                        return RedirectToAction("EditPassword");
                    }
                    else
                    {
                        return RedirectToAction("EditPassword");
                    }
                }
                else
                {
                    return RedirectToAction("EditPassword");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}