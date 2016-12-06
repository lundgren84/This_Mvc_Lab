using ConnectLayer;
using MVC_PictureGallery_Lab.ExtraClasses;
using MVC_PictureGallery_Lab.Mapping;
using MVC_PictureGallery_Lab.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_PictureGallery_Lab.Controllers
{
  [Authorize]
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            //var identity = User.Identity as ClaimsIdentity;
            //var email = identity.FindFirst("name").Value;

            return View();
        }
     
        public ActionResult List()
        {
            //Get Account
            var AccUserName = User.Identity.Name;
            AccountViewModel acc = (Crud.GetAccount(AccUserName)).ToModel();
            //Get Accounts Album
            List<AlbumViewModel> Albums = Crud.AccGetAlbums(acc.Id).ToModelList();
            
            Albums.GetPictures();
            return PartialView("List", Albums);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumViewModel Model)
        { 
            if (ModelState.IsValid)
            {
                var AccUserName = User.Identity.Name;
                AccountViewModel acc = (Crud.GetAccount(AccUserName)).ToModel();
                Model.Account = acc;
                Crud.CreateOrUpdate(Model.ToEntity());            
            }         
            return List();
        }       
        public ActionResult Details(Guid Id)
        {
            var Model = Crud.GetAlbums(Id).ToModel();
            Model.Pictures = Crud.GetAlbumPictures(Model.Id).ToModelList();
            Model.Pictures.ForEach(model => model.Comments = Crud.GetComment(model.Id, "picture").ToModelList());
            return View("Details",Model);
        }
        public ActionResult AddPictures(Guid Id)
        {
            AlbumViewModel model = Crud.GetAlbum(Id).ToModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]      
        public ActionResult AddPictures(AlbumViewModel Model, HttpPostedFileBase file)
        {
            if(file != null)
            {
                Thread.Sleep(1000);
                PictureViewModel PictureModel = new PictureViewModel();
                //Save file in Project
                file.SaveAs(Path.Combine(Server.MapPath("~/Pictures"), file.FileName));
                //Fill Picture Model
                PictureModel.Public = false;
                PictureModel.Name = file.FileName;
                PictureModel.Url = $@"/Pictures/" + file.FileName;
                PictureModel.Size = file.ContentLength;
                PictureModel.Id = Guid.NewGuid();
                PictureModel.AlbumRefID = Model.Id;
                Crud.CreatePicture(PictureModel.ToEntity());
                //Spara ny bild med album ref id (skika till någon vettig plats!)
                return Content("Picture Added!");
            }
            return Content("Need a(.jpg, .jpeg, .bmp, .gif, .png) file!");
       
        }   
        [HttpPost]
        public ActionResult Delete(Guid Id)
        {
            var Model = Crud.GetAlbum(Id).ToModel();
            Crud.DeleteAlbum(Model.ToEntity());
            return PartialView("_Empty");
        }
        [HttpPost]
        public ActionResult Edit(Guid Id)
        {
            var Model = Crud.GetAlbum(Id).ToModel();

            return PartialView("_Edit", Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEdit(AlbumViewModel Model)
        {
            var AccUserName = User.Identity.Name;
            AccountViewModel acc = (Crud.GetAccount(AccUserName)).ToModel();
            Model.Account = acc;
            Crud.CreateOrUpdate(Model.ToEntity());
               
            return PartialView("_SingleAlbum",Model);
        }


    }
}