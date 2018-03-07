﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValleyDreamsIndia.Common;

namespace ValleyDreamsIndia.Controllers
{
    public class CheckContributionController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;
        public CheckContributionController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var myUserList1 = _valleyDreamsIndiaDBEntities.UsersDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.IsPinUsed == 1);

            List<IQueryable<PersonalDetail>> objList = new List<IQueryable<PersonalDetail>>();

            var ownObj = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId == CurrentUser.CurrentUserId);
            objList.Add(ownObj);

            foreach (var usr in myUserList1)
            {
                var obj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == usr.Id && x.LegId == usr.Id);
                objList.Add(obj);
            }


            GetUserInfo();


            return View(objList);
        }

        private void  GetUserInfo()
        {

            var UserDetailsResults = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == CurrentUser.CurrentUserId);
            ViewBag.UserName = UserDetailsResults.UserName;
            var PersonalDetails = UserDetailsResults.PersonalDetails.Where(x => x.UsersDetailsId == CurrentUser.CurrentUserId).FirstOrDefault();
            ViewBag.FullName = PersonalDetails.FirstName + " " + PersonalDetails.LastName;
            ViewBag.Sponsor = UserDetailsResults.UsersDetail1.UserName;
            var SponsorPersonalDetail = UserDetailsResults.UsersDetail1.PersonalDetails.FirstOrDefault();
            ViewBag.SponsorName = SponsorPersonalDetail.FirstName + " " + SponsorPersonalDetail.LastName;

            ViewBag.DirectTeam = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId != CurrentUser.CurrentUserId).Count();

            var myUserList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.IsPinUsed == 1);

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

        [HttpPost]
        public ActionResult SearchByPlacementSide(string placementSide)
        {
            if(placementSide == "")
            {
                return RedirectToAction("Index");
            }
            var myUserList = _valleyDreamsIndiaDBEntities.UsersDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.IsPinUsed == 1);

            List<IQueryable<PersonalDetail>> objList = new List<IQueryable<PersonalDetail>>();

            var ownObj = _valleyDreamsIndiaDBEntities.PersonalDetails
                .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId == CurrentUser.CurrentUserId && x.PlacementSide== placementSide);
            objList.Add(ownObj);

            foreach (var usr in myUserList)
            {
                var obj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == usr.Id && x.LegId == usr.Id && x.PlacementSide == placementSide );
                objList.Add(obj);
            }

            GetUserInfo();

            return View("Index", objList);
        }

        [HttpPost]
        public ActionResult SearchByMemberId(string memberId)
        {
            if (memberId == "")
            {
                return RedirectToAction("Index");
            }

            var myUserList = _valleyDreamsIndiaDBEntities.UsersDetails
                .Where(x => x.IsPinUsed == 1 && x.UserName == memberId).FirstOrDefault();


            //int countDirect = _valleyDreamsIndiaDBEntities.PersonalDetails
            //    .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId != myUserList.Id && x.UsersDetailsId != ).Count();


            //var countDirectO = _valleyDreamsIndiaDBEntities.PersonalDetails
            //    .Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId != myUserList.Id);

            //if (countDirect > 0)
            //{
            //    return View("Index", null);
            //}

            
            List<IQueryable<PersonalDetail>> objList = new List<IQueryable<PersonalDetail>>();
            GetUserInfo();
            //var ownObj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId && x.LegId == CurrentUser.CurrentUserId);
            //objList.Add(ownObj);
            
                try
                {
                    if (myUserList != null && (myUserList.UsersDetail1.SponsoredId == CurrentUser.CurrentUserId || (myUserList.SponsoredId == CurrentUser.CurrentUserId && myUserList.UserName == memberId)))
                    {
                        var obj = _valleyDreamsIndiaDBEntities.PersonalDetails.Where(x => x.UsersDetailsId == myUserList.Id);
                        objList.Add(obj);
                    }
                    else
                    {
                        var ownObject  = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x=>x.UserName == memberId).FirstOrDefault();
                        if(ownObject.Id == CurrentUser.CurrentUserId)
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

            return View("Index", objList);
        }

    }
}