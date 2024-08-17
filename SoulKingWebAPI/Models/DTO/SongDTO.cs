namespace SoulKingWebAPI.Models.DTO
{
  public class SongDTO
  {
    public SongDTO() { }

    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int LikesCount { get; set; }
    public int PlaysCount { get; set; }

    public SongDTO FromSong(Song song)
    {
      Name = song.Name;
      ReleaseDate = song.ReleaseDate;
      LikesCount = song.LikesCount;
      PlaysCount = song.PlaysCount;

      return this;
    }
  }
}
