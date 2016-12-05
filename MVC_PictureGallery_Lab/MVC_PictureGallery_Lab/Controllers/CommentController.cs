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
        [Authorize]
        public ActionResult Create(Guid Id)
        {
                var model = new CommentViewModel()
                {
                    Picture = Crud.GetPicture(Id).ToModel()
                };
            return PartialView(model);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel CommentModel,PictureViewModel Model)
        {
            
            if (CommentModel.Text != null)
            {
                var AccUserName = User.Identity.Name;
                AccountViewModel acc = (Crud.GetAccount(AccUserName)).ToModel();
                CommentModel.Account = acc;
                CommentModel.Picture = Model;       
                Crud.CreateComment(CommentModel.ToEntity());
               
            }
            return List(Model.Id);
        }
       [Authorize]
       [HttpPost]
        public ActionResult Delete(Guid id)
        {
            Crud.DeleteComment(id);
            return PartialView("_Empty");
        }
      
        public ActionResult List(Guid Id)
        {
            var Picture = Crud.GetPicture(Id).ToModel();
            var acc = Crud.GetAccount(Picture.AlbumRefID, "album");
            ViewBag.Name = acc.UserName;
            foreach (var item in Picture.Comments)
            {
                item.Account = Crud.GetAccount(item.Id).ToModel();
            }
      
            return PartialView("List",Picture);
        }
    }
}