using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_PictureGallery_Lab.Models
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name ="Comment")]
        public string Text { get; set; } 
        public PictureViewModel Picture { get; set; }
        public AccountViewModel Account { get; set; }        
    }
}