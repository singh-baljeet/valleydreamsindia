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
    public class BankController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;
        public BankController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            ViewBag.Title = "Admin: Bank Info";
            try
            {
                BankDetail bankDetail = _valleyDreamsIndiaDBEntities.BankDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);
                return View("~/Views/Members/Bank/Edit.cshtml", bankDetail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Edit(BankDetail bankDetail)
        {
            ViewBag.Title = "Admin: Bank Info";
            try
            {
                bankDetail.UpdatedOn = DateTime.Now;
                _valleyDreamsIndiaDBEntities.Entry(bankDetail).State = EntityState.Modified;
                _valleyDreamsIndiaDBEntities.SaveChanges();
                _valleyDreamsIndiaDBEntities.Dispose();
                return RedirectToAction("ViewProfile","Profile");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}