using KnowledgeAccounting.Bll.DTO;
using KnowledgeAccounting.Bll.Interfaces;
using KnowledgeAccounting.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnowledgeAccounting.Bll.Mappers;
using System.Web.Security;

namespace KnowledgeAccounting.Web.Controllers
{
  public class HomeController : Controller
  {

    public ActionResult Index()
    {
        
        return View();
    }

  }
}