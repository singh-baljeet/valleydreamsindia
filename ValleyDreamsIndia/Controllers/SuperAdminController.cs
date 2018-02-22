using System;
using System.Collections.Generic;
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
        public ActionResult AssignPin(int sponsoredId, int totalPin, string pinType)
        {
            UsersDetail userDetail = new UsersDetail();

                for (int i = 1; i <= totalPin; i++) {
                    userDetail.Username = "A00" + _valleyDreamsIndiaDBEntities.UsersDetails.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    userDetail.PinCreatedOn = DateTime.Now;
                    userDetail.Deleted = 0;
                    userDetail.SponsoredId = sponsoredId;
                    userDetail.IsPinUsed = 0;
                    userDetail.PinType = pinType;
                    _valleyDreamsIndiaDBEntities.UsersDetails.Add(userDetail);
                    _valleyDreamsIndiaDBEntities.SaveChanges();
                }

            return View();

        }

    }
}