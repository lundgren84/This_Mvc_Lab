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
        public ActionResult Create(ChatViewModel Model)
        {
            return View();
        }
    }
}