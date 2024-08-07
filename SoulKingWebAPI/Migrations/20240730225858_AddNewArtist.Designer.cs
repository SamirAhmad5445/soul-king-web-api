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
    [Migration("20240730225858_AddNewArtist")]
    partial class AddNewArtist
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
                            PasswordHash = new byte[] { 7, 178, 28, 193, 94, 103, 209, 47, 16, 217, 227, 254, 58, 29, 56, 157, 110, 247, 153, 38, 157, 74, 46, 27, 187, 175, 141, 108, 182, 155, 208, 116, 192, 132, 72, 191, 153, 74, 43, 113, 80, 193, 134, 77, 98, 185, 117, 25, 110, 138, 69, 168, 233, 42, 124, 153, 200, 148, 59, 251, 75, 10, 215, 70 },
                            PasswordSalt = new byte[] { 46, 155, 6, 231, 13, 191, 85, 98, 113, 26, 218, 158, 22, 205, 121, 33, 237, 208, 212, 192, 46, 25, 195, 48, 157, 177, 220, 192, 118, 201, 239, 177, 40, 188, 151, 191, 75, 216, 182, 205, 202, 224, 137, 244, 242, 248, 224, 6, 97, 1, 55, 91, 158, 23, 247, 95, 107, 123, 30, 213, 83, 3, 112, 105, 31, 91, 30, 114, 14, 191, 49, 160, 243, 239, 224, 60, 195, 193, 43, 231, 122, 160, 160, 44, 221, 20, 198, 168, 45, 235, 172, 162, 211, 191, 193, 103, 127, 31, 232, 137, 115, 88, 124, 8, 31, 228, 195, 29, 23, 97, 60, 37, 56, 190, 91, 78, 157, 200, 248, 43, 177, 146, 227, 39, 17, 148, 178, 219 },
                            Token = "",
                            Username = "brook"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateOnly(1996, 8, 29),
                            Description = "Brings happiness and joy to everyone by my songs.",
                            DisplayName = "Uta",
                            Email = "uta@redhairpirates.com",
                            FirstName = "Diva",
                            FollowersCount = 0,
                            IsActivated = false,
                            LastName = "Uta",
                            PasswordHash = new byte[] { 21, 217, 94, 226, 192, 149, 140, 209, 33, 63, 169, 12, 188, 130, 98, 222, 147, 17, 35, 222, 122, 199, 67, 6, 245, 239, 74, 149, 45, 99, 41, 110, 167, 112, 173, 163, 98, 177, 9, 203, 168, 37, 182, 75, 208, 245, 255, 12, 75, 114, 86, 97, 93, 115, 248, 216, 81, 208, 42, 54, 115, 41, 223, 160 },
                            PasswordSalt = new byte[] { 49, 46, 70, 8, 131, 91, 99, 230, 161, 250, 123, 137, 43, 3, 195, 115, 149, 167, 75, 72, 190, 119, 32, 205, 185, 61, 147, 188, 148, 73, 66, 97, 14, 151, 79, 44, 133, 23, 172, 232, 8, 95, 212, 155, 86, 203, 2, 211, 195, 186, 224, 26, 245, 91, 106, 44, 185, 143, 145, 168, 23, 108, 176, 67, 113, 20, 111, 104, 176, 188, 45, 54, 150, 228, 180, 175, 91, 154, 85, 12, 119, 44, 182, 9, 142, 58, 57, 57, 184, 177, 217, 248, 226, 184, 146, 124, 116, 99, 9, 217, 10, 93, 166, 30, 130, 191, 93, 147, 180, 43, 49, 213, 113, 101, 147, 144, 180, 169, 229, 242, 202, 17, 235, 94, 92, 241, 137, 80 },
                            Token = "",
                            Username = "uta"
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
