using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoulKingWebAPI.Data;
using SoulKingWebAPI.Models;
using SoulKingWebAPI.Models.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SoulKingWebAPI.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UserAuthController(DatabaseContext db, IConfiguration config) : ControllerBase
  {
    [HttpHead("check")]
    public ActionResult<bool> IsUsernameAvailable(string Username)
    {
      if (Username == null || Username == string.Empty)
      {
        return BadRequest("Invalid Username.");
      }

      if(IsUsernameExists(Username))
      {
        return Conflict(false);
      }

      return Ok(true);
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register(RegisterUserDTO request)
    {
      if (IsUsernameExists(request.Username))
      {
        return Conflict("This Username is not available.");
      }

      if (request.Password == null || request.Password!.Length < 8) {
        return BadRequest("Weak Password.");
      }

      if (!IsValidEmailAddress(request.Email)) {
        return BadRequest("Invalid Email.");
      }

      if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName)) {
        return BadRequest("Invalid First or Last name.");
      }

      User NewUser = new(
            request.Username,
            request.Password,
            request.FirstName,
            request.LastName,
            request.Email,
            request.BirthDate
          );

      try
      {
        await db.Users.AddAsync(NewUser);
        await db.SaveChangesAsync();

        return Ok("New Account has been created.");
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while generating the token.");
      }
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginUserDTO request)
    {
      if (
        request.Username == null || request.Username == "" ||
        request.Password == null || request.Password == ""
      )
      {
        return BadRequest("Please provide the required info.");
      }

      try
      {
        User? user = await db.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

        if (user == null)
        {
          return NotFound("User not found. Please check your username.");
        }

        if (!user.VerifyPassword(request.Password))
        {
          return Unauthorized("Invalid username or password.");
        }

        string? JwtToken = CreateJwtToken(request.Username, "User");

        if (JwtToken == null)
        {
          return StatusCode(500, "An error occurred while generating the token.");
        }

        var refreshToken = new RefreshToken();
        refreshToken.Generate();

        await SetRefreshToken(user.Username, refreshToken);

        return Ok(JwtToken);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while processing your request.");
      }
    }

    [HttpPut("refresh")]
    public async Task<ActionResult<string>> Refresh(string Username)
    {
      var token = Request.Cookies["refresh-token"];

      try
      {
        var user = await db.Users
          .Include(u => u.RefreshTokens)
          .SingleOrDefaultAsync(u => u.Username == Username);

        if (user == null)
        {
          return NotFound("User was not found");
        }

        var latestToken = user.RefreshTokens.Last();

        if (!latestToken.Value.Equals(token))
        {
          return Unauthorized("Invalid Refresh Token.");
        } 
        else if (latestToken.ExpiryDate < DateTime.Now)
        {
          return Unauthorized("Expired Refresh Token.");
        }

        var newToken = CreateJwtToken(user.Username, "User");
        var newRefreshToken = new RefreshToken();
        newRefreshToken.Generate();

        await SetRefreshToken(user.Username, newRefreshToken);

        return Ok(newToken);
      }
      catch (Exception)
      {
        return StatusCode(500, "An error occurred while generating the token.");
      }
    }

    [HttpGet("test"), Authorize(Roles = "User")]
    public ActionResult<string> Test()
    {
      return Ok("Hello, Wolrd!");
    }

    #region Utils
    private string? CreateJwtToken(string Username, string Role)
    {
      try
      {
        List<Claim> claims = [
            new Claim(ClaimTypes.Name, Username),
            new Claim(ClaimTypes.Role, Role)
          ];

        byte[] AppSecretToken = Encoding.UTF8.GetBytes(config["Secrets:Token"]!);

        var symmetricSecurityKey = new SymmetricSecurityKey(AppSecretToken);

        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
        return null;
      }
    }

    private async Task<bool> SetRefreshToken(string Username, RefreshToken Token)
    {
      var cookieOptions = new CookieOptions
      {
        Secure = true,
        HttpOnly = true,
        Expires = Token.ExpiryDate
      };

      Response.Cookies.Append("refresh-token", Token.Value, cookieOptions);

      try
      {
        User? user = await db.Users
        .Include(u => u.RefreshTokens)
        .SingleOrDefaultAsync(u => u.Username == Username);

        if (user == null) return false;

        user.RefreshTokens.Add(Token);

        db.Users.Update(user);
        await db.SaveChangesAsync();
        return true;
      } 
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
    }

    private bool IsUsernameExists(string Username)
    {
      var user = db.Users.SingleOrDefault(u => u.Username == Username);
      return user != null;
    }

    private bool IsValidEmailAddress(string Email)
    {
      MailAddress.TryCreate(Email, out MailAddress? result);
      return result != null;
    }
    #endregion
  }
}
