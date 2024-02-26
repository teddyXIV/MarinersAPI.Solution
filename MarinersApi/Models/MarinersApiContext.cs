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
        new Player(0.306, 0.456) { PlayerId = 3, Name = "Cal Raleigh", Number = 29, Average = 0.232, OnBase = 0.306, Slug = 0.456, Homerun = 30 },
        new Player(0.337, 0.366) { PlayerId = 4, Name = "Ty France", Number = 23, Average = 0.250, OnBase = 0.337, Slug = 0.366, Homerun = 12 },
        new Player(0.305, 0.435) { PlayerId = 5, Name = "Teoscar Hernandez", Number = 35, Average = 0.258, OnBase = 0.305, Slug = 0.435, Homerun = 26 },
        new Player(0.323, 0.391) { PlayerId = 6, Name = "Eugenio Suarez", Number = 28, Average = 0.232, OnBase = 0.323, Slug = 0.391, Homerun = 22 },
        new Player(0.327, 0.419) { PlayerId = 7, Name = "Jarred Kelenic", Number = 29, Average = 0.253, OnBase = 0.327, Slug = 0.419, Homerun = 11 }
      );
  }

}