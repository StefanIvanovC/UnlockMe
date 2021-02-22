namespace UnlockMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using UnlockMe.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public string Extension { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
