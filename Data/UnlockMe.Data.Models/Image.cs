using System;
using System.Collections.Generic;
using System.Text;
using UnlockMe.Data.Common.Models;

namespace UnlockMe.Data.Models
{
    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public string Extension { get; set; }


    }
}
