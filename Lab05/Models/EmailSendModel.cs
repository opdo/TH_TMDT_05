using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab05.Models
{
    public class EmailSendModel
    {
        [Display(Name = "Tiêu đề")]
        public string title { get; set; }
        [Display(Name = "Nội dung")]
        public string content { get; set; }

    }
}