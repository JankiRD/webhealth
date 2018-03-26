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
using System.IO;
namespace Surrogacy.Controllers
{
    public class DoctorDashboardController : Controller
    {
        // GET: DoctorDashboard
        public ActionResult Index()
        {
            return View();
        }

        [CheckSessionOut]
        public ActionResult DoctorDashboard()
        {
            DoctorDashboadService dashboardService = new DoctorDashboadService();
            DoctorDashboard doctordashboard = new DoctorDashboard();
            doctordashboard = dashboardService.ViewDoctorDashboardData(new DoctorDashboard());
            return View("DoctorDashboard", doctordashboard);
        }
    }
}