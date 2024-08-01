namespace SoulKingWebAPI.Models.DTO
{
  public class ReleaseAlbumDTO
  {
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required IFormFile Image {  get; set; }
  }
}
