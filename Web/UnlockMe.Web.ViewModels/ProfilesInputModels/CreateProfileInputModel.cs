namespace UnlockMe.Web.ViewModels.ProfilesInputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateProfileInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [Range(0, 99)]
        public int Years { get; set; }

        public string AddedByUserId { get; set; }
    }
}
