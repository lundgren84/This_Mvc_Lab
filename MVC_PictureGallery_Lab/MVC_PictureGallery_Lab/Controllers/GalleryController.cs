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
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            IEnumerable<PictureViewModel> Pictures = Crud.GetPictures().ToModelList();
            return View(Pictures);
        }
    }
}