using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MarinersApi.Models;

public class MarinersApiContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Player> Players { get; set; }
    public MarinersApiContext(DbContextOptions<MarinersApiContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<IdentityUserLogin<string>>(e =>
        {
            e.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        builder.Entity<Player>()
          .HasData(
            new Player(0.333, 0.485) { PlayerId = 1, Name = "Julio Rodriguez", Number = 44, Average = 0.275, OnBase = 0.333, Slug = 0.485, Homerun = 32 },
            new Player(0.380, 0.438) { PlayerId = 2, Name = "JP Crawford", Number = 3, Average = 0.266, OnBase = 0.380, Slug = 0.438, Homerun = 19 },
            new Player(0.306, 0.456) { PlayerId = 3, Name = "Cal Raleigh", Number = 29, Average = 0.232, OnBase = 0.306, Slug = 0.456, Homerun = 30 }
          );
    }

}