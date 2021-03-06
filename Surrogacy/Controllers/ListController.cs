﻿using System;
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
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            return View();
        }
        [CheckSessionOut]
        public ActionResult ListSurrogate()
        {
            ListService listservice = new ListService();
            List<ListSurrogate> listsurrogate = new List<ListSurrogate>();
            listsurrogate = listservice.GetListSurrogate(new ListSurrogate());
            return View("ListSurrogate", listsurrogate);
        }

    }
}