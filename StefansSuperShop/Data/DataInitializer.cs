using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StefansSuperShop.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
        }
    }
}