using Microsoft.EntityFrameworkCore;
using Volkin.Musihqa.Management.Core.Domain.Management;

namespace Volkin.Musihqa.Management.DataAccess.Common
{
    public class DataContext
        : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Link 1:N -> Album:Tracks
            modelBuilder.Entity<Album>()
                .HasMany(album => album.Tracks)
                .WithOne(track => track.Album);

            // Link 1:N -> Artist:Albums
            modelBuilder.Entity<Artist>()
                .HasMany(artist => artist.Albums)
                .WithOne(album => album.PrimaryArtist);

            // Link 1:N -> Artist:Tracks
            modelBuilder.Entity<Artist>()
                .HasMany(artist => artist.Tracks)
                .WithOne(track => track.PrimaryArtist);

            //// Link N:N -> Artists:Albums
            //modelBuilder.Entity<ArtistAlbum>()
            //    .HasKey(x => new { x.ArtistId, x.AlbumId });

            //modelBuilder.Entity<ArtistAlbum>()
            //    .HasOne(x => x.Artist)
            //    .WithMany(artist => artist.Albums)
            //    .HasForeignKey(x => x.ArtistId);// https://metanit.com/sharp/entityframeworkcore/3.1.php

            //modelBuilder.Entity<ArtistAlbum>()
            //    .HasOne(x => x.Album)
            //    .WithMany()
            //    .HasForeignKey(x => x.AlbumId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ManagementDatabase");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
