using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Surrogacy.Entity;
using Surrogacy.Helper;
using Surrogacy.Models;
using Surrogacy.Service;
using Surrogacy.Util;
using static Surrogacy.Entity.FormData;
using static Surrogacy.MvcApplication;

namespace Surrogacy.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [CheckSessionOut]
        public ActionResult Index()
        {
            Dashboard dashborad = new Dashboard();
            return View(dashborad);
        }

        [CheckSessionOut]
        public ActionResult Dashboard()
        {
            DashboardService dashboardService = new DashboardService();
            List<Dashboard> dashboard = new List<Dashboard>();
            dashboard = dashboardService.ViewDashboardData(new Dashboard());

            return View("Dashboard", dashboard);
        }

    }
}