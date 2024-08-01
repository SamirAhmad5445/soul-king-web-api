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
    [HttpGet("info")]
    public async Task<ActionResult<ArtistResponseDTO>> GetInfo()
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      try
      {
        string username = Request.Cookies["username"]!;
        Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == username);

        if (artist == null)
        {
          return NotFound("Artist account was not found.");
        }

        var response = new ArtistResponseDTO().FromArtist(artist);

        return Ok(response);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while generating the token.");
      }
    }

    [HttpPut("edit")]
    public async Task<ActionResult<ArtistResponseDTO>> EditInfo(ArtistEditDTO request)
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      if (request.Email == null || request.Email == string.Empty)
      {
        return BadRequest("Invalid email.");
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

      if (request.BirthDate > DateOnly.FromDateTime(DateTime.Now))
      {
        return BadRequest("Invalid date of birth.");
      }

      try
      {
        var artistName = Request.Cookies["username"];

        Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == artistName);

        if (artist == null)
        {
          return NotFound("Artist was not found.");
        }

        artist.Email = request.Email;
        artist.FirstName = request.FirstName;
        artist.LastName = request.LastName;
        artist.DisplayName = request.DisplayName;
        artist.Description = request.Description;
        artist.BirthDate = request.BirthDate;

        db.Artists.Update(artist);
        await db.SaveChangesAsync();

        return Ok(new ArtistResponseDTO().FromArtist(artist));
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while generating the token.");
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

    [HttpGet("profile-image")]
    public async Task<IActionResult> GetImage()
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

      var artistName = Request.Cookies["username"];

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
    [HttpPost("album/relase")]
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
        return StatusCode(500, "An error occurred while generating the token.");
      }
    }

    [HttpGet("album/all")]
    public async Task<ActionResult<List<AlbumDTO>>> GetAllAlbums()
    {
      if (!await IsArtistAllowed())
      {
        return Unauthorized("Your access has been denied.");
      }

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
        return StatusCode(500, "An error occurred while generating the token.");
      }
    }

    [HttpGet("album/{Name}")]
    public async Task<ActionResult<string>> GetAlbum(string Name)
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
        return NotFound("Thumbnail file was not found2222.");
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

    #region SongsActions
    [HttpPost("song/release")]
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
        return Ok();
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while generating the token.");
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
