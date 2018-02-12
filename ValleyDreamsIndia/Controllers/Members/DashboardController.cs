using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValleyDreamsIndia.Controllers.Members
{
    [Authorize]
    public class DashboardController : Controller
    {
        
        public ActionResult Index()
        {
            return View("~/Views/Members/Dashboard/Index.cshtml");
        }
    }
}