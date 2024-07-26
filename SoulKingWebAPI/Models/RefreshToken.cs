namespace SoulKingWebAPI.Models
{
  public class RefreshToken
  {
    #region Constructors
    public RefreshToken(int id, string value, DateTime expiryDate)
    {
      Id = id;
      Value = value;
      ExpiryDate = expiryDate;
    }

    public RefreshToken(string value)
    {
      Value = value;
      ExpiryDate = DateTime.Now.AddDays(30);
    }
    #endregion

    #region mapped props
    public int Id { get; set; }
    public string Value { get; set; }
    public DateTime ExpiryDate { get; set; }
    #endregion

    #region Relationships
    // User
    public int UserId { get; set; } // M:1
    public User User { get; set; }
    #endregion
  }
}
