using Microsoft.EntityFrameworkCore;
using VideoGame.Entities;

namespace VideoGame.DatabaseContext
{
    public class VideoGameDatabaseContext : DbContext
    {
        public VideoGameDatabaseContext(DbContextOptions<VideoGameDatabaseContext> options) : base(options) { }

        public DbSet<VideoGameEntity> VideoGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=6LR48R3; Initial Catalog=VideoGame; Trusted_Connection=True; TrustServerCertificate = True");
        }
    }
}
