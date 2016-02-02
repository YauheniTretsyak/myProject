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
    public class RoleController : Controller
    {
        private readonly IRoleService service;

        public RoleController(IRoleService service)
        {
            this.service = service;
        }


        // GET: Role
        public ActionResult Index()
        {
            return View(service.GetAll().Select(role =>role.ToWebRole())); 
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {

            return View(service.GetById(id));
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleViewModel rol)
        {
            service.Create(rol.ToDTORole());
            return RedirectToAction("Index");
        }

        //// GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            var x = service.GetAll().Where(e => e.RoleId == id).Select(role => role.ToWebRole()).FirstOrDefault();
            return View(x);
        }

        //// POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(RoleViewModel collection)
        {
            try
            {
                service.Update(collection.ToDTORole());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            var x = service.GetAll().Where(e => e.RoleId == id).Select(role =>role.ToWebRole()).FirstOrDefault();
            return View(x);
        }

        //// POST: Role/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try{
                service.Delete(id);
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home", null);
                
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}