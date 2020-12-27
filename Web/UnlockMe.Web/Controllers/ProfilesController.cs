namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Web.ViewModels.ProfilesInputModels;

    public class ProfilesController : Controller
    {

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProfileInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }


            //TODO REDIRECT USER TO THE 
            return this.Redirect("/");
        }
    }
}
