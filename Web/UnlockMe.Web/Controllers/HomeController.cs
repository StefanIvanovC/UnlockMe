namespace UnlockMe.Web.Controllers
{
    using System.Diagnostics;

    using UnlockMe.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Web.ViewModels.Home;
    using UnlockMe.Data;
    using System.Linq;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                ProfilesCount = this.db.Profiles.Count(),
                PicturesCount = this.db.Images.Count(),
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
