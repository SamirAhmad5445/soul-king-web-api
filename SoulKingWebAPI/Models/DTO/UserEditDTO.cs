namespace SoulKingWebAPI.Models.DTO
{
  public class UserEditDTO
  {
    public required string FirtName { get; set; }
    public required string LastName { get; set; }
    public required string Description { get; set; }
    public required string Email { get; set; }
    public required IFormFile Image { get; set; }
  }
}
