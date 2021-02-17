using System;
using System.Collections.Generic;
using System.Text;
using UnlockMe.Data.Common.Models;

namespace UnlockMe.Data.Models
{
     public class Comment : BaseDeletableModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
