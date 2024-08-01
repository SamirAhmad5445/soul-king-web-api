namespace SoulKingWebAPI.Models.DTO
{
  public class ArtistEditDTO
  {
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string DisplayName { get; set; }
    public required string Description { get; set; }
    public required DateOnly BirthDate { get; set; }
  }
}
