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
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string txt)
        {
            var Model = new ChatViewModel();
            Model.Text = txt;
            Model.PostTime = DateTime.UtcNow;
            Model.AccountRefID = new Guid();
            if (User.Identity.IsAuthenticated)
            {
                var acc = Crud.GetAccount(User.Identity.Name);
                Model.AccountRefID = acc.Id;
            }        
            Crud.CreateChatPost(Model.ToEntity());
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            var chatContent = Crud.GetChat().ToModelList();

            List<ChatContentViewModel> ChatObjects = new List<ChatContentViewModel>();
            chatContent.ForEach(m => ChatObjects.Add(new ChatContentViewModel()
            {
                Text = m.Text,
                AccountName = Crud.GetAccountName(m.AccountRefID)
            }));

            return Json(ChatObjects, JsonRequestBehavior.AllowGet);
        }
    }
}