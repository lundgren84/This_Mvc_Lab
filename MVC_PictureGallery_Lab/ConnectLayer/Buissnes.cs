﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer
{
    class Buissnes
    {



    }
    public class Crud
    {
        public static List<Picture> GetPictures()
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Pictures.ToList();
            }
        }

        public static List<Album> GetAlbums()
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Albums.ToList();
            }
        }

        public static void CreateChatPost(Chat chat)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                if(chat.AccountRefID == new Guid())
                {
                    chat.AccountRefID = null;
                }
                chat.Id = Guid.NewGuid();
                ctx.Chats.Add(chat);
                ctx.SaveChanges();
            }
        }

        public static List<Album> AccGetAlbums(Guid id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Albums.Where(x => x.AccountRefID == id).ToList();
            }
        }

        public static string GetAccountName(Guid accountRefID)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                if (accountRefID != new Guid())
                    return ctx.Accounts.SingleOrDefault(x => x.Id == accountRefID).UserName;
                else return null;
            }
        }

        public static List<Chat> GetChat()
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                var sortedChat = ctx.Chats.OrderBy(x => x.PostDate).ToList();
                var result = new List<Chat>();
                for (int i = sortedChat.Count-10; i < sortedChat.Count; i++)
                {
                    result.Add(sortedChat[i]);
                }
                return result;
            }
        }

        public static List<Picture> GetPictureToAlbum(Guid Album_id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Pictures.Where(x => x.AlbumRefID == Album_id).ToList<Picture>();
            }
        }

        public static bool CreateOrUpdate(Account account)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                try
                {
                    var Entity = ctx.Accounts.FirstOrDefault(x => x.Id == account.Id)
                                  ?? new Account() { Id = Guid.NewGuid() };

                    //Entity.UserName = account.UserName;
                    //ctx.Accounts.AddOrUpdate(Entity);
                    //ctx.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static Account GetAccount(Guid id, string Type)
        {
            var accid = new Guid();
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                if (Type == "album")
                {
                    var album = ctx.Albums.SingleOrDefault(x=>x.Id == id);
                    accid = (Guid)album.AccountRefID;
                }
                return ctx.Accounts.FirstOrDefault(x=>x.Id == accid);
            }
            
           
        }

        public static void CreateOrUpdate(Picture picture)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                var Entity = ctx.Pictures.FirstOrDefault(m => m.Id == picture.Id)
                    ?? new Picture() { Id = Guid.NewGuid() };
                Entity.Name = picture.Name;
                Entity.Public = picture.Public;
                ctx.Pictures.AddOrUpdate(Entity);
                ctx.SaveChanges();
            }
        }
     

        public static List<Comment> GetComment(Guid id, string idType)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                if(idType == "picture")
               return ctx.Comments.Where(x => x.PictureRefID == id).ToList();      
            }
            return null;
        }

        public static Album GetAlbums(Guid id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Albums.Find(id);
            }
        }



        public static List<Picture> GetAlbumPictures(Guid id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Pictures.Where(x => x.AlbumRefID == id).ToList();
            }
        }

        public static Account GetAccount(string accUserName)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Accounts.Single(x => x.UserName == accUserName);
            }
        }

        public static Account GetAccount(Guid CommentId)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                var comment = ctx.Comments.Find(CommentId);
                return ctx.Accounts.SingleOrDefault(x => x.Id == comment.AccountRefID);
            }
        }

        public static Album GetAlbum(Guid id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {

                return ctx.Albums.Find(id);
            }
        }

        public static void CreateComment(Comment comment)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                comment.DateCreated = DateTime.Now;
                comment.Id = Guid.NewGuid();
                ctx.Comments.Add(comment);
                ctx.SaveChanges();
            }
        }

        public static Comment GetComment(Guid id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Comments.Find(id);
            }
        }

        public static void DeleteComment(Comment comment)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {              
                    var Entity = ctx.Comments.Find(comment.Id);
                    ctx.Comments.Remove(Entity);
                    ctx.SaveChanges();  
            }
        }
        public static void DeleteComment(Guid id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                var Entity = ctx.Comments.Find(id);
                ctx.Comments.Remove(Entity);
                ctx.SaveChanges();
            }
        }

        public static void CreateAccount(Account account)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                account.Id = Guid.NewGuid();
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
            }
        }

        public static void DeleteAlbum(Album album)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                var Comments = new List<Comment>();
                //Albument
                var Album = ctx.Albums.Find(album.Id);
                //Alla bilder från det albumet
                var Pictures = ctx.Pictures.Where(x => x.AlbumRefID == album.Id).ToList<Picture>();
                //Alla kommentarer på alla bilder
                foreach (var item in Pictures)
                {
                    var comments = ctx.Comments.Where(x => x.PictureRefID == item.Id).ToList<Comment>();
                    Comments.AddRange(comments);

                }
                ctx.Comments.RemoveRange(Comments);
                ctx.Pictures.RemoveRange(Pictures);
                ctx.Albums.Remove(Album);
                ctx.SaveChanges();

            }
        }

        public static void CreateOrUpdate(Album album)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                var entity =
                    ctx.Albums.FirstOrDefault(x => x.Id == album.Id)
                ?? new Album() { Id = Guid.NewGuid(), DateCreated= DateTime.Now  };

                entity.Name = album.Name;
                entity.Topic = album.Topic;
                entity.AccountRefID = album.AccountRefID;
                ctx.Albums.AddOrUpdate(entity);
                ctx.SaveChanges();
            }
        }

        public static void CreateAlbum(Album album)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                album.DateCreated = DateTime.Now;
                album.Id = Guid.NewGuid();
                ctx.Albums.Add(album);
                ctx.SaveChanges();
            }
        }

        public static void CreatePicture(Picture picture)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                ctx.Pictures.Add(picture);
                ctx.SaveChanges();
            }
        }

        public static void DeletePicture(Picture picture)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                var EntityPicture = ctx.Pictures.Find(picture.Id);
                var EntityComments = ctx.Comments.Where(x => x.PictureRefID == picture.Id);
                ctx.Comments.RemoveRange(EntityComments);
                ctx.Pictures.Remove(EntityPicture);
                ctx.SaveChanges();
            }
        }

        public static Picture GetPicture(Guid id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {

                ctx.Configuration.LazyLoadingEnabled = false;

                var Entity = ctx.Pictures.FirstOrDefault(x => x.Id == id);
                ctx.Entry(Entity).Collection(x => x.Comments).Load();
                return Entity;
            }
        }

        public static void EditPicture(Picture picture)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                var EntityToEdit = ctx.Pictures.FirstOrDefault(x => x.Id == picture.Id);
                EntityToEdit.Name = picture.Name;
                EntityToEdit.Url = picture.Url;
                EntityToEdit.Size = picture.Size;
                ctx.SaveChanges();
            }
        }

        public static List<Comment> GetCommentsFromPicture(Guid id)
        {
            using (var ctx = new MVC_GalleryDbEntities1())
            {
                return ctx.Comments.Where(x => x.PictureRefID == id).ToList();
            }
        }
    }
}
