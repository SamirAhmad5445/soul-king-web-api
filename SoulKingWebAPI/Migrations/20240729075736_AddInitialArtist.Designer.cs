﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoulKingWebAPI.Data;

#nullable disable

namespace SoulKingWebAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240729075736_AddInitialArtist")]
    partial class AddInitialArtist
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlbumUser", b =>
                {
                    b.Property<int>("LikedAlbumsId")
                        .HasColumnType("int");

                    b.Property<int>("LikedUsersId")
                        .HasColumnType("int");

                    b.HasKey("LikedAlbumsId", "LikedUsersId");

                    b.HasIndex("LikedUsersId");

                    b.ToTable("AlbumUser");
                });

            modelBuilder.Entity("ArtistUser", b =>
                {
                    b.Property<int>("FollowedArtistId")
                        .HasColumnType("int");

                    b.Property<int>("FollowersId")
                        .HasColumnType("int");

                    b.HasKey("FollowedArtistId", "FollowersId");

                    b.HasIndex("FollowersId");

                    b.ToTable("ArtistUser");
                });

            modelBuilder.Entity("PlaylistSong", b =>
                {
                    b.Property<int>("AssociatedPlaylistsId")
                        .HasColumnType("int");

                    b.Property<int>("SongsId")
                        .HasColumnType("int");

                    b.HasKey("AssociatedPlaylistsId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("PlaylistSong");
                });

            modelBuilder.Entity("PlaylistUser", b =>
                {
                    b.Property<int>("SavedPlaylistsId")
                        .HasColumnType("int");

                    b.Property<int>("SavedUsersId")
                        .HasColumnType("int");

                    b.HasKey("SavedPlaylistsId", "SavedUsersId");

                    b.HasIndex("SavedUsersId");

                    b.ToTable("UserSavedPlaylist", (string)null);
                });

            modelBuilder.Entity("SongUser", b =>
                {
                    b.Property<int>("LikedSongsId")
                        .HasColumnType("int");

                    b.Property<int>("LikedUsersId")
                        .HasColumnType("int");

                    b.HasKey("LikedSongsId", "LikedUsersId");

                    b.HasIndex("LikedUsersId");

                    b.ToTable("UserLikedSongs", (string)null);
                });

            modelBuilder.Entity("SongUser1", b =>
                {
                    b.Property<int>("HeardSongsId")
                        .HasColumnType("int");

                    b.Property<int>("ListenersId")
                        .HasColumnType("int");

                    b.HasKey("HeardSongsId", "ListenersId");

                    b.HasIndex("ListenersId");

                    b.ToTable("UserSongs", (string)null);
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FollowersCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateOnly(1974, 4, 13),
                            Description = "A musician and swordsman who is also a skeleton.",
                            DisplayName = "Sk Brook",
                            Email = "sk.brook@strawhats.com",
                            FirstName = "Soul King",
                            FollowersCount = 0,
                            IsActivated = false,
                            LastName = "Brook",
                            PasswordHash = new byte[] { 154, 166, 139, 205, 10, 166, 188, 105, 212, 60, 69, 33, 191, 85, 154, 76, 223, 196, 239, 107, 51, 151, 70, 112, 65, 87, 172, 82, 52, 145, 168, 11, 100, 141, 214, 18, 25, 204, 176, 211, 83, 82, 119, 54, 149, 81, 45, 136, 175, 143, 81, 121, 109, 252, 140, 179, 172, 166, 27, 90, 158, 109, 232, 100 },
                            PasswordSalt = new byte[] { 104, 248, 147, 93, 162, 213, 87, 3, 78, 28, 132, 215, 111, 212, 20, 141, 163, 79, 251, 239, 245, 134, 208, 10, 243, 83, 192, 14, 78, 23, 169, 8, 158, 199, 215, 186, 1, 223, 255, 1, 20, 207, 166, 241, 161, 104, 178, 103, 238, 24, 131, 132, 197, 85, 239, 88, 228, 28, 149, 88, 75, 60, 70, 215, 209, 2, 191, 207, 251, 125, 38, 146, 104, 138, 48, 225, 128, 51, 50, 51, 72, 176, 128, 174, 47, 102, 148, 253, 153, 150, 33, 73, 249, 172, 14, 130, 220, 126, 5, 255, 112, 111, 208, 123, 152, 144, 18, 70, 15, 85, 163, 179, 202, 228, 174, 253, 34, 211, 151, 255, 182, 190, 3, 122, 175, 159, 104, 135 },
                            Token = "",
                            Username = "brook"
                        });
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pop"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jazz"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hip-hop"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Classical"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Electronic"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Country"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Blues"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Reggae"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Metal"
                        },
                        new
                        {
                            Id = 11,
                            Name = "K-pop"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Rap"
                        },
                        new
                        {
                            Id = 13,
                            Name = "J-pop"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Latin"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Funk"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Soul"
                        });
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("CategiryId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikesCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AlbumUser", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.Album", null)
                        .WithMany()
                        .HasForeignKey("LikedAlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoulKingWebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("LikedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtistUser", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("FollowedArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoulKingWebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaylistSong", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.Playlist", null)
                        .WithMany()
                        .HasForeignKey("AssociatedPlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoulKingWebAPI.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaylistUser", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.Playlist", null)
                        .WithMany()
                        .HasForeignKey("SavedPlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoulKingWebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("SavedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SongUser", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("LikedSongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoulKingWebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("LikedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SongUser1", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("HeardSongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoulKingWebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ListenersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Album", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Playlist", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.RefreshToken", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Song", b =>
                {
                    b.HasOne("SoulKingWebAPI.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoulKingWebAPI.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .IsRequired();

                    b.HasOne("SoulKingWebAPI.Models.Category", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artist");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Category", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.User", b =>
                {
                    b.Navigation("Playlists");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}