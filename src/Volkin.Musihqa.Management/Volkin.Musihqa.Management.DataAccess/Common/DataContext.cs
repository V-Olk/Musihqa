using Microsoft.EntityFrameworkCore;
using Volkin.Musihqa.Management.Domain.Models.Management;

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
                .WithOne(album => album.PrimaryArtist)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;// Disable cascade delete

            // Link 1:N -> Artist:Tracks
            modelBuilder.Entity<Artist>()
                .HasMany(artist => artist.Tracks)
                .WithOne(track => track.PrimaryArtist)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;// Disable cascade delete
        }
    }
}