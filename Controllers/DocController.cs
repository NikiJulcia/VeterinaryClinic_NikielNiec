﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VeterinaryClinic.Controllers
{
    public class DocController : Controller
    {
        // GET: Doc
        public ActionResult Index()
        {
            return View();
        }
    }
}