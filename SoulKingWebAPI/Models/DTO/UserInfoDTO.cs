namespace SoulKingWebAPI.Models.DTO
{
  public class UserInfoDTO
  {

    public UserInfoDTO() { }

    public UserInfoDTO(string username, string firstName, string lastName, string email, DateOnly birthDate, string description)
    {
      Username = username;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      BirthDate = birthDate;
      Description = description;
    }

    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Description {  get; set; }

    public UserInfoDTO FromUser(User user)
    {
      Username = user.Username;
      FirstName = user.FirstName;
      LastName = user.LastName;
      Email = user.Email;
      BirthDate = user.BirthDate;
      Description = user.Description;

      return this;
    }
  }
}
