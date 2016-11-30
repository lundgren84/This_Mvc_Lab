using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PictureGallery_Lab
{
    public class MyIdentityDbContext:IdentityDbContext<IdentityUser>
    {
        public MyIdentityDbContext() : base("name = MvcGalleryAuthorDb") { }
    }
}