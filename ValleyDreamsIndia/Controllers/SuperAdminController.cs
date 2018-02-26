using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValleyDreamsIndia.Models;

namespace ValleyDreamsIndia.Controllers
{
    public class SuperAdminController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;

        public SuperAdminController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AssignPin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AssignPin(string sponsoredId, int totalPin, string pinType)
        {
            var getUser = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == sponsoredId).FirstOrDefault();

            UsersDetail userDetail = new UsersDetail();

                for (int i = 1; i <= totalPin; i++) {
                    //userDetail.Username = "A00" + _valleyDreamsIndiaDBEntities.UsersDetails.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    userDetail.PinCreatedOn = DateTime.Now;
                    userDetail.Deleted = 0;
                    userDetail.SponsoredId = getUser.Id;
                    userDetail.IsPinUsed = 0;
                    userDetail.PinType = pinType;
                    _valleyDreamsIndiaDBEntities.UsersDetails.Add(userDetail);
                    _valleyDreamsIndiaDBEntities.SaveChanges();
            }

            
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return View();

        }

    }
}