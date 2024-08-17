namespace SoulKingWebAPI.Models.DTO
{
  public class AlbumResponseDTO
  {
    public AlbumResponseDTO() { }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ArtistName { get; set; }

    public AlbumResponseDTO FromAlbum(Album al, string artistName)
    {
      Name = al.Name;
      Description = al.Description;
      ReleaseDate = al.ReleaseDate;
      ArtistName = artistName;

      return this;
    }
  }
}
