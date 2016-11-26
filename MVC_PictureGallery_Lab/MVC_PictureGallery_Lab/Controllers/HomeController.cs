
using ConnectLayer;
using MVC_PictureGallery_Lab.ExtraClasses;
using MVC_PictureGallery_Lab.Mapping;
using MVC_PictureGallery_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_PictureGallery_Lab.Controllers
{
   
    public class HomeController : Controller
    {
       

     

        // GET: Home
        public ActionResult Index()
        {
            List<AlbumViewModel> Albums = Crud.GetAlbums().ToModelList();
            Albums.GetPictures();
            return View(Albums);
        }
    }
}