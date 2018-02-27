using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Security.Claims;
using ValleyDreamsIndia.Common;

namespace ValleyDreamsIndia.Controllers.Members
{
    //[Authorize]
    public class DashboardController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;
        public DashboardController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        public ActionResult Index()
        {
            var UserDetailsResults = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == CurrentUser.CurrentUserId);
            ViewBag.UserName = UserDetailsResults.UserName;
            var PersonalDetails = UserDetailsResults.PersonalDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId).FirstOrDefault();
            ViewBag.FullName = PersonalDetails.FirstName + " " + PersonalDetails.LastName;
            ViewBag.Status = (UserDetailsResults.Deleted ==0) ? "Active": "InActive";
            ViewBag.Sponsor = UserDetailsResults.UsersDetail1.UserName;
            ViewBag.DOJ = Convert.ToDateTime(UserDetailsResults.CreatedOn).ToShortDateString();
            ViewBag.LeftTeam = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.PlacementSide == "LEFT").Count();

            ViewBag.RightTeam = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.PlacementSide == "RIGHT").Count();
            ViewBag.MyTeam = UserDetailsResults.UsersDetails1.Where(x=>x.IsPinUsed== 1).Count();
            ViewBag.NewPins = UserDetailsResults.UsersDetails1.Where(x => x.SponsoredId == CurrentUser.CurrentUserId
                                                && x.PinType == "NEW" && x.IsPinUsed == 0).Count();
            ViewBag.RenewalPins = UserDetailsResults.UsersDetails1.Where(x => x.SponsoredId == CurrentUser.CurrentUserId
                                                && x.PinType == "RENEW" && x.IsPinUsed == 0).Count();
            ViewBag.Title = "Admin: Dashboard";
            return View("~/Views/Members/Dashboard/Index.cshtml");
        }
    }
}