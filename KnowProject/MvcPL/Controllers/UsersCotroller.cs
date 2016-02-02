using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Providers;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using PagedList.Mvc;
using PagedList;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using MvcPL.Infrastructura;

namespace MvcPL.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUserService service;
        private readonly IUserKnowledgeService serviceForUserKnowl;
        private readonly IKnowledgeService serviceForKnowl;

        public UsersController(IUserService service, IUserKnowledgeService serviceForUserKnowl, IKnowledgeService serviceForKnowl)
        {
            this.service = service;
            this.serviceForUserKnowl = serviceForUserKnowl;
            this.serviceForKnowl = serviceForKnowl;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(FormCollection form, int? page)
        {
            if (form["WhatDoYouWanna"] == "Find") 
            {
                int pageSize = 3;
                int pageNumber = (page ?? 1);


                var userKnowledgers = serviceForUserKnowl.GetAll().Where((x) => x.Degree >= Convert.ToInt32(form["Numbers"]) && x.KnowledgeId == Convert.ToInt32(form["Knowledges"])).Select(x => x.ToWebUserKnowl());

                var usersTemp = service.GetAll().Select(y =>y.ToWebUser()); 

                Dictionary<int, string> users = new Dictionary<int, string>();
                foreach (var x in service.GetAll().ToList())
                {
                    users.Add(x.UserId, x.Name);
                }
                ViewBag.Users = users;


                var q = from t in userKnowledgers
                        join tID in usersTemp on t.UserId equals tID.UserId
                        select new UserViewModel { Email = tID.Email, Name = tID.Name, Photo = tID.Photo, UserId = tID.UserId };
                return View("Admin", q.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var knowledge = serviceForKnowl.GetById(Convert.ToInt32(form["Knowledges"]));
                var number = Convert.ToInt32(form["Numbers"]);

                var serviceForViewBagKnowl = serviceForKnowl.GetAll().ToList();


                var userKnowledgers = serviceForUserKnowl.GetAll().Where((x) => x.Degree >= number && x.KnowledgeId == knowledge.KnowledgeId).Select(x =>x.ToWebUserKnowl()); 

                var usersTemp = service.GetAll().Select(y =>y.ToWebUser()); 

                Dictionary<int, string> knowlName = new Dictionary<int, string>();
                foreach (var x in serviceForViewBagKnowl)
                {
                    knowlName.Add(x.KnowledgeId, x.Name);
                }


                var q = from t in userKnowledgers
                        join tID in usersTemp on t.UserId equals tID.UserId
                        select new UserViewModel { Email = tID.Email, Name = tID.Name, Photo = tID.Photo, UserId = tID.UserId };

                var q2 = q.ToList();



                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc";


                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = true;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);


                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text = "Knowledge - " + knowledge.Name + ", Power of knowledge >= " + Convert.ToInt32(form["Numbers"]);
                oPara1.Range.Font.Bold = 1;
                oPara1.Format.SpaceAfter = 12;
                oPara1.Range.InsertParagraphAfter();

                foreach (var item in q2)
                {
                    Word.Paragraph oPara2;
                    oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara2.Range.InsertParagraphBefore();
                    oPara2.Range.Text = "IserId - " + item.UserId + ", Users name - " + item.Name + ", Email - " + item.Email;
                    oPara2.Range.InsertParagraphAfter();
                    foreach (var y in serviceForUserKnowl.GetAll().Where(x => x.UserId == item.UserId).ToList())
                    {
                        Word.Paragraph oPara4;
                        oPara4 = oDoc.Content.Paragraphs.Add(ref oMissing);
                        oPara4.Range.Font.Bold = 0;
                        oPara4.Range.Text = "Knowledge - " + knowlName[y.KnowledgeId] + ", Power - " + y.Degree + ", Description - " + y.Description;
                        oPara4.Range.InsertParagraphAfter();
                    }
                }

                return View("DocForYou");
            }

        }

        public ActionResult Details(int id)
        {
            var user = service.GetById(id);

            return View(user.ToWebUser()); 
        }

        public ActionResult DetailsForAdmin(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);


            var users = service.GetAll().Select(x => x.ToWebUser());
            return View("Admin", users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit(int id)
        {
            var x = service.GetAll().Where(e => e.UserId == id).Select(user =>user.ToWebUser()).FirstOrDefault();
            return View(x);
        }
        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel model)
        {
            var blluser = new UserDTO()
            {
                UserId = model.UserId,
                Name = model.Name,
                RoleId = model.RoleId,
                Password = Crypto.HashPassword(model.Password),
                Email = model.Email,
                Photo=model.Photo
            };
            service.Update(blluser);
            if (Roles.Provider.IsUserInRole(Membership.GetUser().UserName, "Admin"))
            {

                return RedirectToAction("DetailsForAdmin", "Users", new { id = Membership.GetUser().ProviderUserKey });
            }
            else
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home", null);
            }

        }

        public ActionResult Login()
        {

            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Users");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid&&uploadImage!=null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                model.Photo = imageData;

                MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(model.Name, model.Password, model.Email, model.Photo);

                if (membershipUser != null)
                {
                   
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                }
            }
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Delete(int id=0) {
            var x = service.GetAll().Where(e => e.UserId == id).Select(user =>user.ToWebUser()).FirstOrDefault();
            return View(x);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {
                

                if (Roles.Provider.IsUserInRole(Membership.GetUser().UserName, "Admin"))
                {
                    service.Delete(id);
                    return RedirectToAction("DetailsForAdmin", "Users");
                }
                else
                {
                    FormsAuthentication.SignOut();
                    service.Delete(id);
                    return RedirectToAction("Index", "Home", null);
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