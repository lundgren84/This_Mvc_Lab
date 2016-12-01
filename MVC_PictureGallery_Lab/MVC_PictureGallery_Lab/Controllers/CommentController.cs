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
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(Guid Id)
        {
                var model = new CommentViewModel()
                {
                    Picture = Crud.GetPicture(Id).ToModel()
                };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CommentViewModel Model)
        {
            if (ModelState.IsValid)
            {
                var AccUserName = User.Identity.Name;
                AccountViewModel acc = (Crud.GetAccount(AccUserName)).ToModel();
                Model.Account = acc;         
                Crud.CreateComment(Model.ToEntity());
                return RedirectToAction("Details","Picture", new { id = Model.Picture.Id });
            }
            return View(Model);
        }
        public ActionResult Delete(Guid id)
        {
            var Model = Crud.GetComment(id).ToModel();
            return View(Model);
        }
        [HttpPost]
        public ActionResult Delete(CommentViewModel Model)
        {
            Crud.DeleteComment(Model.ToEntity());
            return Redirect("Details/Picture");
        }
    }
}