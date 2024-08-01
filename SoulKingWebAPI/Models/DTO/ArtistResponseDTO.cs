namespace SoulKingWebAPI.Models.DTO
{
  public class ArtistResponseDTO
  {
    public ArtistResponseDTO() { }

    public ArtistResponseDTO(string username, string firstName, string lastName, string displayName, string description, bool isActivated)
    {
      Username = username;
      FirstName = firstName;
      LastName = lastName;
      DisplayName = displayName;
      Description = description;
      IsActivated = isActivated;
    }

    public string Username {  get; set; }
    public string FirstName {  get; set; }
    public string LastName {  get; set; }
    public string DisplayName { get; set; }
    public string Description {  get; set; }
    public bool IsActivated { get; set; }

    public ArtistResponseDTO FromArtist(Artist artist)
    {
      Username = artist.Username;
      FirstName = artist.FirstName;
      LastName = artist.LastName;
      DisplayName = artist.DisplayName;
      Description = artist.Description;
      IsActivated = artist.IsActivated;

      return this;
    }
  }
}
