namespace UnlockMe.Web.ViewModels.Post
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class CreatePostViewModel : IMapTo<Post>
    {

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }
    }
}
