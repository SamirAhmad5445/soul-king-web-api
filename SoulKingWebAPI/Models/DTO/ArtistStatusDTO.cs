namespace SoulKingWebAPI.Models.DTO
{
  public class ArtistStatusDTO
  {
    public required int AlbumsCount { get; set; }
    public required int SongsCount { get; set; }
    public required int FollowersCount { get; set; }
  }
}
