﻿using ConnectLayer;
using MVC_PictureGallery_Lab.Mapping;
using MVC_PictureGallery_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace MVC_PictureGallery_Lab.ExtraClasses
{
    public static class UserExtensions
    {
        public static bool isAdministratior(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;

            return claimsIdentity.HasClaim("IsAdministrator", "True");
        }
    }
    public static class ExtendedMethods
    {
        public static void GetPictures(this List<AlbumViewModel> Albums)
        {
            foreach (var album in Albums)
            {
                List<PictureViewModel> PictureModels = (Crud.GetPictureToAlbum(album.Id)).ToModelList();
                if (PictureModels.Count == 0)
                {
                    album.Pictures = new List<PictureViewModel>();
                }
                else
                {
                    album.Pictures = PictureModels;
                }
            }
        }
    }
}