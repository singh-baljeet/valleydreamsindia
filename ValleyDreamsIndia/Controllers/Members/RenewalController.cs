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
        public ActionResult Contribution(string memberid)
        {
            var IsRenewPinAvailable = _valleyDreamsIndiaDBEntities.RenewalPinDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.IsPinUsed == 0).Count();
            if (IsRenewPinAvailable != 0)
            {
                ViewBag.Title = "Admin: Renewal";
                UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
                usersPersonalModelView.RenewalPinDetails = _valleyDreamsIndiaDBEntities.RenewalPinDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId).FirstOrDefault();
                usersPersonalModelView.UserDetails = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.Id == CurrentUser.CurrentUserId).FirstOrDefault();
                usersPersonalModelView.ContributionDetails = _valleyDreamsIndiaDBEntities.ContributionDetails.Where(x => x.UserDetailsId == CurrentUser.CurrentUserId).OrderByDescending(x => x.NextContribNumber).FirstOrDefault();
                ViewBag.RenewalPinAvailable = IsRenewPinAvailable;

                if(memberid != null && memberid != "" && memberid != string.Empty)
                {
                    var otherMemberUserDetails = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == memberid).FirstOrDefault();
                    var otherMemberContributionDetails = _valleyDreamsIndiaDBEntities.ContributionDetails.Where(x => x.UserDetailsId == otherMemberUserDetails.Id).OrderByDescending(x => x.NextContribNumber).FirstOrDefault();
                    ViewBag.OtherContributionNumber = otherMemberContributionDetails.NextContribNumber;
                    ViewBag.OtherContributionDate = otherMemberContributionDetails.NextContribDate;
                    ViewBag.OtherSponsoredId = otherMemberUserDetails.UsersDetail1.UserName;
                }

                return View("~/Views/Members/Renewal/Contribution.cshtml", usersPersonalModelView);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        public ActionResult ContributionPost(string transactionPassword)
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

        [HttpPost]
        public ActionResult OtherContribution(string transactionPassword, string memberid)
        {
            try
            {
                var otherMemberUserDetails = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == memberid).FirstOrDefault();
                BankDetail bankDetail = _valleyDreamsIndiaDBEntities.BankDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);
                if (bankDetail.TransactionPassword == transactionPassword)
                {

                    ContributionDetail ContributionDetails = _valleyDreamsIndiaDBEntities.ContributionDetails
                                                                                .Where(x => x.UserDetailsId == otherMemberUserDetails.Id)
                                                                                .OrderByDescending(x => x.NextContribNumber).FirstOrDefault();

                    ContributionDetail contributionDetails = new ContributionDetail();
                    contributionDetails.ContribNumber = ContributionDetails.NextContribNumber;
                    contributionDetails.ContribDate = DateTime.Now;
                    contributionDetails.ContribAmount = 1000;
                    contributionDetails.NextContribNumber = ContributionDetails.NextContribNumber + 1;
                    contributionDetails.NextContribDate = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 20);
                    contributionDetails.RemainingContrib = 15 - ContributionDetails.NextContribNumber;
                    contributionDetails.UserDetailsId = otherMemberUserDetails.Id;
                    contributionDetails.SponsoredId = CurrentUser.CurrentUserId;
                    contributionDetails.PayedBy = "SPONSOR";
                    contributionDetails.IsCompleted = (contributionDetails.ContribNumber != 15) ? 0 : 1;
                    _valleyDreamsIndiaDBEntities.ContributionDetails.Add(contributionDetails);
                    _valleyDreamsIndiaDBEntities.SaveChanges();


                    RenewalPinDetail renewalPinDetails = _valleyDreamsIndiaDBEntities.RenewalPinDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.IsPinUsed == 0).OrderBy(x => x.PinCreatedOn).FirstOrDefault();

                    renewalPinDetails.IsPinUsed = 1;
                    _valleyDreamsIndiaDBEntities.Entry(renewalPinDetails).State = System.Data.Entity.EntityState.Modified;
                    _valleyDreamsIndiaDBEntities.SaveChanges();

                    return RedirectToAction("Contribution", new { memberid });
                }

                return RedirectToAction("Contribution", new { memberid });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}