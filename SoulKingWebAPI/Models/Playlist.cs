namespace SoulKingWebAPI.Models
{
  public class Playlist
  {
    #region Constructors
    public Playlist(int id, string name, string description, DateTime creationDate, string access)
    {
      Id = id;
      Name = name;
      Description = description;
      CreationDate = creationDate;
      Access = access;
    }

    public Playlist(string name, string description, DateTime creationDate, string access)
    {
      Name = name;
      Description = description;
      CreationDate = creationDate;
      Access = access;
    }
    #endregion

    #region Mapped props
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public string Access {  get; set; }
    #endregion

    #region Relationships
    // User
    public int UserId { get; set; } // M:1
    public User User { get; set; }
    public List<User> SavedUsers { get; set; } // M:N
    // Song
    public List<Song> Songs { get; set; } // M:N

    #endregion
  }
}
