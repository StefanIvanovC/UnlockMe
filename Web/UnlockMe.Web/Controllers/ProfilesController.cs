namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Services.Data;
    using UnlockMe.Web.ViewModels.ProfilesInputModels;

    public class ProfilesController : Controller
    {

        private readonly IProfileServicecs profileServicecs;

        public ProfilesController(IProfileServicecs profileService)
        {
            this.profileServicecs = profileService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = new CreateProfileInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateProfileInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.profileServicecs.CreateAsync(input);
            //TODO REDIRECT USER TO THE INFOPAGE
            return this.Redirect("/");
        }
    }
}
