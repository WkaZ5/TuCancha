﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanchaFinal.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Index()
        {
            if (Session["Adminn"] != null)
            {
                return View();
            }
            else
            {
                return View("../Menu/Menu");
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return View("../Menu/Menu");
        }
    }
}