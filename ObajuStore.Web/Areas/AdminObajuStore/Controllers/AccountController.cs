﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObajuStore.Web.Areas.AdminObajuStore.Controllers
{
    public class AccountController : BaseController
    {
        // GET: AdminObajuStore/Account
        public ActionResult Index()
        {
            return View();
        }
    }
}