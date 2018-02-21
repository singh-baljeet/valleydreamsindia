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
            ViewBag.Title = "Admin: Add New Member";
            UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
            return View("~/Views/Members/Team/Create.cshtml" , usersPersonalModelView);
        }
        
        [HttpPost]
        public ActionResult Create(UsersPersonalModelView usersPersonalModelView, HttpPostedFileBase memberImage)
        {
            ViewBag.Title = "Admin: Add New Member";


            usersPersonalModelView.UserDetails.Username = "A00" + _valleyDreamsIndiaDBEntities.UsersDetails.OrderByDescending(u => u.Id).FirstOrDefault().Id;
            usersPersonalModelView.UserDetails.CreatedOn = DateTime.Now;
            usersPersonalModelView.UserDetails.SponsoredId = CurrentUser.CurrentUserId;

            usersPersonalModelView.UserDetails.Deleted = 0;
            _valleyDreamsIndiaDBEntities.UsersDetails.Add(usersPersonalModelView.UserDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();

            usersPersonalModelView.PersonalDetails.ProfilePic = "";

            if (memberImage != null)
            {
                string randomImageName = Guid.NewGuid().ToString().Substring(0, 5) + memberImage.FileName;
                usersPersonalModelView.PersonalDetails.ProfilePic = "/UploadedTeamImages/" + randomImageName;
                memberImage.SaveAs(Server.MapPath("~/UploadedTeamImages/") + randomImageName);
            }

            usersPersonalModelView.PersonalDetails.UsersDetailsId = usersPersonalModelView.UserDetails.Id;
            usersPersonalModelView.PersonalDetails.CreatedOn = DateTime.Now;
            usersPersonalModelView.PersonalDetails.Deleted = 0;
            _valleyDreamsIndiaDBEntities.PersonalDetails.Add(usersPersonalModelView.PersonalDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();

            usersPersonalModelView.BankDetails.UsersDetailsId = usersPersonalModelView.UserDetails.Id;
            usersPersonalModelView.BankDetails.CreatedOn = DateTime.Now;
            usersPersonalModelView.BankDetails.Deleted = 0;
            _valleyDreamsIndiaDBEntities.BankDetails.Add(usersPersonalModelView.BankDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();

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
            UserPersonalListModelView userPersonalListModelView = new UserPersonalListModelView();
            userPersonalListModelView.PersonalDetail = _valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);

            userPersonalListModelView.Left = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide=="LEFT").Count();
            userPersonalListModelView.Right = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "RIGHT").Count();
            userPersonalListModelView.Direct = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide != "RIGHT"  && x.PlacementSide != "LEFT").Count();

            List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId).ToList();
            List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            foreach(var usr in userDetailList)
            {
                personalDetailList.Add(_valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == usr.Id));
            }
            userPersonalListModelView.PersonalDetails = personalDetailList;
            return View("~/Views/Members/Team/Team.cshtml" , userPersonalListModelView);
        }


        [HttpPost]
        public ActionResult SearchByPlacementSide(string placementSide)
        {
            if(placementSide == "" || placementSide == String.Empty)
            {
                return RedirectToAction("Team");
            }

            ViewBag.Title = "Admin: View Team";
            UserPersonalListModelView userPersonalListModelView = new UserPersonalListModelView();
            userPersonalListModelView.PersonalDetail = _valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);

            userPersonalListModelView.Left = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "LEFT").Count();
            userPersonalListModelView.Right = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "RIGHT").Count();
            userPersonalListModelView.Direct = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide != "RIGHT" && x.PlacementSide != "LEFT").Count();

            List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId).ToList();
            List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            foreach (var usr in userDetailList)
            {
                var objectPersonal = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == usr.Id && x.PlacementSide == placementSide).FirstOrDefault();
                if(objectPersonal != null)
                {
                    personalDetailList.Add(objectPersonal);
                }
            }
            userPersonalListModelView.PersonalDetails = personalDetailList;
            return View("~/Views/Members/Team/Team.cshtml", userPersonalListModelView);
        }

        [HttpPost]
        public ActionResult SearchByMemberId(string memberId)
        {
            if (memberId == "" || memberId == String.Empty)
            {
                return RedirectToAction("Team");
            }

            ViewBag.Title = "Admin: View Team";
            UserPersonalListModelView userPersonalListModelView = new UserPersonalListModelView();
            userPersonalListModelView.PersonalDetail = _valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);

            userPersonalListModelView.Left = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "LEFT").Count();
            userPersonalListModelView.Right = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "RIGHT").Count();
            userPersonalListModelView.Direct = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide != "RIGHT" && x.PlacementSide != "LEFT").Count();

            List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Username == memberId).ToList();
            List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            foreach (var usr in userDetailList)
            {
                var objectPersonal = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == usr.Id).FirstOrDefault();
                    personalDetailList.Add(objectPersonal);
            }
            userPersonalListModelView.PersonalDetails = personalDetailList;
            return View("~/Views/Members/Team/Team.cshtml", userPersonalListModelView);
        }

        [HttpGet]
        public ActionResult Direct()
        {
            ViewBag.Title = "Admin: Direct Team";
            UserPersonalListModelView userPersonalListModelView = new UserPersonalListModelView();
            userPersonalListModelView.PersonalDetail = _valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == CurrentUser.CurrentUserId && x.Deleted == 0);

            userPersonalListModelView.Left = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "LEFT").Count();
            userPersonalListModelView.Right = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "RIGHT").Count();
            userPersonalListModelView.Direct = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "DIRECT").Count();

            List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId).ToList();
            List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            foreach (var usr in userDetailList)
            {
                var objectDirectList = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == usr.Id && x.Deleted == 0 && x.PlacementSide == "DIRECT").FirstOrDefault();
                if(objectDirectList != null)
                    personalDetailList.Add(objectDirectList);
            }
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

            userPersonalListModelView.Left = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "LEFT").Count();
            userPersonalListModelView.Right = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "RIGHT").Count();
            userPersonalListModelView.Direct = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Deleted == 0 && x.PlacementSide == "DIRECT").Count();

            List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.Username == memberId).ToList();
            List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            foreach (var usr in userDetailList)
            {
                var objectDirectList = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == usr.Id && x.Deleted == 0 && x.PlacementSide == "DIRECT").FirstOrDefault();
                if (objectDirectList != null)
                    personalDetailList.Add(objectDirectList);
            }
            userPersonalListModelView.PersonalDetails = personalDetailList;
            return View("~/Views/Members/Team/Direct.cshtml", userPersonalListModelView);
        }


        [HttpGet]
        public ActionResult Tree()
        {
            var parentResult = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.Id == CurrentUser.CurrentUserId)
                .Select(x => new TreeStructure.Parent
                {
                    Detail = new TreeStructure.SelfDetails
                    { Name = x.FirstName+ " " + x.LastName, UserName = x.UsersDetail.Username,
                        SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails.Where(y=>y.Id == x.UsersDetail.SponsoredId).FirstOrDefault().Username
                    },
                }
            ).FirstOrDefault();

           var childernPlacementSide =  _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId);
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
                            UserName = children.UsersDetail.Username,
                            SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails.Where(y => y.Id == children.UsersDetailsId).FirstOrDefault().Username
                        },
                    };

                    var leftSubChildernPlacementSide = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == children.UsersDetailsId);
                    foreach (var subChildren in leftSubChildernPlacementSide)
                    {
                        if (subChildren.PlacementSide == "LEFT")
                        {
                            parentResult.LeftChildren.LeftSubChildren  =
                                new TreeStructure.SelfDetails
                                {
                                    Name = subChildren.FirstName + " " + subChildren.LastName ,
                                    UserName = subChildren.UsersDetail.Username,
                                    SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails.Where(y => y.Id == subChildren.UsersDetailsId).FirstOrDefault().Username
                                };
                        }
                        if (subChildren.PlacementSide == "RIGHT")
                        {
                            parentResult.LeftChildren.RightSubChildren =
                                new TreeStructure.SelfDetails
                                {
                                    Name = subChildren.FirstName + " " + subChildren.LastName,
                                    UserName = subChildren.UsersDetail.Username,
                                    SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails.Where(y => y.Id == subChildren.UsersDetailsId).FirstOrDefault().Username
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
                            UserName = children.UsersDetail.Username,
                            SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails.Where(y => y.Id == children.UsersDetailsId).FirstOrDefault().Username
                        }
                    };

                    var rightSubChildernPlacementSide = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == children.UsersDetailsId);
                    foreach (var subChildren in rightSubChildernPlacementSide)
                    {
                        if (subChildren.PlacementSide == "LEFT")
                        {
                            parentResult.RightChildren.LeftSubChildren =
                                new TreeStructure.SelfDetails
                                {
                                    Name = subChildren.FirstName + " " + subChildren.LastName,
                                    UserName = subChildren.UsersDetail.Username,
                                    SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails.Where(y => y.Id == subChildren.UsersDetailsId).FirstOrDefault().Username
                                };
                        }
                        if (subChildren.PlacementSide == "RIGHT")
                        {
                            parentResult.RightChildren.RightSubChildren =
                                new TreeStructure.SelfDetails
                                {
                                    Name = subChildren.FirstName + " " + subChildren.LastName,
                                    UserName = subChildren.UsersDetail.Username,
                                    SponsorName = _valleyDreamsIndiaDBEntities.UsersDetails.Where(y => y.Id == subChildren.UsersDetailsId).FirstOrDefault().Username
                                };
                        }
                    }
                }
            }

            var res = parentResult;






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



                return View("~/Views/Members/Team/Tree.cshtml");

        }




        [HttpPost]
        public ActionResult TreeByUserId(int userId)
        {
            ViewBag.Title = "Admin: Tree";

            int leftPlacementCount = 0;
            int rightPlacementCount = 0;
            int directLeftPlacementCount = 0;
            int directRightPlacementCount = 0;
            List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == userId).ToList();
            List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            foreach (var usr in userDetailList)
            {
                var placementSide = _valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == usr.Id).PlacementSide;
                if (placementSide == "LEFT")
                {
                    leftPlacementCount += 1;
                }
                if (placementSide == "RIGHT")
                {
                    rightPlacementCount += 1;
                }
            }

            ViewBag.LeftPlacementCount = leftPlacementCount;
            ViewBag.RightPlacementCount = rightPlacementCount;
            ViewBag.DirectLeftPlacementCount = directLeftPlacementCount;
            ViewBag.DirectRightPlacementCount = directRightPlacementCount;

            return View("~/Views/Members/Team/Tree.cshtml");
        }


    }
}