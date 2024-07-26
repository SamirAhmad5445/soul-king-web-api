namespace SoulKingWebAPI.Models
{
  public class Category
  {
    #region Constructors
    public Category(int id, string name)
    {
      Id = id;
      Name = name;
    }

    public Category(string name)
    {
      Name = name;
    }
    #endregion

    #region Mapped props
    public int Id { get; set; }
    public string Name { get; set; }
    #endregion

    #region Relationships
    // song
    public List<Song> Songs { get; set; } // 1:N
    #endregion
  }
}
