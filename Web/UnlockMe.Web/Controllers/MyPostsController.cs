using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnlockMe.Web.ViewModels;

namespace UnlockMe.Web.Controllers
{
    public class MyPostsController : Controller
    {
        [Authorize]
        public IActionResult MyPosts()
        {
            var model = new MyPostsViewModel
            {
                Name = "stefi",
            };
            return this.View(model);
        }

    }
}
