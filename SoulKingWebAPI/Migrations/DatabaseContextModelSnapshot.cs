﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoulKingWebAPI.Data;

#nullable disable

namespace SoulKingWebAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            PasswordHash = new byte[] { 227, 124, 150, 236, 3, 213, 196, 33, 192, 200, 172, 129, 47, 2, 107, 64, 249, 70, 139, 228, 159, 100, 70, 106, 189, 27, 32, 248, 233, 34, 130, 128, 245, 56, 77, 23, 20, 134, 110, 40, 54, 187, 112, 252, 18, 137, 136, 176, 138, 254, 119, 212, 32, 112, 78, 71, 35, 213, 227, 134, 186, 175, 50, 190 },
                            PasswordSalt = new byte[] { 133, 52, 114, 88, 12, 43, 245, 205, 166, 21, 41, 249, 116, 67, 223, 163, 149, 123, 18, 209, 28, 215, 236, 23, 8, 113, 179, 149, 42, 201, 36, 154, 114, 53, 75, 79, 23, 236, 159, 198, 189, 247, 20, 173, 7, 94, 163, 220, 229, 211, 155, 241, 199, 129, 221, 205, 106, 132, 115, 36, 127, 78, 250, 38, 255, 130, 5, 22, 185, 160, 158, 243, 111, 112, 145, 169, 207, 22, 106, 98, 29, 169, 148, 187, 247, 69, 19, 202, 121, 199, 121, 38, 12, 212, 55, 26, 130, 56, 7, 8, 237, 219, 56, 48, 58, 102, 177, 38, 58, 221, 17, 159, 134, 25, 233, 168, 218, 242, 178, 223, 218, 8, 26, 102, 8, 35, 78, 186 },
                            ProfileImage = "",
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
                            PasswordHash = new byte[] { 89, 116, 171, 27, 58, 144, 156, 2, 28, 146, 22, 205, 163, 87, 45, 31, 42, 178, 186, 54, 238, 232, 46, 212, 192, 166, 225, 148, 38, 109, 63, 127, 128, 105, 77, 18, 73, 23, 209, 234, 146, 209, 233, 72, 30, 67, 100, 27, 211, 146, 13, 43, 203, 46, 252, 26, 252, 54, 212, 87, 196, 237, 194, 110 },
                            PasswordSalt = new byte[] { 7, 129, 91, 254, 189, 101, 212, 143, 119, 130, 86, 4, 38, 100, 16, 251, 9, 105, 35, 243, 38, 42, 42, 191, 195, 148, 20, 169, 14, 250, 71, 225, 255, 142, 162, 17, 228, 49, 37, 203, 125, 72, 232, 81, 242, 114, 206, 16, 247, 44, 125, 119, 160, 3, 186, 214, 188, 15, 101, 122, 46, 74, 73, 194, 122, 248, 224, 118, 230, 246, 154, 45, 15, 184, 6, 111, 83, 241, 230, 25, 58, 173, 180, 132, 14, 116, 173, 54, 64, 173, 94, 179, 4, 219, 119, 194, 85, 134, 148, 84, 138, 132, 109, 217, 168, 211, 244, 119, 176, 85, 40, 236, 27, 106, 82, 44, 177, 171, 58, 7, 54, 211, 134, 183, 203, 224, 92, 12 },
                            ProfileImage = "",
                            Token = "",
                            Username = "uta"
                        });
                });

            modelBuilder.Entity("SoulKingWebAPI.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikesCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaysCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

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

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Navigation("Album");

                    b.Navigation("Artist");
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

            modelBuilder.Entity("SoulKingWebAPI.Models.User", b =>
                {
                    b.Navigation("Playlists");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
