using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SoulKingWebAPI.Data;
using SoulKingWebAPI.Models;
using SoulKingWebAPI.Models.DTO;

namespace SoulKingWebAPI.Controllers
{
  [Route("api/user")]
  [ApiController, Authorize(Roles = "User")]
  public class UserActionsController(DatabaseContext db, IWebHostEnvironment env) : ControllerBase
  {
    private readonly string IMAGES_DIRECTORY = "UploadedImages";
    private readonly string PROFILE_IMAGES_FOLDER = "Users";
    private readonly string[] allowedImageExtensions = [".jpg", ".jpeg", ".png"];


    #region Profile Actions
    [HttpGet("{Username}/info")]
    public async Task<ActionResult<UserInfoDTO>> GetUserInfo(string Username)
    {
      try
      {
        var user = await db.Users.SingleOrDefaultAsync(u => u.Username == Username);

        if (user == null)
        {
          return NotFound("User was not found.");
        }

        var result = new UserInfoDTO().FromUser(user);

        return Ok(result);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while processing your request.");
      }
    }

    [HttpPost("edit-profile")]
    public async Task<ActionResult<UserInfoDTO>> EditProfile(UserEditDTO request)
    {
      try
      {
        var username = Request.Cookies["username"];
        var user = await db.Users.SingleOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
          return NotFound("User was not found.");
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


        var rootPath = env.ContentRootPath;
        var uploadsFolder = Path.Combine(rootPath, IMAGES_DIRECTORY, PROFILE_IMAGES_FOLDER);

        if (!Directory.Exists(uploadsFolder))
        {
          Directory.CreateDirectory(uploadsFolder);
        }

        var filePath = Path.Combine(uploadsFolder, $"{username}.webp");

        using (var image = Image.Load(request.Image.OpenReadStream()))
        {
          var size = Math.Min(image.Width, image.Height);
          var rect = new Rectangle((image.Width - size) / 2, (image.Height - size) / 2, size, size);

          image.Mutate(img => img.Crop(rect));
          await image.SaveAsync(filePath, new SixLabors.ImageSharp.Formats.Webp.WebpEncoder());
        }

        user.FirstName = request.FirtName;
        user.LastName = request.LastName;
        user.Description = request.Description;
        user.Email = request.Email;
        user.ProfileImage = Path.Combine(IMAGES_DIRECTORY, PROFILE_IMAGES_FOLDER, $"{username}.webp").ToString();

        db.Users.Update(user);
        await db.SaveChangesAsync();

        var response = new UserInfoDTO().FromUser(user);
        return Ok(response);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while processing your request.");
      }
    }
    #endregion

    #region PlayLists Actions
    #endregion

    #region Artists Action
    [HttpGet("get-artists/{Start}")]
    public async Task<ActionResult<List<ArtistResponseDTO>>> GetArtists(int Start)
    {
      try
      {
        var artists = await db.Artists.ToListAsync();

        List<ArtistResponseDTO> results = [];

        foreach (var artist in artists.GetRange(Start, Math.Min(8, artists.ToList().Count)))
        {
          results.Add(new ArtistResponseDTO().FromArtist(artist));
        }

        return Ok(results);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }

    [HttpGet("get-artist/{Name}")]
    public async Task<ActionResult<ArtistResponseDTO>> GetArtistByName(string Name)
    {
      try
      {
        var artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == Name);

        if (artist == null)
        {
          return NotFound("Artist was not found.");
        }

        return Ok(new ArtistResponseDTO().FromArtist(artist));
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }

    [HttpGet("get-artist/{Name}/profile-image")]
    public async Task<IActionResult> GetArtisProfileImage(string Name)
    {
      try
      {
        var artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == Name);

        if (artist == null)
        {
          return NotFound("Artist was not found.");
        }

        var filePath = Path.Combine(env.ContentRootPath, artist.ProfileImage);

        if (!System.IO.File.Exists(filePath))
        {
          return NotFound("Atist image file was not found.");
        }

        var image = System.IO.File.OpenRead(filePath);
        return File(image, "image/webp");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }

    [HttpPut("follow-artist/{Name}")]
    public async Task<ActionResult<AlbumDTO>> FollowArtist(string Name)
    {
      if (!await IsUserAllowed())
      {
        return Unauthorized("Your request has been denied.");
      }

      var username = Request.Cookies["username"];

      try
      {
        var user = await db.Users
          .Include(u => u.FollowedArtist)
          .SingleOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
          return NotFound("Invalid Username.");
        }

        var artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == Name);

        if (artist == null)
        {
          return NotFound("Invalid artist name.");
        }

        user.FollowedArtist.Add(artist);
        await db.SaveChangesAsync();

        return Ok("Follow request was complete");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }

    [HttpPut("ufollow-artist/{Name}")]
    public async Task<ActionResult<AlbumDTO>> UnfollowArtist(string Name)
    {
      if (!await IsUserAllowed())
      {
        return Unauthorized("Your request has been denied.");
      }

      var username = Request.Cookies["username"];

      try
      {
        var user = await db.Users
          .Include(u => u.FollowedArtist)
          .SingleOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
          return NotFound("Invalid Username.");
        }

        var artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == Name);

        if (artist == null)
        {
          return NotFound("Invalid artist name.");
        }

        user.FollowedArtist.Remove(artist);
        await db.SaveChangesAsync();

        return Ok("Follow request was complete");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }
    #endregion

    #region Songs Actions
    #endregion

    #region Albums Actions
    [HttpGet("get-albums/{Start}")]
    public async Task<ActionResult<List<AlbumDTO>>> GetAlbums(int Start)
    {
      try
      {
        var albums = await db.Albums.ToListAsync();

        List<AlbumDTO> results = [];

        foreach(var al in albums.GetRange(Start, Math.Min(30, albums.ToList().Count - 1)))
        {
          results.Add(new AlbumDTO().FromAlbum(al));
        }

        return Ok(results);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }

    [HttpGet("get-album/{artist}/{name}")]
    public async Task<ActionResult<AlbumDTO>> GetAlbumByName(string artist,string name)
    {
      try
      {
        var album = await db.Albums
          .Include(al => al.Artist)
          .SingleOrDefaultAsync(al => al.Name == name && al.Artist.Username == artist);

        if (album == null)
        {
          return NotFound("Album was not found.");
        }

        return Ok(new AlbumDTO().FromAlbum(album));
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }

    [HttpGet("get-album/{artist}/{name}/thumbnail")]
    public async Task<IActionResult> GetAlbumThumbnail(string artist, string name)
    {
      try
      {
        var album = await db.Albums
          .Include(al => al.Artist)
          .SingleOrDefaultAsync(al => al.Name == name && al.Artist.Username == artist);

        if (album == null)
        {
          return NotFound("Album was not found.");
        }

        var filePath = Path.Combine(env.ContentRootPath, album.Thumbnail);

        if (!System.IO.File.Exists(filePath))
        {
          return NotFound("Thumbnail file was not found.");
        }

        var image = System.IO.File.OpenRead(filePath);
        return File(image, "image/webp");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }

    [HttpPut("star-album/{artist}/{name}")]
    public async Task<ActionResult<AlbumDTO>> StarAlbum(string artist, string name)
    {
      if (!await IsUserAllowed())
      {
        return Unauthorized("Your request has been denied.");
      }

      var username = Request.Cookies["username"];

      try
      {
        var user = await db.Users
          .Include(u => u.LikedAlbums)
          .SingleOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
          return NotFound("Invalid Username.");
        }

        var album = await db.Albums
          .Include(al => al.Artist)
          .SingleOrDefaultAsync(al => al.Name == name && al.Artist.Username == artist);

        if (album == null)
        {
          return NotFound("The album was not found.");
        }

        user.LikedAlbums.Add(album);
        await db.SaveChangesAsync();

        return Ok("The album has been stared");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }

    [HttpPut("unstar-album/{artist}/{name}")]
    public async Task<ActionResult<AlbumDTO>> UnstarAlbum(string artist, string name)
    {
      if (!await IsUserAllowed())
      {
        return Unauthorized("Your request has been denied.");
      }

      var username = Request.Cookies["username"];

      try
      {
        var user = await db.Users
          .Include(u => u.LikedAlbums)
          .SingleOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
          return NotFound("Invalid Username.");
        }

        var album = await db.Albums
          .Include(al => al.Artist)
          .SingleOrDefaultAsync(al => al.Name == name && al.Artist.Username == artist);

        if (album == null)
        {
          return NotFound("The album was not found.");
        }

        user.LikedAlbums.Remove(album);
        await db.SaveChangesAsync();

        return Ok("The album has been unstared");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occured while processing your request.");
      }
    }
    #endregion


    private async Task<bool> IsUserAllowed()
    {
      var username = Request.Cookies["username"];
      var token = Request.Cookies["refresh-token"];
      var role = Request.Cookies["role"];

      if (username == null || token == null || role != "user")
      {
        return false;
      }

      try
      {
        var user = await db.Users
          .Include(u => u.RefreshTokens)
          .SingleOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
          return false;
        }

        var lastToken = user.RefreshTokens.Last();

        if (lastToken == null)
        {
          return false;
        }

        return token.Equals(lastToken);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
    }
  }
}
