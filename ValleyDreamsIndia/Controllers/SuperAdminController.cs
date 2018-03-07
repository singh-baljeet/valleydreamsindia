using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ValleyDreamsIndia.Common;
using ValleyDreamsIndia.Models;
using static ValleyDreamsIndia.Common.TreeStructure;

namespace ValleyDreamsIndia.Controllers
{
    public class SuperAdminController : Controller
    {
        ValleyDreamsIndiaDBEntities _valleyDreamsIndiaDBEntities = null;
        static string password = "";
        static string transactionpassword = "";
        static string username = "";

        public SuperAdminController()
        {
            _valleyDreamsIndiaDBEntities = new ValleyDreamsIndiaDBEntities();
        }


        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.ErrorMessage = false;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsersDetail userDetail)
        {
            UsersDetail usrDetail = _valleyDreamsIndiaDBEntities.UsersDetails
                                        .Where(x => x.UserName == userDetail.UserName && x.Password == userDetail.Password && x.Deleted == -1).FirstOrDefault();
            if (usrDetail != null)
            {
                FormsAuthentication.SetAuthCookie(usrDetail.UserName, false);
                var authTicket = new FormsAuthenticationTicket(1, usrDetail.UserName, DateTime.Now
                    , DateTime.Now.AddMinutes(20), false, usrDetail.Id.ToString());
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("CreateMember", "SuperAdmin");
            }
            else
            {
                ViewBag.ErrorMessage = true;
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateMember()
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            ViewBag.TransactionPassword = transactionpassword;

            ViewBag.Title = "SuperAdmin: Add New Member";
            UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
            return View(usersPersonalModelView);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateMember(UsersPersonalModelView usersPersonalModelView)
        {
            UsersDetail userDetail = new UsersDetail();
            userDetail.SponsoredId = CurrentUser.CurrentUserId;
            userDetail.Password = Guid.NewGuid().ToString().Substring(0, 6);
            userDetail.Deleted = 0;
            userDetail.CreatedOn = DateTime.Now;

            _valleyDreamsIndiaDBEntities.Entry(userDetail).State = EntityState.Added;
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
            contributionDetails.PayedBy = "ADMIN";
            contributionDetails.IsCompleted = 0;
            _valleyDreamsIndiaDBEntities.ContributionDetails.Add(contributionDetails);
            _valleyDreamsIndiaDBEntities.SaveChanges();

            password = userDetail.Password;
            transactionpassword = usersPersonalModelView.BankDetails.TransactionPassword;
            username = userDetail.UserName;

            return RedirectToAction("CreateMember");
        }


        [Authorize]
        [HttpGet]
        public ActionResult AssignPin()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AssignPin(string sponsoredId, int totalPin, string pinType)
        {
            var getUser = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == sponsoredId).FirstOrDefault();
            if (pinType == "NEW")
            {
                UsersDetail userDetail = new UsersDetail();

                for (int i = 1; i <= totalPin; i++)
                {
                    userDetail.PinCreatedOn = DateTime.Now;
                    userDetail.Deleted = 0;
                    userDetail.SponsoredId = getUser.Id;
                    userDetail.IsPinUsed = 0;
                    userDetail.PinType = pinType;
                    _valleyDreamsIndiaDBEntities.UsersDetails.Add(userDetail);
                    _valleyDreamsIndiaDBEntities.SaveChanges();
                }
            }
            if (pinType == "RENEW")
            {
                RenewalPinDetail renewalPinDetail = new RenewalPinDetail();

                for (int i = 1; i <= totalPin; i++)
                {
                    renewalPinDetail.PinCreatedOn = DateTime.Now;
                    renewalPinDetail.Deleted = 0;
                    renewalPinDetail.SponsoredId = getUser.Id;
                    renewalPinDetail.IsPinUsed = 0;
                    _valleyDreamsIndiaDBEntities.RenewalPinDetails.Add(renewalPinDetail);
                    _valleyDreamsIndiaDBEntities.SaveChanges();
                }
            }

            ViewBag.Message = $"{pinType} has been assigned successfully";
            return View();

        }

        [Authorize]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            UserPersonalListModelView userPersonalListModelView = new UserPersonalListModelView();
            List<PersonalDetail> personalDetailList = _valleyDreamsIndiaDBEntities.PersonalDetails.ToList();
            userPersonalListModelView.PersonalDetails = personalDetailList;
            return View(userPersonalListModelView);
        }


        [Authorize]
        [HttpPost]
        public ActionResult SearchByMemberId(string memberId)
        {
            if(memberId == ""  || memberId == string.Empty || memberId == null)
            {
                return RedirectToAction("GetAllUsers");
            }
            UserPersonalListModelView userPersonalListModelView = new UserPersonalListModelView();
            List<PersonalDetail> personalDetailList = _valleyDreamsIndiaDBEntities.PersonalDetails.
                Where(x=>x.UsersDetail.UserName == memberId).ToList();
            userPersonalListModelView.PersonalDetails = personalDetailList;
            return View("GetAllUsers",userPersonalListModelView);
        }


        [HttpGet]
        public ActionResult ViewProfile(int currentId = 0)
        {
            ViewBag.Title = "Admin: Profile";
            try
            {
                if (currentId == 0)
                {
                    return View("~/Views/Members/Profile/ViewProfile.cshtml",
                    GetPersonalAndUserDetails(CurrentUser.CurrentUserId));
                }
                else
                {
                    return View("~/Views/Members/Profile/ViewProfile.cshtml",
                    GetPersonalAndUserDetails(currentId));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Edit(int currentId = 0)
        {
            ViewBag.Title = "Admin: Profile Settings";
            try
            {
                if (currentId == 0)
                {
                    return View("~/Views/Members/Profile/Edit.cshtml", GetPersonalAndUserDetails(CurrentUser.CurrentUserId));
                }
                else
                {
                    return View("~/Views/Members/Profile/Edit.cshtml", GetPersonalAndUserDetails(currentId));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Edit(UsersPersonalModelView usersPersonalModelView, HttpPostedFileBase memberImage)
        {
            ViewBag.Title = "Admin: Profile Settings";
            try
            {
                PersonalDetail personalDetails = _valleyDreamsIndiaDBEntities.PersonalDetails
                    .Where(x => x.UsersDetailsId == usersPersonalModelView.UserDetails.Id).FirstOrDefault();

                BankDetail bankDetails = _valleyDreamsIndiaDBEntities.BankDetails
                    .Where(x => x.UsersDetailsId == usersPersonalModelView.UserDetails.Id).FirstOrDefault();

                if (memberImage != null)
                {
                    string randomImageName = Guid.NewGuid().ToString().Substring(0, 5) + memberImage.FileName;
                    personalDetails.ProfilePic = "/UploadedTeamImages/" + randomImageName;
                    memberImage.SaveAs(Server.MapPath("~/UploadedTeamImages/") + randomImageName);
                }

                personalDetails.BirthDate = usersPersonalModelView.PersonalDetails.BirthDate;
                personalDetails.PhoneNumber2 = usersPersonalModelView.PersonalDetails.PhoneNumber2;
                personalDetails.Email = usersPersonalModelView.PersonalDetails.Email;
                personalDetails.State = usersPersonalModelView.PersonalDetails.State;
                personalDetails.District = usersPersonalModelView.PersonalDetails.District;
                personalDetails.City = usersPersonalModelView.PersonalDetails.City;
                personalDetails.PinCode = usersPersonalModelView.PersonalDetails.PinCode;
                personalDetails.UpdatedOn = DateTime.Now;

                _valleyDreamsIndiaDBEntities.Entry(personalDetails).State = EntityState.Modified;


                bankDetails.NomineeName = usersPersonalModelView.BankDetails.NomineeName;
                bankDetails.NomineeRelation = usersPersonalModelView.BankDetails.NomineeRelation;
                bankDetails.BankName = usersPersonalModelView.BankDetails.BankName;
                bankDetails.AccountHolderName = usersPersonalModelView.BankDetails.AccountHolderName;
                bankDetails.AccountNumber = usersPersonalModelView.BankDetails.AccountNumber;
                bankDetails.IFSCCode = usersPersonalModelView.BankDetails.IFSCCode;
                bankDetails.PANNumber = usersPersonalModelView.BankDetails.PANNumber;
                bankDetails.UpdatedOn = DateTime.Now;
                _valleyDreamsIndiaDBEntities.Entry(bankDetails).State = EntityState.Modified;

                _valleyDreamsIndiaDBEntities.SaveChanges();

                return RedirectToAction("ViewProfile", new { currentId = usersPersonalModelView.UserDetails.Id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private UsersPersonalModelView GetPersonalAndUserDetails(int userDetailsId)
        {
            UsersPersonalModelView usersPersonalModelView = new UsersPersonalModelView();
            usersPersonalModelView.UserDetails = _valleyDreamsIndiaDBEntities.UsersDetails
                .First(x => x.Id == userDetailsId && x.Deleted == 0);
            usersPersonalModelView.PersonalDetails = _valleyDreamsIndiaDBEntities.PersonalDetails
                .First(x => x.UsersDetailsId == userDetailsId && x.Deleted == 0);
            usersPersonalModelView.BankDetails = _valleyDreamsIndiaDBEntities.BankDetails
                .First(x => x.UsersDetailsId == userDetailsId && x.Deleted == 0);
            usersPersonalModelView.ContributionDetails = _valleyDreamsIndiaDBEntities.ContributionDetails
                .Where(x => x.UserDetailsId == userDetailsId).OrderByDescending(x => x.Id).FirstOrDefault();
            return usersPersonalModelView;
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
            return View(parentResult);
        }

        [HttpPost]
        public ActionResult TreeByUserId(string userId)
        {
            ViewBag.Title = "Admin: Tree";
            int currentUserId = _valleyDreamsIndiaDBEntities.UsersDetails.Where(x => x.UserName == userId).FirstOrDefault().Id;
            Parent parentResult = TreeDetails(currentUserId);
            return View("Tree", parentResult);
        }

        public Parent TreeDetails(int currentId)
        {
            var UserDetailsResults = _valleyDreamsIndiaDBEntities.UsersDetails.First(x => x.Id == currentId);
            ViewBag.UserName = UserDetailsResults.UserName;
            var PersonalDetails = UserDetailsResults.PersonalDetails.Where(x => x.UsersDetailsId == currentId).FirstOrDefault();
            ViewBag.FullName = PersonalDetails.FirstName + " " + PersonalDetails.LastName;
            ViewBag.Sponsor = UserDetailsResults.UsersDetail1.UserName;
            //var SponsorPersonalDetail = UserDetailsResults.UsersDetail1.PersonalDetails.FirstOrDefault();
            //ViewBag.SponsorName = SponsorPersonalDetail.FirstName + " " + SponsorPersonalDetail.LastName;

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

            
            return parentResult;

        }


    }
}

//try
//{
//    // Your code...
//    // Could also be before try if you know the exception occurs in SaveChanges


//}
//catch (DbEntityValidationException e)
//{
//    foreach (var eve in e.EntityValidationErrors)
//    {
//        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
//            eve.Entry.Entity.GetType().Name, eve.Entry.State);
//        foreach (var ve in eve.ValidationErrors)
//        {
//            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
//                ve.PropertyName, ve.ErrorMessage);
//        }
//    }
//    throw;
//}

