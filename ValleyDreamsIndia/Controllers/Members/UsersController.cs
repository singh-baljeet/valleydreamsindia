﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ValleyDreamsIndia.Common;

namespace ValleyDreamsIndia.Controllers.Members
{
    public class UsersController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;

        public UsersController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }


        [HttpGet]
        public ActionResult EditPassword()
        {
            ViewBag.Title = "Admin: Change Password";
            ViewBag.ErrorMessage = false;
            ViewBag.TransactionErrorMessage = false;
            try
            {
                return View("~/Views/Members/User/Edit.cshtml");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditPassword(string OldPassword, string NewPassword, string ConfirmNewPassword)
        {
            ViewBag.TransactionErrorMessage = false;
            try
            {
                if (NewPassword == ConfirmNewPassword)
                {
                    UsersDetail usersDetail = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == CurrentUser.CurrentUserId && x.Deleted == 0);
                    if (usersDetail.Password == OldPassword)
                    {
                        usersDetail.Password = NewPassword;
                        usersDetail.UpdatedOn = DateTime.Now;
                        _valleyDreamsIndiaDBEntities.Entry(usersDetail).State = EntityState.Modified;
                        _valleyDreamsIndiaDBEntities.SaveChanges();
                        ViewBag.ErrorMessage = true;
                        ViewBag.Error = "Password Updated";
                        return View("~/Views/Members/User/Edit.cshtml");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = true;
                        ViewBag.Error = "Old Password Mismatched";
                        return View("~/Views/Members/User/Edit.cshtml"); 
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = true;
                    ViewBag.Error = "New And Confirm New Password Mismatched";
                    return View("~/Views/Members/User/Edit.cshtml");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult EditTransactionPassword(string OldTransactionPassword, string NewTransactionPassword, string ConfirmTransactionNewPassword)
        {
            ViewBag.Title = "Admin: Change Password";
            ViewBag.ErrorMessage = false;

            try
            {
                if (NewTransactionPassword == ConfirmTransactionNewPassword)
                {
                    BankDetail bankDetail = _valleyDreamsIndiaDBEntities.BankDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);
                    if (bankDetail.TransactionPassword == OldTransactionPassword)
                    {
                        bankDetail.TransactionPassword = NewTransactionPassword;
                        bankDetail.UpdatedOn = DateTime.Now;
                        _valleyDreamsIndiaDBEntities.Entry(bankDetail).State = EntityState.Modified;
                        _valleyDreamsIndiaDBEntities.SaveChanges();
                        ViewBag.TransactionErrorMessage = true;
                        ViewBag.TransactionError = "Transaction Password Updated";
                        return View("~/Views/Members/User/Edit.cshtml");
                    }
                    else
                    {
                        ViewBag.TransactionErrorMessage = true;
                        ViewBag.TransactionError = "Transaction Old Password Mismatched";
                        return View("~/Views/Members/User/Edit.cshtml");
                    }
                }
                else
                {
                    ViewBag.TransactionErrorMessage = true;
                    ViewBag.TransactionError = "New And Confirm Transaction New Password Mismatched";
                    return View("~/Views/Members/User/Edit.cshtml");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}