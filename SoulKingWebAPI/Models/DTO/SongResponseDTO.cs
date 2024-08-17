namespace SoulKingWebAPI.Models.DTO
{
  public class SongResponseDTO
  {
    public SongResponseDTO() { }

    public string Name { get; set; }
    public int LikesCount { get; set; }
    public int PlaysCount { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ArtistName { get; set; }
    public string AlbumName { get; set; }

    public SongResponseDTO FromSong(Song s, string artistName, string albumName)
    {
      Name = s.Name;
      LikesCount = s.LikesCount;
      PlaysCount = s.PlaysCount;
      ReleaseDate = s.ReleaseDate;
      ArtistName = artistName;
      AlbumName = albumName;

      return this;
    }
  }
}
