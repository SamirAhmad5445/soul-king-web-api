namespace SoulKingWebAPI.Models
{
  public class OneTimePassword
  {
    #region Constructor
    public OneTimePassword(int id, string value, DateTime expiryDate)
    {
      Id = id;
      Value = value;
      ExpiryDate = expiryDate;
    }

    public OneTimePassword(string value)
    {
      Value = value;
      ExpiryDate = DateTime.Now.AddMinutes(5);
    }
    #endregion

    #region Mapped props
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
