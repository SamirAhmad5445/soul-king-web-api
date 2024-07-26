using Microsoft.EntityFrameworkCore;
using SoulKingWebAPI.Models;

namespace SoulKingWebAPI.Data
{
  public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
  {
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> Tokens { get; set; }
    public DbSet<OneTimePassword> OTPs { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Category> Categories { get; set; }

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
          .HasMany(s => s.Listeners)
          .WithMany(u => u.HeardSongs)
          .UsingEntity(j => j.ToTable("UserSongs"));

      modelBuilder.Entity<Song>()
          .HasOne(s => s.Artist)
          .WithMany(a => a.Songs)
          .HasForeignKey(s => s.ArtistId)
          .OnDelete(DeleteBehavior.ClientSetNull);

      modelBuilder.Entity<Category>().HasData(
          new Category(1, "Rock"),
          new Category(2, "Pop"),
          new Category(3, "Jazz"),
          new Category(4, "Hip-hop"),
          new Category(5, "Classical"),
          new Category(6, "Electronic"),
          new Category(7, "Country"),
          new Category(8, "Blues"),
          new Category(9, "Reggae"),
          new Category(10, "Metal"),
          new Category(11, "K-pop"),
          new Category(12, "Rap"),
          new Category(13, "J-pop"),
          new Category(14, "Latin"),
          new Category(15, "Funk"),
          new Category(16, "Soul")
        );


      base.OnModelCreating(modelBuilder);
    }
  }
}
