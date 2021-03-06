﻿namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Data;
    using UnlockMe.Web.ViewModels.ProfilesInputModels;

    public class ProfilesController : Controller
    {

        private readonly IProfileServicecs profileServicecs;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(IProfileServicecs profileService, UserManager<ApplicationUser> userManager)
        {
            this.profileServicecs = profileService;
            this.userManager = userManager;
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
        public async Task<IActionResult> Create(CreateProfileInputModel input, string userId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.profileServicecs.CreateAsync(input, userId);
            // IF model state is true redirect to ThankYou
            return this.Redirect("ThankYou");

        }

        public IActionResult ThankYou()
        {
            return this.View();
        }


        public IActionResult All(int id)
        {
            var viewModel = new ProfilesListViewModel
            {
                PageNumber = id,
            };
            return this.View(viewModel);
        }

        public IActionResult MyProfile()
        {
            return this.View();
        }
    }
}
