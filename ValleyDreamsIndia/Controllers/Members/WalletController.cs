using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValleyDreamsIndia;
using ValleyDreamsIndia.Common;
using ValleyDreamsIndia.Models;

namespace ValleyDreamsIndia.Controllers.Members
{
    public class WalletController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;
        static string notificationMessage = "";
        public WalletController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        [HttpGet]
        public ActionResult Transfer()
        {
            ViewBag.Message = notificationMessage;
            ViewBag.Title = "Admin: Wallet";
            try
            {
                UsersDetail userDetail = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.Id == CurrentUser.CurrentUserId && x.Deleted == 0).FirstOrDefault();
                PersonalDetail personalDetail = userDetail.PersonalDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);
                ViewBag.TotalJoiningPins =userDetail.UsersDetails1.Where(x => x.PinType == "NEW" && x.IsPinUsed == 0).Count();
                ViewBag.TotalRenewPins = userDetail.RenewalPinDetails.Where(x=>x.IsPinUsed == 0).Count();
                if((Convert.ToInt32(ViewBag.TotalJoiningPins) == 0) && (Convert.ToInt32(ViewBag.TotalRenewPins) == 0))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                return View("~/Views/Members/Wallet/Transfer.cshtml", new Tuple<UsersDetail, PersonalDetail>(userDetail,personalDetail));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Transfer(string sponsoredId, int totalPin, string pinType, string transactionPassword)
        {
            UsersDetail userDetail = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.Id == CurrentUser.CurrentUserId && x.Deleted == 0).FirstOrDefault();
            int countPins = userDetail.UsersDetails1.Where(x => x.PinType == pinType && x.IsPinUsed == 0).Count();

            if (countPins != 0)
            {
                try
                {
                    var getUser = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == sponsoredId).FirstOrDefault();

                    var isTransactionPasswordExists = _valleyDreamsIndiaDBEntities.BankDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.TransactionPassword == transactionPassword).FirstOrDefault();
                    if (isTransactionPasswordExists != null)
                    {

                        var userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId
                                                                                                                            && x.PinType == pinType && x.IsPinUsed == 0).Take(totalPin);


                        foreach (var usr in userDetailList)
                        {
                            usr.SponsoredId = getUser.Id;
                            _valleyDreamsIndiaDBEntities.Entry<UsersDetail>(usr).State = EntityState.Modified;

                        }

                        _valleyDreamsIndiaDBEntities.SaveChanges();
                        _valleyDreamsIndiaDBEntities.Dispose();
                    }

                    notificationMessage = $"{pinType} type pins transfered successfully";
                    return RedirectToAction("Transfer");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                
            }
            else
            {
                notificationMessage = $"You have no {pinType} type pins";
                return RedirectToAction("Transfer");
            }
        }
        
    }
}