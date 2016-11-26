using ConnectLayer;
using MVC_PictureGallery_Lab.Mapping;
using MVC_PictureGallery_Lab.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_PictureGallery_Lab.Controllers
{
    public class PictureController : Controller
    {
        // GET: Picture
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PictureViewModel Model, HttpPostedFileBase file)
        {
            if(file == null ||file.ContentLength == 0)
            {
                ModelState.AddModelError("error", "En fil vill jag gärna att du laddar upp!");
                return PartialView("Error", file);
            }
            if (file != null)
            {
                //Save file in Project
                file.SaveAs(Path.Combine(Server.MapPath("~/Pictures"), file.FileName));
                //Fill Picture Model
                Model.Name = file.FileName;
                Model.Url = $@"/Pictures/" + file.FileName;
                Model.Size = file.ContentLength;
                Model.Id = Guid.NewGuid();
                Crud.CreatePicture(Model.ToEntity());
                return RedirectToAction("Index", "Gallery");
            }
            return View(Model);
        }

        public ActionResult Details(Guid Id)
        {
            var Model = Crud.GetPicture(Id).ToModel();
            return View(Model);
        }
        public ActionResult Edit(Guid Id)
        {
            var Model = Crud.GetPicture(Id).ToModel();
            return View(Model);
        }
        [HttpPost]
        public ActionResult Edit(PictureViewModel Model)
        {
            if (ModelState.IsValid)
            {
                Crud.EditPicture(Model.ToEntity());
                return RedirectToAction("Details", new { id = Model.Id });
            }
            return View(Model);
        }
        public ActionResult Delete(Guid id)
        {
            var Model = Crud.GetPicture(id).ToModel();

            Crud.DeletePicture(Model.ToEntity());
            if (Model.AlbumRefID == new Guid())
            {
                return Redirect("~/Gallery/Index");
            }
            else
            {
                return RedirectToAction("Details", "Album", new { id = Model.AlbumRefID });
            }    
        }
        //[HttpPost]
        //public ActionResult Delete(PictureViewModel Model)
        //{
        //    Crud.DeletePicture(Model.ToEntity());
        //    if (Model.AlbumRefID == null)
        //    {
        //        return Redirect("~/Gallery/Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Details","Album", new { id = Model.AlbumRefID });
        //    }
        //}
    }
}