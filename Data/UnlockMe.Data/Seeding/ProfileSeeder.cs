namespace UnlockMe.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProfileSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Profiles.Any())
            {
                return;
            }

            await dbContext.Profiles.AddAsync(new Models.Profile { Name = "Stefan" });
            await dbContext.Profiles.AddAsync(new Models.Profile { Name = "Tanq" });
            await dbContext.Profiles.AddAsync(new Models.Profile { Name = "Ivana" });

            await dbContext.SaveChangesAsync();

        }
    }
}
