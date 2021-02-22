namespace UnlockMe.Web.ViewModels.Post
{
    using System;

    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class AddPostViewModel : IMapFrom<Post>
    {
        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url => $"/p/{this.Title.Replace(' ', '-')}";

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}