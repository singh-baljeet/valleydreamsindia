﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValleyDreamsIndia;
using ValleyDreamsIndia.AuthData;
using ValleyDreamsIndia.Common;
using ValleyDreamsIndia.Models;

namespace ValleyDreamsIndia.Controllers.Members
{
            
    
    public class ProfileController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;
        public ProfileController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        [HttpGet]
        public ActionResult ViewProfile()
        {
            ViewBag.Title = "Admin: Profile";
            try
            {
                return View("~/Views/Members/Profile/ViewProfile.cshtml" , GetPersonalAndUserDetails(CurrentUser.CurrentUserId));
            }
            catch(Exception ex)
            {
                throw new  Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {
            ViewBag.Title = "Admin: Profile Settings";
            try
            {
                return View("~/Views/Members/Profile/Edit.cshtml", GetPersonalAndUserDetails(CurrentUser.CurrentUserId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Edit(UsersPersonalModelView usersPersonalModelView,HttpPostedFileBase memberImage)
        {
            ViewBag.Title = "Admin: Profile Settings";
            try
            {
                if(memberImage != null)
                {
                    string randomImageName = Guid.NewGuid().ToString().Substring(0, 5) + memberImage.FileName;
                    usersPersonalModelView.PersonalDetails.ProfilePic = "/UploadedImages/"+randomImageName;
                    memberImage.SaveAs(Server.MapPath("~/UploadedImages/") + randomImageName);
                }
                usersPersonalModelView.PersonalDetails.UpdatedOn = DateTime.Now;
                var personalDetailObject = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId).FirstOrDefault();
                _valleyDreamsIndiaDBEntities.Entry(personalDetailObject).CurrentValues.SetValues(usersPersonalModelView.PersonalDetails);

                usersPersonalModelView.BankDetails.UpdatedOn = DateTime.Now;
                var bankDetailObject = _valleyDreamsIndiaDBEntities.BankDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId);
                _valleyDreamsIndiaDBEntities.Entry(bankDetailObject).CurrentValues.SetValues( usersPersonalModelView.BankDetails);

                _valleyDreamsIndiaDBEntities.SaveChanges();
                _valleyDreamsIndiaDBEntities.Dispose();

                return RedirectToAction("ViewProfile");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private UsersPersonalModelView GetPersonalAndUserDetails(int userDetailsId)
        {
            UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
            usersPersonalModelView.UserDetails = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == userDetailsId && x.Deleted == 0);
            usersPersonalModelView.PersonalDetails = _valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == userDetailsId && x.Deleted == 0);
            usersPersonalModelView.BankDetails = _valleyDreamsIndiaDBEntities.BankDetails.First(x => x.UsersDetailsId == userDetailsId && x.Deleted == 0);
            return usersPersonalModelView;
        }

    }

}