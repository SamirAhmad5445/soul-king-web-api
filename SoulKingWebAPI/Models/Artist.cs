using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace SoulKingWebAPI.Models
{
  public class Artist
  {
    #region Constructors
    public Artist(int id, string username, string displayName, byte[] passwordHash, byte[] passwordSalt, string email, string description, string firstName, string lastName, DateOnly birthDate, bool isActivated, int followersCount)
    {
      Id = id;
      Username = username;
      DisplayName = displayName;
      PasswordHash = passwordHash;
      PasswordSalt = passwordSalt;
      Email = email;
      Description = description;
      FirstName = firstName;
      LastName = lastName;
      BirthDate = birthDate;
      IsActivated = isActivated;
      FollowersCount = followersCount;
    }

    public Artist(string username, string displayName, string password, string email, string description, string firstName, string lastName, DateOnly birthDate) {
      Username = username;
      DisplayName = displayName;
      Email = email;
      Description = description;
      FirstName = firstName;
      LastName = lastName;
      BirthDate = birthDate;
      IsActivated = false;
      FollowersCount = 0;

      CreatePasswordHash(password);
    }
    #endregion

    #region Mapped props
    public int Id { get; set; }
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public string Email { get; set; }
    public string Description { get; set; }
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public DateOnly BirthDate { get; set; }
    public bool IsActivated { get; set; } = false;
    public int FollowersCount { get; set; } = 0;
    #endregion

    #region Relationships
    // song
    public List<Song> Songs { get; set; } // 1:N

    // album
    public List<Album> Albums { get; set; } // 1:N

    // user
    public List<User> Followers { get; set; } // M:N
    #endregion

    #region Methods
    private bool CreatePasswordHash(string Password)
    {
      if (Password.Length < 8)
      {
        return false;
      }

      using var hmac = new HMACSHA512();
      PasswordSalt = hmac.Key;
      PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));

      return true;
    }

    public bool UpdatePassword(string Password)
    {
      if (Password == null || PasswordHash.Length == 0)
      {
        return false;
      }

      return CreatePasswordHash(Password);
    }

    public bool VerifyPassword(string Password)
    {
      if (Password.Length < 8)
      {
        return false;
      }

      using var hmac = new HMACSHA512(PasswordSalt);
      byte[] ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));

      return PasswordHash.SequenceEqual(ComputedHash);
    }

    #endregion
  }
}
