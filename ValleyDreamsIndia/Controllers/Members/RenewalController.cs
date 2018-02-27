using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValleyDreamsIndia.Common;
using ValleyDreamsIndia.Models;

namespace ValleyDreamsIndia.Controllers.Members
{
    public class RenewalController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;

        public RenewalController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Contribution()
        {
            var IsRenewPinAvailable = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId
                                                && x.PinType == "RENEW" && x.IsPinUsed == 0).Count();
            if (IsRenewPinAvailable != 0)
            {
                ViewBag.Title = "Admin: Renewal";
                UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
                usersPersonalModelView.UserDetails = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.Id == CurrentUser.CurrentUserId).FirstOrDefault();
                usersPersonalModelView.ContributionDetails = _valleyDreamsIndiaDBEntities.ContributionDetails.Where(x => x.UserDetailsId == CurrentUser.CurrentUserId).OrderByDescending(x => x.NextContribNumber).FirstOrDefault();
                ViewBag.RenewalPinAvailable = IsRenewPinAvailable;
                return View("~/Views/Members/Renewal/Contribution.cshtml", usersPersonalModelView);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        public ActionResult Contribution(string transactionPassword)
        {
            try
            {
                BankDetail bankDetail = _valleyDreamsIndiaDBEntities.BankDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);
                if (bankDetail.TransactionPassword == transactionPassword)
                {

                    ContributionDetail ContributionDetails = _valleyDreamsIndiaDBEntities.ContributionDetails
                                                                                .Where(x => x.UserDetailsId == CurrentUser.CurrentUserId)
                                                                                .OrderByDescending(x => x.NextContribNumber).FirstOrDefault();

                    ContributionDetail contributionDetails = new ContributionDetail();
                    contributionDetails.ContribNumber = ContributionDetails.NextContribNumber;
                    contributionDetails.ContribDate = DateTime.Now;
                    contributionDetails.ContribAmount = 1000;
                    contributionDetails.NextContribNumber = ContributionDetails.NextContribNumber + 1;
                    contributionDetails.NextContribDate = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 20);
                    contributionDetails.RemainingContrib = 15 - ContributionDetails.NextContribNumber;
                    contributionDetails.UserDetailsId = CurrentUser.CurrentUserId;
                    contributionDetails.SponsoredId = bankDetail.UsersDetail.SponsoredId;
                    contributionDetails.PayedBy = "SELF";
                    contributionDetails.IsCompleted = (contributionDetails.ContribNumber != 15) ? 0 : 1;
                    _valleyDreamsIndiaDBEntities.ContributionDetails.Add(contributionDetails);
                    _valleyDreamsIndiaDBEntities.SaveChanges();


                    UsersDetail userDetails = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId
                                               && x.PinType == "RENEW" && x.IsPinUsed == 0).OrderBy(x => x.PinCreatedOn).FirstOrDefault();

                    userDetails.IsPinUsed = 1;
                    _valleyDreamsIndiaDBEntities.Entry(userDetails).State = System.Data.Entity.EntityState.Modified;
                    _valleyDreamsIndiaDBEntities.SaveChanges();


                    return RedirectToAction("Contribution");
                }

                return RedirectToAction("Contribution");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}