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
        public WalletController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        [HttpGet]
        public ActionResult Transfer()
        {
            ViewBag.Title = "Admin: Wallet";
            try
            {
                UsersDetail userDetail = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.Id == CurrentUser.CurrentUserId && x.Deleted == 0).FirstOrDefault();
                PersonalDetail personalDetail = userDetail.PersonalDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);
                ViewBag.TotalJoiningPins =userDetail.UsersDetails1.Where(x => x.PinType == "NEW" && x.IsPinUsed == 0).Count();
                ViewBag.TotalRenewPins = userDetail.UsersDetails1.Where(x => x.PinType == "RENEW" && x.IsPinUsed == 0).Count();
                return View("~/Views/Members/Wallet/Transfer.cshtml", new Tuple<UsersDetail, PersonalDetail>(userDetail,personalDetail));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Transfer(int sponsoredId, int totalPin, string pinType, string transactionPassword)
        {
            ViewBag.Title = "Admin: Wallet";
            try
            {
                var isTransactionPasswordExists = _valleyDreamsIndiaDBEntities.BankDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.TransactionPassword == transactionPassword).FirstOrDefault();
                if(isTransactionPasswordExists != null)
                {
                    
                    var userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x=>x.SponsoredId == CurrentUser.CurrentUserId
                                                                                                                        && x.PinType == pinType && x.IsPinUsed == 0).Take(totalPin);


                    foreach(var usr in userDetailList)
                    {
                        usr.SponsoredId = sponsoredId;
                        _valleyDreamsIndiaDBEntities.Entry<UsersDetail>(usr).State = EntityState.Modified;
                        
                        }

                    _valleyDreamsIndiaDBEntities.SaveChanges();
                    _valleyDreamsIndiaDBEntities.Dispose();
                }
                return RedirectToAction("Transfer", "Wallet");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}