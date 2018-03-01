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

            ViewBag.DirectTeam = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId != CurrentUser.CurrentUserId).Count();

            var myUserList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.IsPinUsed == 1);

            int countLeftTeam = 0, countRightTeam = 0;

            var ownobj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId == CurrentUser.CurrentUserId);
            foreach (var ob in ownobj)
            {
                if (ob.PlacementSide == "LEFT")
                {
                    countLeftTeam += 1;
                }
                if (ob.PlacementSide == "RIGHT")
                {
                    countRightTeam += 1;
                }
            }


            foreach (var usr in myUserList)
            {
                var obj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == usr.Id && x.LegId == usr.Id);
                foreach(var ob in obj)
                {
                    if(ob.PlacementSide == "LEFT")
                    {
                        countLeftTeam += 1;
                    }
                    if(ob.PlacementSide == "RIGHT")
                    {
                        countRightTeam += 1;
                    }
                }
             }


            ViewBag.LeftTeam = countLeftTeam;
            ViewBag.RightTeam = countRightTeam;

            ViewBag.MyTeam = Convert.ToInt32(ViewBag.DirectTeam) + Convert.ToInt32(ViewBag.LeftTeam) + Convert.ToInt32(ViewBag.RightTeam);

            ViewBag.NewPins = UserDetailsResults.UsersDetails1.Where(x => x.SponsoredId == CurrentUser.CurrentUserId
                                                && x.PinType == "NEW" && x.IsPinUsed == 0).Count();

            ViewBag.RenewalPins = UserDetailsResults.RenewalPinDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId
                                               && x.IsPinUsed == 0).Count();
            ViewBag.Title = "Admin: Dashboard";
            return View("~/Views/Members/Dashboard/Index.cshtml");
        }
    }
}