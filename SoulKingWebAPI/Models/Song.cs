namespace SoulKingWebAPI.Models
{
  public class Song
  {
    #region Constructors
    public Song(int id, string name, string filePath, string imagePath, DateTime releaseDate, int playsCount, int likesCount)
    {
      Id = id;
      Name = name;
      FilePath = filePath;
      ImagePath = imagePath;
      ReleaseDate = releaseDate;
      PlaysCount = playsCount;
      LikesCount = likesCount;
    }

    public Song(string name, string filePath, string imagePath)
    {
      Name = name;
      FilePath = filePath;
      ImagePath = imagePath;
      ReleaseDate = DateTime.Now;
      PlaysCount = 0;
      LikesCount = 0;
    }
    #endregion

    #region Mapped props
    public int Id { get; set; }
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string ImagePath { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int PlaysCount { get; set; } = 0;
    public int LikesCount { get; set; } = 0;
    #endregion

    #region Relationships
    // User
    public List<User> LikedUsers { get; set; } // M:N
    // Artist
    public int ArtistId { get; set; } // M:1
    public Artist Artist { get; set; }
    // Albums
    public int AlbumId { get; set; } // M:1
    public Album Album { get; set; }
    // Playlist
    public List<Playlist> AssociatedPlaylists { get; set; } // M:N
    #endregion
  }
}
