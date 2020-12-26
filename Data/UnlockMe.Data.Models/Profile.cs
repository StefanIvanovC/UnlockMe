using System;
using System.Collections.Generic;
using System.Text;
using UnlockMe.Data.Common.Models;

namespace UnlockMe.Data.Models
{
    public class Profile : BaseDeletableModel<int>
    {

        public Profile()
        {
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public int Years { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Image> Images {get; set;}

    }
}
