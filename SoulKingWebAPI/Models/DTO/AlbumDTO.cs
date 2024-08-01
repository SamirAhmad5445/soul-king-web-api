using Microsoft.AspNetCore.Mvc;

namespace SoulKingWebAPI.Models.DTO
{
  public class AlbumDTO
  {
    public AlbumDTO() { }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }

    public AlbumDTO FromAlbum(Album al)
    {
      Name = al.Name; 
      Description = al.Description;
      ReleaseDate = al.ReleaseDate;

      return this;
    }
  }
}
