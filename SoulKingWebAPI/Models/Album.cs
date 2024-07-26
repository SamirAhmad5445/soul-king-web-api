namespace SoulKingWebAPI.Models
{
  public class Album
  {
    #region Constructors
    public Album(int id, string name, string description, DateTime releaseDate)
    {
      Id = id;
      Name = name;
      Description = description;
      ReleaseDate = releaseDate;
    }
    public Album(string name, string description, DateTime releaseDate)
    {
      Name = name;
      Description = description;
      ReleaseDate = releaseDate;
    }
    #endregion

    #region Mapped props
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    #endregion

    #region Relationships
    // altist
    public int ArtistId { get; set; } // M:1
    public Artist Artist { get; set; }
    // songs
    public List<Song> Songs { get; set; } // 1:N
    // user
    public List<User> LikedUsers { get; set; } // M:N
    #endregion

  }
}
