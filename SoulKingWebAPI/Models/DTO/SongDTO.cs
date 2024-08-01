namespace SoulKingWebAPI.Models.DTO
{
  public class SongDTO
  {
    public SongDTO() { }

    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int LikesCount { get; set; }
    public int ListenersCount { get; set; }

    public SongDTO FromSong(Song song, int listenersCount)
    {
      Name = song.Name;
      ReleaseDate = song.ReleaseDate;
      LikesCount = song.LikesCount;
      ListenersCount = listenersCount;

      return this;
    }
  }
}
