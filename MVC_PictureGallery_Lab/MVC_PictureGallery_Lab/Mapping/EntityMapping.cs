using ConnectLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        public static AccountViewModel ToModel(this Account Entity)
        {
            var Model = new AccountViewModel()
            {
                Id = Entity.Id,
                UserName = Entity.UserName,
                
            };
            return Model;
        }
        public static Account ToEntity(this AccountViewModel user)
        {
            return new Account()
            {

                UserName = user.UserName,
                Id = user.Id
            };
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
            if(model.Account != null)
            {
                Entity.AccountRefID = model.Account.Id;
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
                DateCreated = (DateTime)Entity.DateCreated
            };
            return Model;
        }
        public static List<AlbumViewModel> ToModelList(this List<Album> Entites)
        {
            var Models = new List<AlbumViewModel>();
            Entites.ForEach(x => Models.Add(x.ToModel()));
            Models.OrderBy(x => x.DateCreated);
            return Models;
        }


        //Comment
        public static Comment ToEntity(this CommentViewModel model)
        {
            if (model.Picture == null)
            {
                model.Picture = new PictureViewModel() {Id = new Guid() };
            }
            if(model.Account == null) { model.Account = new AccountViewModel() { Id = new Guid() }; }
            var Entity = new Comment()
            {
                Id = model.Id,
                Text = model.Text,
                PictureRefID = model.Picture.Id,
                AccountRefID = model.Account.Id
            };
            return Entity;
        }
        public static CommentViewModel ToModel(this Comment Entity)
        {
            var Model = new CommentViewModel()
            {
                Id = Entity.Id,
                Text = Entity.Text,
                DateCreated = (DateTime)Entity.DateCreated
            };
            return Model;
        }
        public static List<CommentViewModel> ToModelList(this List<Comment> Entites)
        {
            var Models = new List<CommentViewModel>();
            Entites.ForEach(x => Models.Add(x.ToModel()));
            Models.OrderBy(x => x.DateCreated);
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
                Public = model.Public

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
                Public = (bool)Entity.Public,
                Comments = (Crud.GetCommentsFromPicture(Entity.Id)).ToModelList(),
            };
            
            if (Entity.AlbumRefID != null)
            {
                Model.AlbumRefID = (Guid)Entity.AlbumRefID;
            };

            return Model;
        }
        public static List<PictureViewModel> ToModelList(this List<Picture> Pictures)
        {
            var ModelPictures = new List<PictureViewModel>();
            Pictures.ForEach(x => ModelPictures.Add(x.ToModel()));
            return ModelPictures;
        }
        
        //Chat
        public static ChatViewModel ToModel(this Chat Entity)
        {
            var Model = new ChatViewModel()
            {
                Id = Entity.Id,
                PostTime = (DateTime)Entity.PostDate,
                Text = Entity.Text,           
            };
            if(Entity.AccountRefID != null)
            {
                Model.AccountRefID = (Guid)Entity.AccountRefID;
            }

            return Model;
        }
        public static List<ChatViewModel> ToModelList(this List<Chat> Chats)
        {
            var Result = new List<ChatViewModel>();
            Chats.ForEach(entity => Result.Add(entity.ToModel()));
            return Result;
        }
        public static Chat ToEntity(this ChatViewModel Model)
        {
            
            var Entity = new Chat()
            {
                Id=Model.Id,
                PostDate = Model.PostTime,
                Text = Model.Text,
                AccountRefID = Model.AccountRefID
            };
          

            return Entity;
        }
   
    }
}

