using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SoulKingWebAPI.Data;
using SoulKingWebAPI.Models;
using SoulKingWebAPI.Models.DTO;

namespace SoulKingWebAPI.Controllers
{
  [Route("api/artist")]
  [ApiController]
  public class ArtistActionsController(DatabaseContext db, IWebHostEnvironment env) : ControllerBase
  {
    private readonly string IMAGES_DIRECTORY = "UploadedImages";
    private readonly string AUDIOS_DIRECTORY = "UploadedAudios";
    private readonly string PROFILE_IMAGES_FOLDER = "Artists";
    private readonly string ALBUM_THUMBNAILS_FOLDER = "Thumbails";
    private readonly string[] allowedImageExtensions = [".jpg", ".jpeg", ".png"];

    #region Profile Actions
    [HttpGet("{artistName}/info")]
    public async Task<ActionResult<ArtistResponseDTO>> GetInfo(string artistName)
    {
      try
      {
        Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == artistName);

        if (artist == null)
        {
          return NotFound("Artist account was not found.");
        }

        var response = new ArtistResponseDTO().FromArtist(artist);

        return Ok(response);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpGet("status")]
    public async Task<ActionResult<ArtistStatusDTO>> GetStatus()
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      try
      {
        string username = Request.Cookies["username"]!;
        Artist? artist = await db.Artists
          .Include(a => a.Songs)
          .Include(a => a.Albums)
          .SingleOrDefaultAsync(a => a.Username == username);

        if (artist == null)
        {
          return NotFound("Artist account was not found.");
        }

        var status = new ArtistStatusDTO
        {
          AlbumsCount = artist.Albums.ToList().Count,
          SongsCount = artist.Songs.ToList().Count,
          FollowersCount = artist.FollowersCount
        };

        return Ok(status);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpPut("edit")]
    public async Task<ActionResult<ArtistResponseDTO>> EditInfo(ArtistEditDTO request)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      if (request.FirstName == null || request.FirstName == string.Empty)
      {
        return BadRequest("Invalid first name.");
      }

      if (request.LastName == null || request.LastName == string.Empty)
      {
        return BadRequest("Invalid last name.");
      }

      if (request.DisplayName == null || request.DisplayName == string.Empty)
      {
        return BadRequest("Invalid dispaly name.");
      }

      if (request.Description == null || request.Description == string.Empty)
      {
        return BadRequest("Invalid profile description.");
      }

      try
      {
        var artistName = Request.Cookies["username"];

        Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == artistName);

        if (artist == null)
        {
          return NotFound("Artist was not found.");
        }

        artist.FirstName = request.FirstName;
        artist.LastName = request.LastName;
        artist.DisplayName = request.DisplayName;
        artist.Description = request.Description;

        db.Artists.Update(artist);
        await db.SaveChangesAsync();

        return Ok(new ArtistResponseDTO().FromArtist(artist));
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpPost("profile-image")]
    public async Task<ActionResult<string>> UploadImage([FromForm] ImageUpload request)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      if (request.Image == null || request.Image.Length == 0)
      {
        return BadRequest("No image was uploaded.");
      }

      var extension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
      if (!allowedImageExtensions.Contains(extension))
      {
        return BadRequest("Invalid image format. Only .jpg, .jpeg, and .png are allowed.");
      }

      var artistName = Request.Cookies["username"]!;

      Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == artistName);

      if (artist == null)
      {
        return NotFound("Artist was not found.");
      }

      var rootPath = env.ContentRootPath;
      var uploadsFolder = Path.Combine(rootPath, IMAGES_DIRECTORY, PROFILE_IMAGES_FOLDER);

      if (!Directory.Exists(uploadsFolder))
      {
        Directory.CreateDirectory(uploadsFolder);
      }

      var filePath = Path.Combine(uploadsFolder, $"{artistName}.webp");

      using (var image = Image.Load(request.Image.OpenReadStream()))
      {
        var size = Math.Min(image.Width, image.Height);
        var rect = new Rectangle((image.Width - size) / 2, (image.Height - size) / 2, size, size);

        image.Mutate(img => img.Crop(rect));
        await image.SaveAsync(filePath, new SixLabors.ImageSharp.Formats.Webp.WebpEncoder());
      }

      artist.ProfileImage = Path.Combine(IMAGES_DIRECTORY, PROFILE_IMAGES_FOLDER, $"{artistName}.webp").ToString();

      db.Artists.Update(artist);
      await db.SaveChangesAsync();

      return Ok("Your profile image has been uploaded.");
    }

    [HttpGet("{artistName}/profile-image")]
    public async Task<IActionResult> GetImage(string artistName)
    {
      Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == artistName);
      
      if (artist == null)
      {
        NotFound("Artist was not found.");
      }

      if (string.IsNullOrEmpty(artist!.ProfileImage))
      {
        NotFound("Progile image was not found.");
      }

      var filePath = Path.Combine(env.ContentRootPath, artist.ProfileImage);

      if (!System.IO.File.Exists(filePath))
      {
        return NotFound("Image file was not found.");
      }

      var image = System.IO.File.OpenRead(filePath);
      return File(image, "image/webp");
    }
    #endregion

    #region Albums Actions
    [HttpPost("album/release")]
    public async Task<ActionResult<string>> RelaseAlbum(ReleaseAlbumDTO request)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      if (artistName == null || artistName == string.Empty)
      {
        return Unauthorized("Invalid username for artist account.");
      }

      if (request.Name == null || request.Name == string.Empty)
      {
        return BadRequest("Invalid album name.");
      }

      if (request.Description == null || request.Description == string.Empty)
      {
        return BadRequest("Invalid album description.");
      }

      if (request.Image == null || request.Image.Length == 0)
      {
        return BadRequest("No thumnail image was uploaded.");
      }

      var extension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
      if (!allowedImageExtensions.Contains(extension))
      {
        return BadRequest("Invalid image format. Only .jpg, .jpeg, and .png are allowed.");
      }

      try
      {
        Artist? artist = await db.Artists
          .Include(a => a.Albums)
          .SingleOrDefaultAsync(a => a.Username == artistName);

        if (artist == null)
        {
          return NotFound("Artist was not found.");
        }

        if (artist.Albums.SingleOrDefault(al => al.Name == request.Name) != null)
        {
          return Conflict("Album already exits by this name.");
        }

        var rootPath = env.ContentRootPath;
        var uploadsFolder = Path.Combine(
            rootPath, 
            IMAGES_DIRECTORY, 
            ALBUM_THUMBNAILS_FOLDER , 
            artist.Username
          );

        if (!Directory.Exists(uploadsFolder))
        {
          Directory.CreateDirectory(uploadsFolder);
        }

        var filePath = Path.Combine(uploadsFolder, $"{request.Name}.webp");

        using (var image = Image.Load(request.Image.OpenReadStream()))
        {
          var size = Math.Min(image.Width, image.Height);
          var rect = new Rectangle((image.Width - size) / 2, (image.Height - size) / 2, size, size);

          image.Mutate(img => img.Crop(rect));
          await image.SaveAsync(filePath, new SixLabors.ImageSharp.Formats.Webp.WebpEncoder());
        }

        var thumbnail = Path.Combine(
            IMAGES_DIRECTORY, 
            ALBUM_THUMBNAILS_FOLDER, 
            artist.Username, 
            $"{request.Name}.webp"
          ).ToString();

        artist.Albums.Add(new Album(
            request.Name,
            request.Description,
            thumbnail
          ));

        db.Artists.Update(artist);
        await db.SaveChangesAsync();

        return Ok("New album has been created successfully");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpGet("album/all")]
    public async Task<ActionResult<List<AlbumDTO>>> GetAllAlbums()
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      try
      {
        Artist? artist = await db.Artists
          .Include(a => a.Albums)
          .SingleOrDefaultAsync(a => a.Username == artistName);

        if (artist == null)
        {
          return NotFound("Artist was not found.");
        }

        List<AlbumDTO> results = [];

        foreach(var album in artist.Albums.ToList())
        {
          results.Add(new AlbumDTO().FromAlbum(album));
        }

        return Ok(results);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpGet("album/{Name}")]
    public async Task<ActionResult<AlbumDTO>> GetAlbum(string Name)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      Artist? artist = await db.Artists
        .Include(a => a.Albums)
        .SingleOrDefaultAsync(a => a.Username == artistName);

      if (artist == null)
      {
        NotFound("Artist was not found.");
      }

      Album? album = artist!.Albums.ToList().SingleOrDefault(al => al.Name == Name);

      if (album == null)
      {
        return NotFound("Album was not found.");
      }

      return Ok(new AlbumDTO().FromAlbum(album));
    }

    [HttpGet("album/{Name}/thumbnail")]
    public async Task<IActionResult> GetAlbumThumbnail(string Name)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      Artist? artist = await db.Artists
        .Include(a => a.Albums)
        .SingleOrDefaultAsync(a => a.Username == artistName);

      if (artist == null)
      {
        NotFound("Artist was not found.");
      }

      Album? album = artist!.Albums.ToList().SingleOrDefault(al => al.Name == Name);

      if (album == null)
      {
        return NotFound("Album does't exists");
      }

      var filePath = Path.Combine(env.ContentRootPath, album.Thumbnail);

      if (!System.IO.File.Exists(filePath))
      {
        return NotFound("Thumbnail file was not found.");
      }

      var image = System.IO.File.OpenRead(filePath);
      return File(image, "image/webp");
    }

    [HttpDelete("album/delete-all")]
    public async Task<ActionResult<string>> DeleteAllAlbums()
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      Artist? artist = await db.Artists
        .Include(a => a.Albums)
        .SingleOrDefaultAsync(a => a.Username == artistName);

      if (artist == null)
      {
        NotFound("Artist was not found.");
      }

      var thumbnailsFolder = Path.Combine(
          env.ContentRootPath,
          IMAGES_DIRECTORY,
          ALBUM_THUMBNAILS_FOLDER,
          artist!.Username
        );

      Directory.Delete(thumbnailsFolder, true);

      artist!.Albums.Clear();
      await db.SaveChangesAsync();

      return Ok("All Albums were destroyed.");
    }

    [HttpDelete("album/{Name}/delete")]
    public async Task<ActionResult<string>> DeleteAlbum(string Name)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      if (Name == null || Name == string.Empty)
      {
        return BadRequest("Invalid album name.");
      }

      var artistName = Request.Cookies["username"];

      Artist? artist = await db.Artists
        .Include(a => a.Albums)
        .SingleOrDefaultAsync(a => a.Username == artistName);

      if (artist == null)
      {
        NotFound("Artist was not found.");
      }

      Album? album = artist!.Albums.ToList().SingleOrDefault(al => al.Name == Name);

      if (album == null)
      {
        return NotFound("Album was not found.");
      }

      var thumbnailPath = Path.Combine(
          env.ContentRootPath,
          album.Thumbnail
        );

      if (!System.IO.File.Exists(thumbnailPath))
      {
        return NotFound("Image file was not found.");
      }

      System.IO.File.Delete(thumbnailPath);

      artist.Albums.Remove(album);
      await db.SaveChangesAsync();

      return Ok("One album has been deleted.");
    }
    #endregion

    #region Songs Actions
    [HttpGet("song/all")]
    public async Task<ActionResult<List<SongDTO>>> GetAllSongs()
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      try
      {
        Artist? artist = await db.Artists
          .Include(a => a.Songs)
          .SingleOrDefaultAsync(a => a.Username == artistName);

        if (artist == null)
        {
          return NotFound("Artist was not found.");
        }

        List<SongDTO> results = [];

        foreach (var song in artist.Songs.ToList())
        {
          results.Add(new SongDTO().FromSong(song));
        }

        return Ok(results);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpPost("album/add-song")]
    public async Task<ActionResult<string>> ReleaseSong(ReleaseSongDTO request)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      if (request.Name == null || request.Name == string.Empty)
      {
        return BadRequest("Invalid album name.");
      }
      
      if (request.AlbumName == null || request.AlbumName == string.Empty)
      {
        return BadRequest("Invalid album name.");
      }

      if (request.Image == null || request.Image.Length == 0)
      {
        return BadRequest("No image file was uploaded.");
      }

      if (request.Audio == null || request.Audio.Length == 0)
      {
        return BadRequest("No audio file was uploaded.");
      }

      var imageExtension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
      if (!allowedImageExtensions.Contains(imageExtension))
      {
        return BadRequest("Invalid image format. Only .jpg, .jpeg, and .png are allowed.");
      }

      if (request.Audio.ContentType != "audio/mpeg")
      {
        return BadRequest("Invalid audio format. Only .mp3 files are allowed.");
      }

      try
      {
        Album? album = await db.Albums
          .Include(al => al.Artist)
          .Include(al => al.Songs)
          .SingleOrDefaultAsync(al => al.Name == request.AlbumName && al.Artist.Username == artistName);

        if (album == null)
        {
          return NotFound("Album was not Found.");
        }

        if(album.Songs.SingleOrDefault(s => s.Name == request.Name) != null)
        {
          return Conflict("The album contain a song with the same name.");
        }

        var rootPath = env.ContentRootPath;
        var songPath = Path.Combine(
            AUDIOS_DIRECTORY,
            album.Artist.Username,
            request.AlbumName,
            request.Name
          );
        var uploadsFolder = Path.Combine(
            rootPath,
            songPath
          );

        if (!Directory.Exists(uploadsFolder))
        {
          Directory.CreateDirectory(uploadsFolder);
        }

        var imagePath = Path.Combine(uploadsFolder, $"{request.Name}.webp");

        using (var image = Image.Load(request.Image.OpenReadStream()))
        {
          var size = Math.Min(image.Width, image.Height);
          var rect = new Rectangle((image.Width - size) / 2, (image.Height - size) / 2, size, size);

          image.Mutate(img => img.Crop(rect));
          await image.SaveAsync(imagePath, new SixLabors.ImageSharp.Formats.Webp.WebpEncoder());
        }

        var audioPath = Path.Combine(uploadsFolder, $"{request.Name}.mp3");

        using (var fileStream = new FileStream(audioPath, FileMode.Create))
        {
          await request.Audio.CopyToAsync(fileStream);
        }

        var newSong = new Song(
            request.Name,
            Path.Combine(songPath, $"{request.Name}.mp3").ToString(),
            Path.Combine(songPath, $"{request.Name}.webp").ToString()
          )
          {
            ArtistId = album.ArtistId,
            AlbumId = album.Id
          };

        await db.Songs.AddAsync(newSong);
        await db.SaveChangesAsync();

        return Ok("New song added to the album.");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpGet("album/{AlbumName}/songs")]
    public async Task<ActionResult<List<SongDTO>>> GetAllSongInfo(string AlbumName)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }
      var artistName = Request.Cookies["username"]!;

      if (AlbumName == null || AlbumName == string.Empty)
      {
        return BadRequest("Invalid album name.");
      }

      try
      {
        var album = await db.Albums
          .Include(al => al.Artist)
          .Include(al => al.Songs)
          .SingleOrDefaultAsync(al => al.Name == AlbumName && al.Artist.Username == artistName);

        if (album == null)
        {
          return NotFound("Album was not found.");
        }

        List<SongDTO> results = [];

        foreach (var song in album.Songs.ToList())
        {
          results.Add(new SongDTO().FromSong(song));
        }

        return Ok(results);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpGet("album/{AlbumName}/{Name}")]
    public async Task<ActionResult<SongDTO>> GetSongInfo(string AlbumName, string Name)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }
      var artistName = Request.Cookies["username"]!;

      if (AlbumName == null || AlbumName == string.Empty)
      {
        return BadRequest("Invalid album name.");
      }

      try
      {
        var song = await db.Songs
          .Include(s => s.Artist)
          .Include(s => s.Album)
          .SingleOrDefaultAsync(
            s => s.Name == Name && s.Artist.Username == artistName && s.Album.Name == AlbumName
          );

        if (song == null)
        {
          return NotFound("song was not found.");
        }

        var result = new SongDTO().FromSong(song);
        return Ok(result);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }

    [HttpGet("album/{AlbumName}/{Name}/image")]
    public async Task<IActionResult> GetSongImage(string AlbumName, string Name) {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      var song = await db.Songs
          .Include(s => s.Artist)
          .Include(s => s.Album)
          .SingleOrDefaultAsync(
            s => s.Name == Name && s.Artist.Username == artistName && s.Album.Name == AlbumName
          );

      if (song == null)
      {
        NotFound("Song was not found.");
      }

      var filePath = Path.Combine(env.ContentRootPath, song!.ImagePath);

      if (!System.IO.File.Exists(filePath))
      {
        return NotFound("Thumbnail file was not found.");
      }

      var image = System.IO.File.OpenRead(filePath);
      return File(image, "image/webp");
    }

    [HttpGet("album/{AlbumName}/{Name}/file")]
    public async Task<IActionResult> GetSongFile(string AlbumName, string Name)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

      var song = await db.Songs
          .Include(s => s.Artist)
          .Include(s => s.Album)
          .SingleOrDefaultAsync(
            s => s.Name == Name && s.Artist.Username == artistName && s.Album.Name == AlbumName
          );

      if (song == null)
      {
        NotFound("Song was not found.");
      }

      var filePath = Path.Combine(env.ContentRootPath, song!.FilePath);

      if (!System.IO.File.Exists(filePath))
        return NotFound("File not found.");

      var mimeType = "audio/mpeg";
      return PhysicalFile(filePath, mimeType, $"{Name}.mp3");
    }

    [HttpDelete("album/{AlbumName}/{Name}/delete")]
    public async Task<ActionResult<string>> DeleteSong(string AlbumName, string Name)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }
      var artistName = Request.Cookies["username"]!;

      if (AlbumName == null || AlbumName == string.Empty)
      {
        return BadRequest("Invalid album name.");
      }


      if (Name == null || Name == string.Empty)
      {
        return BadRequest("Invalid song name.");
      }

      try
      {
        var song = await db.Songs
          .Include(s => s.Artist)
          .Include(s => s.Album)
          .SingleOrDefaultAsync(s => s.Artist.Username == artistName &&
            s.Album.Name == AlbumName && s.Name == Name);

        if (song == null)
        {
          return NotFound("Song was not found.");
        }

        var folderPath = Path.Combine(
                 env.ContentRootPath,
                 AUDIOS_DIRECTORY,
                 artistName,
                 AlbumName,
                 Name
               );

        if (!Directory.Exists(folderPath))
        {
          return NotFound("Image file was not found.");
        }

        Directory.Delete(folderPath, true);

        db.Songs.Remove(song);
        await db.SaveChangesAsync();

        return Ok("Song has been deleted from the album.");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while proccessing your request.");
      }
    }
    #endregion

    private async Task<bool> IsArtistAllowed()
    {
      var username = Request.Cookies["username"];
      var token = Request.Cookies["token"];
      var role = Request.Cookies["role"];

      if (username == null || token == null || role != "artist")
      {
        return false;
      }

      try
      {
        Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == username);

        if (artist == null) { return false; }
        if (artist.Token != token) { return false; }
        if (!artist.IsActivated) { return false; }

        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
    }
  }
}
