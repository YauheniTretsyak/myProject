using KnowledgeAccounting.Bll.DTO;
using KnowledgeAccounting.Bll.Interfaces;
using KnowledgeAccounting.Web.Models;
using MvcPL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnowledgeAccounting.Web.Util;

namespace KnowledgeAccounting.Web.Controllers
{
    [Authorize]
    [MyAuthorize(Roles = "Admin")]
    public class KnowledgeController : Controller
    {

      private readonly IService<KnowledgeDTO> service;
        // GET: Knowledge
      public KnowledgeController(IService<KnowledgeDTO> service)
      {
        this.service = service;
      }
      public ActionResult Index()
      {
          
          return View(service.GetAll().Select(Knowledge => Knowledge.ToWebKnowl()));
      }

      public ActionResult IndexPartial()
      {
          
          return PartialView(service.GetAll().Select(Knowledge => Knowledge.ToWebKnowl()));
      }

      // GET: Knowledge/Details/5
      public ActionResult Details(int id = 0)
      {
          if (id != 0) { return View(service.GetById(id)); }
          else { return View(); }

      }

      // GET: Knowledge/Create
      public ActionResult Create()
      {
          return View();
      }

      // POST: Knowledge/Create
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(KnowledgeViewModel knowledge)
      {
          if (ModelState.IsValid)
          {
              service.Create(knowledge.ToDTOKnowl());
              return RedirectToAction("Index");
          }
          return View(knowledge);
      }

      //GET: Knowledge/Delete/5
      public ActionResult Delete(int id = 0)
      {
          if (id != 0)
          {
              var x = service.GetAll().Where(e => e.KnowledgeId == id).Select(knowl => knowl.ToWebKnowl()).FirstOrDefault();
              return View(x);
          }
          else { return RedirectToAction("Index", "Home"); }
      }

      // POST: Knowledge/Delete/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(FormCollection collection, int id = 0)
      {

          try
          {
              service.Delete(id);
              return RedirectToAction("Index", "Knowledge");
          }
          catch
          {
              return RedirectToAction("Index", "Home");
          }


      }
        protected override void Dispose(bool disposing)
        {
          service.Dispose();
          base.Dispose(disposing);
        }
    }
}
