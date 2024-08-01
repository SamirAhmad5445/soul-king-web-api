namespace SoulKingWebAPI.Models.DTO
{
  public class ArtistResponseDTO
  {
    public ArtistResponseDTO() { }

    public string Username {  get; set; }
    public string FirstName {  get; set; }
    public string LastName {  get; set; }
    public string DisplayName { get; set; }
    public string Description {  get; set; }
    public bool IsActivated { get; set; }
    public int FollowersCount { get; set; } = 0;


    public ArtistResponseDTO FromArtist(Artist artist)
    {
      Username = artist.Username;
      FirstName = artist.FirstName;
      LastName = artist.LastName;
      DisplayName = artist.DisplayName;
      Description = artist.Description;
      FollowersCount = artist.FollowersCount;
      IsActivated = artist.IsActivated;

      return this;
    }
  }
}
