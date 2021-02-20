namespace UnlockMe.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using UnlockMe.Data.Common.Repositories;
    using UnlockMe.Data.Models;
    using UnlockMe.Services.Mapping;
    using UnlockMe.Web.ViewModels.ProfilesInputModels;

    public class ProfileService : IProfileServicecs
    {
        private IDeletableEntityRepository<Profile> profilesRepository;

        public ProfileService(IDeletableEntityRepository<Profile> profilesRepository)
        {
            this.profilesRepository = profilesRepository;
        }

        public async Task CreateAsync(CreateProfileInputModel input, string userId)
        {
            var profile = new Profile
            {
                Name = input.Title,
                Years = input.Years,
                AddedByUserId = userId,
            };

            await this.profilesRepository.AddAsync(profile);
            await this.profilesRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var post = this.profilesRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
            return post;
        }
    }
}