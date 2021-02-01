namespace UnlockMe.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using UnlockMe.Web.ViewModels.ProfilesInputModels;

    public interface IProfileServicecs
    {
        Task CreateAsync(CreateProfileInputModel input, string userId);

       
    }
}
