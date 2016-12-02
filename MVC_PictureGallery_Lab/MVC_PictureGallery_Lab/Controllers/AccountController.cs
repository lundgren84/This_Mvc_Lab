using ConnectLayer;
using MVC_PictureGallery_Lab.Mapping;
using MVC_PictureGallery_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_PictureGallery_Lab.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [Authorize]
        public ActionResult Edit()
        {
            var accName = User.Identity.Name;
            var acc = Crud.GetAccount(accName).ToModel();          
            return View(acc);
        }
        public ActionResult SaveEdit(AccountViewModel Model)
        {
            string msg = "Save succeded";
            if (Model.Email == "")
            {
                msg = "Your e-mail cant be nothing!";
            }
            else
            {
              if(!Crud.CreateOrUpdate(Model.ToEntity()))
                {
                    msg = "Unabled to save changes in database! contact personal!";
                }
            }
            return PartialView("_Result", msg);
        }
    }
}