using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValleyDreamsIndia.Common;
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
        public ActionResult CreateMember()
        {
            ViewBag.Title = "SuperAdmin: Add New Member";
            UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
            return View(usersPersonalModelView);
        }


        [HttpPost]
        public ActionResult CreateMember(UsersPersonalModelView usersPersonalModelView)
        {
            ViewBag.Title = "SuperAdmin: Add New Member";

            UsersDetail userDetail = new UsersDetail();
            userDetail.SponsoredId = CurrentUser.CurrentUserId;
            userDetail.Password = Guid.NewGuid().ToString().Substring(0, 6);
            userDetail.Deleted = 0;
            userDetail.CreatedOn = DateTime.Now;

            _valleyDreamsIndiaDBEntities.Entry(userDetail).State = EntityState.Added;
            _valleyDreamsIndiaDBEntities.SaveChanges();


            usersPersonalModelView.PersonalDetails.UsersDetailsId = userDetail.Id;
            usersPersonalModelView.PersonalDetails.JoinedOn = DateTime.Now.ToString();
            usersPersonalModelView.PersonalDetails.CreatedOn = DateTime.Now;
            usersPersonalModelView.PersonalDetails.SponsoredId = CurrentUser.CurrentUserId;
            usersPersonalModelView.PersonalDetails.Deleted = 0;
            _valleyDreamsIndiaDBEntities.PersonalDetails.Add(usersPersonalModelView.PersonalDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();

            usersPersonalModelView.BankDetails.UsersDetailsId = userDetail.Id;
            usersPersonalModelView.BankDetails.CreatedOn = DateTime.Now;
            usersPersonalModelView.BankDetails.TransactionPassword = Guid.NewGuid().ToString().Substring(0, 6);
            usersPersonalModelView.BankDetails.Deleted = 0;
            _valleyDreamsIndiaDBEntities.BankDetails.Add(usersPersonalModelView.BankDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();

            ContributionDetail contributionDetails = new ContributionDetail();
            contributionDetails.ContribNumber = 1;
            contributionDetails.ContribDate = DateTime.Now;
            contributionDetails.ContribAmount = 1000;
            contributionDetails.NextContribNumber = 2;
            contributionDetails.NextContribDate = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 20);
            contributionDetails.RemainingContrib = 15 - 1;
            contributionDetails.UserDetailsId = userDetail.Id;
            contributionDetails.SponsoredId = CurrentUser.CurrentUserId;
            contributionDetails.PayedBy = "ADMIN";
            contributionDetails.IsCompleted = 0;
            _valleyDreamsIndiaDBEntities.ContributionDetails.Add(contributionDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();


            return RedirectToAction("CreateMember");
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
            if (pinType == "NEW")
            {
                UsersDetail userDetail = new UsersDetail();

                for (int i = 1; i <= totalPin; i++)
                {
                    //userDetail.Username = "A00" + _valleyDreamsIndiaDBEntities.UsersDetails.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    userDetail.PinCreatedOn = DateTime.Now;
                    userDetail.Deleted = 0;
                    userDetail.SponsoredId = getUser.Id;
                    userDetail.IsPinUsed = 0;
                    userDetail.PinType = pinType;
                    _valleyDreamsIndiaDBEntities.UsersDetails.Add(userDetail);
                    _valleyDreamsIndiaDBEntities.SaveChanges();
                }
            }
            if (pinType == "RENEW")
            {
                RenewalPinDetail renewalPinDetail = new RenewalPinDetail();

                for (int i = 1; i <= totalPin; i++)
                {
                    //userDetail.Username = "A00" + _valleyDreamsIndiaDBEntities.UsersDetails.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    renewalPinDetail.PinCreatedOn = DateTime.Now;
                    renewalPinDetail.Deleted = 0;
                    renewalPinDetail.SponsoredId = getUser.Id;
                    renewalPinDetail.IsPinUsed = 0;
                    _valleyDreamsIndiaDBEntities.RenewalPinDetails.Add(renewalPinDetail);
                    _valleyDreamsIndiaDBEntities.SaveChanges();
                }
            }
            return View();

        }

    }
}

//try
//{
//    // Your code...
//    // Could also be before try if you know the exception occurs in SaveChanges


//}
//catch (DbEntityValidationException e)
//{
//    foreach (var eve in e.EntityValidationErrors)
//    {
//        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
//            eve.Entry.Entity.GetType().Name, eve.Entry.State);
//        foreach (var ve in eve.ValidationErrors)
//        {
//            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
//                ve.PropertyName, ve.ErrorMessage);
//        }
//    }
//    throw;
//}

