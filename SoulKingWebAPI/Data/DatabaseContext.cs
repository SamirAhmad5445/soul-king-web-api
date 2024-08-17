using Microsoft.EntityFrameworkCore;
using SoulKingWebAPI.Models;

namespace SoulKingWebAPI.Data
{
  public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
  {
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> Tokens { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
          .HasMany(u => u.Playlists)
          .WithOne(p => p.User)
          .HasForeignKey(p => p.UserId)
          .OnDelete(DeleteBehavior.ClientSetNull);

      modelBuilder.Entity<User>()
          .HasMany(u => u.LikedSongs)
          .WithMany(s => s.LikedUsers)
          .UsingEntity(j => j.ToTable("UserLikedSongs"));

      modelBuilder.Entity<User>()
             .HasMany(u => u.SavedPlaylists)
             .WithMany(p => p.SavedUsers)
             .UsingEntity(j => j.ToTable("UserSavedPlaylist"));

      modelBuilder.Entity<Song>()
          .HasOne(s => s.Artist)
          .WithMany(a => a.Songs)
          .HasForeignKey(s => s.ArtistId)
          .OnDelete(DeleteBehavior.ClientSetNull);

      modelBuilder.Entity<Artist>().HasData(
          new Artist(
              1,
              "brook",
              "Sk Brook",
              "p@ss1234",
              "sk.brook@strawhats.com",
              "A musician and swordsman who is also a skeleton.",
              "Soul King",
              "Brook",
              new DateOnly(1974, 4, 13)
          ),
          new Artist(
              2,
              "uta",
              "Uta",
              "p@ss1234",
              "uta@redhairpirates.com",
              "Brings happiness and joy to everyone by my songs.",
              "Diva",
              "Uta",
              new DateOnly(1996, 8, 29)
          ),
          new Artist(
              3,
              "apoo",
              "Scratchmen Apoo",
              "p@ss1234",
              "apoo@onairpirates.com",
              "A musician who uses his body as an instrument to create powerful sound-based attacks.",
              "Roar of the Sea",
              "Apoo",
              new DateOnly(1982, 3, 5)
          ),
          new Artist(
              4,
              "cindry",
              "Victoria Cindry",
              "p@ss1234",
              "cindry@thrillerbark.com",
              "A former stage actress and singer with a tragic past.",
              "Stage Star",
              "Cindry",
              new DateOnly(1970, 11, 20)
          ),
          new Artist(
              5,
              "napoleon",
              "Napoleon",
              "p@ss1234",
              "napoleon@bigmompirates.com",
              "A homie who often sings with his fellow homies Zeus and Prometheus.",
              "Singing Sword",
              "Napoleon",
              new DateOnly(2011, 7, 1)
          ),
          new Artist(
              6,
              "gaban",
              "Scopper Gaban",
              "p@ss1234",
              "gaban@rogerpirates.com",
              "A legendary pirate who may also have a passion for music.",
              "Rock Star",
              "Gaban",
              new DateOnly(1953, 5, 21)
          ),
          new Artist(
              7,
              "sogeking",
              "Sogeking",
              "p@ss1234",
              "sogeking@sniperisland.com",
              "A brave and mysterious hero with an amazing theme song.",
              "King of Snipers",
              "Sogeking",
              new DateOnly(1997, 4, 1)
          )
      );


      base.OnModelCreating(modelBuilder);
    }
  }
}
