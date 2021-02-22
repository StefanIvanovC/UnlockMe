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
    using UnlockMe.Services.Data;
    using UnlockMe.Services.Mapping;
    using UnlockMe.Web.ViewModels.Post;

    public class PostController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;

        public PostController(
            ApplicationDbContext db,
            IDeletableEntityRepository<Post> postsRepository,
            UserManager<ApplicationUser> userManager,
            IPostsService postsService)
        {
            this.db = db;
            this.postsRepository = postsRepository;
            this.userManager = userManager;
            this.postsService = postsService;
        }

        public IActionResult Add()
        {
            var viewModel = new PostsViewModel();
            var posts = this.postsRepository.All()
                .To<AddPostViewModel>()
                .ToList();
            viewModel.Posts = posts;
            return this.View(viewModel);
        }

        public IActionResult ById()
        {
            var byIdpostViewModel = new ByIdPostViewModel();
            return this.View(byIdpostViewModel);
        }

        [HttpPost]
        public IActionResult ById(int id)
        {
            var postViewModel = this.postsService.GetById<ByIdPostViewModel>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
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
