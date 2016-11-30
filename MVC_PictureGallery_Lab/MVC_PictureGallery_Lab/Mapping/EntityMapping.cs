using ConnectLayer;
using MVC_PictureGallery_Lab.Mapping;
using MVC_PictureGallery_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PictureGallery_Lab.Mapping
{
    public static class EntityMapping
    {
        //Account
        public static Account ModelToEntity(AccountViewModel model)
        {
            var Entity = new Account()
            {
                Id = model.Id,
                FirstName = model.Fistname,
                LastName = model.Lastname,
                Email = model.Email,
                Hash = model.Hash,
          
            };
            return Entity;
        }
        public static AccountViewModel EntityToModel(Account Entity)
        {
            var Model = new AccountViewModel()
            {
                Id = Entity.Id,
                Fistname = Entity.FirstName,
                Lastname = Entity.LastName,
                Email = Entity.Email,
                Hash = Entity.Hash,           
            };
            return Model;
        }
        //Album
        public static Album ToEntity(this AlbumViewModel model)
        {
            var Entity = new Album()
            {
                Id = model.Id,
                Name = model.Name,
                Topic = model.Topic,          
            };
            return Entity;
        }
        public static AlbumViewModel ToModel(this Album Entity)
        {
            var Model = new AlbumViewModel()
            {
                Id = Entity.Id,
                Name = Entity.Name,
                Topic = (AlbumTopic)((int)Entity.Topic),
            };
            return Model;
        }
        public static List<AlbumViewModel> ToModelList(this List<Album> Entites)
        {
            var Models = new List<AlbumViewModel>();
            Entites.ForEach(x => Models.Add(x.ToModel()));
            return Models;
        }


        //Comment
        public static Comment ToEntity(this CommentViewModel model)
        {
            if(model.Picture == null)
            {
                model.Picture = new PictureViewModel();
            }
            var Entity = new Comment()
            {
                Id = model.Id,
                Text = model.Text,
                PictureRefID = model.Picture.Id        
            };
            return Entity;
        }
        public static CommentViewModel ToModel(this Comment Entity)
        {
            var Model = new CommentViewModel()
            {
                Id = Entity.Id,
                Text = Entity.Text,
            };
            return Model;
        }
        public static List<CommentViewModel> ToModelList(this List<Comment> Entites)
        {
            var Models = new List<CommentViewModel>();
            Entites.ForEach(x => Models.Add(x.ToModel()));
            return Models;
        }
        //Picture
        public static Picture ToEntity(this PictureViewModel model)
        {
            var Entity = new Picture()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                Size = model.Size,
                
            };
            if (model.AlbumRefID != new Guid())
            {
                Entity.AlbumRefID = model.AlbumRefID;
            };
            return Entity;
        }
        public static PictureViewModel ToModel(this Picture Entity)
        {
            var Model = new PictureViewModel()
            {
                Id = Entity.Id,
                Name = Entity.Name,
                Url = Entity.Url,
                Size = (int)Entity.Size,
                Comments = (Crud.GetCommentsFromPicture(Entity.Id)).ToModelList(),                      
            };
            if(Entity.AlbumRefID != null)
            {
                Model.AlbumRefID = (Guid)Entity.AlbumRefID;
            };

            return Model;
        }
        public static List<PictureViewModel> ToModelList(this List<Picture> Pictures)
        {
            var ModelPictures = new List<PictureViewModel>();
            Pictures.ForEach(x=> ModelPictures.Add(x.ToModel()));
            return ModelPictures;
        }
    }
}

