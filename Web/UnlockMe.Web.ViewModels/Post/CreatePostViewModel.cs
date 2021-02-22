using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UnlockMe.Services.Mapping;
using UnlockMe.Data.Models;
using UnlockMe.Services.Mapping;

namespace UnlockMe.Web.ViewModels.Post
{
    public class CreatePostViewModel 
    {

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }

    }
}
