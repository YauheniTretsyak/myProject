﻿
using System;
using System.Web.Mvc;



namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult Problem()
        {
            return View();
        }
        
    }
}