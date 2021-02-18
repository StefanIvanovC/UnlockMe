namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data;
    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Web.ViewModels.Post;

    public class PostController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(
            ApplicationDbContext db,
            IDeletableEntityRepository<Post> postsRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.postsRepository = postsRepository;
            this.userManager = userManager;

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

        public IActionResult ById()
        {
            //To Do finish redirection must go to this page when user send valid input view model
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var post = new Post
            {
                Title = input.Title,
                Description = input.Description,
                UserId = user.Id,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();

            return this.RedirectToAction("ById", new { id = post.Id });

        }
    }
}
