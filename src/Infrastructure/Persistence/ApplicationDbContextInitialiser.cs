using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movie_basic.Domain.Const.Users;
using movie_basic.Domain.Entities.Movies;
using movie_basic.Domain.Enums.Medias;
using movie_basic.Infrastructure.Identity;

namespace movie_basic.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(RoleEnum.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        var userRole = new IdentityRole(RoleEnum.User);

        if (_roleManager.Roles.All(r => r.Name != userRole.Name))
        {
            await _roleManager.CreateAsync(userRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }

        // Default data
        // Seed, if necessary
        if (!_context.Movies.Any())
        {
            var listMovie = new List<Movie>()
            {
                new Movie
                {
                    Title = "Thor 2011",
                    Cover = new Domain.Entities.Medias.Media()
                    {
                        OriginalName = "thor-1.jpg",
                        Name = "thor-1",
                        ContentType = "image/jpg",
                        Extention = ".jpg",
                        Path = "https://upload.wikimedia.org/wikipedia/en/9/95/Thor_%28film%29_poster.jpg",
                        Type = MediaType.Movie,
                        Status = MediaStatus.Active
                    }
                },
                new Movie
                {
                    Title = "Captain America: The First Avenger (1942)",
                    Cover = new Domain.Entities.Medias.Media()
                    {
                        OriginalName = "captain-america.jpg",
                        Name = "captain-america",
                        ContentType = "image/jpg",
                        Extention = ".jpg",
                        Path = "https://lakehighlands.advocatemag.com/wp-content/uploads/2011/07/Captain-America-Movie-Poster.jpg",
                        Type = MediaType.Movie,
                        Status = MediaStatus.Active
                    }
                },
                new Movie
                {
                    Title = "captain marvel (1995)",
                    Cover = new Domain.Entities.Medias.Media()
                    {
                        OriginalName = "captain-marvel.jpg",
                        Name = "captain-marvel",
                        ContentType = "image/jpg",
                        Extention = ".jpg",
                        Path = "https://img.youtube.com/vi/7y0Yp5T_6Ho/hqdefault.jpg",
                        Type = MediaType.Movie,
                        Status = MediaStatus.Active
                    }
                },
            };

            _context.Movies.AddRange(listMovie);

            await _context.SaveChangesAsync();
        }
    }
}
