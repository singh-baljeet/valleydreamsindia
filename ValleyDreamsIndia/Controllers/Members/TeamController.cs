using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValleyDreamsIndia.Common;
using ValleyDreamsIndia.Models;

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
        public ActionResult Create(UsersPersonalModelView usersPersonalModelView)
        {
            ViewBag.Title = "Admin: Add New Member";
            

            usersPersonalModelView.UserDetails.Password = "test";
            usersPersonalModelView.UserDetails.CreatedOn = DateTime.Now;
            usersPersonalModelView.UserDetails.SponsoredId = CurrentUser.CurrentUserId;

            usersPersonalModelView.UserDetails.Deleted = 0;
            _valleyDreamsIndiaDBEntities.UsersDetails.Add(usersPersonalModelView.UserDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();

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

        [HttpGet]
        public ActionResult Team()
        {
            ViewBag.Title = "Admin: View Team";
            List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId).ToList();
            List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            foreach(var usr in userDetailList)
            {
                personalDetailList.Add(_valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == usr.Id));
            }
            return View("~/Views/Members/Team/Team.cshtml" , personalDetailList);
        }

        [HttpGet]
        public ActionResult Tree()
        {
            ViewBag.Title = "Admin: Tree";
            int leftPlacementCount = 0;
            int rightPlacementCount = 0;
            int directLeftPlacementCount = 0;
            int directRightPlacementCount = 0;
            List<UsersDetail> userDetailList = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.SponsoredId == CurrentUser.CurrentUserId).ToList();
            List<PersonalDetail> personalDetailList = new List<PersonalDetail>();
            foreach (var usr in userDetailList)
            {
                var placementSide =_valleyDreamsIndiaDBEntities.PersonalDetails.First(x => x.UsersDetailsId == usr.Id).PlacementSide;
                if(placementSide == "LEFT")
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