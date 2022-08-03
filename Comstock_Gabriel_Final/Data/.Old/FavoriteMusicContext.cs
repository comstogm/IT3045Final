using Comstock_Gabriel_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Comstock_Gabriel_Final.Data
{
    public class FavoriteMusicContext : DbContext
    {
        public FavoriteMusicContext(DbContextOptions<FavoriteMusicContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Music>().HasData(
                new Music { Id = 1, FullName = "Gabriel Comstock", GenreName = "Doom", Instrument = "Guitar", AverageLengthOfSong = 5},
                new Music { Id = 1, FullName = "Person McName", GenreName = "Drum and Bass", Instrument = "Drum", AverageLengthOfSong = 3}
                );
        }

        public DbSet<Music> FavoriteMusic { get; set; }
    }
}