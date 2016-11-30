using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_PictureGallery_Lab.Models
{
    public class PictureViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public bool Public { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        [Required]
        public Guid AlbumRefID { get; set; }
    }
}