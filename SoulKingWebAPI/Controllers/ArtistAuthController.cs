using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoulKingWebAPI.Data;
using SoulKingWebAPI.Models;
using SoulKingWebAPI.Models.DTO;
using System.Data;
using System.Security.Cryptography;

namespace SoulKingWebAPI.Controllers
{
  [Route("api/artist")]
  [ApiController]
  public class ArtistAuthController(DatabaseContext db) : ControllerBase
  {
    [HttpPost("login")]
    public async Task<ActionResult<ArtistResponseDTO>> Login(ArtisttLoginDTO request)
    {
      try
      {
        if (request.Username == null || request.Username == string.Empty)
        {
          return BadRequest("Username is required to login.");
        }

        if (request.Password == null || request.Password == string.Empty)
        {
          return BadRequest("A password is required to login.");
        }

        Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == request.Username);

        if (artist == null)
        {
          DeleteCookies();
          return NotFound("Artist account was not found.");
        }

        if (!artist.VerifyPassword(request.Password))
        {
          DeleteCookies();
          return Unauthorized("Invalid username or password.");
        }

        ArtistResponseDTO response = new ArtistResponseDTO().FromArtist(artist);

        string token = CreateCookies(request.Username);

        artist.Token = token;

        db.Artists.Update(artist);
        await db.SaveChangesAsync();

        return Ok(response);
      }
      catch (Exception)
      {
        DeleteCookies();
        return StatusCode(500, "An error occurred while generating the token.");
      }
    }

    [HttpPut("activate")]
    public async Task<ActionResult<ArtistResponseDTO>> Activate([FromBody]string NewPassword)
    {
      try
      {
        if (NewPassword == null || NewPassword == string.Empty || NewPassword.Length < 8)
        {
          return BadRequest("Invalid pasword.");
        }

        var Username = Request.Cookies["username"];
        var Token = Request.Cookies["token"];
        var Role = Request.Cookies["role"];

        if (Username == null || Token == null || Role != "artist")
        {
          return Unauthorized("Your access has been denied.");
        }

        Artist? artist = await db.Artists.SingleOrDefaultAsync(a => a.Username == Username);

        if (artist == null)
        {
          return NotFound("Artist account was not found.");
        }

        if (artist.Token != Token)
        {
          return Unauthorized("Invalid token.");
        }

        if (artist.IsActivated)
        {
          return BadRequest("Your account has been activated once.");
        }

        if (artist.VerifyPassword(NewPassword))
        {
          return BadRequest("Your new password can't be the old password.");
        }

        artist.UpdatePassword(NewPassword);
        artist.IsActivated = true;

        ArtistResponseDTO response = new ArtistResponseDTO().FromArtist(artist);

        db.Artists.Update(artist);
        await db.SaveChangesAsync();

        return Ok(response);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while generating the token.");
      }
    }

    private string CreateCookies(string Username)
    {
      var CookieOpt = new CookieOptions()
      {
        Secure = true,
        HttpOnly = false,
        Expires = DateTime.Now.AddDays(1),
        SameSite = SameSiteMode.None,
      };

      string newToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

      Response.Cookies.Append("username", Username, CookieOpt);
      Response.Cookies.Append("token", newToken, CookieOpt);
      Response.Cookies.Append("role", "artist", CookieOpt);

      return newToken;
    }

    private void DeleteCookies()
    {
      Response.Cookies.Delete("username");
      Response.Cookies.Delete("token");
      Response.Cookies.Delete("role");
    }
  }
}
