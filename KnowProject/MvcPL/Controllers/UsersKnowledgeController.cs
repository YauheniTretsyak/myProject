using System;
using System.Web.Mvc;
using System.Linq;
using BLL.Interface.Services;
using MvcPL.Filters;
using System.Collections.Generic;
using MvcPL.Infrastructura;
using MvcPL.Models;
using System.Web.Security;

namespace MvcPL.Controllers
{
   [Authorize]
    public class UsersKnowledgeController : Controller
    {
        private readonly IUserKnowledgeService service;
        private readonly IKnowledgeService serviceForKnowl;
        private readonly IUserService serviceForUser;

        public UsersKnowledgeController(IUserKnowledgeService service, IKnowledgeService serviceForKnowl, IUserService serviceForUser)
        {
            this.service = service;
            this.serviceForKnowl = serviceForKnowl;
            this.serviceForUser = serviceForUser;
        }
        // GET: UsersKnowledge
       [MyAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<SelectListItem> knowl = new List<SelectListItem>();
            foreach (var x in serviceForKnowl.GetAll().ToArray())
            {
                knowl.Add(new SelectListItem { Text = x.Name.ToString(), Value = x.KnowledgeId.ToString() });
            }
            ViewBag.Knowledges = knowl;

            Dictionary<int, string> users = new Dictionary<int, string>();
            foreach (var x in serviceForUser.GetAll())
            {
                users.Add(x.UserId, x.Name);
            }
            ViewBag.Users = users;

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "1", Value = "1" });
            items.Add(new SelectListItem { Text = "2", Value = "2" });
            items.Add(new SelectListItem { Text = "3", Value = "3" });
            items.Add(new SelectListItem { Text = "4", Value = "4" });
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            ViewBag.Numbers = items;

            return View(service.GetAll().Select(user =>user.ToWebUserKnowl()));
        }

        [MyAuthorize(Roles = "Admin")]
        public ActionResult Find()
        {
            List<SelectListItem> knowl = new List<SelectListItem>();
            foreach (var x in serviceForKnowl.GetAll())
            {
                knowl.Add(new SelectListItem { Text = x.Name.ToString(), Value = x.KnowledgeId.ToString() });
            }
            ViewBag.Knowledges = knowl;

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "1", Value = "1" });
            items.Add(new SelectListItem { Text = "2", Value = "2" });
            items.Add(new SelectListItem { Text = "3", Value = "3" });
            items.Add(new SelectListItem { Text = "4", Value = "4" });
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            ViewBag.Numbers = items;
            if (Request.IsAjaxRequest())
            {
                return PartialView("AdminAjax");
            }
            return PartialView();
        }

        // GET: UsersKnowledge/Details/5
        public ActionResult Details(int id)
        {
            var edfl = service.GetById(id);
            return View(service.GetById(id));
        }
       
        public ActionResult CertainKnowledgeOfUser(int id)
        {
            Dictionary<int, string> knowl = new Dictionary<int, string>();
            var y = serviceForKnowl.GetAll().ToArray();
            foreach (var x in y)
            {
                knowl.Add(x.KnowledgeId, x.Name);
            }
            ViewBag.Knowledges = knowl;

            var edfl = service.GetAll().Where(x => x.UserId == id).Select(user =>user.ToWebUserKnowl()); 
            ViewBag.Id = id;
            return PartialView(edfl);
        }
        // GET: UsersKnowledge/Create
        
        public ActionResult Create(int Id)
        {
            SelectList knowl = new SelectList(serviceForKnowl.GetAll(), "KnowledgeId", "Name");
            ViewBag.Knowledges = knowl;
            ViewBag.Id = Id;
            return View();
        }

        // POST: UsersKnowledge/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersKnowledgeViewModel mod)
        {
            if (ModelState.IsValid)
            {
                service.Create(mod.ToDALUserKnowl());
                if (Roles.Provider.IsUserInRole(Membership.GetUser().UserName, "Admin"))
                {

                    return RedirectToAction("DetailsForAdmin", "Users");
                }
                else
                {
                    return RedirectToAction("Details", "Users", new { id = Membership.GetUser().ProviderUserKey });
                }
            }
            else
            {
                return View("Create", mod);
            }
        }

        //// GET: UsersKnowledge/Edit/5
        public ActionResult Edit(int UsersKnowledgeId)
        {
            Dictionary<int, string> knowl = new Dictionary<int, string>();
            foreach (var x in serviceForKnowl.GetAll())
            {
                knowl.Add(x.KnowledgeId, x.Name);
            }
            ViewBag.Knowledges = knowl;
            var edfl = service.GetAll().Where(x => x.UsersKnowledgeId == UsersKnowledgeId).Select(user =>user.ToWebUserKnowl()).FirstOrDefault();
            return View(edfl);
        }

        //// POST: UsersKnowledge/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersKnowledgeViewModel collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Update(collection.ToDALUserKnowl());
                    if (Roles.Provider.IsUserInRole(Membership.GetUser().UserName, "Admin"))
                    {

                        return RedirectToAction("DetailsForAdmin", "Users");
                    }
                    else
                    {
                        return RedirectToAction("Details", "Users", new { id = Membership.GetUser().ProviderUserKey });
                    }
                }
                catch
                {
                    return View("Edit", collection);
                }
            }
            else
            {
                return View();
            }
        }

        // GET: UsersKnowledge/Delete/5
        public ActionResult Delete(int UsersKnowledgeId)
        {
            var edfl = service.GetAll().Where(x => x.UsersKnowledgeId == UsersKnowledgeId).Select(user =>user.ToWebUserKnowl()).FirstOrDefault();
            return View(edfl);
        }

        // POST: UsersKnowledge/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete( FormCollection collection,int id=0)
        {
            try
            {
                service.Delete(id);

                if (Roles.Provider.IsUserInRole(Membership.GetUser().UserName, "Admin"))
                {

                    return RedirectToAction("DetailsForAdmin", "Users");
                }
                else
                {
                    return RedirectToAction("Details", "Users", new { id = Membership.GetUser().ProviderUserKey });
                }
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