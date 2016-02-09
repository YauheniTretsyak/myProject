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
using System.Web.Security;

namespace KnowledgeAccounting.Web.Controllers
{
    [Authorize]
    [MyAuthorize(Roles = "Admin")]
    public class RoleController : Controller
    {
          private readonly IService<RoleDTO> service;
          public RoleController(IService<RoleDTO> service)
          {
            this.service = service;
          }
        // GET: Role
          // GET: Role

          public ActionResult Index()
          {
              return View(service.GetAll().Select(role => role.ToWebRole()));
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
              if (ModelState.IsValid)
              {
                  service.Create(rol.ToDTORole());
                  return RedirectToAction("Index");
              }
              else
              {
                  return View("Create", rol);
              }
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
              if (ModelState.IsValid)
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
              else
              {
                  return View("Edit", collection);
              }
          }

          //// GET: Role/Delete/5
          public ActionResult Delete(int id)
          {
              var x = service.GetAll().Where(e => e.RoleId == id).Select(role => role.ToWebRole()).FirstOrDefault();
              return View(x);
          }

          //// POST: Role/Delete/5
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(FormCollection collection, int id = 0)
          {
              try
              {
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
          service.Dispose();
          base.Dispose(disposing);
        }
    }
}
