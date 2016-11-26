using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PictureGallery_Lab.Models
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Fistname { get; set; }
        public string Lastname { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public List<AlbumViewModel> Albums { get; set; }
        public List<AccountViewModel> Friends { get; set; }
    }
}