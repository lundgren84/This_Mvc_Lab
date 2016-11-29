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
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AlbumViewModel Model)
        {

        
            if (ModelState.IsValid)
            {
                Model.Id = Guid.NewGuid();   
                Crud.CreateAlbum(Model.ToEntity());
                return Redirect("~/Home/Index");
            }
            return View(Model);
        }
        public ActionResult Details(Guid Id)
        {
            var Model = Crud.GetAlbums(Id).ToModel();
            Model.Pictures = Crud.GetAlbumPictures(Model.Id).ToModelList();
            return View(Model);
        }
        public ActionResult AddPictures(Guid Id)
        {
            AlbumViewModel model = Crud.GetAlbum(Id).ToModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPictures(AlbumViewModel Model, HttpPostedFileBase file)
        {
            PictureViewModel PictureModel = new PictureViewModel();
            //Save file in Project
            file.SaveAs(Path.Combine(Server.MapPath("~/Pictures"), file.FileName));
            //Fill Picture Model
            PictureModel.Name = file.FileName;
            PictureModel.Url = $@"/Pictures/" + file.FileName;
            PictureModel.Size = file.ContentLength;
            PictureModel.Id = Guid.NewGuid();
            PictureModel.AlbumRefID = Model.Id;
            Crud.CreatePicture(PictureModel.ToEntity());
            //Spara ny bild med album ref id (skika till någon vettig plats!)
            return RedirectToAction("Details",new { id = Model.Id });
        }
        public ActionResult Delete(Guid Id)
        {
            var Model = Crud.GetAlbum(Id).ToModel();
            return View(Model);
        }
        [HttpPost]
        public ActionResult Delete(AlbumViewModel model)
        {
            Crud.DeleteAlbum(model.ToEntity());
            return Redirect("~/Home/Index");
        }


    }
}