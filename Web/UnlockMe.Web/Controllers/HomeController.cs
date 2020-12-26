namespace UnlockMe.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data;
    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Web.ViewModels;
    using UnlockMe.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Profile> profilesRepository;
        private readonly IRepository<Image> imagesRepository;

        public HomeController(
            IDeletableEntityRepository<Profile> profilesRepository,
            IRepository<Image> imagesRepository)
        {
            this.profilesRepository = profilesRepository;
            this.imagesRepository = imagesRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                ProfilesCount = this.profilesRepository.All().Count(),
                PicturesCount = this.imagesRepository.All().Count(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
