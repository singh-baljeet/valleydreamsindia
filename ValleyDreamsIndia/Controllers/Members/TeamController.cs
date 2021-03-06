﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValleyDreamsIndia.Common;
using ValleyDreamsIndia.Models;
using static ValleyDreamsIndia.Common.TreeStructure;

namespace ValleyDreamsIndia.Controllers.Members
{
    public class TeamController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;
        static string password = "";
        static string transactionpassword = "";
        static string username = "";
        static string smsstatus =  "";

        public TeamController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            ViewBag.TransactionPassword = transactionpassword;
            ViewBag.SmsStatus = smsstatus;

            var IsNewPinAvailable = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId 
                                                && x.PinType == "NEW" && x.IsPinUsed == 0).Count();
            if (IsNewPinAvailable != 0)
            {
                ViewBag.Title = "Admin: Add New Member";
                UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
                usersPersonalModelView.UserDetails = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.Id == CurrentUser.CurrentUserId).FirstOrDefault();
                return View("~/Views/Members/Team/Create.cshtml", usersPersonalModelView);
            }
            else
            {
                return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
            }
        }
        
        [HttpPost]
        public ActionResult Create(UsersPersonalModelView usersPersonalModelView)
        {
            ViewBag.Title = "Admin: Add New Member";

            UsersDetail userDetail = _valleyDreamsIndiaDBEntities.UsersDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && 
                x.PinType == "NEW" && x.IsPinUsed == 0).OrderBy(x => x.UserName).FirstOrDefault();
            userDetail.IsPinUsed = 1;
            userDetail.Password = Guid.NewGuid().ToString().Substring(0, 6);
            
            userDetail.Deleted = 0;
            userDetail.CreatedOn = DateTime.Now;
            _valleyDreamsIndiaDBEntities.Entry(userDetail).State = EntityState.Modified;
            _valleyDreamsIndiaDBEntities.SaveChanges();


            int legId = _valleyDreamsIndiaDBEntities.UsersDetails
                .Where(x => x.UserName == usersPersonalModelView.UserDetails.UserName).FirstOrDefault().Id;

            usersPersonalModelView.PersonalDetails.UsersDetailsId = userDetail.Id;
            usersPersonalModelView.PersonalDetails.JoinedOn = DateTime.Now.ToString();
            usersPersonalModelView.PersonalDetails.CreatedOn = DateTime.Now;
            usersPersonalModelView.PersonalDetails.SponsoredId = CurrentUser.CurrentUserId;
            usersPersonalModelView.PersonalDetails.LegId = legId;
            usersPersonalModelView.PersonalDetails.Deleted = 0;
            usersPersonalModelView.PersonalDetails.ProfilePic = "/UploadedTeamImages/default1_avatar_small.png";
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
            contributionDetails.PayedBy = "SPONSOR";
            contributionDetails.IsCompleted = 0;
            _valleyDreamsIndiaDBEntities.ContributionDetails.Add(contributionDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();


            password = userDetail.Password;
            transactionpassword = usersPersonalModelView.BankDetails.TransactionPassword;
            username = userDetail.UserName;
            

            string textMessage = String.Format("Your username is {0}, password is {1} and transactionpassword is {2}",username,password,transactionpassword);
            string smsStatus = SmsProvider.SendSms(usersPersonalModelView.PersonalDetails.PhoneNumber1, textMessage);
            if(smsStatus == "Success")
            {
                smsstatus = "Credentials Sent To Your Registered Mobile Number Successfully";
            }
            else
            {
                smsstatus = "Sended Sms Failed";
            }

            return RedirectToAction("Create");
        }


        [HttpPost]
        public ActionResult Search(int userId)
        {
            UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
            usersPersonalModelView.UserDetails = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.Id == userId).FirstOrDefault();
            usersPersonalModelView.PersonalDetails = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == userId).FirstOrDefault();
            usersPersonalModelView.BankDetails = _valleyDreamsIndiaDBEntities.BankDetails.Where(x => x.UsersDetailsId == userId).FirstOrDefault();
            return View("~/Views/Members/Team/Create.cshtml", usersPersonalModelView);
        }


        [HttpGet]
        public ActionResult Team()
        {
            ViewBag.Title = "Admin: View Team";


            var UserDetailsResults = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == CurrentUser.CurrentUserId);
            ViewBag.UserName = UserDetailsResults.UserName;
            var PersonalDetails = UserDetailsResults.PersonalDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId).FirstOrDefault();
            ViewBag.FullName = PersonalDetails.FirstName + " " + PersonalDetails.LastName;
            ViewBag.Sponsor = UserDetailsResults.UsersDetail1.UserName;
            var SponsorPersonalDetail = UserDetailsResults.UsersDetail1.PersonalDetails.FirstOrDefault();
            ViewBag.SponsorName = SponsorPersonalDetail.FirstName + " " + SponsorPersonalDetail.LastName;


            GetUserInfo(CurrentUser.CurrentUserId);

            List<IQueryable<PersonalDetail>> objList = new List<IQueryable<PersonalDetail>>();
            var ownObj = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId == CurrentUser.CurrentUserId);
            objList.Add(ownObj);

            try
            {
                var myUserList1 = _valleyDreamsIndiaDBEntities.UsersDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.IsPinUsed == 1);
                foreach (var usr in myUserList1)
                {
                    var obj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == usr.Id && x.LegId == usr.Id);
                    objList.Add(obj);
                }
            }
            catch(Exception e)
            {
                objList = null;
            }
            return View("~/Views/Members/Team/Team.cshtml" , objList);
        }

        [HttpPost]
        public ActionResult SearchByPlacementSide(string placementSide)
        {
            if(placementSide == "" || placementSide == String.Empty)
            {
                return RedirectToAction("Team");
            }

            ViewBag.Title = "Admin: View Team";

            var UserDetailsResults = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == CurrentUser.CurrentUserId);
            ViewBag.UserName = UserDetailsResults.UserName;
            var PersonalDetails = UserDetailsResults.PersonalDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId).FirstOrDefault();
            ViewBag.FullName = PersonalDetails.FirstName + " " + PersonalDetails.LastName;
            ViewBag.Sponsor = UserDetailsResults.UsersDetail1.UserName;

            GetUserInfo(CurrentUser.CurrentUserId);

            List<IQueryable<PersonalDetail>> objList = new List<IQueryable<PersonalDetail>>();
            var ownObj = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId == CurrentUser.CurrentUserId && x.PlacementSide == placementSide);
            objList.Add(ownObj);

            try
            {
                var myUserList1 = _valleyDreamsIndiaDBEntities.UsersDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.IsPinUsed == 1);
                foreach (var usr in myUserList1)
                {
                    var obj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == usr.Id && x.LegId == usr.Id && x.PlacementSide == placementSide);
                    objList.Add(obj);
                }
            }
            catch (Exception e)
            {
                objList = null;
            }

            return View("~/Views/Members/Team/Team.cshtml", objList);
        }

        [HttpPost]
        public ActionResult SearchByMemberId(string memberId)
        {
            if (memberId == "" || memberId == String.Empty)
            {
                return RedirectToAction("Team");
            }

            ViewBag.Title = "Admin: View Team";

            var UserDetailsResults = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == CurrentUser.CurrentUserId);
            ViewBag.UserName = UserDetailsResults.UserName;
            var PersonalDetails = UserDetailsResults.PersonalDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId).FirstOrDefault();
            ViewBag.FullName = PersonalDetails.FirstName + " " + PersonalDetails.LastName;
            ViewBag.Sponsor = UserDetailsResults.UsersDetail1.UserName;

            var myUserList = _valleyDreamsIndiaDBEntities.UsersDetails
                .Where(x =>x.IsPinUsed == 1 && x.UserName == memberId).FirstOrDefault();


            List<IQueryable<PersonalDetail>> objList = new List<IQueryable<PersonalDetail>>();
            GetUserInfo(CurrentUser.CurrentUserId);
            //var ownObj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId == CurrentUser.CurrentUserId);
            //objList.Add(ownObj);

            try
            {
                if (myUserList != null && myUserList.UsersDetail1.SponsoredId == CurrentUser.CurrentUserId || (myUserList.SponsoredId == CurrentUser.CurrentUserId && myUserList.UserName == memberId))
                {
                    var obj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == myUserList.Id);
                    objList.Add(obj);
                }
                else
                {
                    var ownObject = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == memberId).FirstOrDefault();
                    if (ownObject.Id == CurrentUser.CurrentUserId)
                    {
                        var obj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == ownObject.Id);
                        objList.Add(obj);
                    }
                }
            }
            catch (Exception e)
            {
                objList = null;
            }

            return View("~/Views/Members/Team/Team.cshtml", objList);
        }

        [HttpGet]
        public ActionResult Direct()
        {
            ViewBag.Title = "Admin: Direct Team";

            UserPersonalListModelView userPersonalListModelView = new UserPersonalListModelView();
            userPersonalListModelView.PersonalDetail = _valleyDreamsIndiaDBEntities.PersonalDetails
                .First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);

            GetUserInfo(CurrentUser.CurrentUserId);

            List<PersonalDetail> personalDetailList = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId != CurrentUser.CurrentUserId).ToList();

            userPersonalListModelView.PersonalDetails = personalDetailList;
            return View("~/Views/Members/Team/Direct.cshtml", userPersonalListModelView);
        }

        [HttpPost]
        public ActionResult DirectByMemberId(string memberId)
        {
            if(memberId == "" || memberId == String.Empty)
            {
                return RedirectToAction("Direct");
            }

            ViewBag.Title = "Admin: Direct Team";


            UserPersonalListModelView userPersonalListModelView = new UserPersonalListModelView();
            userPersonalListModelView.PersonalDetail = _valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);
            GetUserInfo(CurrentUser.CurrentUserId);

            try
            {
                UsersDetail userDetail = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == memberId).FirstOrDefault();
                List<PersonalDetail> personalDetailList = _valleyDreamsIndiaDBEntities.PersonalDetails
                   .Where(x => x.SponsoredId == CurrentUser.CurrentUserId
                   && x.LegId != CurrentUser.CurrentUserId && x.UsersDetailsId == userDetail.Id).ToList();
                userPersonalListModelView.PersonalDetails = personalDetailList;
            }
            catch(Exception e) {
                userPersonalListModelView.PersonalDetails = null;
            }
            
            return View("~/Views/Members/Team/Direct.cshtml", userPersonalListModelView);
        }

        private void GetUserInfo(int currentId)
        {
            ViewBag.DirectTeam = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == currentId && x.LegId != currentId).Count();

            var myUserList = _valleyDreamsIndiaDBEntities.UsersDetails.
                Where(x => x.SponsoredId == currentId && x.IsPinUsed == 1);

            int countLeftTeam = 0, countRightTeam = 0;
            var response = _valleyDreamsIndiaDBEntities.CountPlacementSideFunc(CurrentUser.CurrentUserId);
            foreach (var res in response)
            {
                countLeftTeam = Convert.ToInt32(res.LeftNodes);
                countRightTeam = Convert.ToInt32(res.RightNodes);
            }
           
            ViewBag.LeftTeam = countLeftTeam;
            ViewBag.RightTeam = countRightTeam;

        }

        [HttpGet]
        public ActionResult Tree()
        {
            Parent parentResult = TreeDetails(CurrentUser.CurrentUserId);
            return View("~/Views/Members/Team/Tree.cshtml", parentResult);

        }

        [HttpPost]
        public ActionResult TreeByUserId(string userId)
        {
            ViewBag.Title = "Admin: Tree";
            int currentUserId = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == userId).FirstOrDefault().Id;
            Parent parentResult = TreeDetails(currentUserId);
            return View("~/Views/Members/Team/Tree.cshtml", parentResult);
        }

        public Parent TreeDetails(int currentId)
        {
            var UserDetailsResults = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == currentId);
            ViewBag.UserName = UserDetailsResults.UserName;
            var PersonalDetails = UserDetailsResults.PersonalDetails.Where(x => x.UsersDetailsId == currentId).FirstOrDefault();
            ViewBag.FullName = PersonalDetails.FirstName + " " + PersonalDetails.LastName;
            ViewBag.Sponsor = UserDetailsResults.UsersDetail1.UserName;
            var SponsorPersonalDetail = UserDetailsResults.UsersDetail1.PersonalDetails.FirstOrDefault();
            ViewBag.SponsorName = SponsorPersonalDetail.FirstName + " " + SponsorPersonalDetail.LastName;

            GetUserInfo(currentId);

            var parentResult = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.UsersDetailsId == currentId)
                .Select(x => new TreeStructure.Parent
                {
                    Detail = new TreeStructure.SelfDetails
                    {
                        Name = x.FirstName + " " + x.LastName,
                        UserName = x.UsersDetail.UserName,
                        SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails.
                        Where(y => y.Id.ToString() == x.UsersDetail.SponsoredId.ToString()).FirstOrDefault().UserName
                    },
                }
            ).FirstOrDefault();

            var childernPlacementSide = _valleyDreamsIndiaDBEntities.PersonalDetails
                 .Where(x => x.LegId == currentId);
            foreach (var children in childernPlacementSide)
            {
                if (children.PlacementSide == "LEFT")
                {
                    parentResult.LeftChildren = new Children
                    {
                        Detail =
                        new TreeStructure.SelfDetails
                        {
                            Name = children.FirstName + " " + children.LastName,
                            UserName = children.UsersDetail.UserName,
                            SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails
                            .Where(y => y.Id == children.SponsoredId).FirstOrDefault().UserName
                        },
                    };

                    var leftSubChildernPlacementSide = _valleyDreamsIndiaDBEntities.PersonalDetails
                        .Where(x => x.LegId == children.UsersDetailsId);
                    foreach (var subChildren in leftSubChildernPlacementSide)
                    {
                        if (subChildren.PlacementSide == "LEFT")
                        {
                            parentResult.LeftChildren.LeftSubChildren =
                                new TreeStructure.SelfDetails
                                {
                                    Name = subChildren.FirstName + " " + subChildren.LastName,
                                    UserName = subChildren.UsersDetail.UserName,
                                    SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails
                                    .Where(y => y.Id == subChildren.SponsoredId).FirstOrDefault().UserName
                                };
                        }
                        if (subChildren.PlacementSide == "RIGHT")
                        {
                            parentResult.LeftChildren.RightSubChildren =
                                new TreeStructure.SelfDetails
                                {
                                    Name = subChildren.FirstName + " " + subChildren.LastName,
                                    UserName = subChildren.UsersDetail.UserName,
                                    SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails
                                    .Where(y => y.Id == subChildren.SponsoredId).FirstOrDefault().UserName
                                };
                        }
                    }
                }
                if (children.PlacementSide == "RIGHT")
                {
                    parentResult.RightChildren = new Children
                    {
                        Detail =
                        new TreeStructure.SelfDetails
                        {
                            Name = children.FirstName + " " + children.LastName,
                            UserName = children.UsersDetail.UserName,
                            SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails
                            .Where(y => y.Id == children.SponsoredId).FirstOrDefault().UserName
                        }
                    };

                    var rightSubChildernPlacementSide = _valleyDreamsIndiaDBEntities.PersonalDetails
                        .Where(x => x.LegId == children.UsersDetailsId);
                    foreach (var subChildren in rightSubChildernPlacementSide)
                    {
                        if (subChildren.PlacementSide == "LEFT")
                        {
                            parentResult.RightChildren.LeftSubChildren =
                                new TreeStructure.SelfDetails
                                {
                                    Name = subChildren.FirstName + " " + subChildren.LastName,
                                    UserName = subChildren.UsersDetail.UserName,
                                    SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails
                                    .Where(y => y.Id == subChildren.SponsoredId).FirstOrDefault().UserName
                                };
                        }
                        if (subChildren.PlacementSide == "RIGHT")
                        {
                            parentResult.RightChildren.RightSubChildren =
                                new TreeStructure.SelfDetails
                                {
                                    Name = subChildren.FirstName + " " + subChildren.LastName,
                                    UserName = subChildren.UsersDetail.UserName,
                                    SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails
                                    .Where(y => y.Id == subChildren.SponsoredId).FirstOrDefault().UserName
                                };
                        }
                    }
                }
            }

            //ViewBag.Title = "Admin: Tree";
            //int leftPlacementCount = 0;
            //int rightPlacementCount = 0;
            //int directLeftPlacementCount = 0;
            //int directRightPlacementCount = 0;
            //List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId).ToList();
            //List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            //foreach (var usr in userDetailList)
            //{
            //    var placementSide =_valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == usr.Id).PlacementSide;
            //    if(placementSide == "LEFT")
            //    {
            //        leftPlacementCount += 1;
            //    }
            //    if (placementSide == "RIGHT")
            //    {
            //        rightPlacementCount += 1;
            //    }
            //}

            //ViewBag.LeftPlacementCount = leftPlacementCount;
            //ViewBag.RightPlacementCount = rightPlacementCount;
            //ViewBag.DirectLeftPlacementCount = directLeftPlacementCount;
            //ViewBag.DirectRightPlacementCount = directRightPlacementCount;
            return parentResult;

        }


        [HttpGet]
        public JsonResult TeamCheckPins()
        {
            UsersDetail userDetail = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.Id == CurrentUser.CurrentUserId && x.Deleted == 0).FirstOrDefault();
            int newPins = userDetail.UsersDetails1.Where(x => x.PinType == "NEW" && x.IsPinUsed == 0).Count();

            if (newPins > 0)
            {
                return Json("True", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }
        }

    }
}