using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVC_PictureGallery_Lab.Filters
{
    public class AdministartionAuthorisation : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var principal = filterContext.HttpContext.User as ClaimsPrincipal;
            if(principal == null || !principal.HasClaim("IsAdministrator", "True"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}