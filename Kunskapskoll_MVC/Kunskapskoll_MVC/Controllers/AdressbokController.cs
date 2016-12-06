using Kunskapskoll_MVC.Data;
using Kunskapskoll_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kunskapskoll_MVC.Controllers
{
    public class AdressbokController : Controller
    {
        // GET: Adressbok

        IAdressBook db= new DbConnection();

        //public AdressbokController()
        //{
        //    IAdressBook db = new DbConnection();
        //}
        public ActionResult Index()
        {
            //HttpCookie cookie = new HttpCookie("Name","Hampus Lundgren");
            //HttpCookie cookie2 = new HttpCookie("Adress", "Ollevägen 5");
            //Response.Cookies.Add(cookie);
            //Response.Cookies.Add(cookie);
            //var thecookie = Request.Cookies;


            return View();
        }
        public ActionResult List()
        {
            return PartialView("ListAdress", db.All().ToModel());
        }
        [HttpPost]
        public ActionResult Create(AdressViewModel Model)
        {
            db.addOrEdit(Model.ToDb());
            return List();
        }
        [HttpPost]
        public ActionResult Edit(Guid id)
        {
            var model = db.One(id).ToModel();
            return PartialView("_EditPartialView", model);
        }
        [HttpPost]
        public ActionResult SaveEdit(AdressViewModel Model)
        {
            Model.Updaterades = DateTime.Now;
            db.addOrEdit(Model.ToDb());
            return PartialView("_ViewAdress", Model);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            db.Delete(id);
            return PartialView("_Empty");
        }
        public ActionResult Details(Guid Id)
        {
            //FIX
            return View();
        }

    }
}