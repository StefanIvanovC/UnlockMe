using System;
using UnlockMe.Data.Common.Models;

namespace UnlockMe.Web.ViewModels.Post
{
    public class AddPostViewModel : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}