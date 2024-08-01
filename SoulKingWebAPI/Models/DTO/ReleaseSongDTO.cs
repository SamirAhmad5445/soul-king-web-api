namespace SoulKingWebAPI.Models.DTO
{
  public class ReleaseSongDTO
  {
    public required string AlbumName { get; set; }
    public required string Name { get; set; }
    public required IFormFile Image { get; set; }
    public required IFormFile Audio { get; set; }
  }
}
