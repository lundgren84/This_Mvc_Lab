
using ConnectLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_PictureGallery_Lab.Models
{
    public class AlbumViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "1-50 char´s")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public AlbumTopic Topic { get; set; }
        public AccountViewModel Account { get; set; }
        public List<PictureViewModel> Pictures { get; set; }
    }
   
}