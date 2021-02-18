namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data;
    using UnlockMe.Web.ViewModels.Post;

    public class PostController : BaseController
    {
        private readonly ApplicationDbContext db;

        public PostController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Add()
        {
            var viewModel = new PostsViewModel();
            var posts = this.db.Posts.Select(x => new AddPostViewModel
            {
                Title = x.Title,
                Description = x.Description,
            }).ToList();
            viewModel.Posts = posts;
            return this.View(viewModel);
        }
    }
}
