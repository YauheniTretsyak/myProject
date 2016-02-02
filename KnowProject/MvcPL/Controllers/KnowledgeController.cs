using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcPL.Infrastructura;

namespace MvcPL.Controllers
{
    public class KnowledgeController : Controller
    {

        private readonly IKnowledgeService service;

        public KnowledgeController(IKnowledgeService service)
        {
            this.service = service;
        }


        public ActionResult Index()
        {
            var edfl = service.GetAll();
            return View(service.GetAll().Select(Knowledge =>Knowledge.ToWebKnowl())); 
        }

        // GET: Knowledge/Details/5
        public ActionResult Details(int id)
        {

            return View(service.GetById(id));
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

            service.Create(knowledge.ToDTOKnowl());
            return RedirectToAction("Index");
        }

         //GET: Knowledge/Delete/5
        public ActionResult Delete(int id)
        {
            var x = service.GetAll().Where(e => e.KnowledgeId == id).Select(knowl =>knowl.ToWebKnowl()).FirstOrDefault();
            return View(x);
        }

        // POST: Knowledge/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
            try
            {
                service.Delete(id);
                return RedirectToAction("Index", "Knowledge");
            }
              catch
            {
                  return RedirectToAction("Index", "Home", null);
            }  
            
   
        }
        protected override void Dispose(bool disposing)
        {
          
            base.Dispose(disposing);
        }
    }
}