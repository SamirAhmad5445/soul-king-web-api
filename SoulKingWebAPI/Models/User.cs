using System.Text;
using System.Security.Cryptography;

namespace SoulKingWebAPI.Models
{
  public class User
  {
    #region Constructors
    public User(int id, string username, byte[] passwordHash, byte[] passwordSalt, string firstName, string lastName, string email, string description, DateOnly birthDate)
    {
      Id = id;
      Username = username;
      PasswordHash = passwordHash;
      PasswordSalt = passwordSalt;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Description = description;
      BirthDate = birthDate;
    }

    public User(string username, string password, string firstName, string lastName, string email, DateOnly birthDate)
    {
      Username = username;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      BirthDate = birthDate;
      Description = string.Empty;

      CreatePasswordHash(password);
    }
    #endregion

    #region Mapped props
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public DateOnly BirthDate { get; set; }
    #endregion

    #region Relationships
    // Refresh Token
    public List<RefreshToken> RefreshTokens { get; set; } // 1:N
    // playlists
    public List<Playlist> Playlists { get; set; } // 1:N
    public List<Playlist> SavedPlaylists { get; set; } // M:N
    // Songs
    public List<Song> HeardSongs { get; set; } // M:N
    public List<Song> LikedSongs { get; set; } // M:N
    // Artists
    public List<Artist> FollowedArtist { get; set; } // M:N
    // Albums
    public List<Album> LikedAlbums { get; set; } // M:N
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
