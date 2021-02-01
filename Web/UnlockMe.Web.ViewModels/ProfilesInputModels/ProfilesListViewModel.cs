namespace UnlockMe.Web.ViewModels.ProfilesInputModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfilesListViewModel
    {
        public IEnumerable<ProfileInListViewModel> Profiles { get; set; }

        public int PageNumber { get; set; }
    }
}
