using Microsoft.IdentityModel.Tokens;
using PlatformService.Models;

namespace PlatformService.Data
{


    public static class PrepDb
    {

        public static void prepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                Console.WriteLine("----->Seeding data");
                if (serviceScope.ServiceProvider.GetService<AppDbContext>()==null)
                {
                    Console.WriteLine("----->null context");
                }
                SeeData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeeData(AppDbContext context)
        {

            if (!context.Platforms.Any())
            {
                Console.WriteLine("----->Seeding data");
                context.Platforms.AddRange(new Platform() { Name = "Joel", Publisher = "test", Cost = 10 },
                new Platform() { Name = "Joel", Publisher = "test", Cost = 10 },
                new Platform() { Name = "Joel", Publisher = "test", Cost = 10 }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("----->We already have data");
            }
        }



    }
}