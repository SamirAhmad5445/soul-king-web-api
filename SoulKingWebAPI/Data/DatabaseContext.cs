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
              "pass1234",
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
              "pass1234",
              "uta@redhairpirates.com",
              "Brings happiness and joy to everyone by my songs.",
              "Diva",
              "Uta",
              new DateOnly(1996, 8, 29)
            )
        );

      base.OnModelCreating(modelBuilder);
    }
  }
}
