using eTheaters.Data.Static;
using eTheaters.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace eTheaters.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Theaters
                if (!context.Theaters.Any())
                {
                    context.Theaters.AddRange(new List<Theater>()
                    {
                        new Theater()
                        {
                            Name = "Teatr im. Wandy Siemaszkowej w Rzeszowie",
                            Logo = "https://1drv.ms/i/c/4fc1ba6efa8e8db4/EaN_a8zf2bxDjNq9oLMymOcBlS6HdJI1x2GCqV-veC10AQ?e=FAmKQt",
                            Description = "Description",
                        },
                        new Theater()
                        {
                            Name = "Teatr Narodowy w Warszawie",
                            Logo = "https://1drv.ms/i/c/4fc1ba6efa8e8db4/Ed7qOGjY-StGqjQwvivkBA8BKZSz26cHPrsuaUaUDj2qNg?e=0js1bo",
                            Description = "Description",
                        },
                        new Theater()
                        {
                            Name = "Teatr im. Juliusza Słowackiego",
                            Logo = "https://1drv.ms/i/c/4fc1ba6efa8e8db4/EQVfQOSBDwBFsyptDy17FqQBVw0ohU35BzjwcwcAz0xLPQ?e=TBz8BL",
                            Description = "Description",
                        },
                        new Theater()
                        {
                            Name = "Teatr Dramatyczny m. st. Warszawy",
                            Logo = "https://1drv.ms/i/c/4fc1ba6efa8e8db4/EVDOshYABMdKlK_u-uTF5_8BZtJ_Y4EgyHXIZaGIZ3T-RA?e=6hdbNq",
                            Description = "Description",
                        },
                        new Theater()
                        {
                            Name = "Gdański Teatr Szekspirowski",
                            Logo = "https://1drv.ms/i/c/4fc1ba6efa8e8db4/Eeh3SHvwkZ9Evq702eQ1H00Bl0N_IBrvcJopZxs2FmUJ7Q?e=yKT2YC",
                            Description = "Description",
                        },
                    });
                    context.SaveChanges();
                }

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                        new Actor()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                        new Actor()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                        new Actor()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                        new Actor()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                    });
                    context.SaveChanges();
                }

                //Directors
                if (!context.Directors.Any())
                {
                    context.Directors.AddRange(new List<Director>()
                    {
                        new Director()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                        new Director()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                        new Director()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                        new Director()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                        new Director()
                        {
                            FullName = "name",
                            Bio = "some bio",
                            Picture = "https sth",
                        },
                    });
                    context.SaveChanges();
                }

                //Plays
                if (!context.Plays.Any())
                {
                    context.Plays.AddRange(new List<Play>()
                    {
                        new Play()
                        {
                            Name = "title",
                            Description = "some desc",
                            Price = 45.50,
                            ImageURL = "httpcos",
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(13),
                            TheaterId = 1,
                            DirectorId = 1,
                            PlayCategory = Enums.PlayCategory.Political
                        },
                        new Play()
                        {
                            Name = "title",
                            Description = "some desc",
                            Price = 45.50,
                            ImageURL = "httpcos",
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(13),
                            TheaterId = 1,
                            DirectorId = 1,
                            PlayCategory = Enums.PlayCategory.Political
                        },
                        new Play()
                        {
                            Name = "title",
                            Description = "some desc",
                            Price = 45.50,
                            ImageURL = "httpcos",
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(13),
                            TheaterId = 1,
                            DirectorId = 1,
                            PlayCategory = Enums.PlayCategory.Political
                        },
                        new Play()
                        {
                            Name = "title",
                            Description = "some desc",
                            Price = 45.50,
                            ImageURL = "httpcos",
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(13),
                            TheaterId = 1,
                            DirectorId = 1,
                            PlayCategory = Enums.PlayCategory.Political
                        },
                        new Play()
                        {
                            Name = "title",
                            Description = "some desc",
                            Price = 45.50,
                            ImageURL = "httpcos",
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(13),
                            TheaterId = 1,
                            DirectorId = 1,
                            PlayCategory = Enums.PlayCategory.Political
                        },
                    });
                    context.SaveChanges();
                }

                //Actors & Movies
                if (!context.Actors_Plays.Any())
                {
                    context.Actors_Plays.AddRange(new List<Actor_Play>()
                    {
                        new Actor_Play()
                        {
                            ActorId = 1,
                            PlayId = 1,
                        },
                        new Actor_Play()
                        {
                            ActorId = 4,
                            PlayId = 1,
                        },
                        new Actor_Play()
                        {
                            ActorId = 2,
                            PlayId = 1,
                        },

                        new Actor_Play()
                        {
                            ActorId = 1,
                            PlayId = 2,
                        },
                        new Actor_Play()
                        {
                            ActorId = 5,
                            PlayId = 2,
                        },

                        new Actor_Play()
                        {
                            ActorId = 3,
                            PlayId = 3,
                        },
                        new Actor_Play()
                        {
                            ActorId = 2,
                            PlayId = 3,
                        },
                        new Actor_Play()
                        {
                            ActorId = 4,
                            PlayId = 3,
                        },

                        new Actor_Play()
                        {
                            ActorId = 5,
                            PlayId = 4,
                        },
                        new Actor_Play()
                        {
                            ActorId = 1,
                            PlayId = 4,
                        },
                        new Actor_Play()
                        {
                            ActorId = 2,
                            PlayId = 4,
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etheaters.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Project!67498");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etheaters.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (adminUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Project!67498");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
