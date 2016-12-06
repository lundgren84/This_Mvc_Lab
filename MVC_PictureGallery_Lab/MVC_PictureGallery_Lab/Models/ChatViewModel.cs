using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PictureGallery_Lab.Models
{
    public class ChatViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime PostTime { get; set; }
        public Guid AccountRefID { get; set; }
    }
    public class ChatContentViewModel
    {
        public string Text { get; set; }
        public string AccountName { get; set; }
    }
}