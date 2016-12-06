using MVC_PictureGallery_Lab.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_PictureGallery_Lab.Areas.Administration.Controllers
{
    [AdministartionAuthorisation]    
    public class DashboardController : Controller
    {
        // GET: Administration/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}