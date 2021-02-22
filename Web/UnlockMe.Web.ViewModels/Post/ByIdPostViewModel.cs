namespace UnlockMe.Web.ViewModels.Post
{
    using System;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;

    public class ByIdPostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
