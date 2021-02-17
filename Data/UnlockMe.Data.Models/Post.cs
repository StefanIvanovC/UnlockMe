using System;
using System.Collections.Generic;
using System.Text;
using UnlockMe.Data.Common.Models;

namespace UnlockMe.Data.Models
{
    public class Post : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; } // The user who will create post

        public virtual ApplicationUser User { get; set; } //The user Id from the Idenntity. 
    }
}
